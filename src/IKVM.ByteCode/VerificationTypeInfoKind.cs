namespace IKVM.ByteCode
{

    /// <summary>
    /// Identifies the type of a verification type info entry in a stack map frame, as defined in JVMS §4.7.4.
    /// </summary>
    public enum VerificationTypeInfoKind : byte
    {

        /// <summary>Indicates a top (unusable) type (tag 0).</summary>
        Top = 0,
        /// <summary>Indicates an <c>int</c> or smaller integer type (tag 1).</summary>
        Integer = 1,
        /// <summary>Indicates a <c>float</c> type (tag 2).</summary>
        Float = 2,
        /// <summary>Indicates a <c>double</c> type, occupying two slots (tag 3).</summary>
        Double = 3,
        /// <summary>Indicates a <c>long</c> type, occupying two slots (tag 4).</summary>
        Long = 4,
        /// <summary>Indicates a <c>null</c> reference (tag 5).</summary>
        Null = 5,
        /// <summary>Indicates the uninitialized <c>this</c> reference in an instance initialiser (tag 6).</summary>
        UninitializedThis = 6,
        /// <summary>Indicates a reference to an object of a known type (tag 7).</summary>
        Object = 7,
        /// <summary>Indicates an uninitialized object reference created by a specific <c>new</c> instruction (tag 8).</summary>
        Uninitialized = 8,

    }

}