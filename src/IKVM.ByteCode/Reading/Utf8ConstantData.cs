using System;
using System.Buffers;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct Utf8ConstantData(string Value)
    {

        /// <summary>
        /// Parses a UTF8 constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        public static bool TryReadData(ref ClassFormatReader reader, out ReadOnlySequence<byte> data, out int skip)
        {
            data = default;
            skip = 0;

            // read length
            if (reader.TryReadU2(out ushort length) == false)
                return false;

            // rewind back to length to read entire UTF8 constant data
            reader.Rewind(ClassFormatReader.U2);
            if (reader.TryReadMany(ClassFormatReader.U2 + length, out data) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Parses a UTF8 constant in the constant pool.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        /// <param name="majorVersion"></param>
        public static bool TryRead(ref ClassFormatReader reader, out Utf8ConstantData constant, int majorVersion)
        {
            constant = default;

            if (reader.TryReadU2(out var length) == false)
                return false;
            if (reader.TryReadMany(length, out var value) == false)
                return false;

            constant = new Utf8ConstantData(Decode(value, majorVersion));
            return true;
        }

        /// <summary>
        /// Decodes the UTF8 constant into a string value according the major version.
        /// </summary>
        /// <param name="majorVersion"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        static string Decode(ReadOnlySequence<byte> data, int majorVersion)
        {
            var encoding = MUTF8Encoding.GetMUTF8(majorVersion);
            if (encoding == null)
                throw new InvalidOperationException($"Could not retrieve MUTF8 encoding for major version {majorVersion}.");

            if (data.IsSingleSegment)
                return encoding.GetString(data.First.Span);
            else
            {
                int l = checked((int)data.Length);
                var o = ArrayPool<byte>.Shared.Rent(l);
                try
                {
                    data.CopyTo(o);
                    return encoding.GetString(o, 0, l);
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(o);
                }
            }
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
