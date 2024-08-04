using System;
using System.Buffers.Binary;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes multiple table switch arguments.
    /// </summary>
    public class TableSwitchInstructionEncoder
    {

        readonly InstructionEncoder _encoder;
        readonly ushort _offset;
        readonly int _low;
        readonly Blob _highBlob;
        int _high;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="encoder"></param>
        /// <param name="defaultLabel"></param>
        /// <param name="low"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public TableSwitchInstructionEncoder(InstructionEncoder encoder, LabelHandle defaultLabel, int low)
        {
            _encoder = encoder ?? throw new ArgumentNullException(nameof(encoder));

            // header of table switch is instruction, alignment, then default
            _offset = _encoder.Offset;
            _encoder.OpCode(OpCode._tableswitch);
            _encoder.Align(4);
            _encoder.Label(defaultLabel, 4, _offset);

            // write low value
            _low = low;
            encoder.WriteInt32(_low);

            // reserve space for high value and start at low
            _high = _low - 1;
            _highBlob = _encoder.ReserveBytes(4);
            BinaryPrimitives.WriteInt32BigEndian(_highBlob.GetBytes(), _high);
        }

        /// <summary>
        /// Adds a new case to the table switch.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public TableSwitchInstructionEncoder Case(LabelHandle label)
        {
            _encoder.Label(label, 4, _offset);
            BinaryPrimitives.WriteInt32BigEndian(_highBlob.GetBytes(), ++_high);
            return this;
        }

        /// <summary>
        /// Validates whether we have written correct values.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void Validate()
        {
            if (_high < _low)
                throw new InvalidOperationException("TableSwitch requires at least one item.");
        }

    }

}
