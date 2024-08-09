using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Reading;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes a 'bootstrap_methods' structure.
    /// </summary>
    public struct BootstrapMethodTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public BootstrapMethodTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds a bootstrap method.
        /// </summary>
        /// <param name="methodRef"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public BootstrapMethodTableEncoder Method(MethodHandleConstantHandle methodRef, Action<ConstantTableEncoder> arguments)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.WriteU2(methodRef.Index);
            arguments(new ConstantTableEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

    }

}
