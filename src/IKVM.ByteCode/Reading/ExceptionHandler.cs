using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ExceptionHandler(ushort StartOffset, ushort EndOffset, ushort HandlerOffset, ClassConstantHandle CatchType)
    {

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref ExceptionTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            encoder.Exception(StartOffset, EndOffset, HandlerOffset, map.Map(CatchType));
        }

        public readonly ushort StartOffset = StartOffset;
        public readonly ushort EndOffset = EndOffset;
        public readonly ushort HandlerOffset = HandlerOffset;
        public readonly ClassConstantHandle CatchType = CatchType;
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
