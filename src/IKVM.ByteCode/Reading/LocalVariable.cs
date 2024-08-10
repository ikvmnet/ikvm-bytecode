﻿using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct LocalVariable(ushort StartPc, ushort Length, Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, ushort Slot)
    {

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref LocalVariableTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            encoder.LocalVariable(StartPc, Length, map.Map(Name), map.Map(Descriptor), Slot);
        }

        public readonly ushort StartPc = StartPc;
        public readonly ushort Length = Length;
        public readonly Utf8ConstantHandle Name = Name;
        public readonly Utf8ConstantHandle Descriptor = Descriptor;
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
