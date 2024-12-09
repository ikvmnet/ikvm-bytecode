using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct BootstrapMethod(MethodHandleConstantHandle Method, ConstantHandleTable Arguments)
    {

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

        public readonly MethodHandleConstantHandle Method = Method;
        public readonly ConstantHandleTable Arguments = Arguments;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

    }

}
