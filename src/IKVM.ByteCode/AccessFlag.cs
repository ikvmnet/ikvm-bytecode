using System;

namespace IKVM.ByteCode
{

    [Flags]
    public enum AccessFlag : ushort
    {

        Public = 0x0001,
        Final = 0x0010,
        Super = 0x0020,
        Interface = 0x0200,
        Abstract = 0x0400,
        Synthetic = 0x1000,
        Annotation = 0x2000,
        Enum = 0x4000,
        Module = 0x8000,

    }


}
