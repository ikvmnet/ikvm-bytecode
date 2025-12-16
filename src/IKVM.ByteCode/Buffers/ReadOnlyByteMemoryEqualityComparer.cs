using System;
using System.Collections.Generic;

namespace IKVM.ByteCode.Buffers
{

    /// <summary>
    /// Represents a key in a dictionary associated with a blob.
    /// </summary>
    readonly struct ReadOnlyByteMemoryEqualityComparer : IEqualityComparer<ReadOnlyMemory<byte>>
    {

        /// <inheritdoc />
        public bool Equals(ReadOnlyMemory<byte> x, ReadOnlyMemory<byte> y)
        {
            return x.Equals(y) || x.Span.SequenceEqual(y.Span);
        }

        /// <inheritdoc />
        public int GetHashCode(ReadOnlyMemory<byte> obj)
        {
            return BlobHash.GetFNVHashCode(obj.Span);
        }

    }

}
