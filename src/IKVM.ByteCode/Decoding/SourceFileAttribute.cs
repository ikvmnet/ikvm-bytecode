using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Decoded <c>SourceFile</c> attribute identifying the source file from which this class was compiled.
    /// </summary>
    /// <param name="SourceFile">Handle to the source file name constant.</param>
    public readonly record struct SourceFileAttribute(Utf8ConstantHandle SourceFile)
    {

        /// <summary>
        /// Gets the nil instance.
        /// </summary>
        public static SourceFileAttribute Nil => default;

        /// <summary>
        /// Attempts to read the attribute structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, out SourceFileAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort sourceFileIndex) == false)
                return false;

            attribute = new SourceFileAttribute(new Utf8ConstantHandle(sourceFileIndex));
            return true;
        }

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
        /// Gets the source file name.
        /// </summary>
        public readonly Utf8ConstantHandle SourceFile = SourceFile;

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