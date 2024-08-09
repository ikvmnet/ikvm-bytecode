using System;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Writing
{

    public struct LocalVariableTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public LocalVariableTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds a new local variable.
        /// </summary>
        public LocalVariableTableEncoder LocalVariable(ushort startPc, ushort length, Utf8ConstantHandle name, Utf8ConstantHandle type, ushort slot)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.WriteU2(startPc);
            w.WriteU2(length);
            w.WriteU2(name.Index);
            w.WriteU2(type.Index);
            w.WriteU2(slot);
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

    }

}
