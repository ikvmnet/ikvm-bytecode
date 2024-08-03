using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes a 'bootstrap_methods' structure.
    /// </summary>
    public struct BootstrapMethodsTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public BootstrapMethodsTableEncoder(BlobBuilder builder)
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
        public BootstrapMethodsTableEncoder Add(MethodHandleConstantHandle methodRef, Action<BootstrapArgumentsTableEncoder> arguments)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(methodRef.Index);
            arguments(new BootstrapArgumentsTableEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Adds an existing bootstrap method.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public BootstrapMethodsTableEncoder Add(BootstrapMethodsAttributeMethodRecord record)
        {
            return Add(record.Method, e => e.Add(record.Arguments.AsSpan()));
        }

    }

}
