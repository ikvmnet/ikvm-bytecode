using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;

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

        /// <summary>
        /// Adds a new module requires record.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="flags"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public ModuleRequiresTableEncoder Requires(ModuleConstantHandle module, ModuleRequiresFlag flags, Utf8ConstantHandle version)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.WriteU2(module.Slot);
            w.WriteU2((ushort)flags);
            w.WriteU2(version.Slot);
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

    }

}
