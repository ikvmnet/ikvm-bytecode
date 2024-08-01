using System.Collections.Generic;

using IKVM.ByteCode.Parsing;

using static IKVM.ByteCode.Util;

namespace IKVM.ByteCode.Reading
{

    public sealed class BootstrapMethodsAttributeMethodReader : ReaderBase<BootstrapMethodsAttributeMethodRecord>
    {

        MethodHandleConstantReader method;
        IReadOnlyList<IConstantReader> arguments;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="record"></param>
        internal BootstrapMethodsAttributeMethodReader(ClassReader declaringClass, BootstrapMethodsAttributeMethodRecord record) :
            base(declaringClass, record)
        {

        }

        /// <summary>
        /// Gets the method being referenced.
        /// </summary>
        public MethodHandleConstantReader Method => LazyGet(ref method, () => DeclaringClass.Constants.Get<MethodHandleConstantReader>(Record.Method));

        /// <summary>
        /// Gets the arguments bound to the method reference.
        /// </summary>
        public IReadOnlyList<IConstantReader> Arguments => LazyGet(ref arguments, () => new DelegateLazyReaderList<IConstantReader, ConstantHandle>(DeclaringClass, Record.Arguments, (_, handle) => DeclaringClass.Constants[handle]));

    }

}
