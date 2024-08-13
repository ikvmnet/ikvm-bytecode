using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct LookupSwitchMatch(int Match, int Target)
    {

        /// <summary>
        /// Attempts to read the structure.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool TryRead(ref SequenceReader<byte> reader, out LookupSwitchMatch item)
        {
            item = default;

            if (reader.TryReadBigEndian(out int match) == false)
                return false;

            if (reader.TryReadBigEndian(out int target) == false)
                return false;

            item = new LookupSwitchMatch(match, target);
            return true;
        }

        /// <summary>
        /// Gets the value to match.
        /// </summary>
        public readonly int Match = Match;

        /// <summary>
        /// Gets the offset target.
        /// </summary>
        public readonly int Target = Target;

    }

}