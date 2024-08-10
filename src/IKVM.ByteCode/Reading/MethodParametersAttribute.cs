using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct MethodParametersAttribute(MethodParameterTable Parameters)
    {

        public static MethodParametersAttribute Nil => default;

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

        public readonly MethodParameterTable Parameters = Parameters;
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
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="attributeName"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, Utf8ConstantHandle attributeName, ref AttributeTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            var self = this;
            encoder.MethodParameters(attributeName, e => self.Parameters.EncodeTo(map, ref e));
        }

    }

}
