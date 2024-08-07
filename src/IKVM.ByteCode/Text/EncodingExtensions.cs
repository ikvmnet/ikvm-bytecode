﻿using System;
using System.Text;

namespace IKVM.ByteCode.Text
{

    static class EncodingExtensions
    {

#if NETFRAMEWORK

        public static unsafe string GetString(this Encoding self, ReadOnlySpan<byte> bytes)
        {
            if (self is null)
                throw new ArgumentNullException(nameof(self));

            if (bytes.IsEmpty)
                return string.Empty;

            fixed (byte* bytesPtr = bytes)
                return self.GetString(bytesPtr, bytes.Length);
        }

#endif

    }

}
