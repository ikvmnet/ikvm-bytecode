using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleRequireInfo(ModuleConstantHandle Module, ModuleRequiresFlag Flag, Utf8ConstantHandle Version)
    {

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref ModuleRequiresTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            encoder.Requires(map.Map(Module), Flag, map.Map(Version));
        }

    }

}