namespace IKVM.ByteCode
{

    /// <summary>
    /// Identity of a label within a <see cref="ControlFlowBuilder"/>.
    /// </summary>
    /// <param name="Id"></param>
    public readonly record struct LabelHandle(int Id)
    {

        /// <summary>
        /// Gets whether or not this is a nil handle.
        /// </summary>
        public bool IsNil => Id == 0;

    }

}
