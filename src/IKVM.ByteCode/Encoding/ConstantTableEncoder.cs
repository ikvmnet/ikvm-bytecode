using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Encoding
{

    /// <summary>
    /// Encodes a constant table structure.
    /// </summary>
    public struct ConstantTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Intializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public ConstantTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds a class to the table.
        /// </summary>
        /// <param name="constant"></param>
        public ConstantTableEncoder Constant(ConstantHandle constant)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.WriteU2(constant.Slot);
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds multiple classes to the table.
        /// </summary>
        /// <param name="constants"></param>
        /// <returns></returns>
        public ConstantTableEncoder Constants(ReadOnlySpan<ConstantHandle> constants)
        {
            foreach (var i in constants)
                Constant(i);

            return this;
        }

        /// <summary>
        /// Adds multiple classes to the table.
        /// </summary>
        /// <param name="constants"></param>
        /// <returns></returns>
        public ConstantTableEncoder Constants(IEnumerable<ConstantHandle> constants)
        {
            foreach (var i in constants)
                Constant(i);

            return this;
        }

    }

}
