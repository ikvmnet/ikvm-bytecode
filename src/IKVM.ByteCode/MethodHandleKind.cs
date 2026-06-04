namespace IKVM.ByteCode
{

    /// <summary>
    /// Identifies the kind of a method handle as defined in JVMS §4.4.8.
    /// </summary>
    public enum MethodHandleKind : byte
    {

        /// <summary>A method handle for a <c>getfield</c> instruction (reference kind 1).</summary>
        GetField = 1,
        /// <summary>A method handle for a <c>getstatic</c> instruction (reference kind 2).</summary>
        GetStatic = 2,
        /// <summary>A method handle for a <c>putfield</c> instruction (reference kind 3).</summary>
        PutField = 3,
        /// <summary>A method handle for a <c>putstatic</c> instruction (reference kind 4).</summary>
        PutStatic = 4,
        /// <summary>A method handle for an <c>invokevirtual</c> instruction (reference kind 5).</summary>
        InvokeVirtual = 5,
        /// <summary>A method handle for an <c>invokestatic</c> instruction (reference kind 6).</summary>
        InvokeStatic = 6,
        /// <summary>A method handle for an <c>invokespecial</c> instruction (reference kind 7).</summary>
        InvokeSpecial = 7,
        /// <summary>A method handle for a <c>new</c> followed by <c>invokespecial</c> instruction (reference kind 8).</summary>
        NewInvokeSpecial = 8,
        /// <summary>A method handle for an <c>invokeinterface</c> instruction (reference kind 9).</summary>
        InvokeInterface = 9,

    }

}
