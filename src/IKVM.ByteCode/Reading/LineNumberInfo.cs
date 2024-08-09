﻿using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct LineNumberInfo(ushort StartPc, ushort LineNumber)
    {

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref LineNumberTableEncoder encoder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            encoder.LineNumber(StartPc, LineNumber);
        }

    }

}
