﻿using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct InvokeDynamicConstantData(ushort BootstrapMethodAttributeIndex, NameAndTypeConstantHandle NameAndType)
    {

        /// <summary>
        /// Measures a constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2 + ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2 + ClassFormatReader.U2) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a InvokeDynamic constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 0;

            if (reader.TryReadMany(ClassFormatReader.U2 + ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a InvokeDynamic constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryRead(ref ClassFormatReader reader, out InvokeDynamicConstantData constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort bootstrapMethodAttrIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort nameAndTypeIndex) == false)
                return false;

            constant = new InvokeDynamicConstantData(bootstrapMethodAttrIndex, new(nameAndTypeIndex));
            return true;
        }

        public readonly ushort BootstrapMethodAttributeIndex = BootstrapMethodAttributeIndex;
        public readonly NameAndTypeConstantHandle NameAndType = NameAndType;
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