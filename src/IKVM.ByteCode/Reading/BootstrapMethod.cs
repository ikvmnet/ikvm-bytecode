﻿using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct BootstrapMethod(MethodHandleConstantHandle Method, ConstantHandleTable Arguments)
    {

        public static bool TryRead(ref ClassFormatReader reader, out BootstrapMethod method)
        {
            method = default;

            if (reader.TryReadU2(out ushort methodIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort argumentCount) == false)
                return false;

            var arguments = argumentCount == 0 ? [] : new ConstantHandle[argumentCount];
            for (int i = 0; i < argumentCount; i++)
            {
                if (reader.TryReadU2(out ushort argumentIndex) == false)
                    return false;

                arguments[i] = new(ConstantKind.Unknown, argumentIndex);
            }

            method = new BootstrapMethod(new(methodIndex), new(arguments));
            return true;
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref BootstrapMethodTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            var self = this;
            encoder.Method(map.Map(Method), e => self.Arguments.EncodeTo(map, ref e));
        }

    }

}
