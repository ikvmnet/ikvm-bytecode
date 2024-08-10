using System;
using System.Buffers.Binary;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes instructions.
    /// </summary>
    public class InstructionEncoder
    {

        /// <summary>
        /// Describes a label fixup to be applied.
        /// </summary>
        /// <param name="Region"></param>
        /// <param name="Offset"></param>
        readonly record struct FixupData(Blob Region, ushort Offset);

        /// <summary>
        /// Describes a recorded label and optionally it's absolute value.
        /// </summary>
        /// <param name="Blob"></param>
        /// <param name="LabelOffset"></param>
        /// <param name="RelativeOffset"></param>
        struct LabelInfo
        {

            public readonly int Id;
            public int Value;
            public FixupData Fixup1;
            public FixupData Fixup2;
            public FixupData[] Fixups = [];
            public int FixupCount;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="id"></param>
            public LabelInfo(int id)
            {
                Id = id;
                Value = -1;
            }

            /// <summary>
            /// Adds a new fixup.
            /// </summary>
            /// <param name="data"></param>
            public void AddFixup(in FixupData data)
            {
                var index = FixupCount;

                if (index == 0)
                {
                    FixupCount = 1;
                    Fixup1 = data;
                    return;
                }

                if (index == 1)
                {
                    FixupCount = 2;
                    Fixup2 = data;
                    return;
                }

                FixupCount++;
                if (FixupCount > Fixups.Length - 2)
                    Array.Resize(ref Fixups, Fixups.Length + 8);

                Fixups[index - 2] = data;
            }

            /// <summary>
            /// Gets the fixup at the specified index.
            /// </summary>
            /// <param name="info"></param>
            /// <param name="index"></param>
            /// <returns></returns>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static ref FixupData GetFixup(ref LabelInfo info, int index)
            {
                if (index >= info.FixupCount)
                    throw new ArgumentOutOfRangeException(nameof(index));

                switch (index)
                {
                    case 0: return ref info.Fixup1;
                    case 1: return ref info.Fixup2;
                    default: return ref info.Fixups[index - 2];
                }
            }

        }

        readonly BlobBuilder _builder;
        LabelInfo[] _labels = Array.Empty<LabelInfo>();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public InstructionEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));

            // JVM limits code size to 65535
            if (_builder.Count >= 65535)
                throw new InvalidOperationException("Maximum size of code buffer (65535) reached.");
        }

        /// <summary>
        /// Gets the offset of the next instruction inserted.
        /// </summary>
        public ushort Offset => checked((ushort)_builder.Count);

        /// <summary>
        /// Reserves the specified number of bytes in the builder.
        /// </summary>
        /// <param name="byteCount"></param>
        /// <returns></returns>
        internal Blob ReserveBytes(ushort byteCount)
        {
            if (_builder.Count + byteCount > ushort.MaxValue)
                throw new InvalidOperationException("Maximum size of code buffer (65535) reached.");

            return _builder.ReserveBytes(byteCount);
        }

        /// <summary>
        /// Defines a label that can later be used to mark and refer to a location in the instruction stream.
        /// </summary>
        /// <returns>Label handle.</returns>
        public LabelHandle DefineLabel()
        {
            var h = new LabelHandle(_labels.Length);
            if (h.Id >= _labels.Length)
                Array.Resize(ref _labels, _labels.Length + 8);
            _labels[h.Id] = new LabelInfo(h.Id);
            return h;
        }

        /// <summary>
        /// Defines a label that can later be used to mark and refer to a location in the instruction stream.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public InstructionEncoder DefineLabel(out LabelHandle label)
        {
            label = DefineLabel();
            return this;
        }

        /// <summary>
        /// Associates specified label with the current bytecode positon, returning the program offset of the label.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="offset"></param>
        public InstructionEncoder MarkLabel(LabelHandle label, out int offset)
        {
            ref var l = ref _labels[label.Id];
            if (l.Value != -1)
                throw new InvalidOperationException($"Label {label.Id} has already been marked.");

            // apply new value to label
            offset = Offset;
            l.Value = offset;

            // apply any outstanding fixups for the label
            for (int index = 0; index < l.FixupCount; index++)
                ApplyFixup(ref l, ref LabelInfo.GetFixup(ref l, index));

            // reset label fixups
            l.FixupCount = 0;
            l.Fixups = [];

            return this;
        }

        /// <summary>
        /// Associates specified label with the current bytecode positon.
        /// </summary>
        /// <param name="label"></param>
        public InstructionEncoder MarkLabel(LabelHandle label)
        {
            return MarkLabel(label, out _);
        }

        /// <summary>
        /// Gets the absolute offset of a label.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public ushort GetLabelOffset(LabelHandle label)
        {
            ref var l = ref _labels[label.Id];
            var v = l.Value;
            if (v == -1)
                throw new InvalidOperationException($"Label {l.Id} has not been marked.");

            return (ushort)v;
        }

        /// <summary>
        /// Inserts a label value at the current position of the specified size, as calculated by the relative offset.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="size"></param>
        /// <param name="offset"></param>
        public InstructionEncoder Label(LabelHandle label, byte size, ushort offset)
        {
            if (size is not 2 and not 4)
                throw new ArgumentException("Label output size can only be 2 or 4 bytes.");

            ref var l = ref _labels[label.Id];
            var d = new FixupData(ReserveBytes(size), offset);
            if (l.Value == -1)
                l.AddFixup(d);
            else
                ApplyFixup(ref l, ref d);

            return this;
        }

        /// <summary>
        /// Inserts a label value at the current position of the specified size, as calculated by the relative offset.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="size"></param>
        public InstructionEncoder Label(LabelHandle label, byte size)
        {
            return Label(label, size, Offset);
        }

        /// <summary>
        /// Applies the fixup.
        /// </summary>
        /// <param name="fixup"></param>
        void ApplyFixup(ref LabelInfo label, ref FixupData fixup)
        {
            var v = label.Value;
            if (v == -1)
                throw new InvalidOperationException($"Label {label.Id} has not been marked.");

            var o = v - fixup.Offset;
            if (fixup.Region.Length == 2)
            {
                if (o < short.MinValue || o > short.MaxValue)
                    throw new InvalidOperationException($"Label {label.Id} out of range for instruction operand size.");

                BinaryPrimitives.WriteInt16BigEndian(fixup.Region.GetBytes(), (short)o);
            }
            else
                BinaryPrimitives.WriteInt32BigEndian(fixup.Region.GetBytes(), o);
        }

        /// <summary>
        /// Encodes the specified op-code.
        /// </summary>
        /// <param name="code"></param>
        public InstructionEncoder OpCode(OpCode code)
        {
            WriteByte((byte)code);
            return this;
        }

        /// <summary>
        /// Encodes the specified op-code.
        /// </summary>
        /// <param name="code"></param>
        public InstructionEncoder OpCode(OpCode code, ConstantHandle arg1)
        {
            WriteByte((byte)code);
            Constant(arg1);
            return this;
        }

        /// <summary>
        /// Encodes the specified op-code.
        /// </summary>
        /// <param name="code"></param>
        public InstructionEncoder OpCode(OpCode code, byte arg1)
        {
            WriteByte((byte)code);
            WriteByte(arg1);
            return this;
        }

        /// <summary>
        /// Encodes the specified op-code.
        /// </summary>
        /// <param name="code"></param>
        public InstructionEncoder OpCode(OpCode code, ushort arg1)
        {
            WriteByte((byte)code);
            WriteUInt16(arg1);
            return this;
        }

        /// <summary>
        /// Encodes the specified op-code.
        /// </summary>
        /// <param name="code"></param>
        public InstructionEncoder OpCode(OpCode code, uint arg1)
        {
            WriteByte((byte)code);
            WriteUInt32(arg1);
            return this;
        }

        /// <summary>
        /// Aligns the current position of the writer on <paramref name="alignment"/> boundary.
        /// </summary>
        /// <param name="alignment"></param>
        internal void Align(int alignment)
        {
            _builder.Align(alignment);
        }

        /// <summary>
        /// Encodes a 8 bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        internal void WriteSByte(sbyte value)
        {
            _builder.WriteBytes((byte)value, 1);
        }

        /// <summary>
        /// Encodes a 16-bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        internal void WriteInt16(short value)
        {
            BinaryPrimitives.WriteInt16BigEndian(ReserveBytes(sizeof(short)).GetBytes(), value);
        }

        /// <summary>
        /// Encodes a 32-bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        internal void WriteInt32(int value)
        {
            BinaryPrimitives.WriteInt32BigEndian(ReserveBytes(sizeof(int)).GetBytes(), value);
        }

        /// <summary>
        /// Encodes a 8 bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        internal void WriteByte(byte value)
        {
            ReserveBytes(sizeof(byte)).GetBytes().AsSpan()[0] = value;
        }

        /// <summary>
        /// Encodes a 16-bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        internal void WriteUInt16(ushort value)
        {
            BinaryPrimitives.WriteUInt16BigEndian(ReserveBytes(sizeof(ushort)).GetBytes(), value);
        }

        /// <summary>
        /// Encodes a 32-bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        internal void WriteUInt32(uint value)
        {
            BinaryPrimitives.WriteUInt32BigEndian(ReserveBytes(sizeof(uint)).GetBytes(), value);
        }

        /// <summary>
        /// Inserts a <see cref="ConstantHandle"/> as an unsigned big endian pair of bytes.
        /// </summary>
        /// <param name="handle"></param>
        public InstructionEncoder Constant(ConstantHandle handle)
        {
            WriteUInt16(handle.Slot);
            return this;
        }

        /// <summary>
        /// Inserts an 'invokestatic' instruction.
        /// </summary>
        /// <param name="handle"></param>
        public InstructionEncoder InvokeStatic(MethodrefConstantHandle handle)
        {
            return OpCode(ByteCode.OpCode._invokestatic, handle.Slot);
        }

        /// <summary>
        /// Inserts an 'invokestatic' instruction.
        /// </summary>
        /// <param name="handle"></param>
        public InstructionEncoder InvokeStatic(InterfaceMethodrefConstantHandle handle)
        {
            return OpCode(ByteCode.OpCode._invokestatic, handle.Slot);
        }

        /// <summary>
        /// Inserts an 'invokevirtual' instruction.
        /// </summary>
        /// <param name="handle"></param>
        public InstructionEncoder InvokeVirtual(MethodrefConstantHandle handle)
        {
            return OpCode(ByteCode.OpCode._invokevirtual, handle.Slot);
        }

        /// <summary>
        /// Encodes a local variable load instruction.
        /// </summary>
        /// <param name="slot"></param>
        public InstructionEncoder LoadLocalInteger(ushort slot)
        {
            switch (slot)
            {
                case 0: OpCode(IKVM.ByteCode.OpCode._iload_0); break;
                case 1: OpCode(IKVM.ByteCode.OpCode._iload_1); break;
                case 2: OpCode(IKVM.ByteCode.OpCode._iload_2); break;
                case 3: OpCode(IKVM.ByteCode.OpCode._iload_3); break;
                default:
                    if (slot <= byte.MaxValue)
                        OpCode(IKVM.ByteCode.OpCode._iload, (byte)slot);
                    else
                    {
                        OpCode(IKVM.ByteCode.OpCode._wide);
                        OpCode(IKVM.ByteCode.OpCode._iload, slot);
                    }
                    break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable load instruction.
        /// </summary>
        /// <param name="slot"></param>
        public InstructionEncoder LoadLocalFloat(ushort slot)
        {
            switch (slot)
            {
                case 0: OpCode(IKVM.ByteCode.OpCode._fload_0); break;
                case 1: OpCode(IKVM.ByteCode.OpCode._fload_1); break;
                case 2: OpCode(IKVM.ByteCode.OpCode._fload_2); break;
                case 3: OpCode(IKVM.ByteCode.OpCode._fload_3); break;
                default:
                    if (slot <= byte.MaxValue)
                        OpCode(IKVM.ByteCode.OpCode._fload, (byte)slot);
                    else
                    {
                        OpCode(IKVM.ByteCode.OpCode._wide);
                        OpCode(IKVM.ByteCode.OpCode._fload, slot);
                    }
                    break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable load instruction.
        /// </summary>
        /// <param name="slot"></param>
        public InstructionEncoder LoadLocalLong(ushort slot)
        {
            switch (slot)
            {
                case 0: OpCode(IKVM.ByteCode.OpCode._lload_0); break;
                case 1: OpCode(IKVM.ByteCode.OpCode._lload_1); break;
                case 2: OpCode(IKVM.ByteCode.OpCode._lload_2); break;
                case 3: OpCode(IKVM.ByteCode.OpCode._lload_3); break;
                default:
                    if (slot <= byte.MaxValue)
                        OpCode(IKVM.ByteCode.OpCode._lload, (byte)slot);
                    else
                    {
                        OpCode(IKVM.ByteCode.OpCode._wide);
                        OpCode(IKVM.ByteCode.OpCode._lload, slot);
                    }
                    break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable load instruction.
        /// </summary>
        /// <param name="slot"></param>
        public InstructionEncoder LoadLocalDouble(ushort slot)
        {
            switch (slot)
            {
                case 0: OpCode(IKVM.ByteCode.OpCode._dload_0); break;
                case 1: OpCode(IKVM.ByteCode.OpCode._dload_1); break;
                case 2: OpCode(IKVM.ByteCode.OpCode._dload_2); break;
                case 3: OpCode(IKVM.ByteCode.OpCode._dload_3); break;
                default:
                    if (slot <= byte.MaxValue)
                        OpCode(IKVM.ByteCode.OpCode._dload, (byte)slot);
                    else
                    {
                        OpCode(IKVM.ByteCode.OpCode._wide);
                        OpCode(IKVM.ByteCode.OpCode._dload, slot);
                    }
                    break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable load instruction.
        /// </summary>
        /// <param name="slot"></param>
        public InstructionEncoder LoadLocalReference(ushort slot)
        {
            switch (slot)
            {
                case 0: OpCode(IKVM.ByteCode.OpCode._aload_0); break;
                case 1: OpCode(IKVM.ByteCode.OpCode._aload_1); break;
                case 2: OpCode(IKVM.ByteCode.OpCode._aload_2); break;
                case 3: OpCode(IKVM.ByteCode.OpCode._aload_3); break;
                default:
                    if (slot <= byte.MaxValue)
                        OpCode(IKVM.ByteCode.OpCode._aload, (byte)slot);
                    else
                    {
                        OpCode(IKVM.ByteCode.OpCode._wide);
                        OpCode(IKVM.ByteCode.OpCode._aload, slot);
                    }
                    break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable store instruction.
        /// </summary>
        /// <param name="slot"></param>
        public InstructionEncoder StoreLocalInteger(ushort slot)
        {
            switch (slot)
            {
                case 0: OpCode(IKVM.ByteCode.OpCode._istore_0); break;
                case 1: OpCode(IKVM.ByteCode.OpCode._istore_1); break;
                case 2: OpCode(IKVM.ByteCode.OpCode._istore_2); break;
                case 3: OpCode(IKVM.ByteCode.OpCode._istore_3); break;
                default:
                    if (slot <= byte.MaxValue)
                        OpCode(IKVM.ByteCode.OpCode._istore, (byte)slot);
                    else
                    {
                        OpCode(IKVM.ByteCode.OpCode._wide);
                        OpCode(IKVM.ByteCode.OpCode._istore, slot);
                    }
                    break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable store instruction.
        /// </summary>
        /// <param name="slot"></param>
        public InstructionEncoder StoreLocalFloat(ushort slot)
        {
            switch (slot)
            {
                case 0: OpCode(IKVM.ByteCode.OpCode._fstore_0); break;
                case 1: OpCode(IKVM.ByteCode.OpCode._fstore_1); break;
                case 2: OpCode(IKVM.ByteCode.OpCode._fstore_2); break;
                case 3: OpCode(IKVM.ByteCode.OpCode._fstore_3); break;
                default:
                    if (slot <= byte.MaxValue)
                        OpCode(IKVM.ByteCode.OpCode._fstore, (byte)slot);
                    else
                    {
                        OpCode(IKVM.ByteCode.OpCode._wide);
                        OpCode(IKVM.ByteCode.OpCode._fstore, slot);
                    }
                    break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable store instruction.
        /// </summary>
        /// <param name="slot"></param>
        public InstructionEncoder StoreLocalLong(ushort slot)
        {
            switch (slot)
            {
                case 0: OpCode(IKVM.ByteCode.OpCode._lstore_0); break;
                case 1: OpCode(IKVM.ByteCode.OpCode._lstore_1); break;
                case 2: OpCode(IKVM.ByteCode.OpCode._lstore_2); break;
                case 3: OpCode(IKVM.ByteCode.OpCode._lstore_3); break;
                default:
                    if (slot <= byte.MaxValue)
                        OpCode(IKVM.ByteCode.OpCode._lstore, (byte)slot);
                    else
                    {
                        OpCode(IKVM.ByteCode.OpCode._wide);
                        OpCode(IKVM.ByteCode.OpCode._lstore, slot);
                    }
                    break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable store instruction.
        /// </summary>
        /// <param name="slot"></param>
        public InstructionEncoder StoreLocalDouble(ushort slot)
        {
            switch (slot)
            {
                case 0: OpCode(IKVM.ByteCode.OpCode._dstore_0); break;
                case 1: OpCode(IKVM.ByteCode.OpCode._dstore_1); break;
                case 2: OpCode(IKVM.ByteCode.OpCode._dstore_2); break;
                case 3: OpCode(IKVM.ByteCode.OpCode._dstore_3); break;
                default:
                    if (slot <= byte.MaxValue)
                        OpCode(IKVM.ByteCode.OpCode._dstore, (byte)slot);
                    else
                    {
                        OpCode(IKVM.ByteCode.OpCode._wide);
                        OpCode(IKVM.ByteCode.OpCode._dstore, slot);
                    }
                    break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable store instruction.
        /// </summary>
        /// <param name="slot"></param>
        public InstructionEncoder StoreLocalReference(ushort slot)
        {
            switch (slot)
            {
                case 0: OpCode(IKVM.ByteCode.OpCode._astore_0); break;
                case 1: OpCode(IKVM.ByteCode.OpCode._astore_1); break;
                case 2: OpCode(IKVM.ByteCode.OpCode._astore_2); break;
                case 3: OpCode(IKVM.ByteCode.OpCode._astore_3); break;
                default:
                    if (slot <= byte.MaxValue)
                        OpCode(IKVM.ByteCode.OpCode._astore, (byte)slot);
                    else
                    {
                        OpCode(IKVM.ByteCode.OpCode._wide);
                        OpCode(IKVM.ByteCode.OpCode._astore, slot);
                    }
                    break;
            }

            return this;
        }

        /// <summary>
        /// Loads an integer constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        public InstructionEncoder LoadConstant(IntegerConstantHandle handle)
        {
            if (handle.Slot <= byte.MaxValue)
                return OpCode(IKVM.ByteCode.OpCode._ldc, (byte)handle.Slot);
            else
                return OpCode(IKVM.ByteCode.OpCode._ldc_w, handle.Slot);
        }

        /// <summary>
        /// Loads a float constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        public InstructionEncoder LoadConstant(FloatConstantHandle handle)
        {
            if (handle.Slot <= byte.MaxValue)
                return OpCode(IKVM.ByteCode.OpCode._ldc, (byte)handle.Slot);
            else
                return OpCode(IKVM.ByteCode.OpCode._ldc_w, handle.Slot);
        }

        /// <summary>
        /// Loads a string constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        public InstructionEncoder LoadConstant(StringConstantHandle handle)
        {
            if (handle.Slot <= byte.MaxValue)
                return OpCode(IKVM.ByteCode.OpCode._ldc, (byte)handle.Slot);
            else
                return OpCode(IKVM.ByteCode.OpCode._ldc_w, handle.Slot);
        }

        /// <summary>
        /// Loads a class constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        public InstructionEncoder LoadConstant(ClassConstantHandle handle)
        {
            if (handle.Slot <= byte.MaxValue)
                return OpCode(IKVM.ByteCode.OpCode._ldc, (byte)handle.Slot);
            else
                return OpCode(IKVM.ByteCode.OpCode._ldc_w, handle.Slot);
        }

        /// <summary>
        /// Loads a class constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        public InstructionEncoder LoadConstant(MethodTypeConstantHandle handle)
        {
            if (handle.Slot <= byte.MaxValue)
                return OpCode(IKVM.ByteCode.OpCode._ldc, (byte)handle.Slot);
            else
                return OpCode(IKVM.ByteCode.OpCode._ldc_w, handle.Slot);
        }

        /// <summary>
        /// Loads a class constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        public InstructionEncoder LoadConstant(MethodHandleConstantHandle handle)
        {
            if (handle.Slot <= byte.MaxValue)
                return OpCode(IKVM.ByteCode.OpCode._ldc, (byte)handle.Slot);
            else
                return OpCode(IKVM.ByteCode.OpCode._ldc_w, handle.Slot);
        }

        /// <summary>
        /// Loads a float constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        public InstructionEncoder LoadConstant(LongConstantHandle handle)
        {
            return OpCode(IKVM.ByteCode.OpCode._ldc2_w, handle.Slot);
        }

        /// <summary>
        /// Loads a double constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        public InstructionEncoder LoadConstant(DoubleConstantHandle handle)
        {
            return OpCode(IKVM.ByteCode.OpCode._ldc2_w, handle.Slot);
        }

        /// <summary>
        /// Encodes a branch instruction.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="label"></param>
        public InstructionEncoder Branch(OpCode opcode, LabelHandle label)
        {
            var offset = Offset;
            OpCode(opcode);
            Label(label, opcode.GetBranchOperandSize(), offset);
            return this;
        }

        /// <summary>
        /// Encodes a tableswitch instruction.
        /// </summary>
        /// <param name="defaultLabel"></param>
        /// <param name="low"></param>
        /// <param name="encode"></param>
        public InstructionEncoder TableSwitch(LabelHandle defaultLabel, int low, Action<TableSwitchInstructionEncoder> encode)
        {
            if (encode is null)
                throw new ArgumentNullException(nameof(encode));

            var encoder = new TableSwitchInstructionEncoder(this, defaultLabel, low);
            encode(encoder);
            encoder.Validate();

            return this;
        }

        /// <summary>
        /// Encodes a lookupswitch instruction.
        /// </summary>
        /// <param name="defaultLabel"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public InstructionEncoder LookupSwitch(LabelHandle defaultLabel, Action<LookupSwitchInstructionEncoder> encode)
        {
            if (encode is null)
                throw new ArgumentNullException(nameof(encode));

            encode(new LookupSwitchInstructionEncoder(this, defaultLabel));

            return this;
        }

    }

}
