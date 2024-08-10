using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleMainClassAttribute(ClassConstantHandle MainClass)
    {

        public static ModuleMainClassAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out ModuleMainClassAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort mainClassIndex) == false)
                return false;

            attribute = new ModuleMainClassAttribute(new ClassConstantHandle(mainClassIndex));
            return true;
        }

        public readonly ClassConstantHandle MainClass = MainClass;
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
            encoder.ModuleMainClass(attributeName, map.Map(MainClass));
        }

    }

}
