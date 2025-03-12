using System;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Encoding
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
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(_count);
        }

        /// <summary>
        /// Adds a new module open record.
        /// </summary>
        /// <param name="package"></param>
        /// <param name="flags"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public ModuleOpensTableEncoder Opens(PackageConstantHandle package, ModuleOpensFlag flags, Action<ModuleTableEncoder> to)
        {
            if (to is null)
                throw new ArgumentNullException(nameof(to));

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.WriteU2(package.Slot);
            w.WriteU2((ushort)flags);
            to(new ModuleTableEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

    }

}
