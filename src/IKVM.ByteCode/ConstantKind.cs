namespace IKVM.ByteCode
{

    /// <summary>
    /// Identifies the type of a constant pool entry as defined in JVMS §4.4.
    /// </summary>
    public enum ConstantKind : byte
    {

        /// <summary>An unknown or unrecognised constant pool tag.</summary>
        Unknown = 0,
        /// <summary>A <c>CONSTANT_Utf8_info</c> entry (tag 1).</summary>
        Utf8 = 1,
        /// <summary>A <c>CONSTANT_Integer_info</c> entry (tag 3).</summary>
        Integer = 3,
        /// <summary>A <c>CONSTANT_Float_info</c> entry (tag 4).</summary>
        Float = 4,
        /// <summary>A <c>CONSTANT_Long_info</c> entry (tag 5).</summary>
        Long = 5,
        /// <summary>A <c>CONSTANT_Double_info</c> entry (tag 6).</summary>
        Double = 6,
        /// <summary>A <c>CONSTANT_Class_info</c> entry (tag 7).</summary>
        Class = 7,
        /// <summary>A <c>CONSTANT_String_info</c> entry (tag 8).</summary>
        String = 8,
        /// <summary>A <c>CONSTANT_Fieldref_info</c> entry (tag 9).</summary>
        Fieldref = 9,
        /// <summary>A <c>CONSTANT_Methodref_info</c> entry (tag 10).</summary>
        Methodref = 10,
        /// <summary>A <c>CONSTANT_InterfaceMethodref_info</c> entry (tag 11).</summary>
        InterfaceMethodref = 11,
        /// <summary>A <c>CONSTANT_NameAndType_info</c> entry (tag 12).</summary>
        NameAndType = 12,
        /// <summary>A <c>CONSTANT_MethodHandle_info</c> entry (tag 15).</summary>
        MethodHandle = 15,
        /// <summary>A <c>CONSTANT_MethodType_info</c> entry (tag 16).</summary>
        MethodType = 16,
        /// <summary>A <c>CONSTANT_Dynamic_info</c> entry (tag 17).</summary>
        Dynamic = 17,
        /// <summary>A <c>CONSTANT_InvokeDynamic_info</c> entry (tag 18).</summary>
        InvokeDynamic = 18,
        /// <summary>A <c>CONSTANT_Module_info</c> entry (tag 19).</summary>
        Module = 19,
        /// <summary>A <c>CONSTANT_Package_info</c> entry (tag 20).</summary>
        Package = 20,

    }

}
