using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct LineNumberTableAttribute(LineNumberTable LineNumbers)
    {

        public static LineNumberTableAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out LineNumberTableAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort itemCount) == false)
                return false;

            var items = itemCount == 0 ? [] : new LineNumberInfo[itemCount];
            for (int i = 0; i < itemCount; i++)
            {
                if (reader.TryReadU2(out ushort codeOffset) == false)
                    return false;
                if (reader.TryReadU2(out ushort lineNumber) == false)
                    return false;

                items[i] = new LineNumberInfo(codeOffset, lineNumber);
            }

            attribute = new LineNumberTableAttribute(new(items));
            return true;
        }

        public readonly LineNumberTable LineNumbers = LineNumbers;
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
            encoder.LineNumberTable(constantPool.Get(AttributeName.LineNumberTable), e => self.LineNumbers.CopyTo(constantView, constantPool, ref e));
        }

    }

}
