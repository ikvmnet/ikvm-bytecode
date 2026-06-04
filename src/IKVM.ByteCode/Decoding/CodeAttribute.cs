using System;
using System.Buffers;
using System.Buffers.Binary;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>Code</c> attribute containing the bytecode and associated metadata for a method.
    /// </summary>
    /// <param name="MaxStack">Maximum operand stack depth.</param>
    /// <param name="MaxLocals">Number of local variable slots.</param>
    /// <param name="Code">The raw bytecode sequence.</param>
    /// <param name="ExceptionTable">Table of exception handlers.</param>
    /// <param name="Attributes">Nested attributes such as <c>LineNumberTable</c> and <c>LocalVariableTable</c>.</param>
    public readonly record struct CodeAttribute(ushort MaxStack, ushort MaxLocals, ReadOnlySequence<byte> Code, ExceptionHandlerTable ExceptionTable, AttributeTable Attributes)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static CodeAttribute Nil => default;

        /// <summary>
        /// Attempts to read the code attribute starting from the current position.
        /// </summary>
        /// <param name="reader">The <see cref="ClassFormatReader"/> to read from.</param>
        /// <param name="attribute">The decoded attribute.</param>
        /// <returns><see langword="true"/> if the operation succeeded; otherwise <see langword="false"/>.</returns>
        public static bool TryRead(ref ClassFormatReader reader, out CodeAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort maxStack) == false)
                return false;
            if (reader.TryReadU2(out ushort maxLocals) == false)
                return false;
            if (reader.TryReadU4(out uint codeLength) == false)
                return false;
            if (reader.TryReadMany(codeLength, out ReadOnlySequence<byte> code) == false)
                return false;

            if (ExceptionHandlerTable.TryRead(ref reader, out var exceptionTable) == false)
                return false;

            if (AttributeTable.TryRead(ref reader, out var attributes) == false)
                return false;

            attribute = new CodeAttribute(maxStack, maxLocals, code, exceptionTable, attributes);
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
        /// Gets the maximum operand stack depth.
        /// </summary>
        public readonly ushort MaxStack = MaxStack;

        /// <summary>
        /// Gets the number of local variable slots.
        /// </summary>
        public readonly ushort MaxLocals = MaxLocals;

        /// <summary>
        /// Gets the raw bytecode sequence.
        /// </summary>
        public readonly ReadOnlySequence<byte> Code = Code;

        /// <summary>
        /// Gets the exception handler table.
        /// </summary>
        public readonly ExceptionHandlerTable ExceptionTable = ExceptionTable;

        /// <summary>
        /// Gets the nested attribute table.
        /// </summary>
        public readonly AttributeTable Attributes = Attributes;

        /// <summary>
        /// Copies this attribute to the specified attribute encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView">The <see cref="IConstantView"/> used to resolve constants.</param>
        /// <param name="constantPool">The constant pool to copy constants into.</param>
        /// <param name="encoder">The encoder to write to.</param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            // copy code to new blob
            var code = new BlobBuilder((int)Code.Length);
            new CodeDecoder(Code).CopyTo(constantView, constantPool, new CodeBuilder(code));

            // copy attribute table to new builder
            var attr = new AttributeTableBuilder(constantPool);
            Attributes.CopyTo(constantView, constantPool, attr);

            // add code attribute with copied values
            var excp = ExceptionTable;
            encoder.Code(constantPool.Get(AttributeName.Code), MaxStack, MaxLocals, code, e => excp.CopyTo(constantView, constantPool, ref e, 0), attr);
        }

    }

}
