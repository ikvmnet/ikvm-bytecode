using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct LocalVariableType(ushort StartPc, ushort Length, Utf8ConstantHandle Name, Utf8ConstantHandle Signature, ushort Slot)
    {

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantMap>(TConstantMap map, ref LocalVariableTypeTableEncoder encoder)
            where TConstantMap : IConstantMap
        {
            encoder.LocalVariableType(StartPc, Length, map.Map(Name), map.Map(Signature), Slot);
        }

        public readonly ushort StartPc = StartPc;
        public readonly ushort Length = Length;
        public readonly Utf8ConstantHandle Name = Name;
        public readonly Utf8ConstantHandle Signature = Signature;
        public readonly ushort Slot = Slot;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

    }

}
