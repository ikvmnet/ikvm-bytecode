using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Provides the capability to write a set of attributes.
    /// </summary>
    public class AttributeBuilder
    {

        readonly BlobBuilder _builder = new();
        ushort _count = 0;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AttributeBuilder()
        {

        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void AddAttribute(Utf8ConstantHandle name, BlobBuilder data)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(name.Value);
            w.TryWriteU2((ushort)data.Count);
            _builder.LinkSuffix(data);
        }

        /// <summary>
        /// Serializes the attributes to the specified builder.
        /// </summary>
        /// <param name="builder"></param>
        public void Serialize(BlobBuilder builder)
        {
            var w = new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U2 + builder.Count).GetBytes());
            w.TryWriteU2(_count);
            builder.LinkSuffix(_builder);
        }

    }

}
