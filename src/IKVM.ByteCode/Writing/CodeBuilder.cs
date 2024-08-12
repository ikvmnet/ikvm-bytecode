using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes a code block.
    /// </summary>
    public partial class CodeBuilder
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
        LabelInfo[] _labels = [];

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public CodeBuilder(BlobBuilder builder)
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder DefineLabel(out LabelHandle label)
        {
            label = DefineLabel();
            return this;
        }

        /// <summary>
        /// Associates specified label with the current bytecode positon, returning the program offset of the label.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="offset"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder MarkLabel(LabelHandle label, out int offset)
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder MarkLabel(LabelHandle label)
        {
            return MarkLabel(label, out _);
        }

        /// <summary>
        /// Gets the absolute offset of a label.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Label(LabelHandle label, byte size, ushort offset)
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Label(LabelHandle label, byte size)
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder OpCode(OpCode code)
        {
            WriteByte((byte)code);
            return this;
        }

        /// <summary>
        /// Aligns the current position of the writer on <paramref name="alignment"/> boundary.
        /// </summary>
        /// <param name="alignment"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Align(int alignment)
        {
            _builder.Align(alignment);
        }

        /// <summary>
        /// Encodes a 8 bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteSByte(sbyte value)
        {
            _builder.WriteBytes((byte)value, 1);
        }

        /// <summary>
        /// Encodes a 16-bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteInt16(short value)
        {
            BinaryPrimitives.WriteInt16BigEndian(ReserveBytes(sizeof(short)).GetBytes(), value);
        }

        /// <summary>
        /// Encodes a 32-bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteInt32(int value)
        {
            BinaryPrimitives.WriteInt32BigEndian(ReserveBytes(sizeof(int)).GetBytes(), value);
        }

        /// <summary>
        /// Encodes a 8 bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteByte(byte value)
        {
            ReserveBytes(sizeof(byte)).GetBytes().AsSpan()[0] = value;
        }

        /// <summary>
        /// Encodes a 16-bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteUInt16(ushort value)
        {
            BinaryPrimitives.WriteUInt16BigEndian(ReserveBytes(sizeof(ushort)).GetBytes(), value);
        }

        /// <summary>
        /// Encodes a 32-bit sized integer argument.
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteUInt32(uint value)
        {
            BinaryPrimitives.WriteUInt32BigEndian(ReserveBytes(sizeof(uint)).GetBytes(), value);
        }

        /// <summary>
        /// Encodes a local variable load instruction.
        /// </summary>
        /// <param name="slot"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LoadLocalInteger(ushort slot)
        {
            switch (slot)
            {
                case 0: Iload0(); break;
                case 1: Iload1(); break;
                case 2: Iload2(); break;
                case 3: Iload3(); break;
                default: Iload(slot); break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable load instruction.
        /// </summary>
        /// <param name="slot"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LoadLocalFloat(ushort slot)
        {
            switch (slot)
            {
                case 0: Fload0(); break;
                case 1: Fload1(); break;
                case 2: Fload2(); break;
                case 3: Fload3(); break;
                default: Fload(slot); break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable load instruction.
        /// </summary>
        /// <param name="slot"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LoadLocalLong(ushort slot)
        {
            switch (slot)
            {
                case 0: Lload0(); break;
                case 1: Lload1(); break;
                case 2: Lload2(); break;
                case 3: Lload3(); break;
                default: Lload(slot); break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable load instruction.
        /// </summary>
        /// <param name="slot"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LoadLocalDouble(ushort slot)
        {
            switch (slot)
            {
                case 0: Dload0(); break;
                case 1: Dload1(); break;
                case 2: Dload2(); break;
                case 3: Dload3(); break;
                default: Dload(slot); break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable load instruction.
        /// </summary>
        /// <param name="slot"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LoadLocalReference(ushort slot)
        {
            switch (slot)
            {
                case 0: Aload0(); break;
                case 1: Aload1(); break;
                case 2: Aload2(); break;
                case 3: Aload3(); break;
                default: Aload(slot); break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable store instruction.
        /// </summary>
        /// <param name="slot"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder StoreLocalInteger(ushort slot)
        {
            switch (slot)
            {
                case 0: Istore0(); break;
                case 1: Istore1(); break;
                case 2: Istore2(); break;
                case 3: Istore3(); break;
                default: Istore(slot); break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable store instruction.
        /// </summary>
        /// <param name="slot"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder StoreLocalFloat(ushort slot)
        {
            switch (slot)
            {
                case 0: Fstore0(); break;
                case 1: Fstore1(); break;
                case 2: Fstore2(); break;
                case 3: Fstore3(); break;
                default: Fstore(slot); break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable store instruction.
        /// </summary>
        /// <param name="slot"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder StoreLocalLong(ushort slot)
        {
            switch (slot)
            {
                case 0: Lstore0(); break;
                case 1: Lstore1(); break;
                case 2: Lstore2(); break;
                case 3: Lstore3(); break;
                default: Lstore(slot); break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable store instruction.
        /// </summary>
        /// <param name="slot"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder StoreLocalDouble(ushort slot)
        {
            switch (slot)
            {
                case 0: Dstore0(); break;
                case 1: Dstore1(); break;
                case 2: Dstore2(); break;
                case 3: Dstore3(); break;
                default: Dstore(slot); break;
            }

            return this;
        }

        /// <summary>
        /// Encodes a local variable store instruction.
        /// </summary>
        /// <param name="slot"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder StoreLocalReference(ushort slot)
        {
            switch (slot)
            {
                case 0: Astore0(); break;
                case 1: Astore1(); break;
                case 2: Astore2(); break;
                case 3: Astore3(); break;
                default: Astore(slot); break;
            }

            return this;
        }

        /// <summary>
        /// Loads a constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LoadConstant(ConstantHandle handle)
        {
            switch (handle.Kind)
            {
                case ConstantKind.Integer:
                    return LoadConstant((IntegerConstantHandle)handle);
                case ConstantKind.Float:
                    return LoadConstant((FloatConstantHandle)handle);
                case ConstantKind.Long:
                    return LoadConstant((LongConstantHandle)handle);
                case ConstantKind.Double:
                    return LoadConstant((DoubleConstantHandle)handle);
                case ConstantKind.Class:
                    return LoadConstant((ClassConstantHandle)handle);
                case ConstantKind.String:
                    return LoadConstant((StringConstantHandle)handle);
                case ConstantKind.MethodHandle:
                    return LoadConstant((MethodHandleConstantHandle)handle);
                case ConstantKind.MethodType:
                    return LoadConstant((MethodTypeConstantHandle)handle);
                case ConstantKind.Unknown:
                default:
                    throw new InvalidOperationException("Invalid constant kind for load.");
            }
        }

        /// <summary>
        /// Loads an integer constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LoadConstant(IntegerConstantHandle handle)
        {
            if (handle.Slot <= byte.MaxValue)
                return Ldc(handle);
            else
                return LdcW(handle);
        }

        /// <summary>
        /// Loads a float constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LoadConstant(FloatConstantHandle handle)
        {
            if (handle.Slot <= byte.MaxValue)
                return Ldc(handle);
            else
                return LdcW(handle);
        }

        /// <summary>
        /// Loads a string constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LoadConstant(StringConstantHandle handle)
        {
            if (handle.Slot <= byte.MaxValue)
                return Ldc(handle);
            else
                return LdcW(handle);
        }

        /// <summary>
        /// Loads a class constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LoadConstant(ClassConstantHandle handle)
        {
            if (handle.Slot <= byte.MaxValue)
                return Ldc(handle);
            else
                return LdcW(handle);
        }

        /// <summary>
        /// Loads a class constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LoadConstant(MethodTypeConstantHandle handle)
        {
            if (handle.Slot <= byte.MaxValue)
                return Ldc(handle);
            else
                return LdcW(handle);
        }

        /// <summary>
        /// Loads a class constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LoadConstant(MethodHandleConstantHandle handle)
        {
            if (handle.Slot <= byte.MaxValue)
                return Ldc(handle);
            else
                return LdcW(handle);
        }

        /// <summary>
        /// Loads a float constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LoadConstant(LongConstantHandle handle)
        {
            return Ldc2W(handle);
        }

        /// <summary>
        /// Loads a double constant from the constant pool.
        /// </summary>
        /// <param name="handle"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LoadConstant(DoubleConstantHandle handle)
        {
            return Ldc2W(handle);
        }

        /// <summary>
        /// Encodes a branch instruction.
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="label"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Branch(OpCode opcode, LabelHandle label)
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder TableSwitch(LabelHandle defaultLabel, int low, Action<TableSwitchCodeEncoder> encode)
        {
            encode(new TableSwitchCodeEncoder(this, defaultLabel, low));
            return this;
        }

        /// <summary>
        /// Encodes a lookupswitch instruction.
        /// </summary>
        /// <param name="defaultLabel"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LookupSwitch(LabelHandle defaultLabel, Action<LookupSwitchCodeEncoder> encode)
        {
            encode(new LookupSwitchCodeEncoder(this, defaultLabel));
            return this;
        }

    }

}
