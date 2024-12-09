using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
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

        public readonly InnerClassTable Table = Table;
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
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.InnerClasses(constantPool.Get(AttributeName.InnerClasses), e => self.CopyTo(constantView, constantPool, ref e));
        }

        /// <summary>
        /// Copies this attribute to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref InnerClassTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            foreach (var i in Table)
                encoder.InnerClass(constantPool.Get(constantView.Get(i.Inner)), constantPool.Get(constantView.Get(i.Outer)), constantPool.Get(constantView.Get(i.InnerName)), i.InnerAccessFlags);
        }

    }

}
