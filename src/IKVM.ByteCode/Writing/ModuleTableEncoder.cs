using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    public struct ModuleTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public ModuleTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds many existing modules.
        /// </summary>
        /// <param name="modules"></param>
        /// <returns></returns>
        public ModuleTableEncoder AddMany(ReadOnlySpan<ModuleConstantHandle> modules)
        {
            foreach (var i in modules)
                Add(i);

            return this;
        }

        /// <summary>
        /// Adds many existing modules.
        /// </summary>
        /// <param name="modules"></param>
        /// <returns></returns>
        public ModuleTableEncoder AddMany(IEnumerable<ModuleConstantHandle> modules)
        {
            foreach (var i in modules)
                Add(i);

            return this;
        }

        /// <summary>
        /// Adds a module.
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public ModuleTableEncoder Add(ModuleConstantHandle module)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(module.Index);
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

    }

}
