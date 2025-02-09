﻿using System;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Encoding
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
        /// Adds a new local variable type.
        /// </summary>
        public LocalVariableTypeTableEncoder LocalVariableType(ushort startPc, ushort length, Utf8ConstantHandle name, Utf8ConstantHandle signature, ushort slot)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.WriteU2(startPc);
            w.WriteU2(length);
            w.WriteU2(name.Slot);
            w.WriteU2(signature.Slot);
            w.WriteU2(slot);
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

    }

}
