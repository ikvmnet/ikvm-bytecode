﻿using System.Security.Claims;

namespace IKVM.ByteCode.Parsing
{

    public readonly record struct FieldRecord(AccessFlag AccessFlags, Utf8ConstantHandle Name, Utf8ConstantHandle Descriptor, AttributeInfoRecord[] Attributes)
    {

        /// <summary>
        /// Parses a field.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="field"></param>
        public static bool TryRead(ref ClassFormatReader reader, out FieldRecord field)
        {
            field = default;

            if (reader.TryReadU2(out ushort accessFlags) == false)
                return false;
            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort descriptorIndex) == false)
                return false;
            if (ClassRecord.TryReadAttributes(ref reader, out var attributes) == false)
                return false;

            field = new FieldRecord((AccessFlag)accessFlags, new(nameIndex), new(descriptorIndex), attributes);
            return true;
        }

    }

}
