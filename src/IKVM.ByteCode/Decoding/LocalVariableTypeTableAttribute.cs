using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct LocalVariableTypeTableAttribute(LocalVariableTypeTable LocalVariableTypes)
    {

        public static LocalVariableTypeTableAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out LocalVariableTypeTableAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort length) == false)
                return false;

            var items = length == 0 ? [] : new LocalVariableType[length];
            for (int i = 0; i < length; i++)
            {
                if (reader.TryReadU2(out ushort codeOffset) == false)
                    return false;
                if (reader.TryReadU2(out ushort codeLength) == false)
                    return false;
                if (reader.TryReadU2(out ushort nameIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort signatureIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort index) == false)
                    return false;

                items[i] = new LocalVariableType(codeOffset, codeLength, new(nameIndex), new(signatureIndex), index);
            }

            attribute = new LocalVariableTypeTableAttribute(new(items));
            return true;
        }

        public readonly LocalVariableTypeTable LocalVariableTypes = LocalVariableTypes;
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
            encoder.LocalVariableTypeTable(constantPool.Get(AttributeName.LocalVariableTypeTable), e => self.LocalVariableTypes.CopyTo(constantView, constantPool, ref e));
        }

    }

}
