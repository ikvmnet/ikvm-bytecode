using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct ModuleRequireInfo(ModuleConstantHandle Module, ModuleRequiresFlag Flag, Utf8ConstantHandle Version)
    {

        public readonly ModuleConstantHandle Module = Module;
        public readonly ModuleRequiresFlag Flag = Flag;
        public readonly Utf8ConstantHandle Version = Version;
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
        public readonly void EncodeTo<TConstantMap>(TConstantMap map, ref ModuleRequiresTableEncoder encoder)
            where TConstantMap : IConstantMap
        {
            encoder.Requires(map.Map(Module), Flag, map.Map(Version));
        }

    }

}