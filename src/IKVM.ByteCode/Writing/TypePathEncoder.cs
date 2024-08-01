using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    public struct TypePathEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        byte _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public TypePathEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U1);
            _count = 0;
        }

        /// <summary>
        /// Encodes an existing type path.
        /// </summary>
        /// <param name="targetPath"></param>
        public void Encode(TypePathRecord targetPath)
        {
            foreach (var i in targetPath.Path)
                Encode(i);
        }

        /// <summary>
        /// Encodes an existing type path item.
        /// </summary>
        /// <param name="item"></param>
        public void Encode(TypePathItemRecord item)
        {
            switch (item.Kind)
            {
                case TypePathKind.Array:
                    Array();
                    break;
                case TypePathKind.InnerType:
                    InnerType();
                    break;
                case TypePathKind.Wildcard:
                    Wildcard();
                    break;
                case TypePathKind.TypeArgument:
                    TypeArgument(item.ArgumentIndex);
                    break;
            }
        }

        /// <summary>
        /// Annotation is deeper in an array type.
        /// </summary>
        public void Array()
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(0);
            w.TryWriteU1(0);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU1(++_count);
        }

        /// <summary>
        /// Annotation is deeper in a nested type.
        /// </summary>
        public void InnerType()
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(1);
            w.TryWriteU1(0);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU1(++_count);
        }

        /// <summary>
        /// Annotation is on the bound of a wildcard type argument of a parameterized type.
        /// </summary>
        public void Wildcard()
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(2);
            w.TryWriteU1(0);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU1(++_count);
        }

        /// <summary>
        /// Annotation is on the bound of a wildcard type argument of a parameterized type.
        /// </summary>
        public void TypeArgument(byte index)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(3);
            w.TryWriteU1(index);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU1(++_count);
        }
    }

}
