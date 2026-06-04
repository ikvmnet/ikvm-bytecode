namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to a method within a class file.
    /// </summary>
    /// <param name="Index">The index of the method within its containing class.</param>
    public readonly record struct MethodHandle(ushort Index)
    {



    }

}
