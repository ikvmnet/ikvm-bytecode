using System;
using System.Collections.Generic;

namespace IKVM.ByteCode.Buffers
{

    /// <summary>
    /// Represents a key in a dictionary associated with a blob.
    /// </summary>
    public readonly struct ReadOnlyByteMemoryEqualityComparer : IEqualityComparer<ReadOnlyMemory<byte>>
    {

        public bool Equals(ReadOnlyMemory<byte> x, ReadOnlyMemory<byte> y)
        {
            return x.Equals(y) || x.Span.SequenceEqual(y.Span);
        }

        public int GetHashCode(ReadOnlyMemory<byte> obj)
        {
            return BlobHash.GetFNVHashCode(obj.Span);
        }

    }

}
