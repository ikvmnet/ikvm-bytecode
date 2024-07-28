using System;

namespace IKVM.ByteCode.Buffers
{

    /// <summary>
    /// Provides hash related functions.
    /// </summary>
    static class BlobHash
    {

        /// <summary>
        /// The offset bias value used in the FNV-1a algorithm
        /// See http://en.wikipedia.org/wiki/Fowler%E2%80%93Noll%E2%80%93Vo_hash_function
        /// </summary>
        const int FnvOffsetBias = unchecked((int)2166136261);

        /// <summary>
        /// The generative factor used in the FNV-1a algorithm
        /// See http://en.wikipedia.org/wiki/Fowler%E2%80%93Noll%E2%80%93Vo_hash_function
        /// </summary>
        const int FnvPrime = 16777619;

        /// <summary>
        /// Compute the FNV-1a hash of a sequence of bytes
        /// See http://en.wikipedia.org/wiki/Fowler%E2%80%93Noll%E2%80%93Vo_hash_function
        /// </summary>
        /// <param name="data">The sequence of bytes</param>
        /// <returns>The FNV-1a hash of <paramref name="data"/></returns>
        public static int GetFNVHashCode(ReadOnlySpan<byte> data)
        {
            int hashCode = FnvOffsetBias;

            for (int i = 0; i < data.Length; i++)
                hashCode = unchecked((hashCode ^ data[i]) * FnvPrime);

            return hashCode;
        }

    }

}
