using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct BootstrapMethodsAttribute(BootstrapMethodTable Methods)
    {

        public static BootstrapMethodsAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out BootstrapMethodsAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var methods = count == 0 ? [] : new BootstrapMethod[count];
            for (int i = 0; i < count; i++)
            {
                if (BootstrapMethod.TryRead(ref reader, out var method) == false)
                    return false;

                methods[i] = method;
            }

            attribute = new BootstrapMethodsAttribute(new(methods));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly BootstrapMethodTable Methods = Methods;

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
        public readonly void EncodeTo<TConstantMap>(TConstantMap map, Utf8ConstantHandle attributeName, ref AttributeTableEncoder encoder)
            where TConstantMap : IConstantMap
        {
            var self = this;
            encoder.BootstrapMethods(attributeName, e => self.Methods.EncodeTo(map, ref e));
        }

    }

}
