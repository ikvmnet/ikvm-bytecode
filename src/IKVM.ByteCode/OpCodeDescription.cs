namespace IKVM.ByteCode
{

    /// <summary>
    /// Provides various information about an <see cref="OpCode"/>.
    /// </summary>
    readonly partial struct OpCodeDescription(OpCode OpCode, OpCodeArgumentKind ArgumentKind, OpCodeArgumentKind WideArgumentKind, OpCodeFlowKind FlowKind, OpCodeFlags Flags)
    {

        /// <summary>
        /// Gets the described <see cref="OpCode"/>.
        /// </summary>
        public OpCode OpCode { get; } = OpCode;

        /// <summary>
        /// Gets the argument kind of the regular version of the described <see cref="OpCode"/>.
        /// </summary>
        public OpCodeArgumentKind ArgumentKind { get; } = ArgumentKind;

        /// <summary>
        /// Gets the argument kind of the wide version of the described <see cref="OpCode"/>. That is, how the argument layout changes when the <c>wide</c> prefix is used.
        /// </summary>
        public OpCodeArgumentKind WideArgumentKind { get; } = WideArgumentKind;

        /// <summary>
        /// Gets the flow kind of the described <see cref="OpCode"/>.
        /// </summary>
        public OpCodeFlowKind FlowKind { get; } = FlowKind;

        /// <summary>
        /// Gets the flags of the described <see cref="OpCode"/>.
        /// </summary>
        public OpCodeFlags Flags { get; } = Flags;

    }

}
