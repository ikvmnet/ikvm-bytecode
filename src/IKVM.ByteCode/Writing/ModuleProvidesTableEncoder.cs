using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    public struct ModuleProvidesTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public ModuleProvidesTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        public ModuleProvidesTableEncoder Provides(ClassConstantHandle clazz, Action<ClassConstantTableEncoder> with)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(clazz.Index);
            with(new ClassConstantTableEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
