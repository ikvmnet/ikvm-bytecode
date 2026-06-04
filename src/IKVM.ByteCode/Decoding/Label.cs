namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a bytecode label consisting of an absolute and relative position.
    /// </summary>
    /// <param name="Position">The absolute bytecode offset of the label.</param>
    /// <param name="RelativePosition">The relative bytecode offset of the label from the start of the current code section.</param>
    public readonly record struct Label(ushort Position, ushort RelativePosition)
    {



    }

}
