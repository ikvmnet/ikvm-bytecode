namespace IKVM.ByteCode
{

    /// <summary>
    /// Identifies the type of an annotation element value as defined in JVMS §4.7.16.1.
    /// The tag character used in the class file is listed for each member.
    /// </summary>
    public enum ElementValueKind : byte
    {

        /// <summary>An unknown or unrecognised element value tag.</summary>
        Unknown = 0x00,
        /// <summary>A <c>byte</c> primitive value (tag <c>'B'</c>).</summary>
        Byte = (byte)'B',
        /// <summary>A <c>char</c> primitive value (tag <c>'C'</c>).</summary>
        Char = (byte)'C',
        /// <summary>A <c>double</c> primitive value (tag <c>'D'</c>).</summary>
        Double = (byte)'D',
        /// <summary>A <c>float</c> primitive value (tag <c>'F'</c>).</summary>
        Float = (byte)'F',
        /// <summary>An <c>int</c> primitive value (tag <c>'I'</c>).</summary>
        Integer = (byte)'I',
        /// <summary>A <c>long</c> primitive value (tag <c>'J'</c>).</summary>
        Long = (byte)'J',
        /// <summary>A <c>short</c> primitive value (tag <c>'S'</c>).</summary>
        Short = (byte)'S',
        /// <summary>A <c>boolean</c> primitive value (tag <c>'Z'</c>).</summary>
        Boolean = (byte)'Z',
        /// <summary>A <see cref="string"/> value (tag <c>'s'</c>).</summary>
        String = (byte)'s',
        /// <summary>An enum constant value (tag <c>'e'</c>).</summary>
        Enum = (byte)'e',
        /// <summary>A class literal value (tag <c>'c'</c>).</summary>
        Class = (byte)'c',
        /// <summary>A nested annotation value (tag <c>'@'</c>).</summary>
        Annotation = (byte)'@',
        /// <summary>An array of element values (tag <c>'['</c>).</summary>
        Array = (byte)'[',

    }

}
