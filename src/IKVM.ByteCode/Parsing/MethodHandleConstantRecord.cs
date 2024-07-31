namespace IKVM.ByteCode.Parsing
{

    public sealed record MethodHandleConstantRecord(ReferenceKind Kind, RefConstantHandle Reference) : ConstantRecord
    {

        /// <summary>
        /// Parses a MethodHandle constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        /// <param name="skip"></param>
        public static bool TryReadMethodHandleConstant(ref ClassFormatReader reader, out ConstantRecord constant, out int skip)
        {
            constant = null;
            skip = 0;

            if (reader.TryReadU1(out byte referenceKind) == false)
                return false;
            if (reader.TryReadU2(out ushort referenceIndex) == false)
                return false;

            constant = new MethodHandleConstantRecord((ReferenceKind)referenceKind, new(referenceIndex));
            return true;
        }

    }

}
