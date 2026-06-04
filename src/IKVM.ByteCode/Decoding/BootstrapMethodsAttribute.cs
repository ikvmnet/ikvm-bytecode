using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents the decoded <c>BootstrapMethods</c> attribute of a class file.
    /// </summary>
    /// <param name="Methods">The bootstrap method table.</param>
    public readonly record struct BootstrapMethodsAttribute(BootstrapMethodTable Methods)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static BootstrapMethodsAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute from the given reader.
        /// </summary>
        /// <param name="reader">The class format reader to read from.</param>
        /// <param name="attribute">The decoded attribute on success.</param>
        /// <returns><see langword="true"/> if the attribute was read successfully; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out BootstrapMethodsAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var methods = count == 0 ? [] : new BootstrapMethod[count];
            for (int i = 0; i < count; i++)
            {
                if (BootstrapMethod.TryRead(ref reader, out var method) == false)
                    return false;

                methods[i] = method;
            }

            attribute = new BootstrapMethodsAttribute(new(methods));
            return true;
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
        /// Gets the bootstrap method table.
        /// </summary>
        public readonly BootstrapMethodTable Methods = Methods;

        /// <summary>
        /// Copies this attribute to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.BootstrapMethods(constantPool.Get(AttributeName.BootstrapMethods), e => self.Methods.CopyTo(constantView, constantPool, ref e));
        }

    }

}
