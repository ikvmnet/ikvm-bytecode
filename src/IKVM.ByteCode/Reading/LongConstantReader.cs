﻿using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Reading
{

    public sealed class LongConstantReader : ConstantReader<LongConstantRecord>
    {


        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal LongConstantReader(ClassReader declaringClass, LongConstantHandle handle, LongConstantRecord record) :
            base(declaringClass, handle, record)
        {

        }

        /// <inheritdoc />
        public new LongConstantHandle Handle => (LongConstantHandle)base.Handle;

        /// <summary>
        /// Gets the value of the constant.
        /// </summary>
        public long Value => Record.Value;

        /// <summary>
        /// Returns <c>true</c> if this constant is loadable.
        /// </summary>
        public override bool IsLoadable => DeclaringClass.Version >= new ClassFormatVersion(45, 3);

    }

}