using System;

namespace IKVM.ByteCode.Buffers
{

    /// <summary>
    /// Represents a range within a <see cref="BlobBuilder"/>.
    /// </summary>
    public readonly record struct Blob(byte[] Buffer, int Start, int Length)
    {

        public bool IsDefault => Buffer == null;

        public ArraySegment<byte> GetBytes() => new ArraySegment<byte>(Buffer, Start, Length);

    }

}
