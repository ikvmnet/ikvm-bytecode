using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    public struct LocalVariableTypeTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public LocalVariableTypeTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds an existing local variable type.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public LocalVariableTypeTableEncoder Add(LocalVariableTypeTableAttributeItemRecord record)
        {
            return LocalVarType(record.CodeOffset, record.CodeLength, record.Name, record.Signature, record.Index);
        }

        /// <summary>
        /// Adds many existing local variable types.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public LocalVariableTypeTableEncoder AddMany(ReadOnlySpan<LocalVariableTypeTableAttributeItemRecord> records)
        {
            foreach (var i in records)
                Add(i);

            return this;
        }

        /// <summary>
        /// Adds many existing local variable types.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public LocalVariableTypeTableEncoder AddMany(IEnumerable<LocalVariableTypeTableAttributeItemRecord> records)
        {
            foreach (var i in records)
                Add(i);

            return this;
        }

        /// <summary>
        /// Adds a new local variable type.
        /// </summary>
        public LocalVariableTypeTableEncoder LocalVarType(ushort start, ushort length, Utf8ConstantHandle name, Utf8ConstantHandle signature, ushort index)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(start);
            w.TryWriteU2(length);
            w.TryWriteU2(name.Index);
            w.TryWriteU2(signature.Index);
            w.TryWriteU2(index);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
