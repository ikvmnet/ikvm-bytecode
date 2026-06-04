using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents the decoded <c>LocalVariableTypeTable</c> attribute of a <c>Code</c> attribute.
    /// </summary>
    /// <param name="LocalVariableTypes">The local variable type table.</param>
    public readonly record struct LocalVariableTypeTableAttribute(LocalVariableTypeTable LocalVariableTypes)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static LocalVariableTypeTableAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute from the given reader.
        /// </summary>
        /// <param name="reader">The class format reader to read from.</param>
        /// <param name="attribute">The decoded attribute on success.</param>
        /// <returns><see langword="true"/> if the attribute was read successfully; otherwise <see langword="false"/>.</returns>
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
        /// Gets the local variable type table.
        /// </summary>
        public readonly LocalVariableTypeTable LocalVariableTypes = LocalVariableTypes;

        /// <summary>
        /// Copies this attribute to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.LocalVariableTypeTable(constantPool.Get(AttributeName.LocalVariableTypeTable), e => self.LocalVariableTypes.CopyTo(constantView, constantPool, ref e));
        }

    }

}
