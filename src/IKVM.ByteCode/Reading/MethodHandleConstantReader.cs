using IKVM.ByteCode.Parsing;

using static IKVM.ByteCode.Util;

namespace IKVM.ByteCode.Reading
{

    public sealed class MethodHandleConstantReader : ConstantReader<MethodHandleConstantRecord>
    {

        IRefConstantReader reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="declaringClass"></param>
        /// <param name="handle"></param>
        /// <param name="record"></param>
        internal MethodHandleConstantReader(ClassReader declaringClass, MethodHandleConstantHandle handle, MethodHandleConstantRecord record) :
            base(declaringClass, handle, record)
        {

        }

        /// <summary>
        /// Gets the kind of this reference.
        /// </summary>
        public ReferenceKind ReferenceKind => Record.Kind;

        /// <summary>
        /// Gets the constant refered to by this MethodHandle.
        /// </summary>
        public IRefConstantReader Reference => LazyGet(ref reference, () => DeclaringClass.Constants.Get<IRefConstantReader>(Record.Reference));

        /// <summary>
        /// Returns <c>true</c> if this constant type is loadable.
        /// </summary>
        public override bool IsLoadable => DeclaringClass.Version >= new ClassFormatVersion(51, 0);

    }

}
