using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct TypePathComponent(TypePathKind Kind, byte ArgumentIndex)
    {

        public static bool TryRead(ref ClassFormatReader reader, out TypePathComponent record)
        {
            record = default;

            if (reader.TryReadU1(out byte kind) == false)
                return false;
            if (reader.TryReadU1(out byte argumentIndex) == false)
                return false;

            record = new TypePathComponent((TypePathKind)kind, argumentIndex);
            return true;
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref TypePathEncoder encoder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            switch (Kind)
            {
                case TypePathKind.TypeArgument:
                    encoder.TypeArgument(ArgumentIndex);
                    break;
                case TypePathKind.InnerType:
                    encoder.InnerType();
                    break;
                case TypePathKind.Array:
                    encoder.Array();
                    break;
                case TypePathKind.Wildcard:
                    encoder.Wildcard();
                    break;
            }
        }

    }

}
