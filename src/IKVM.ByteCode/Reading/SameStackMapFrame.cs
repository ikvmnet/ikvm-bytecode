﻿using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct SameStackMapFrame(byte FrameType)
    {

        /// <summary>
        /// Measures the size of the current element value constant value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, byte frameType, ref int size)
        {
            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, byte frameType, out SameStackMapFrame frame)
        {
            frame = new SameStackMapFrame(frameType);
            return true;
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref StackMapTableEncoder encoder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            encoder.Same(FrameType);
        }

    }

}
