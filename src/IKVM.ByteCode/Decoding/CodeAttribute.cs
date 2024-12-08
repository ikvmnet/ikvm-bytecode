﻿using System;
using System.Buffers;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct CodeAttribute(ushort MaxStack, ushort MaxLocals, ReadOnlySequence<byte> Code, ExceptionHandlerTable ExceptionTable, AttributeTable Attributes)
    {

        public static CodeAttribute Nil => default;

        /// <summary>
        /// Attempts to read the code attribute starting from the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
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

        public readonly ushort MaxStack = MaxStack;
        public readonly ushort MaxLocals = MaxLocals;
        public readonly ReadOnlySequence<byte> Code = Code;
        public readonly ExceptionHandlerTable ExceptionTable = ExceptionTable;
        public readonly AttributeTable Attributes = Attributes;
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
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="attributeName"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantMap>(TConstantMap map, Utf8ConstantHandle attributeName, ref AttributeTableEncoder encoder)
            where TConstantMap : IConstantMap
        {
            var self = this;
            throw new NotImplementedException("Cannot import the Code attribute since we are currently unable to parse byte code.");

            //var b = new BlobBuilder();
            //var s = b.ReserveBytes((int)source.Code.Length);
            //source.Code.CopyTo(s.GetBytes());
            //builder.Code(source.MaxStack, source.MaxLocals, b, e => Import(source.ExceptionTable, ref e), Import(source.Attributes));
        }

    }

}
