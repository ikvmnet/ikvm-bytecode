using System;
using System.Buffers;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct SourceDebugExtensionAttribute(ReadOnlySequence<byte> Data)
    {

        public static SourceDebugExtensionAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out SourceDebugExtensionAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadMany(reader.Length, out var data) == false)
                return false;

            attribute = new SourceDebugExtensionAttribute(data);
            return true;
        }

        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Gets the raw debug extension data.
        /// </summary>
        public readonly ReadOnlySequence<byte> Data = Data;

        /// <summary>
        /// Copies this attribute to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var b = new BlobBuilder();
            Data.CopyTo(b.ReserveBytes((int)Data.Length).GetBytes().AsSpan());
            encoder.SourceDebugExtension(constantPool.Get(AttributeName.SourceDebugExtension), b);
        }

    }

}
