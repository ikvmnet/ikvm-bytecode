using System;

namespace IKVM.ByteCode.Buffers
{

    /// <summary>
    /// Represents a single blob.
    /// </summary>
    /// <param name="Buffer"></param>
    /// <param name="Offset"></param>
    /// <param name="Length"></param>
    public readonly record struct Blob(byte[] Buffer, int Offset, int Length)
    {

        /// <summary>
        /// Returns <c>true</c> if this is a default instance.
        /// </summary>
        public readonly bool IsDefault => Buffer == null;

        /// <summary>
        /// Gets the underlying array segment.
        /// </summary>
        /// <returns></returns>
        public readonly ArraySegment<byte> GetBytes() => new(Buffer, Offset, Length);

        /// <inheritdoc />
        public readonly override int GetHashCode() => BlobHash.GetFNVHashCode(GetBytes());

    }

}
