namespace IKVM.ByteCode
{

    /// <summary>
    /// Represents a handle to an interface entry in a class file's interfaces table.
    /// </summary>
    /// <param name="Index">The index of the interface within the interfaces table.</param>
    public readonly record struct InterfaceHandle(ushort Index)
    {



    }

}
