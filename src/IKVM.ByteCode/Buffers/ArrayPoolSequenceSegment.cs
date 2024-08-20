using System;
using System.Buffers;

namespace IKVM.ByteCode.Buffers
{

    /// <summary>
    /// Implementation of <see cref="ReadOnlySequenceSegment{T}"/> that holds a segment of an array rented from a <see cref="ArrayPool{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ArrayPoolSequenceSegment<T> : ReadOnlySequenceSegment<T>, IMemoryOwner<T>
    {

        readonly ArraySegment<T> _array;
        readonly ArrayPool<T> _pool;

        /// <summary>
        /// Gets the array segment referenced from this <see cref="ReadOnlySequenceSegment{T}"/>.
        /// </summary>
        internal ArraySegment<T> Array => _array;

        /// <summary>
        /// Gets the pool that owns the segment.
        /// </summary>
        internal ArrayPool<T> Pool => _pool;

        /// <summary>
        /// Gets the <see cref="Memory{T}" /> value for the current node.
        /// </summary>
        public new Memory<T> Memory => _array.AsMemory();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="pool"></param>
        public ArrayPoolSequenceSegment(ArraySegment<T> array, ArrayPool<T> pool)
        {
            _array = array;
            _pool = pool ?? throw new ArgumentNullException(nameof(pool));

            base.Memory = array.AsMemory();
        }

        /// <summary>
        /// Appends a memory segment.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="pool"></param>
        /// <returns></returns>
        public ArrayPoolSequenceSegment<T> Append(ArraySegment<T> array, ArrayPool<T> pool)
        {
            var segment = new ArrayPoolSequenceSegment<T>(array, pool)
            {
                RunningIndex = RunningIndex + Memory.Length
            };

            Next = segment;
            return segment;
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            // instruct the next segment to dispose
            if (Next is IMemoryOwner<T> next)
                next.Dispose();

            // return this array
            if (_array.Array is not null)
                _pool.Return(_array.Array);
        }

    }

}
