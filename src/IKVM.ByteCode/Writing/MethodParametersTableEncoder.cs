using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encoes a method parameters structure.
    /// </summary>
    public struct MethodParametersTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        byte _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public MethodParametersTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U1);
            _count = 0;
        }

        /// <summary>
        /// Adds an existing method parameter.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public MethodParametersTableEncoder Add(MethodParametersAttributeParameterRecord record)
        {
            return Parameter(record.Name, record.AccessFlags);
        }

        /// <summary>
        /// Adds many existing method parameters.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public MethodParametersTableEncoder AddMany(ReadOnlySpan<MethodParametersAttributeParameterRecord> records)
        {
            foreach (var i in records)
                Add(i);

            return this;
        }

        /// <summary>
        /// Adds many existing method parameters.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public MethodParametersTableEncoder AddMany(IEnumerable<MethodParametersAttributeParameterRecord> records)
        {
            foreach (var i in records)
                Add(i);

            return this;
        }

        /// <summary>
        /// Adds a parameter.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="accessFlags"></param>
        /// <returns></returns>
        public MethodParametersTableEncoder Parameter(Utf8ConstantHandle name, AccessFlag accessFlags)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(name.Index);
            w.TryWriteU2((ushort)accessFlags);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU1(++_count);
            return this;
        }

    }

}
