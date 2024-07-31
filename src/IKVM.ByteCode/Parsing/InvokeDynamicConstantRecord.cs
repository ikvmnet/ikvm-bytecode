﻿namespace IKVM.ByteCode.Parsing
{

    public sealed record InvokeDynamicConstantRecord(ushort BootstrapMethodAttributeIndex, NameAndTypeConstantHandle NameAndType) : ConstantRecord
    {

        /// <summary>
        /// Parses a InvokeDynamic constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryReadInvokeDynamicConstant(ref ClassFormatReader reader, out ConstantRecord constant, out int skip)
        {
            constant = null;
            skip = 0;

            if (reader.TryReadU2(out ushort bootstrapMethodAttrIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort nameAndTypeIndex) == false)
                return false;

            constant = new InvokeDynamicConstantRecord(bootstrapMethodAttrIndex, new(nameAndTypeIndex));
            return true;
        }

    }

}