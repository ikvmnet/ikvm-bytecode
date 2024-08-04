using System;
using System.Buffers.Binary;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes a lookupswitch instruction.
    /// </summary>
    public struct LookupSwitchInstructionEncoder
    {

        readonly InstructionEncoder _encoder;
        readonly ushort _offset;
        readonly Blob _npairsBlob;
        int _npairs;
        long _lastKey = long.MinValue;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="encoder"></param>
        /// <param name="defaultLabel"></param>
        /// <param name="low"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public LookupSwitchInstructionEncoder(InstructionEncoder encoder, LabelHandle defaultLabel)
        {
            _encoder = encoder ?? throw new ArgumentNullException(nameof(encoder));

            // header of table switch is instruction, alignment, then default
            _offset = _encoder.Offset;
            _encoder.OpCode(OpCode._lookupswitch);
            _encoder.Align(4);
            _encoder.Label(defaultLabel, 4, _offset);

            // reserve space for high value and start at low
            _npairs = 0;
            _npairsBlob = encoder.ReserveBytes(4);
            BinaryPrimitives.WriteInt32BigEndian(_npairsBlob.GetBytes(), _npairs);
        }

        /// <summary>
        /// Adds a new case to the lookup switch.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public LookupSwitchInstructionEncoder Case(int key, LabelHandle label)
        {
            if (key < _lastKey)
                throw new ArgumentOutOfRangeException("Key must be greater than previos key.", nameof(key));

            _lastKey = key;
            _encoder.WriteInt32(key);
            _encoder.Label(label, 4, _offset);
            BinaryPrimitives.WriteInt32BigEndian(_npairsBlob.GetBytes(), ++_npairs);
            return this;
        }

    }

}
