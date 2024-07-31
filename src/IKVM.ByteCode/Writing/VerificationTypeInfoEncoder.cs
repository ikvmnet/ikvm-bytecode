using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes a 'verification_type_info' structure.
    /// </summary>
    public struct VerificationTypeInfoEncoder
    {

        readonly BlobBuilder _builder;
        readonly ushort _fixedCount;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public VerificationTypeInfoEncoder(BlobBuilder builder, ushort fixedCount = 0)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _fixedCount = fixedCount;

            if (_fixedCount > 0)
            {
                _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
                _count = 0;
            }
        }

        /// <summary>
        /// Increments the count if required.
        /// </summary>
        void IncrementCount()
        {
            if (_fixedCount > 0)
                new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
        }

        public VerificationTypeInfoEncoder Top()
        {
            if (_fixedCount > 0 && _count >= _fixedCount)
                throw new InvalidOperationException($"Only {_fixedCount} verification type info records can be inserted.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(0);
            IncrementCount();
            return this;
        }

        public VerificationTypeInfoEncoder Integer()
        {
            if (_fixedCount > 0 && _count >= _fixedCount)
                throw new InvalidOperationException($"Only {_fixedCount} verification type info records can be inserted.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(1);
            IncrementCount();
            return this;
        }

        public VerificationTypeInfoEncoder Float()
        {
            if (_fixedCount > 0 && _count >= _fixedCount)
                throw new InvalidOperationException($"Only {_fixedCount} verification type info records can be inserted.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(2);
            IncrementCount();
            return this;
        }

        public VerificationTypeInfoEncoder Double()
        {
            if (_fixedCount > 0 && _count >= _fixedCount)
                throw new InvalidOperationException($"Only {_fixedCount} verification type info records can be inserted.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(3);
            IncrementCount();
            return this;
        }

        public VerificationTypeInfoEncoder Long()
        {
            if (_fixedCount > 0 && _count >= _fixedCount)
                throw new InvalidOperationException($"Only {_fixedCount} verification type info records can be inserted.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(4);
            IncrementCount();
            return this;
        }

        public VerificationTypeInfoEncoder Null()
        {
            if (_fixedCount > 0 && _count >= _fixedCount)
                throw new InvalidOperationException($"Only {_fixedCount} verification type info records can be inserted.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(5);
            IncrementCount();
            return this;
        }

        public VerificationTypeInfoEncoder UninitializedThis()
        {
            if (_fixedCount > 0 && _count >= _fixedCount)
                throw new InvalidOperationException($"Only {_fixedCount} verification type info records can be inserted.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.TryWriteU1(6);
            IncrementCount();
            return this;
        }

        public VerificationTypeInfoEncoder Object(ClassConstantHandle clazz)
        {
            if (_fixedCount > 0 && _count >= _fixedCount)
                throw new InvalidOperationException($"Only {_fixedCount} verification type info records can be inserted.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1(7);
            w.TryWriteU2(clazz.Index);
            IncrementCount();
            return this;
        }

        public VerificationTypeInfoEncoder Uninitialized(ushort offset)
        {
            if (_fixedCount > 0 && _count >= _fixedCount)
                throw new InvalidOperationException($"Only {_fixedCount} verification type info records can be inserted.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1(8);
            w.TryWriteU2(offset);
            IncrementCount();
            return this;
        }

    }

}
