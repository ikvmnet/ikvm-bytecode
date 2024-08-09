using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct InnerClassesAttribute(InnerClassTable Table)
    {

        public static InnerClassesAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out InnerClassesAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var table = count == 0 ? [] : new InnerClass[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort innerClassInfoIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort outerClassInfoIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort innerNameIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort innerClassAccessFlags) == false)
                    return false;

                table[i] = new InnerClass(new(innerClassInfoIndex), new(outerClassInfoIndex), new(innerNameIndex), (AccessFlag)innerClassAccessFlags);
            }

            attribute = new InnerClassesAttribute(new(table));
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

            var self = this;
            builder.InnerClasses(e => self.EncodeTo(view, pool, ref e));
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref InnerClassTableEncoder encoder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            foreach (var i in Table)
                encoder.InnerClass(pool.Import(view, i.Inner), pool.Import(view, i.Outer), pool.Import(view, i.InnerName), i.InnerAccessFlags);
        }

    }

}
