﻿using System;
using System.Buffers;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Reading
{

    /// <summary>
    /// Represents a class file.
    /// </summary>
    public sealed class ClassFile : IDisposable
    {

        const int MIN_CLASS_SIZE = 30;

        /// <summary>
        /// Attempts to read a class from the given memory position. This method is unsafe and assumes the lifetime of
        /// the memory remains valid for as long as the <see cref="ClassFile"/> instance is retained.
        /// </summary>
        /// <param name="pointer"></param>
        /// <param name="length"></param>
        /// <param name="clazz"></param>
        /// <returns></returns>
        public static unsafe bool TryRead(byte* pointer, int length, out ClassFile clazz)
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
            return TryRead(pointer, length, out var clazz) ? clazz : throw new InvalidClassException("Failed to open ClassFile. Incomplete class data.");
        }

        /// <summary>
        /// Attempts to read a class from the given file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="clazz"></param>
        /// <returns></returns>
        public static unsafe bool TryRead(string path, out ClassFile clazz)
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
            return TryRead(path, out var clazz) ? clazz : throw new InvalidClassException("Failed to open ClassFile. Incomplete class data.");
        }

        /// <summary>
        /// Attempts to read a class from the given buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="clazz"></param>
        /// <returns></returns>
        public static bool TryRead(IMemoryOwner<byte> owner, out ClassFile clazz)
        {
            return TryRead(owner.Memory, out clazz, owner);
        }

        /// <summary>
        /// Attempts to read a class from the given buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="clazz"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static bool TryRead(ReadOnlyMemory<byte> buffer, out ClassFile clazz, IMemoryOwner<byte> owner = null)
        {
            return TryRead(new ReadOnlySequence<byte>(buffer), out clazz, owner);
        }

        /// <summary>
        /// Attempts to read a class from the given buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="clazz"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static bool TryRead(in ReadOnlySequence<byte> buffer, out ClassFile clazz, IMemoryOwner<byte> owner = null)
        {
            return TryRead(buffer, out clazz, out _, out _, owner);
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
        public static bool TryRead(in ReadOnlySequence<byte> buffer, out ClassFile clazz, out SequencePosition consumed, out SequencePosition examined, IMemoryOwner<byte> owner = null)
        {
            consumed = buffer.Start;

            var reader = new ClassFormatReader(buffer);
            if (TryRead(ref reader, out clazz, owner) == false)
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
        /// <param name="owner">Optional owner of the memory.</param>
        /// <returns></returns>
        /// <exception cref="InvalidClassMagicException"></exception>
        /// <exception cref="UnsupportedClassVersionException"></exception>
        public static bool TryRead(ref ClassFormatReader reader, out ClassFile clazz, IMemoryOwner<byte> owner = null)
        {
            clazz = default;

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

            if (TryReadConstantTable(version, ref reader, out var constants) == false)
                return false;

            if (reader.TryReadU2(out ushort accessFlags) == false)
                return false;

            if (reader.TryReadU2(out ushort thisClass) == false)
                return false;

            if (reader.TryReadU2(out ushort superClass) == false)
                return false;

            if (TryReadInterfaceTable(ref reader, out var interfaces) == false)
                return false;

            if (TryReadFieldTable(ref reader, out var fields) == false)
                return false;

            if (TryReadMethodTable(ref reader, out var methods) == false)
                return false;

            if (TryReadAttributeTable(ref reader, out var attributes) == false)
                return false;

            clazz = new ClassFile(version, constants, (AccessFlag)accessFlags, new(thisClass), new(superClass), interfaces, fields, methods, attributes, owner);
            return true;
        }

        /// <summary>
        /// Attempts to read the set of constants at the current position.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="reader"></param>
        /// <param name="constants"></param>
        /// <returns></returns>
        internal static bool TryReadConstantTable(ClassFormatVersion version, ref ClassFormatReader reader, out ConstantTable constants)
        {
            constants = default;

            if (TryReadConstants(ref reader, out var data) == false)
                return false;

            constants = new ConstantTable(version, data);
            return true;
        }

        /// <summary>
        /// Attempts to read the set of constants at the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constantData"></param>
        /// <returns></returns>
        internal static bool TryReadConstants(ref ClassFormatReader reader, out Constant[] constantData)
        {
            constantData = null;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            constantData = new Constant[count];
            for (int i = 1; i < count; i++)
            {
                if (Constant.TryRead(ref reader, out var data, out var skip) == false)
                    return false;

                constantData[i] = data;
                i += skip;
            }

            return true;
        }

        /// <summary>
        /// Attempts to read the interface table starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="interfaces"></param>
        /// <returns></returns>
        internal static bool TryReadInterfaceTable(ref ClassFormatReader reader, out InterfaceTable interfaces)
        {
            interfaces = default;

            if (TryReadInterfaces(ref reader, out var items) == false)
                return false;

            interfaces = new InterfaceTable(items);
            return true;
        }

        /// <summary>
        /// Attempts to read the set of interfaces starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="interfaces"></param>
        /// <returns></returns>
        internal static bool TryReadInterfaces(ref ClassFormatReader reader, out Interface[] interfaces)
        {
            interfaces = null;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            interfaces = new Interface[count];
            for (int i = 0; i < count; i++)
            {
                if (Interface.TryRead(ref reader, out Interface iface) == false)
                    return false;

                interfaces[i] = iface;
            }

            return true;
        }

        /// <summary>
        /// Attempts to read the field table starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        internal static bool TryReadFieldTable(ref ClassFormatReader reader, out FieldTable fields)
        {
            fields = default;

            if (TryReadFields(ref reader, out var items) == false)
                return false;

            fields = new FieldTable(items);
            return true;
        }

        /// <summary>
        /// Attempts to read the set of fields starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        internal static bool TryReadFields(ref ClassFormatReader reader, out Field[] fields)
        {
            fields = null;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            fields = new Field[count];
            for (int i = 0; i < count; i++)
            {
                if (Field.TryRead(ref reader, out Field field) == false)
                    return false;

                fields[i] = field;
            }

            return true;
        }

        /// <summary>
        /// Attempts to read the method table starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="methods"></param>
        /// <returns></returns>
        internal static bool TryReadMethodTable(ref ClassFormatReader reader, out MethodTable methods)
        {
            methods = default;

            if (TryReadMethods(ref reader, out var items) == false)
                return false;

            methods = new MethodTable(items);
            return true;
        }

        /// <summary>
        /// Attempts to read the set of methods starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="methods"></param>
        /// <returns></returns>
        internal static bool TryReadMethods(ref ClassFormatReader reader, out Method[] methods)
        {
            methods = null;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            methods = new Method[count];
            for (int i = 0; i < count; i++)
            {
                if (Method.TryRead(ref reader, out Method method) == false)
                    return false;

                methods[i] = method;
            }

            return true;
        }

        /// <summary>
        /// Attempts to read the set of attributes starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        internal static bool TryReadAttributeTable(ref ClassFormatReader reader, out AttributeTable attributes)
        {
            attributes = default;

            if (TryReadAttributes(ref reader, out var items) == false)
                return false;

            attributes = new AttributeTable(items);
            return true;
        }

        /// <summary>
        /// Attempts to read the set of attributes starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        internal static bool TryReadAttributes(ref ClassFormatReader reader, out Attribute[] attributes)
        {
            attributes = null;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            attributes = new Attribute[count];
            for (int i = 0; i < count; i++)
            {
                if (Attribute.TryRead(ref reader, out var attribute) == false)
                    return false;

                attributes[i] = attribute;
            }

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
            return TryRead(buffer, out var clazz) ? clazz : throw new InvalidClassException("Failed to open ClassFile. Incomplete class data.");
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

            return TryRead(owner.Memory, out var clazz, owner) ? clazz : throw new InvalidClassException("Failed to open ClassFile. Incomplete class data.");
        }

        /// <summary>
        /// Attempts to read a class from the given buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        public static ClassFile Read(in ReadOnlySequence<byte> buffer, IMemoryOwner<byte> owner = null)
        {
            return TryRead(buffer, out var clazz, owner) ? clazz : throw new InvalidClassException("Failed to open ClassFile. Incomplete class data.");
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
                var result = await reader.ReadAtLeastAsync(MIN_CLASS_SIZE, cancellationToken);
                if (result.IsCanceled)
                    throw new OperationCanceledException();

                // temporary buffer used since ClassFile retains memory
                var owner = MemoryPool<byte>.Shared.Rent(checked((int)result.Buffer.Length));

                try
                {
                    result.Buffer.CopyTo(owner.Memory.Span);
                    if (TryRead(new ReadOnlySequence<byte>(owner.Memory), out var clazz, out var consumed, out var examined, owner) == false)
                    {
                        // slice original buffer to report back
                        var range = result.Buffer.Slice(consumed.GetInteger(), examined.GetInteger());
                        reader.AdvanceTo(range.Start, range.End);

                        // we couldn't read a full class, and the pipe is at the end
                        if (result.IsCompleted)
                            throw new InvalidClassException("End of stream reached before valid class.");

                        continue;
                    }
                    else
                    {
                        // slice original buffer to report back
                        var range = result.Buffer.Slice(consumed.GetInteger(), examined.GetInteger());
                        reader.AdvanceTo(range.Start, range.End);
                        return clazz;
                    }
                }
                catch
                {
                    owner.Dispose();
                    throw;
                }
            }
        }

        readonly ClassFormatVersion _version;
        readonly ConstantTable _constants;
        readonly AccessFlag _accessFlags;
        readonly ClassConstantHandle _this;
        readonly ClassConstantHandle _super;
        readonly InterfaceTable _interfaces;
        readonly FieldTable _fields;
        readonly MethodTable _methods;
        readonly AttributeTable _attributes;
        readonly IMemoryOwner<byte> _owner;

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
        /// <param name="owner"></param>
        internal ClassFile(ClassFormatVersion version, ConstantTable constants, AccessFlag accessFlags, ClassConstantHandle @this, ClassConstantHandle super, InterfaceTable interfaces, FieldTable fields, MethodTable methods, AttributeTable attributes, IMemoryOwner<byte> owner)
        {
            _version = version;
            _constants = constants;
            _accessFlags = accessFlags;
            _this = @this;
            _super = super;
            _interfaces = interfaces;
            _fields = fields;
            _methods = methods;
            _attributes = attributes ?? throw new ArgumentNullException(nameof(attributes));
            _owner = owner;
        }

        /// <summary>
        /// Gets the version of the class file.
        /// </summary>
        public ClassFormatVersion Version => _version;

        /// <summary>
        /// Gets the constants of the class file.
        /// </summary>
        public ConstantTable Constants => _constants;

        /// <summary>
        /// Gets the access flags of the class file.
        /// </summary>
        public AccessFlag AccessFlags => _accessFlags;

        /// <summary>
        /// Gets the class constant that represents this class.
        /// </summary>
        public ClassConstantHandle This => _this;

        /// <summary>
        /// Gets the class constnat that represents the super class.
        /// </summary>
        public ClassConstantHandle Super => _super;

        /// <summary>
        /// Gets the interfaces of the class file.
        /// </summary>
        public InterfaceTable Interfaces => _interfaces;

        /// <summary>
        /// Gets the fields of the class file.
        /// </summary>
        public FieldTable Fields => _fields;

        /// <summary>
        /// Gets the methods of the class file.
        /// </summary>
        public MethodTable Methods => _methods;

        /// <summary>
        /// Gets the attributes of the class file.
        /// </summary>
        public AttributeTable Attributes => _attributes;

        /// <summary>
        /// Unique magic of a Java class file.
        /// </summary>
        public const uint MAGIC = 0xCAFEBABE;

        /// <summary>
        /// Discovers the kind of the specified constant handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public ConstantKind GetKind(ConstantHandle handle)
        {
            return _constants.GetKind(handle);
        }

        /// <summary>
        /// Gets the <see cref="Utf8Constant"/> value refered to by the <see cref="Utf8ConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ByteCodeException"></exception>
        public Utf8Constant GetUtf8(Utf8ConstantHandle handle)
        {
            return _constants.GetUtf8(handle);
        }

        /// <summary>
        /// Gets the <see cref="Utf8Constant"/> value refered to by the <see cref="Utf8ConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ByteCodeException"></exception>
        public string GetUtf8Value(Utf8ConstantHandle handle)
        {
            return GetUtf8(handle).Value;
        }

        /// <summary>
        /// Gets the <see cref="IntegerConstant"/> value refered to by the <see cref="IntegerConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public IntegerConstant GetInteger(IntegerConstantHandle handle)
        {
            return _constants.GetInteger(handle);
        }

        /// <summary>
        /// Gets the <see cref="IntegerConstant"/> value refered to by the <see cref="IntegerConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public int GetIntegerValue(IntegerConstantHandle handle)
        {
            return GetInteger(handle).Value;
        }

        /// <summary>
        /// Gets the <see cref="FloatConstant"/> value refered to by the <see cref="FloatConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public FloatConstant GetFloat(FloatConstantHandle handle)
        {
            return _constants.GetFloat(handle);
        }

        /// <summary>
        /// Gets the <see cref="FloatConstant"/> value refered to by the <see cref="FloatConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public float GetFloatValue(FloatConstantHandle handle)
        {
            return GetFloat(handle).Value;
        }

        /// <summary>
        /// Gets the <see cref="LongConstant"/> value refered to by the <see cref="LongConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public LongConstant GetLong(LongConstantHandle handle)
        {
            return _constants.GetLong(handle);
        }

        /// <summary>
        /// Gets the <see cref="LongConstant"/> value refered to by the <see cref="LongConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public long GetLongValue(LongConstantHandle handle)
        {
            return GetLong(handle).Value;
        }

        /// <summary>
        /// Gets the <see cref="DoubleConstant"/> value refered to by the <see cref="DoubleConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public DoubleConstant GetDouble(DoubleConstantHandle handle)
        {
            return _constants.GetDouble(handle);
        }

        /// <summary>
        /// Gets the <see cref="DoubleConstant"/> value refered to by the <see cref="DoubleConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public double GetDoubleValue(DoubleConstantHandle handle)
        {
            return GetDouble(handle).Value;
        }

        /// <summary>
        /// Gets the <see cref="ClassConstant"/> value refered to by the <see cref="ClassConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public ClassConstant GetClass(ClassConstantHandle handle)
        {
            return _constants.GetClass(handle);
        }

        /// <summary>
        /// Gets the <see cref="ClassConstant"/> value refered to by the <see cref="ClassConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public string GetClassName(ClassConstantHandle handle)
        {
            return GetUtf8Value(GetClass(handle).Name);
        }

        /// <summary>
        /// Gets the <see cref="StringConstant"/> value refered to by the <see cref="StringConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public StringConstant GetString(StringConstantHandle handle)
        {
            return _constants.GetString(handle);
        }

        /// <summary>
        /// Gets the <see cref="StringConstant"/> value refered to by the <see cref="StringConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public string GetStringValue(StringConstantHandle handle)
        {
            return GetUtf8Value(GetString(handle).Value);
        }

        /// <summary>
        /// Gets the <see cref="FieldrefConstant"/> value refered to by the <see cref="FieldrefConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public FieldrefConstant GetFieldref(FieldrefConstantHandle handle)
        {
            return _constants.GetFieldref(handle);
        }

        /// <summary>
        /// Gets the <see cref="MethodrefConstant"/> value refered to by the <see cref="MethodrefConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public MethodrefConstant GetMethodref(MethodrefConstantHandle handle)
        {
            return _constants.GetMethodref(handle);
        }

        /// <summary>
        /// Gets the <see cref="InterfaceMethodrefConstant"/> value refered to by the <see cref="InterfaceMethodrefConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public InterfaceMethodrefConstant GetInterfaceMethodref(InterfaceMethodrefConstantHandle handle)
        {
            return _constants.GetInterfaceMethodref(handle);
        }

        /// <summary>
        /// Gets the <see cref="NameAndTypeConstant"/> value refered to by the <see cref="NameAndTypeConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public NameAndTypeConstant GetNameAndType(NameAndTypeConstantHandle handle)
        {
            return _constants.GetNameAndType(handle);
        }

        /// <summary>
        /// Gets the <see cref="MethodHandleConstant"/> value refered to by the <see cref="MethodHandleConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public MethodHandleConstant GetMethodHandle(MethodHandleConstantHandle handle)
        {
            return _constants.GetMethodHandle(handle);
        }

        /// <summary>
        /// Gets the <see cref="MethodTypeConstant"/> value refered to by the <see cref="MethodTypeConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public MethodTypeConstant GetMethodType(MethodTypeConstantHandle handle)
        {
            return _constants.GetMethodType(handle);
        }

        /// <summary>
        /// Gets the <see cref="MethodTypeConstant"/> value refered to by the <see cref="MethodTypeConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public string GetMethodTypeDescriptor(MethodTypeConstantHandle handle)
        {
            return GetUtf8Value(GetMethodType(handle).Descriptor);
        }

        /// <summary>
        /// Gets the <see cref="DynamicConstant"/> value refered to by the <see cref="DynamicConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public DynamicConstant GetDynamic(DynamicConstantHandle handle)
        {
            return _constants.GetDynamic(handle);
        }

        /// <summary>
        /// Gets the <see cref="InvokeDynamicConstant"/> value refered to by the <see cref="InvokeDynamicConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public InvokeDynamicConstant GetInvokeDynamic(InvokeDynamicConstantHandle handle)
        {
            return _constants.GetInvokeDynamic(handle);
        }

        /// <summary>
        /// Gets the <see cref="ModuleConstant"/> value refered to by the <see cref="ModuleConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public ModuleConstant GetModule(ModuleConstantHandle handle)
        {
            return _constants.GetModule(handle);
        }

        /// <summary>
        /// Gets the <see cref="ModuleConstant"/> value refered to by the <see cref="ModuleConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public string GetModuleName(ModuleConstantHandle handle)
        {
            return GetUtf8Value(GetModule(handle).Name);
        }

        /// <summary>
        /// Gets the <see cref="PackageConstant"/> value refered to by the <see cref="PackageConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public PackageConstant GetPackage(PackageConstantHandle handle)
        {
            return _constants.GetPackage(handle);
        }

        /// <summary>
        /// Gets the <see cref="PackageConstant"/> value refered to by the <see cref="PackageConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public string GetPackageName(PackageConstantHandle handle)
        {
            return GetUtf8Value(GetPackage(handle).Name);
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            _owner?.Dispose();
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
