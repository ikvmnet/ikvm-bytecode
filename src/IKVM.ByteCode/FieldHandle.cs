namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a field within a class file.
    /// </summary>
    /// <param name="Index">The index of the field within its containing class.</param>
    public readonly record struct FieldHandle(ushort Index)
    {



    }

}
