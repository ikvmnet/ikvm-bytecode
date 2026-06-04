using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents the decoded <c>MethodParameters</c> attribute of a class file method.
    /// </summary>
    /// <param name="Parameters">The table of method parameters.</param>
    public readonly record struct MethodParametersAttribute(MethodParameterTable Parameters)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static MethodParametersAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute from the given reader.
        /// </summary>
        /// <param name="reader">The class format reader to read from.</param>
        /// <param name="attribute">The decoded attribute on success.</param>
        /// <returns><see langword="true"/> if the attribute was read successfully; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out MethodParametersAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU1(out byte count) == false)
                return false;

            var arguments = count == 0 ? [] : new MethodParameter[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort nameIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort accessFlags) == false)
                    return false;

                arguments[i] = new MethodParameter(new(nameIndex), (AccessFlag)accessFlags);
            }

            attribute = new MethodParametersAttribute(new(arguments));
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
        /// Gets the table of method parameters.
        /// </summary>
        public readonly MethodParameterTable Parameters = Parameters;

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
            encoder.MethodParameters(constantPool.Get(AttributeName.MethodParameters), e => self.Parameters.CopyTo(constantView, constantPool, ref e));
        }

    }

}
