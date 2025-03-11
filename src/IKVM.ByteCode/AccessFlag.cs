using System;

namespace IKVM.ByteCode
{

    [Flags]
    public enum AccessFlag : ushort
    {

        /// <summary>
        /// The access flag ACC_PUBLIC, corresponding to the source modifier public, with a mask value of 0x0001.
        /// </summary>
        Public = 0x0001,

        /// <summary>
        /// The access flag ACC_FINAL, corresponding to the source modifier final, with a mask value of 0x0010.
        /// </summary>
        Final = 0x0010,

        /// <summary>
        /// The access flag ACC_SUPER with a mask value of 0x0020.
        /// </summary>
        /// <remarks>
        /// In Java SE 8 and above, the JVM treats the ACC_SUPER flag as set in every class file (JVMS 4.1).
        /// </remarks>
        Super = 0x0020,

        /// <summary>
        /// The access flag ACC_INTERFACE with a mask value of 0x0200.
        /// </summary>
        Interface = 0x0200,

        /// <summary>
        /// The access flag ACC_ABSTRACT, corresponding to the source modifier abstract, with a mask value of 0x0400.
        /// </summary>
        Abstract = 0x0400,

        /// <summary>
        /// The access flag ACC_SYNTHETIC with a mask value of 0x1000.
        /// </summary>
        Synthetic = 0x1000,

        /// <summary>
        /// The access flag ACC_ANNOTATION with a mask value of 0x2000.
        /// </summary>
        Annotation = 0x2000,

        /// <summary>
        /// The access flag ACC_ENUM with a mask value of 0x4000.
        /// </summary>
        Enum = 0x4000,

        /// <summary>
        /// The access flag ACC_MODULE with a mask value of 0x8000.
        /// </summary>
        Module = 0x8000,

        /// <summary>
        /// The access flag ACC_BRIDGE with a mask value of 0x0040.
        /// </summary>
        Bridge = 0x0040,

        /// <summary>
        /// The access flag ACC_MANDATED with a mask value of 0x8000.
        /// </summary>
        Mandated = 0x8000,

        /// <summary>
        /// The access flag ACC_NATIVE, corresponding to the source modifier native, with a mask value of 0x0100.
        /// </summary>
        Native = 0x0100,

        /// <summary>
        /// The module flag ACC_OPEN with a mask value of 0x0020.
        /// </summary>
        Open = 0x0020,

        /// <summary>
        /// The access flag ACC_PRIVATE, corresponding to the source modifier private, with a mask value of 0x0002.
        /// </summary>
        Private = 0x0002,

        /// <summary>
        /// The access flag ACC_PROTECTED, corresponding to the source modifier protected, with a mask value of 0x0004.
        /// </summary>
        Protected = 0x0004,

        /// <summary>
        /// The access flag ACC_STATIC, corresponding to the source modifier static, with a mask value of 0x0008.
        /// </summary>
        Static = 0x0008,

        /// <summary>
        /// The module requires flag ACC_STATIC_PHASE with a mask value of 0x0040.
        /// </summary>
        StaticPhase = 0x0040,

        /// <summary>
        /// The access flag ACC_STRICT, corresponding to the source modifier strictfp, with a mask value of 0x0800.
        /// </summary>
        Strict = 0x0800,

        /// <summary>
        /// The access flag ACC_SYNCHRONIZED, corresponding to the source modifier synchronized, with a mask value of 0x0020.
        /// </summary>
        Synchronized = 0x0020,

        /// <summary>
        /// The access flag ACC_TRANSIENT, corresponding to the source modifier transient, with a mask value of 0x0080.
        /// </summary>
        Transient = 0x0080,

        /// <summary>
        /// The module requires flag ACC_TRANSITIVE with a mask value of 0x0020.
        /// </summary>
        Transitive = 0x0020,

        /// <summary>
        /// The access flag ACC_VARARGS with a mask value of 0x0080.
        /// </summary>
        VarArgs = 0x0080,

        /// <summary>
        /// The access flag ACC_VOLATILE, corresponding to the source modifier volatile, with a mask value of 0x0040.
        /// </summary>
        Volatile = 0x0040

    }


}
