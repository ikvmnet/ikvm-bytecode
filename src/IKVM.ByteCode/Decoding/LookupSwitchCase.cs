using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    /// <summary>
    /// Represents a single case entry in a <c>lookupswitch</c> instruction.
    /// </summary>
    /// <param name="Key">The integer match value for this case.</param>
    /// <param name="Target">The signed branch offset for this case.</param>
    public readonly record struct LookupSwitchCase(int Key, int Target)
    {

        /// <summary>
        /// Attempts to read the structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        internal static bool TryRead(ref SequenceReader<byte> reader, out LookupSwitchCase item)
        {
            item = default;

            if (reader.TryReadBigEndian(out int key) == false)
                return false;

            if (reader.TryReadBigEndian(out int target) == false)
                return false;

            item = new LookupSwitchCase(key, target);
            return true;
        }

        /// <summary>
        /// Gets the key to match.
        /// </summary>
        public readonly int Key = Key;

        /// <summary>
        /// Gets the offset target.
        /// </summary>
        public readonly int Target = Target;

    }

}