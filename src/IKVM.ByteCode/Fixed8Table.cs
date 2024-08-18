using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Implements a table where the first 8 items do not require an array to be allocated.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal struct Fixed8Table<T>
        where T : struct
    {

#if NET8_0_OR_GREATER

        [System.Runtime.CompilerServices.InlineArray(8)]
        struct InlineArray
        {

            public T _item0;

        }

        InlineArray _item0;

#else

        T _item1 = default;
        T _item2 = default;
        T _item3 = default;
        T _item4 = default;
        T _item5 = default;
        T _item6 = default;
        T _item7 = default;
        T _item8 = default;

#endif

        T[] _items = [];
        int _count = 0;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Fixed8Table()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Fixed8Table(int allocate)
        {
            if (allocate > 8)
                _items = new T[allocate - 8];
        }

        /// <summary>
        /// Gets the number of items in the table.
        /// </summary>
        public readonly int Count => _count;

        /// <summary>
        /// Adds a new item to the table.
        /// </summary>
        /// <param name="item"></param>
        public void Add(in T item)
        {
            var count = Count;

#if NET8_0_OR_GREATER

            if (count < 8)
            {
                _item0[_count++] = item;
                return;
            }

#else

            if (count == 0)
            {
                _count = 1;
                _item1 = item;
                return;
            }

            if (count == 1)
            {
                _count = 2;
                _item2 = item;
                return;
            }

            if (count == 2)
            {
                _count = 3;
                _item3 = item;
                return;
            }

            if (count == 3)
            {
                _count = 4;
                _item4 = item;
                return;
            }

            if (count == 4)
            {
                _count = 5;
                _item5 = item;
                return;
            }

            if (count == 5)
            {
                _count = 6;
                _item6 = item;
                return;
            }

            if (count == 6)
            {
                _count = 7;
                _item7 = item;
                return;
            }

            if (count == 7)
            {
                _count = 8;
                _item8 = item;
                return;
            }

#endif

            _count++;
            if (_count > _items.Length - 8)
                Array.Resize(ref _items, _items.Length + 8);

            _items[count - 8] = item;
        }

        /// <summary>
        /// Gets the item at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index] => GetItem(ref this, index);

        /// <summary>
        /// Gets the item at the specified index.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static ref T GetItem(ref Fixed8Table<T> table, int index)
        {
            if (index >= table.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

#if NET8_0_OR_GREATER

            if (index < 8)
                return ref table._item0[index];

#else

            if (index == 0)
                return ref table._item1;
            if (index == 1)
                return ref table._item2;
            if (index == 2)
                return ref table._item3;
            if (index == 3)
                return ref table._item4;
            if (index == 4)
                return ref table._item5;
            if (index == 5)
                return ref table._item6;
            if (index == 6)
                return ref table._item7;
            if (index == 7)
                return ref table._item8;

#endif

            return ref table._items[index - 8];
        }

        /// <summary>
        /// Clears the table.
        /// </summary>
        public void Clear()
        {
            _count = 0;
            _items = [];
        }

    }

}
