﻿using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct InvokeDynamicConstant(ushort BootstrapMethodAttributeIndex, NameAndTypeConstantHandle NameAndType, bool IsNotNil = true)
    {

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
        public static bool TryRead(ref ClassFormatReader reader, out InvokeDynamicConstant constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort bootstrapMethodAttrIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort nameAndTypeIndex) == false)
                return false;

            constant = new InvokeDynamicConstant(bootstrapMethodAttrIndex, new(nameAndTypeIndex));
            return true;
        }

        public readonly bool IsNil => !IsNotNil;

    }

}