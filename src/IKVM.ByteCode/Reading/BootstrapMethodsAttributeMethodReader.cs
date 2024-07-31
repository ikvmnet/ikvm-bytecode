﻿using System.Collections.Generic;

using IKVM.ByteCode.Parsing;

using static IKVM.ByteCode.Util;

namespace IKVM.ByteCode.Reading
{

    public sealed class BootstrapMethodsAttributeMethodReader : ReaderBase<BootstrapMethodsAttributeMethodRecord>
    {

        MethodrefConstantReader methodref;
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
        public MethodrefConstantReader Methodref => LazyGet(ref methodref, () => DeclaringClass.Constants.Get<MethodrefConstantReader>(Record.Methodref));

        /// <summary>
        /// Gets the arguments bound to the method reference.
        /// </summary>
        public IReadOnlyList<IConstantReader> Arguments => LazyGet(ref arguments, () => new DelegateLazyReaderList<IConstantReader, ConstantHandle>(DeclaringClass, Record.Arguments, (_, handle) => DeclaringClass.Constants[handle]));

    }

}
