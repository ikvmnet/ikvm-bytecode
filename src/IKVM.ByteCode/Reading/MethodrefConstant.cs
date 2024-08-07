﻿using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct MethodrefConstant(ClassConstantHandle Class, NameAndTypeConstantHandle NameAndType)
    {

        /// <summary>
        /// Parses a Methodref constant in the constant pool.
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
        /// Parses a Methodref constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryRead(ref ClassFormatReader reader, out MethodrefConstant constant)
        {
            constant = default;

            if (reader.TryReadU2(out ushort classIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort nameAndTypeIndex) == false)
                return false;

            constant = new MethodrefConstant(new(classIndex), new(nameAndTypeIndex));
            return true;
        }

    }

}