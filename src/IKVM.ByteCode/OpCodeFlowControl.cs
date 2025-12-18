namespace IKVM.ByteCode
{

    /// <summary>
    /// Describes the flow of an opcode.
    /// </summary>
    public enum OpCodeFlowControl : byte
    {

        /// <summary>
        /// The instruction proceeds to the next instruction directly.
        /// </summary>
        Next,

        /// <summary>
        /// The instruction conditionally branches.
        /// </summary>
        ConditionalBranch,

        /// <summary>
        /// The instruction unconditionally branches.
        /// </summary>
        Branch,

        /// <summary>
        /// The instruction represents a switch.
        /// </summary>
        Switch,

        /// <summary>
        /// The instruction returns from the method.
        /// </summary>
        Return,

        /// <summary>
        /// Throw instruction throws from the method.
        /// </summary>
        Throw,

    }

}
