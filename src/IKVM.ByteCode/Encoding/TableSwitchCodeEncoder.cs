using System;
using System.Buffers.Binary;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Encoding
{

    /// <summary>
    /// Encodes multiple table switch arguments.
    /// </summary>
    public struct TableSwitchCodeEncoder
    {

        readonly CodeBuilder _code;
        readonly ushort _offset;
        readonly int _low;
        readonly Blob _highBlob;
        int _high;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="defaultLabel"></param>
        /// <param name="low"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public TableSwitchCodeEncoder(CodeBuilder code, LabelHandle defaultLabel, int low)
        {
            _code = code ?? throw new ArgumentNullException(nameof(code));

            // header of table switch is instruction, alignment, then default
            _offset = _code.Offset;
            _code.OpCode(OpCode.TableSwitch);
            _code.Align(4);
            _code.Label(defaultLabel, true, _offset);

            // write low value
            _low = low;
            code.WriteInt32(_low);

            // reserve space for high value and start at low
            _high = _low - 1;
            _highBlob = _code.ReserveBytes(4);
            BinaryPrimitives.WriteInt32BigEndian(_highBlob.GetBytes(), _high);
        }

        /// <summary>
        /// Adds a new case to the table switch.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public TableSwitchCodeEncoder Case(LabelHandle label)
        {
            _code.Label(label, true, _offset);
            BinaryPrimitives.WriteInt32BigEndian(_highBlob.GetBytes(), ++_high);
            return this;
        }

    }

}
