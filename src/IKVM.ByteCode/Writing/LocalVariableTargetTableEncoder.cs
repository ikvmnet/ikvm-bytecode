using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    public struct LocalVariableTargetTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public LocalVariableTargetTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Encodes an existing local variable target table record.
        /// </summary>
        /// <param name="table"></param>
        public void Encode(LocalVariableTargetTableRecord table)
        {
            foreach (var i in table.Items)
                Encode(i);
        }

        /// <summary>
        /// Encodes an existing local variable target.
        /// </summary>
        /// <param name="target"></param>
        public void Encode(LocalVariableTargetTableItemRecord target)
        {
            LocalVar(target.Start, target.Length, target.Index);
        }

        /// <summary>
        /// Adds a new local variable.
        /// </summary>
        public LocalVariableTargetTableEncoder LocalVar(ushort start, ushort length, ushort index)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(start);
            w.TryWriteU2(length);
            w.TryWriteU2(index);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }
    }

}
