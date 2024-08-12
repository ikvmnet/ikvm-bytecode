namespace IKVM.ByteCode
{

    /// <summary>
    /// Describes the kind of an OpCode.
    /// </summary>
    public enum OpCodeKind : byte
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
        Constant2_Immediate1,

        /// <summary>
        /// Has a two byte constant argument followed by a single byte value followed by a single byte value.
        /// </summary>
        Constant2_1_1,

        /// <summary>
        /// Has a single byte argument containing a local variable index.
        /// </summary>
        Local1,

        /// <summary>
        /// Has a single byte argument containing a local variable index followed by a single byte immediate value.
        /// </summary>
        Local1_Immediate1,

        /// <summary>
        /// Has a single byte immediate value.
        /// </summary>
        Immediate1,

        /// <summary>
        /// Has a two byte immediate value.
        /// </summary>
        Immediate2,

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
        Tableswitch,

        /// <summary>
        /// Has a localswitch argument structure.
        /// </summary>
        Lookupswitch,

        /// <summary>
        /// Is a wide prefix.
        /// </summary>
        WidePrefix,

    }

}
