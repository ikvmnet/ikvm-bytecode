using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a bootstrap method entry decoded from the <c>BootstrapMethods</c> attribute.
    /// </summary>
    /// <param name="Method">The constant pool handle to the method handle used as the bootstrap method.</param>
    /// <param name="Arguments">The constant pool handles to the static arguments passed to the bootstrap method.</param>
    public readonly record struct BootstrapMethod(MethodHandleConstantHandle Method, ConstantHandleTable Arguments)
    {

        /// <summary>
        /// Attempts to read the bootstrap method entry from the given reader.
        /// </summary>
        /// <param name="reader">The class format reader to read from.</param>
        /// <param name="method">The decoded bootstrap method entry on success.</param>
        /// <returns><see langword="true"/> if the entry was read successfully; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out BootstrapMethod method)
        {
            method = default;

            if (reader.TryReadU2(out ushort methodIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort argumentCount) == false)
                return false;

            var arguments = argumentCount == 0 ? [] : new ConstantHandle[argumentCount];
            for (int i = 0; i < argumentCount; i++)
            {
                if (reader.TryReadU2(out ushort argumentIndex) == false)
                    return false;

                arguments[i] = new(ConstantKind.Unknown, argumentIndex);
            }

            method = new BootstrapMethod(new(methodIndex), new(arguments));
            return true;
        }

        /// <summary>
        /// Copies this method to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref BootstrapMethodTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.Method(constantPool.Get(constantView.Get(Method)), e => self.Arguments.CopyTo(constantView, constantPool, ref e));
        }

        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Gets the constant pool handle to the method handle used as the bootstrap method.
        /// </summary>
        public readonly MethodHandleConstantHandle Method = Method;

        /// <summary>
        /// Gets the constant pool handles to the static arguments passed to the bootstrap method.
        /// </summary>
        public readonly ConstantHandleTable Arguments = Arguments;

    }

}
