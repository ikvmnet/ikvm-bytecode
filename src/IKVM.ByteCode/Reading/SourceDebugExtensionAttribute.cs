using System;
using System.Buffers;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
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

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="builder"></param>
        public void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, AttributeTableBuilder builder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            var b = new BlobBuilder();
            Data.CopyTo(b.ReserveBytes((int)Data.Length).GetBytes().AsSpan());
            builder.SourceDebugExtension(b);
        }

    }

}
