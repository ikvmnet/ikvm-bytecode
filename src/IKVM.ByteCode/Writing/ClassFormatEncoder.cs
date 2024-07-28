using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes class format values into a builder.
    /// </summary>
    public readonly ref struct ClassFormatEncoder
    {

        readonly BlobBuilder builder;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ClassFormatEncoder(BlobBuilder builder)
        {
            this.builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        /// <summary>
        /// Writes a value defined as a 'u1' in the class format specification.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void WriteU1(byte value)
        {
            var w = new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(value);
        }

        /// <summary>
        /// Writes a value defined as a 'u2' in the class format specification.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void WriteU2(ushort value)
        {
            var w = new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(value);
        }

        /// <summary>
        /// Writes a value defined as a 'u4' in the class format specification.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void WriteU4(uint value)
        {
            var w = new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U4).GetBytes());
            w.TryWriteU4(value);
        }

    }

}
