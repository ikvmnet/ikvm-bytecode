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

        public readonly ReadOnlySequence<byte> Data = Data;
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
        /// Copies this attribute to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
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
