namespace IKVM.ByteCode
{

    /// <summary>
    /// Describes the kind of an OpCode.
    /// </summary>
    public enum OpCodeArgumentKind : byte
    {

        /// <summary>
        /// No kind specified.
        /// </summary>
        None,

        /// <summary>
        /// Has no arguments.
        /// </summary>
        Simple,

        /// <summary>
        /// Has a single byte constant argument.
        /// </summary>
        Constant1,

        /// <summary>
        /// Has a two byte constant argument.
        /// </summary>
        Constant2,

        /// <summary>
        /// Has a two byte constant argument followed by a single byte immediate value.
        /// </summary>
        Constant2_ImmediateU1,

        /// <summary>
        /// Has a two byte constant argument followed by a single signed byte value that represents a count followed by a single byte value that must always be zero.
        /// </summary>
        Constant2_Count1_Zero1,

        /// <summary>
        /// Has a single byte argument containing a local variable index.
        /// </summary>
        Local1,

        /// <summary>
        /// Has a single byte argument containing a local variable index followed by a single signed byte immediate value.
        /// </summary>
        Local1_ImmediateS1,

        /// <summary>
        /// Has a single byte unsigned immediate value.
        /// </summary>
        ImmediateU1,

        /// <summary>
        /// Has a single byte signed immediate value.
        /// </summary>
        ImmediateS1,

        /// <summary>
        /// Has a two byte immediate value.
        /// </summary>
        ImmediateS2,

        /// <summary>
        /// Branches to a two byte offset.
        /// </summary>
        Branch2,

        /// <summary>
        /// Has a four byte branch offset.
        /// </summary>
        Branch4,

        /// <summary>
        /// Has a tableswitch argument structure.
        /// </summary>
        TableSwitch,

        /// <summary>
        /// Has a localswitch argument structure.
        /// </summary>
        LookupSwitch,

        /// <summary>
        /// Is a wide prefix.
        /// </summary>
        WidePrefix,

    }

}
