using System;
using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly partial struct Attribute
    {

        public static Attribute Nil => default;

        /// <summary>
        /// Parses an attribute.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="attribute"></param>
        public static bool TryRead(ref ClassFormatReader reader, out Attribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort nameIndex) == false)
                return false;
            if (reader.TryReadU4(out uint length) == false)
                return false;
            if (reader.TryReadMany(length, out var data) == false)
                return false;

            attribute = new Attribute(new(nameIndex), data);
            return true;
        }

        readonly Utf8ConstantHandle _name;
        readonly ReadOnlySequence<byte> _data;
        readonly bool _isNotNil = false;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public Attribute(Utf8ConstantHandle name, ReadOnlySequence<byte> data)
        {
            _name = name;
            _data = data;
        }

        /// <summary>
        /// Gets the name of the attribute.
        /// </summary>
        public Utf8ConstantHandle Name => _name;

        /// <summary>
        /// Gets the backing data of the attribute.
        /// </summary>
        public ReadOnlySequence<byte> Data => _data;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
