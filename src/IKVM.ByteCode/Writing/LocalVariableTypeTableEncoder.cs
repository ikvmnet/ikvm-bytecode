﻿using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;

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
        /// Adds a new local variable type.
        /// </summary>
        public LocalVariableTypeTableEncoder LocalVariableType(ushort startPc, ushort length, Utf8ConstantHandle name, Utf8ConstantHandle signature, ushort slot)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(startPc);
            w.TryWriteU2(length);
            w.TryWriteU2(name.Index);
            w.TryWriteU2(signature.Index);
            w.TryWriteU2(slot);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
