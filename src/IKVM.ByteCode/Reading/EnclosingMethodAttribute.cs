using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct EnclosingMethodAttribute(ClassConstantHandle Class, NameAndTypeConstantHandle Method)
    {

        public static EnclosingMethodAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out EnclosingMethodAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort classIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort methodIndex) == false)
                return false;

            attribute = new EnclosingMethodAttribute(new(classIndex), new(methodIndex));
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
        public readonly void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, AttributeTableBuilder builder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            builder.EnclosingMethod(pool.Import(view, Class), pool.Import(view, Method));
        }

    }

}
