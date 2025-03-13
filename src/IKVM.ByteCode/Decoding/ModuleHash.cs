using System.Buffers;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Describes a hash of a named module.
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Hash"></param>
    public readonly record struct ModuleHash(Utf8ConstantHandle Name, ReadOnlySequence<byte> Hash)
    {

        /// <summary>
        /// Attempts to measure the structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            size += ClassFormatReader.U2;
            if (reader.TryReadU2(out var length) == false)
                return false;

            size += length;
            if (reader.TryAdvance(length) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to read the structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, out ModuleHash hash)
        {
            hash = default;

            if (reader.TryReadU2(out ushort name) == false)
                return false;

            if (reader.TryReadU2(out ushort length) == false)
                return false;

            if (reader.TryReadMany(length, out var data) == false)
                return false;

            hash = new ModuleHash(new(name), data);
            return true;
        }

        /// <summary>
        /// Gets the name of the module to which this hash applies.
        /// </summary>
        public readonly Utf8ConstantHandle Name = Name;

        /// <summary>
        /// Gets the hash of the module.
        /// </summary>
        public readonly ReadOnlySequence<byte> Hash = Hash;

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
        /// Copes this info to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref ModuleHashTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.Hash(constantPool.Get(constantView.Get(Name)), Hash);
        }

    }

}
