// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace IKVM.ByteCode.Buffers
{

    public partial class BlobBuilder
    {

        public struct Chunks : IEnumerable<BlobBuilder>, IEnumerator<BlobBuilder>, IEnumerator
        {

            readonly BlobBuilder _head;
            BlobBuilder _next;
            BlobBuilder? _currentOpt;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="builder"></param>
            internal Chunks(BlobBuilder builder)
            {
                Debug.Assert(builder.IsHead);

                _head = builder;
                _next = builder.FirstChunk;
                _currentOpt = null;
            }

            object IEnumerator.Current => Current;

            /// <inheritdoc />
            public readonly BlobBuilder Current => _currentOpt!;

            /// <inheritdoc />
            public bool MoveNext()
            {
                if (_currentOpt == _head)
                {
                    return false;
                }

                if (_currentOpt == _head._nextOrPrevious)
                {
                    _currentOpt = _head;
                    return true;
                }

                _currentOpt = _next;
                _next = _next._nextOrPrevious;
                return true;
            }

            /// <inheritdoc />
            public void Reset()
            {
                _currentOpt = null;
                _next = _head.FirstChunk;
            }

            /// <inheritdoc />
            readonly void IDisposable.Dispose() { }

            /// <inheritdoc />
            public Chunks GetEnumerator() => this;

            /// <inheritdoc />
            IEnumerator<BlobBuilder> IEnumerable<BlobBuilder>.GetEnumerator() => GetEnumerator();

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        }

        public struct Blobs : IEnumerable<Blob>, IEnumerator<Blob>, IEnumerator
        {

            Chunks _chunks;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="builder"></param>
            internal Blobs(BlobBuilder builder)
            {
                _chunks = new Chunks(builder);
            }

            /// <inheritdoc />
            object IEnumerator.Current => Current;

            public Blob Current
            {
                get
                {
                    var current = _chunks.Current;
                    if (current != null)
                        return new Blob(current._buffer, 0, current.Length);
                    else
                        return default(Blob);
                }
            }

            /// <inheritdoc />
            public bool MoveNext() => _chunks.MoveNext();

            /// <inheritdoc />
            public void Reset() => _chunks.Reset();

            /// <inheritdoc />
            void IDisposable.Dispose() { }

            /// <inheritdoc />
            public Blobs GetEnumerator() => this;

            /// <inheritdoc />
            IEnumerator<Blob> IEnumerable<Blob>.GetEnumerator() => GetEnumerator();

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        }

    }

}