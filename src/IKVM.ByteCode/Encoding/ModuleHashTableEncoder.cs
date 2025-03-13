using System;
using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Encoding
{

    /// <summary>
    /// Encodes an module hash table structure.
    /// </summary>
    public struct ModuleHashTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _algorithmBlob;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="algorithm"></param>
        public ModuleHashTableEncoder(BlobBuilder builder, Utf8ConstantHandle algorithm)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));

            // write algorithm value
            _algorithmBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            new ClassFormatWriter(_algorithmBlob.GetBytes()).WriteU2(algorithm.Slot);

            // write initial count value
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(_count);
        }

        /// <summary>
        /// Adds a new module hash.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public ModuleHashTableEncoder Hash(Utf8ConstantHandle name, BlobBuilder hash)
        {
            if (hash is null)
                throw new ArgumentNullException(nameof(hash));

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.WriteU2(name.Slot);
            w.WriteU2((ushort)hash.Count);
            _builder.LinkSuffix(hash);

            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds a new module hash.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public ModuleHashTableEncoder Hash(Utf8ConstantHandle name, ReadOnlySpan<byte> hash)
        {
            var b = new BlobBuilder(hash.Length);
            b.WriteBytes(hash);
            return Hash(name, b);
        }

        /// <summary>
        /// Adds a new module hash.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public ModuleHashTableEncoder Hash(Utf8ConstantHandle name, ReadOnlySequence<byte> hash)
        {
            var b = new BlobBuilder((int)hash.Length);
            b.WriteBytes(hash);
            return Hash(name, b);
        }

    }

}