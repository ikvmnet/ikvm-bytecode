using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    public struct ModuleRequiresTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public ModuleRequiresTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        public ModuleRequiresTableEncoder Requires(ModuleConstantHandle module, ModuleRequiresFlag flags, Utf8ConstantHandle version)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(module.Index);
            w.TryWriteU2((ushort)flags);
            w.TryWriteU2(version.Index);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
