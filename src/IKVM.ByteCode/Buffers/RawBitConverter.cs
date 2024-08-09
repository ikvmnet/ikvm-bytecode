using System;
using System.Runtime.CompilerServices;

namespace IKVM.ByteCode.Buffers
{

    static class RawBitConverter
    {


        /// <summary>
        /// Converts the specified 32-bit signed integer to a single-precision floating point number.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>A single-precision floating point number whose bits are identical to <paramref name="value"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe float Int32BitsToSingle(int value)
        {
#if NET
            return BitConverter.Int32BitsToSingle(value);
#else
            return Unsafe.AsRef<float>(Unsafe.AsPointer(ref value));
#endif
        }

        /// <summary>
        /// Converts the specified 32-bit signed integer to a single-precision floating point number.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>A single-precision floating point number whose bits are identical to <paramref name="value"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Int64BitsToDouble(long value)
        {
            return BitConverter.Int64BitsToDouble(value);
        }

        /// <summary>
        /// Converts the specified 32-bit unsigned integer to a single-precision floating point number.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>A single-precision floating point number whose bits are identical to <paramref name="value"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe float UInt32BitsToSingle(uint value)
        {
#if NET
            return BitConverter.UInt32BitsToSingle(value);
#else
            return Int32BitsToSingle((int)value);
#endif
        }

        /// <summary>
        /// Converts the specified 32-bit unsigned integer to a single-precision floating point number.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>A single-precision floating point number whose bits are identical to <paramref name="value"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double UInt64BitsToDouble(ulong value)
        {
#if NET
            return BitConverter.UInt64BitsToDouble(value);
#else
            return Int64BitsToDouble((long)value);
#endif
        }

        /// <summary>
        /// Converts the specified single-precision floating point number to an integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int SingleToInt32Bits(float value)
        {
#if NET
            return BitConverter.SingleToInt32Bits(value);
#else
            return Unsafe.AsRef<int>(Unsafe.AsPointer(ref value));
#endif
        }

        /// <summary>
        /// Converts the specified single-precision floating point number to an integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint SingleToUInt32Bits(float value)
        {
#if NET
            return BitConverter.SingleToUInt32Bits(value);
#else
            return (uint)SingleToInt32Bits(value);
#endif
        }

        /// <summary>
        /// Converts the specified double-precision floating point number to an integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe long DoubleToInt64Bits(double value)
        {
            return BitConverter.DoubleToInt64Bits(value);
        }

        /// <summary>
        /// Converts the specified double-precision floating point number to an integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ulong DoubleToUInt64Bits(double value)
        {
#if NET
            return BitConverter.DoubleToUInt64Bits(value);
#else
            return (ulong)DoubleToInt64Bits(value);
#endif
        }
    }

}
