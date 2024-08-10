using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleProvideInfo(ClassConstantHandle Class, ClassConstantHandleTable With)
    {

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref ModuleProvidesTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            var self = this;
            encoder.Provides(map.Map(Class), e => self.With.EncodeTo(map, ref e));
        }

    }

}
