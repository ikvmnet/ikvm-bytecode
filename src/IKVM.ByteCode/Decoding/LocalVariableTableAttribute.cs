using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct LocalVariableTableAttribute(LocalVariableTable LocalVariables)
    {

        public static LocalVariableTableAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out LocalVariableTableAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort length) == false)
                return false;

            var items = length == 0 ? [] : new LocalVariable[length];
            for (int i = 0; i < length; i++)
            {
                if (reader.TryReadU2(out ushort codeOffset) == false)
                    return false;
                if (reader.TryReadU2(out ushort codeLength) == false)
                    return false;
                if (reader.TryReadU2(out ushort nameIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort descriptorIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort index) == false)
                    return false;

                items[i] = new LocalVariable(codeOffset, codeLength, new(nameIndex), new(descriptorIndex), index);
            }

            attribute = new LocalVariableTableAttribute(new(items));
            return true;
        }

        public readonly LocalVariableTable LocalVariables = LocalVariables;
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
            encoder.LocalVariableTable(constantPool.Get(AttributeName.LocalVariableTable), e => self.LocalVariables.CopyTo(constantView, constantPool, ref e));
        }

    }

}
