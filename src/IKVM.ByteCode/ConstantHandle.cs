using IKVM.ByteCode.Reading;

namespace IKVM.ByteCode
{

    public readonly record struct ConstantHandle(ConstantKind Kind, ushort Index)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static readonly ConstantHandle Nil = new(ConstantKind.Unknown, 0);

        /// <summary>
        /// Gets whether or not this represents the nil instance.
        /// </summary>
        public readonly bool IsNil => Index == 0;

    }

}
