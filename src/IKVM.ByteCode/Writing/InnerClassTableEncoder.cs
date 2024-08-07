using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Reading;

namespace IKVM.ByteCode.Writing
{

    public struct InnerClassTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Intializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public InnerClassTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds a inner class to the table.
        /// </summary>
        /// <param name="innerClass"></param>
        /// <param name="outerClass"></param>
        /// <param name="innerName"></param>
        /// <param name="innerAccessFlags"></param>
        /// <returns></returns>
        public InnerClassTableEncoder InnerClass(ClassConstantHandle innerClass, ClassConstantHandle outerClass, Utf8ConstantHandle innerName, AccessFlag innerAccessFlags)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(innerClass.Index);
            w.TryWriteU2(outerClass.Index);
            w.TryWriteU2(innerName.Index);
            w.TryWriteU2((ushort)innerAccessFlags);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
