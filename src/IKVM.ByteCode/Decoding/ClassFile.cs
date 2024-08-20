using System;
using System.Buffers;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a class file.
    /// </summary>
    public sealed class ClassFile : IDisposable
    {

        public const uint MAGIC = 0xCAFEBABE;
        public const uint MIN_CLASS_SIZE = 30;


        /// <summary>
        /// Attempts to measure a class starting at the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U4;
            if (reader.TryReadU4(out uint magic) == false)
                return false;
            if (magic != MAGIC)
                throw new InvalidClassMagicException(magic);

            size += ClassFormatReader.U2 + ClassFormatReader.U2;
            if (reader.TryReadU2(out ushort minorVersion) == false)
                return false;
            if (reader.TryReadU2(out ushort majorVersion) == false)
                return false;

            if (majorVersion > 63)
                throw new UnsupportedClassVersionException(new ClassFormatVersion(majorVersion, minorVersion));

            if (ConstantTable.TryMeasure(ref reader, ref size) == false)
                return false;

            size += ClassFormatReader.U2 + ClassFormatReader.U2 + ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2 + ClassFormatReader.U2 + ClassFormatReader.U2) == false)
                return false;

            if (InterfaceTable.TryMeasure(ref reader, ref size) == false)
                return false;

            if (FieldTable.TryMeasure(ref reader, ref size) == false)
                return false;

            if (MethodTable.TryMeasure(ref reader, ref size) == false)
                return false;

            if (AttributeTable.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read a class from the given memory position. This method is unsafe and assumes the lifetime of
        /// the memory remains valid for as long as the <see cref="ClassFile"/> instance is retained.
        /// </summary>
        /// <param name="pointer"></param>
        /// <param name="length"></param>
        /// <param name="clazz"></param>
        /// <returns></returns>
        public static unsafe bool TryRead(byte* pointer, int length, out ClassFile? clazz)
        {
            return TryRead(new UnmanagedMemoryManager(pointer, length), out clazz);
        }

        /// <summary>
        /// Attempts to read a class from the given memory location. This method is unsafe and assumes the lifetime of
        /// the memory remains valid for as long as the <see cref="ClassFile"/> instance is retained.
        /// </summary>
        /// <param name="pointer"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        public static unsafe ClassFile Read(byte* pointer, int length)
        {
            return TryRead(pointer, length, out var clazz) ? clazz! : throw new InvalidClassException("Failed to open ClassFile. Incomplete class data.");
        }

        /// <summary>
        /// Attempts to read a class from the given file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="clazz"></param>
        /// <returns></returns>
        public static unsafe bool TryRead(string path, out ClassFile? clazz)
        {
            if (path is null)
                throw new ArgumentNullException(nameof(path));

            var file = MemoryMappedFile.CreateFromFile(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read), null, 0, MemoryMappedFileAccess.Read, HandleInheritability.None, true);
            var view = file.CreateViewAccessor(0, 0, MemoryMappedFileAccess.Read);
            return TryRead(new MappedFileMemoryManager(file, view), out clazz);
        }

        /// <summary>
        /// Attempts to read a class from the given file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        public static unsafe ClassFile Read(string path)
        {
            return TryRead(path, out var clazz) ? clazz! : throw new InvalidClassException("Failed to open ClassFile. Incomplete class data.");
        }

        /// <summary>
        /// Attempts to read a class from the given buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="clazz"></param>
        /// <returns></returns>
        public static bool TryRead(IMemoryOwner<byte> owner, out ClassFile? clazz)
        {
            return TryRead(owner.Memory, out clazz, owner);
        }

        /// <summary>
        /// Attempts to read a class from the given buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="clazz"></param>
        /// <param name="disposable"></param>
        /// <returns></returns>
        public static bool TryRead(ReadOnlyMemory<byte> buffer, out ClassFile? clazz, IDisposable? disposable = null)
        {
            return TryRead(new ReadOnlySequence<byte>(buffer), out clazz, disposable);
        }

        /// <summary>
        /// Attempts to read a class from the given buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="clazz"></param>
        /// <param name="disposable"></param>
        /// <returns></returns>
        public static bool TryRead(in ReadOnlySequence<byte> buffer, out ClassFile? clazz, IDisposable? disposable = null)
        {
            return TryRead(buffer, out clazz, out _, out _, disposable);
        }

        /// <summary>
        /// Attempts to measure a class from the given buffer, returning information about the number of consumed and examined bytes.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="size"></param>
        /// <param name="consumed"></param>
        /// <param name="examined"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        public static bool TryMeasure(in ReadOnlySequence<byte> buffer, ref int size, out SequencePosition consumed, out SequencePosition examined)
        {
            consumed = buffer.Start;

            var reader = new ClassFormatReader(buffer);
            if (TryMeasure(ref reader, ref size) == false)
            {
                // examined up to the position of the reader, but consumed nothing
                examined = reader.Position;
                return false;
            }
            else
            {
                // examined up to the point of the reader, consumed the same
                consumed = reader.Position;
                examined = reader.Position;
                return true;
            }
        }

        /// <summary>
        /// Attempts to read a class from the given buffer, returning information about the number of consumed and examined bytes.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="clazz"></param>
        /// <param name="consumed"></param>
        /// <param name="examined"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        public static bool TryRead(in ReadOnlySequence<byte> buffer, out ClassFile? clazz, out SequencePosition consumed, out SequencePosition examined, IDisposable? disposable = null)
        {
            consumed = buffer.Start;

            var reader = new ClassFormatReader(buffer);
            if (TryRead(ref reader, out clazz, disposable) == false)
            {
                // examined up to the position of the reader, but consumed nothing
                examined = reader.Position;
                return false;
            }
            else
            {
                // examined up to the point of the reader, consumed the same
                consumed = reader.Position;
                examined = reader.Position;
                return true;
            }
        }

        /// <summary>
        /// Attempts to read a class record starting at the current position. The memory underlying the <see
        /// cref="ClassFormatReader"/> must remain valid for the lifetime of the <see cref="ClassFile"/> instance.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="clazz"></param>
        /// <param name="disposable">Optional owner of the memory.</param>
        /// <returns></returns>
        /// <exception cref="InvalidClassMagicException"></exception>
        /// <exception cref="UnsupportedClassVersionException"></exception>
        public static bool TryRead(ref ClassFormatReader reader, out ClassFile? clazz, IDisposable? disposable = null)
        {
            clazz = null;

            if (reader.TryReadU4(out uint magic) == false)
                return false;
            if (magic != MAGIC)
                throw new InvalidClassMagicException(magic);

            if (reader.TryReadU2(out ushort minorVersion) == false)
                return false;
            if (reader.TryReadU2(out ushort majorVersion) == false)
                return false;

            if (majorVersion > 63)
                throw new UnsupportedClassVersionException(new ClassFormatVersion(majorVersion, minorVersion));

            var version = new ClassFormatVersion(majorVersion, minorVersion);

            if (ConstantTable.TryRead(version, ref reader, out var constants) == false)
                return false;

            if (reader.TryReadU2(out ushort accessFlags) == false)
                return false;

            if (reader.TryReadU2(out ushort thisClass) == false)
                return false;

            if (reader.TryReadU2(out ushort superClass) == false)
                return false;

            if (InterfaceTable.TryRead(ref reader, out var interfaces) == false)
                return false;

            if (FieldTable.TryRead(ref reader, out var fields) == false)
                return false;

            if (MethodTable.TryRead(ref reader, out var methods) == false)
                return false;

            if (AttributeTable.TryRead(ref reader, out var attributes) == false)
                return false;

            clazz = new ClassFile(version, constants, (AccessFlag)accessFlags, new(thisClass), new(superClass), interfaces, fields, methods, attributes, disposable);
            return true;
        }

        /// <summary>
        /// Attempts to read a class from the given buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        public static ClassFile Read(ReadOnlyMemory<byte> buffer)
        {
            return TryRead(buffer, out var clazz) ? clazz! : throw new InvalidClassException("Failed to open ClassFile. Incomplete class data.");
        }

        /// <summary>
        /// Attempts to read a class from the given buffer.
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        public static ClassFile Read(IMemoryOwner<byte> owner)
        {
            if (owner is null)
                throw new ArgumentNullException(nameof(owner));

            return TryRead(owner.Memory, out var clazz, owner) ? clazz! : throw new InvalidClassException("Failed to open ClassFile. Incomplete class data.");
        }

        /// <summary>
        /// Attempts to read a class from the given buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="disposable"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        public static ClassFile Read(in ReadOnlySequence<byte> buffer, IDisposable? disposable = null)
        {
            return TryRead(buffer, out var clazz, disposable) ? clazz! : throw new InvalidClassException("Failed to open ClassFile. Incomplete class data.");
        }

        /// <summary>
        /// Reads the next class from the stream.
        /// </summary>
        /// <returns></returns>
        public static async ValueTask<ClassFile> ReadAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            var reader = PipeReader.Create(stream, new StreamPipeReaderOptions(minimumReadSize: 1, leaveOpen: true));

            try
            {
                return await ReadAsync(reader, cancellationToken);
            }
            catch (Exception e)
            {
                await reader.CompleteAsync(e);
                throw;
            }
            finally
            {
                await reader.CompleteAsync();
            }
        }

        /// <summary>
        /// Reads the next class from the stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static ClassFile Read(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            return ReadAsync(stream, cancellationToken).AsTask().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Reads the next class from the stream.
        /// </summary>
        /// <returns></returns>
        public static async ValueTask<ClassFile> ReadAsync(PipeReader reader, CancellationToken cancellationToken = default)
        {
            if (reader is null)
                throw new ArgumentNullException(nameof(reader));

            while (true)
            {
                var result = await reader.ReadAtLeastAsync((int)MIN_CLASS_SIZE, cancellationToken);
                if (result.IsCanceled)
                    throw new OperationCanceledException();

                // we measure first, to prevent allocation of expensive arrays and structures if the data stream is not complete or the class structure invalid
                int size = 0;
                if (TryMeasure(result.Buffer, ref size, out var consumed, out var examined) == false)
                {
                    reader.AdvanceTo(consumed, examined);

                    // we couldn't read a full class, and the pipe is at the end
                    if (result.IsCompleted)
                        throw new InvalidClassException("End of stream reached before valid class.");

                    continue;
                }

                // allocate a new buffer of the appropriate size, private to the class file
                var owner = MemoryPool<byte>.Shared.Rent(size);

                try
                {
                    // copy original buffer for private use by the class file
                    result.Buffer.CopyTo(owner.Memory.Span);

                    if (TryRead(new ReadOnlySequence<byte>(owner.Memory), out var clazz, out _, out _, owner) == false)
                    {
                        throw new ByteCodeException("End of stream reached reading already measured class data.");
                    }
                    else
                    {
                        // advance to values previously read by measurement
                        reader.AdvanceTo(consumed, examined);
                        owner = null;
                        return clazz!;
                    }

                }
                finally
                {
                    owner?.Dispose();
                }
            }
        }

        readonly IDisposable? _disposable;

        /// <summary>
        /// Gets the constants of the class file.
        /// </summary>
        public readonly ConstantTable Constants;

        /// <summary>
        /// Gets the version of the class file.
        /// </summary>
        public readonly ClassFormatVersion Version;

        /// <summary>
        /// Gets the access flags of the class file.
        /// </summary>
        public readonly AccessFlag AccessFlags;

        /// <summary>
        /// Gets the class constant that represents this class.
        /// </summary>
        public readonly ClassConstantHandle This;

        /// <summary>
        /// Gets the class constnat that represents the super class.
        /// </summary>
        public readonly ClassConstantHandle Super;

        /// <summary>
        /// Gets the interfaces of the class file.
        /// </summary>
        public readonly InterfaceTable Interfaces;

        /// <summary>
        /// Gets the fields of the class file.
        /// </summary>
        public readonly FieldTable Fields;

        /// <summary>
        /// Gets the methods of the class file.
        /// </summary>
        public readonly MethodTable Methods;

        /// <summary>
        /// Gets the attributes of the class file.
        /// </summary>
        public readonly AttributeTable Attributes;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="constants"></param>
        /// <param name="accessFlags"></param>
        /// <param name="this"></param>
        /// <param name="super"></param>
        /// <param name="interfaces"></param>
        /// <param name="fields"></param>
        /// <param name="methods"></param>
        /// <param name="attributes"></param>
        /// <param name="disposable"></param>
        internal ClassFile(ClassFormatVersion version, ConstantTable constants, AccessFlag accessFlags, ClassConstantHandle @this, ClassConstantHandle super, InterfaceTable interfaces, FieldTable fields, MethodTable methods, AttributeTable attributes, IDisposable? disposable)
        {
            Version = version;
            Constants = constants;
            AccessFlags = accessFlags;
            This = @this;
            Super = super;
            Interfaces = interfaces;
            Fields = fields;
            Methods = methods;
            Attributes = attributes;
            _disposable = disposable;
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            _disposable?.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes the instance.
        /// </summary>
        ~ClassFile()
        {
            Dispose();
        }

    }

}
