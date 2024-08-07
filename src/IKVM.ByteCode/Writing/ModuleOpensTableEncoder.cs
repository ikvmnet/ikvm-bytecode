using System;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Writing
{

    public struct ModuleOpensTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public ModuleOpensTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds a new module open record.
        /// </summary>
        /// <param name="package"></param>
        /// <param name="flags"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public ModuleOpensTableEncoder ModuleOpens(PackageConstantHandle package, ModuleOpensFlag flags, Action<ModuleTableEncoder> to)
        {
            if (to is null)
                throw new ArgumentNullException(nameof(to));

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(package.Index);
            w.TryWriteU2((ushort)flags);
            to(new ModuleTableEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
