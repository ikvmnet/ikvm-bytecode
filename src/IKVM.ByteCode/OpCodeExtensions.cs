using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Extension methods for the <see cref="OpCode"/> enumeration.
    /// </summary>
    public static class OpCodeExtensions
    {

        /// <summary>
        /// Returns <c>true</c> if the <see cref="OpCode"/> value is a valid JVM opcode.
        /// </summary>
        /// <param name="opcode"></param>
        /// <returns></returns>
        public static bool IsValid(this OpCode opcode)
        {
#if NETFRAMEWORK || NETSTANDARD
            return Enum.IsDefined(typeof(OpCode), opcode);
#else
            return Enum.IsDefined<OpCode>(opcode);
#endif
        }

    }

}
