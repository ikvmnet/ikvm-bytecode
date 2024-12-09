using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct ModuleProvideInfo(ClassConstantHandle Class, ClassConstantHandleTable With)
    {

        public readonly ClassConstantHandle Class = Class;
        public readonly ClassConstantHandleTable With = With;
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
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantMap>(TConstantMap map, ref ModuleProvidesTableEncoder encoder)
            where TConstantMap : IConstantMap
        {
            var self = this;
            encoder.Provides(map.Map(Class), e => self.With.CopyTo(map, ref e));
        }

    }

}
