using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct MethodHandleConstantData(MethodHandleKind Kind, RefConstantHandle Reference)
    {

        /// <summary>
        /// Parses a MethodHandle constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        /// <param name="skip"></param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            skip = 0;

            if (reader.TryReadMany(ClassFormatReader.U1 + ClassFormatReader.U2, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a MethodHandle constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        public static bool TryRead(ref ClassFormatReader reader, out MethodHandleConstantData constant)
        {
            constant = default;

            if (reader.TryReadU1(out byte referenceKind) == false)
                return false;
            if (reader.TryReadU2(out ushort referenceIndex) == false)
                return false;

            constant = new MethodHandleConstantData((MethodHandleKind)referenceKind, new(ConstantKind.Unknown, referenceIndex));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
