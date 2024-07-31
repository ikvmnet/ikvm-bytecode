using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes a 'bootstrap_arguments' structure.
    /// </summary>
    public struct BootstrapArgumentsTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public BootstrapArgumentsTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds a bootstrap method argument.
        /// </summary>
        /// <param name="argument"></param>
        /// <returns></returns>
        public BootstrapArgumentsTableEncoder Argument(ConstantHandle argument)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(argument.Index);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
