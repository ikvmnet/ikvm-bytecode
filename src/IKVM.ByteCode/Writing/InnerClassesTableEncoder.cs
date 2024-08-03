using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    public struct InnerClassesTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Intializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public InnerClassesTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds an existing inner class.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public InnerClassesTableEncoder Add(InnerClassesAttributeItemRecord record)
        {
            return Add(record.InnerClass, record.OuterClass, record.InnerName, record.InnerClassAccessFlags);
        }

        /// <summary>
        /// Adds many existing inner classes.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public InnerClassesTableEncoder AddMany(ReadOnlySpan<InnerClassesAttributeItemRecord> records)
        {
            foreach (var i in records)
                Add(i);

            return this;
        }

        /// <summary>
        /// Adds many existing inner classes.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public InnerClassesTableEncoder AddMany(IEnumerable<InnerClassesAttributeItemRecord> records)
        {
            foreach (var i in records)
                Add(i);

            return this;
        }

        /// <summary>
        /// Adds a inner class to the table.
        /// </summary>
        /// <param name="package"></param>
        public InnerClassesTableEncoder Add(ClassConstantHandle innerClass, ClassConstantHandle outerClass, Utf8ConstantHandle innerName, AccessFlag innerAccessFlags)
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
