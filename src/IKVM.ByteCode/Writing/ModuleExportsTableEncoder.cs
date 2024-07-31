using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    public struct ModuleExportsTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public ModuleExportsTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        public ModuleExportsTableEncoder Exports(PackageConstantHandle package, ModuleExportsFlag flags, Action<ModuleTableEncoder> to)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(package.Index);
            w.TryWriteU2((ushort)flags);
            to(new ModuleTableEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
