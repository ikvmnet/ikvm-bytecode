using System.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public readonly struct CodeDecoder
    {

        readonly ReadOnlySequence<byte> data;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="data"></param>
        public CodeDecoder(ReadOnlySequence<byte> data)
        {
            this.data = data;
        }

    }

}
