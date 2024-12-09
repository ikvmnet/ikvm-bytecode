using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct SourceFileAttribute(Utf8ConstantHandle SourceFile)
    {

        public static SourceFileAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out SourceFileAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort sourceFileIndex) == false)
                return false;

            attribute = new SourceFileAttribute(new Utf8ConstantHandle(sourceFileIndex));
            return true;
        }

        public readonly Utf8ConstantHandle SourceFile = SourceFile;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Copies this attribute to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            encoder.SourceFile(constantPool.Get(AttributeName.SourceFile), constantPool.Get(constantView.Get(SourceFile)));
        }

    }

}