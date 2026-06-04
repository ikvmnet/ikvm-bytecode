namespace IKVM.ByteCode
{

    /// <summary>
    /// Identifies a step in a <see cref="Decoding.TypePath"/> that locates a type annotation within a composite type, as defined in JVMS §4.7.20.2.
    /// </summary>
    public enum TypePathKind : byte
    {

        /// <summary>Annotation is deeper in an array type (type path kind 0).</summary>
        Array = 0,
        /// <summary>Annotation is deeper in a nested type (type path kind 1).</summary>
        InnerType = 1,
        /// <summary>Annotation is on the bound of a wildcard type argument (type path kind 2).</summary>
        Wildcard = 2,
        /// <summary>Annotation is on a type argument of a parameterized type (type path kind 3).</summary>
        TypeArgument = 3,

    }

}
