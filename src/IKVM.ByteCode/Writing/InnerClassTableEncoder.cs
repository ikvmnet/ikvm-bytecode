using System;

using IKVM.ByteCode.Buffers;

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
        /// <param name="inner"></param>
        /// <param name="outer"></param>
        /// <param name="innerName"></param>
        /// <param name="accessFlags"></param>
        /// <returns></returns>
        public InnerClassTableEncoder InnerClass(ClassConstantHandle inner, ClassConstantHandle outer, Utf8ConstantHandle innerName, AccessFlag accessFlags)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.WriteU2(inner.Index);
            w.WriteU2(outer.Index);
            w.WriteU2(innerName.Index);
            w.WriteU2((ushort)accessFlags);
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

    }

}
