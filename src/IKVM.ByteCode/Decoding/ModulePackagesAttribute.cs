using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct ModulePackagesAttribute(PackageConstantHandleTable Packages)
    {

        public static ModulePackagesAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out ModulePackagesAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var packages = count == 0 ? [] : new PackageConstantHandle[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort packageIndex) == false)
                    return false;

                packages[i] = new(packageIndex);
            }

            attribute = new ModulePackagesAttribute(new(packages));
            return true;
        }

        public readonly PackageConstantHandleTable Packages = Packages;
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
        public readonly void CopyTo<TConstantMap>(TConstantMap map, Utf8ConstantHandle attributeName, ref AttributeTableEncoder encoder)
            where TConstantMap : IConstantMap
        {
            var self = this;
            encoder.ModulePackages(attributeName, e => self.Packages.CopyTo(map, ref e));
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantMap>(TConstantMap map, ref PackageConstantTableEncoder encoder)
            where TConstantMap : IConstantMap
        {
            Packages.CopyTo(map, ref encoder);
        }

    }

}