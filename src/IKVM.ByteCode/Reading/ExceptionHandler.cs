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

    }

}
