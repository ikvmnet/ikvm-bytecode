﻿using System.Collections.Generic;

using IKVM.ByteCode.Parsing;

using static IKVM.ByteCode.Util;

namespace IKVM.ByteCode.Reading
{

    public sealed class ExceptionsAttributeReader : AttributeReader<ExceptionsAttributeRecord>
    {

        DelegateLazyReaderList<ClassConstantReader, ClassConstantHandle> exceptions;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="info"></param>
        /// <param name="record"></param>
        internal ExceptionsAttributeReader(ClassReader declaringClass, AttributeInfoReader info, ExceptionsAttributeRecord record) :
            base(declaringClass, info, record)
        {

        }

        /// <summary>
        /// Gets the names of the exceptions.
        /// </summary>
        public IReadOnlyList<ClassConstantReader> Exceptions => LazyGet(ref exceptions, () => new DelegateLazyReaderList<ClassConstantReader, ClassConstantHandle>(DeclaringClass, Record.Exceptions, (_, handle) => DeclaringClass.Constants.Get<ClassConstantReader>(handle)));

    }

}
