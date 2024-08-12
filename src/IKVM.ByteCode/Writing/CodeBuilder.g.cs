using System;
using System.Runtime.CompilerServices;

namespace IKVM.ByteCode.Writing
{

    public partial class CodeBuilder
    {

        /// <summary>
        /// Encodes the 'nop' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Nop()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Nop);
            return this;
        }

        /// <summary>
        /// Encodes the 'aconst_null' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder AconstNull()
        {
            this.OpCode(IKVM.ByteCode.OpCode.AconstNull);
            return this;
        }

        /// <summary>
        /// Encodes the 'iconst_m1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IconstM1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.IconstM1);
            return this;
        }

        /// <summary>
        /// Encodes the 'iconst_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iconst0()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iconst0);
            return this;
        }

        /// <summary>
        /// Encodes the 'iconst_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iconst1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iconst1);
            return this;
        }

        /// <summary>
        /// Encodes the 'iconst_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iconst2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iconst2);
            return this;
        }

        /// <summary>
        /// Encodes the 'iconst_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iconst3()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iconst3);
            return this;
        }

        /// <summary>
        /// Encodes the 'iconst_4' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iconst4()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iconst4);
            return this;
        }

        /// <summary>
        /// Encodes the 'iconst_5' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iconst5()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iconst5);
            return this;
        }

        /// <summary>
        /// Encodes the 'lconst_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lconst0()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lconst0);
            return this;
        }

        /// <summary>
        /// Encodes the 'lconst_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lconst1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lconst1);
            return this;
        }

        /// <summary>
        /// Encodes the 'fconst_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fconst0()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fconst0);
            return this;
        }

        /// <summary>
        /// Encodes the 'fconst_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fconst1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fconst1);
            return this;
        }

        /// <summary>
        /// Encodes the 'fconst_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fconst2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fconst2);
            return this;
        }

        /// <summary>
        /// Encodes the 'dconst_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dconst0()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dconst0);
            return this;
        }

        /// <summary>
        /// Encodes the 'dconst_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dconst1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dconst1);
            return this;
        }

        /// <summary>
        /// Encodes the 'bipush' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Bipush(sbyte value)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Bipush);
            this.WriteSByte(value);
            return this;
        }

        /// <summary>
        /// Encodes the 'sipush' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Sipush(short value)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Sipush);
            this.WriteInt16(value);
            return this;
        }

        /// <summary>
        /// Encodes the 'ldc' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ldc(ConstantHandle handle)
        {
            if (handle.Slot > byte.MaxValue)
                throw new InvalidOperationException("Ldc does not support wide constant handles.");

            this.OpCode(IKVM.ByteCode.OpCode.Ldc);
            this.WriteByte(checked((byte)handle.Slot));
            return this;
        }

        /// <summary>
        /// Encodes the 'ldc_w' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LdcW(ConstantHandle handle)
        {
            this.OpCode(IKVM.ByteCode.OpCode.LdcW);
            this.WriteUInt16(handle.Slot);
            return this;
        }

        /// <summary>
        /// Encodes the 'ldc2_w' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ldc2W(ConstantHandle handle)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Ldc2W);
            this.WriteUInt16(handle.Slot);
            return this;
        }

        /// <summary>
        /// Encodes the 'iload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iload(ushort local)
        {
            if (local > byte.MaxValue)
            {
                this.OpCode(IKVM.ByteCode.OpCode.Wide);
                this.OpCode(IKVM.ByteCode.OpCode.Iload);
                this.WriteUInt16(local);
                return this;
            }
            else
            {
                this.OpCode(IKVM.ByteCode.OpCode.Iload);
                this.WriteByte((byte)local);
                return this;
            }
        }
        /// <summary>
        /// Encodes the 'lload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lload(ushort local)
        {
            if (local > byte.MaxValue)
            {
                this.OpCode(IKVM.ByteCode.OpCode.Wide);
                this.OpCode(IKVM.ByteCode.OpCode.Lload);
                this.WriteUInt16(local);
                return this;
            }
            else
            {
                this.OpCode(IKVM.ByteCode.OpCode.Lload);
                this.WriteByte((byte)local);
                return this;
            }
        }
        /// <summary>
        /// Encodes the 'fload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fload(ushort local)
        {
            if (local > byte.MaxValue)
            {
                this.OpCode(IKVM.ByteCode.OpCode.Wide);
                this.OpCode(IKVM.ByteCode.OpCode.Fload);
                this.WriteUInt16(local);
                return this;
            }
            else
            {
                this.OpCode(IKVM.ByteCode.OpCode.Fload);
                this.WriteByte((byte)local);
                return this;
            }
        }
        /// <summary>
        /// Encodes the 'dload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dload(ushort local)
        {
            if (local > byte.MaxValue)
            {
                this.OpCode(IKVM.ByteCode.OpCode.Wide);
                this.OpCode(IKVM.ByteCode.OpCode.Dload);
                this.WriteUInt16(local);
                return this;
            }
            else
            {
                this.OpCode(IKVM.ByteCode.OpCode.Dload);
                this.WriteByte((byte)local);
                return this;
            }
        }
        /// <summary>
        /// Encodes the 'aload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Aload(ushort local)
        {
            if (local > byte.MaxValue)
            {
                this.OpCode(IKVM.ByteCode.OpCode.Wide);
                this.OpCode(IKVM.ByteCode.OpCode.Aload);
                this.WriteUInt16(local);
                return this;
            }
            else
            {
                this.OpCode(IKVM.ByteCode.OpCode.Aload);
                this.WriteByte((byte)local);
                return this;
            }
        }
        /// <summary>
        /// Encodes the 'iload_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iload0()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iload0);
            return this;
        }

        /// <summary>
        /// Encodes the 'iload_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iload1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iload1);
            return this;
        }

        /// <summary>
        /// Encodes the 'iload_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iload2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iload2);
            return this;
        }

        /// <summary>
        /// Encodes the 'iload_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iload3()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iload3);
            return this;
        }

        /// <summary>
        /// Encodes the 'lload_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lload0()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lload0);
            return this;
        }

        /// <summary>
        /// Encodes the 'lload_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lload1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lload1);
            return this;
        }

        /// <summary>
        /// Encodes the 'lload_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lload2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lload2);
            return this;
        }

        /// <summary>
        /// Encodes the 'lload_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lload3()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lload3);
            return this;
        }

        /// <summary>
        /// Encodes the 'fload_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fload0()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fload0);
            return this;
        }

        /// <summary>
        /// Encodes the 'fload_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fload1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fload1);
            return this;
        }

        /// <summary>
        /// Encodes the 'fload_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fload2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fload2);
            return this;
        }

        /// <summary>
        /// Encodes the 'fload_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fload3()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fload3);
            return this;
        }

        /// <summary>
        /// Encodes the 'dload_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dload0()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dload0);
            return this;
        }

        /// <summary>
        /// Encodes the 'dload_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dload1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dload1);
            return this;
        }

        /// <summary>
        /// Encodes the 'dload_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dload2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dload2);
            return this;
        }

        /// <summary>
        /// Encodes the 'dload_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dload3()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dload3);
            return this;
        }

        /// <summary>
        /// Encodes the 'aload_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Aload0()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Aload0);
            return this;
        }

        /// <summary>
        /// Encodes the 'aload_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Aload1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Aload1);
            return this;
        }

        /// <summary>
        /// Encodes the 'aload_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Aload2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Aload2);
            return this;
        }

        /// <summary>
        /// Encodes the 'aload_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Aload3()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Aload3);
            return this;
        }

        /// <summary>
        /// Encodes the 'iaload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iaload()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iaload);
            return this;
        }

        /// <summary>
        /// Encodes the 'laload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Laload()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Laload);
            return this;
        }

        /// <summary>
        /// Encodes the 'faload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Faload()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Faload);
            return this;
        }

        /// <summary>
        /// Encodes the 'daload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Daload()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Daload);
            return this;
        }

        /// <summary>
        /// Encodes the 'aaload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Aaload()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Aaload);
            return this;
        }

        /// <summary>
        /// Encodes the 'baload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Baload()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Baload);
            return this;
        }

        /// <summary>
        /// Encodes the 'caload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Caload()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Caload);
            return this;
        }

        /// <summary>
        /// Encodes the 'saload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Saload()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Saload);
            return this;
        }

        /// <summary>
        /// Encodes the 'istore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Istore(ushort local)
        {
            if (local > byte.MaxValue)
            {
                this.OpCode(IKVM.ByteCode.OpCode.Wide);
                this.OpCode(IKVM.ByteCode.OpCode.Istore);
                this.WriteUInt16(local);
                return this;
            }
            else
            {
                this.OpCode(IKVM.ByteCode.OpCode.Istore);
                this.WriteByte((byte)local);
                return this;
            }
        }
        /// <summary>
        /// Encodes the 'lstore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lstore(ushort local)
        {
            if (local > byte.MaxValue)
            {
                this.OpCode(IKVM.ByteCode.OpCode.Wide);
                this.OpCode(IKVM.ByteCode.OpCode.Lstore);
                this.WriteUInt16(local);
                return this;
            }
            else
            {
                this.OpCode(IKVM.ByteCode.OpCode.Lstore);
                this.WriteByte((byte)local);
                return this;
            }
        }
        /// <summary>
        /// Encodes the 'fstore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fstore(ushort local)
        {
            if (local > byte.MaxValue)
            {
                this.OpCode(IKVM.ByteCode.OpCode.Wide);
                this.OpCode(IKVM.ByteCode.OpCode.Fstore);
                this.WriteUInt16(local);
                return this;
            }
            else
            {
                this.OpCode(IKVM.ByteCode.OpCode.Fstore);
                this.WriteByte((byte)local);
                return this;
            }
        }
        /// <summary>
        /// Encodes the 'dstore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dstore(ushort local)
        {
            if (local > byte.MaxValue)
            {
                this.OpCode(IKVM.ByteCode.OpCode.Wide);
                this.OpCode(IKVM.ByteCode.OpCode.Dstore);
                this.WriteUInt16(local);
                return this;
            }
            else
            {
                this.OpCode(IKVM.ByteCode.OpCode.Dstore);
                this.WriteByte((byte)local);
                return this;
            }
        }
        /// <summary>
        /// Encodes the 'astore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Astore(ushort local)
        {
            if (local > byte.MaxValue)
            {
                this.OpCode(IKVM.ByteCode.OpCode.Wide);
                this.OpCode(IKVM.ByteCode.OpCode.Astore);
                this.WriteUInt16(local);
                return this;
            }
            else
            {
                this.OpCode(IKVM.ByteCode.OpCode.Astore);
                this.WriteByte((byte)local);
                return this;
            }
        }
        /// <summary>
        /// Encodes the 'istore_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Istore0()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Istore0);
            return this;
        }

        /// <summary>
        /// Encodes the 'istore_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Istore1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Istore1);
            return this;
        }

        /// <summary>
        /// Encodes the 'istore_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Istore2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Istore2);
            return this;
        }

        /// <summary>
        /// Encodes the 'istore_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Istore3()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Istore3);
            return this;
        }

        /// <summary>
        /// Encodes the 'lstore_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lstore0()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lstore0);
            return this;
        }

        /// <summary>
        /// Encodes the 'lstore_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lstore1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lstore1);
            return this;
        }

        /// <summary>
        /// Encodes the 'lstore_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lstore2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lstore2);
            return this;
        }

        /// <summary>
        /// Encodes the 'lstore_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lstore3()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lstore3);
            return this;
        }

        /// <summary>
        /// Encodes the 'fstore_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fstore0()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fstore0);
            return this;
        }

        /// <summary>
        /// Encodes the 'fstore_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fstore1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fstore1);
            return this;
        }

        /// <summary>
        /// Encodes the 'fstore_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fstore2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fstore2);
            return this;
        }

        /// <summary>
        /// Encodes the 'fstore_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fstore3()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fstore3);
            return this;
        }

        /// <summary>
        /// Encodes the 'dstore_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dstore0()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dstore0);
            return this;
        }

        /// <summary>
        /// Encodes the 'dstore_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dstore1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dstore1);
            return this;
        }

        /// <summary>
        /// Encodes the 'dstore_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dstore2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dstore2);
            return this;
        }

        /// <summary>
        /// Encodes the 'dstore_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dstore3()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dstore3);
            return this;
        }

        /// <summary>
        /// Encodes the 'astore_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Astore0()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Astore0);
            return this;
        }

        /// <summary>
        /// Encodes the 'astore_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Astore1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Astore1);
            return this;
        }

        /// <summary>
        /// Encodes the 'astore_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Astore2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Astore2);
            return this;
        }

        /// <summary>
        /// Encodes the 'astore_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Astore3()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Astore3);
            return this;
        }

        /// <summary>
        /// Encodes the 'iastore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iastore()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iastore);
            return this;
        }

        /// <summary>
        /// Encodes the 'lastore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lastore()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lastore);
            return this;
        }

        /// <summary>
        /// Encodes the 'fastore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fastore()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fastore);
            return this;
        }

        /// <summary>
        /// Encodes the 'dastore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dastore()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dastore);
            return this;
        }

        /// <summary>
        /// Encodes the 'aastore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Aastore()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Aastore);
            return this;
        }

        /// <summary>
        /// Encodes the 'bastore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Bastore()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Bastore);
            return this;
        }

        /// <summary>
        /// Encodes the 'castore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Castore()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Castore);
            return this;
        }

        /// <summary>
        /// Encodes the 'sastore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Sastore()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Sastore);
            return this;
        }

        /// <summary>
        /// Encodes the 'pop' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Pop()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Pop);
            return this;
        }

        /// <summary>
        /// Encodes the 'pop2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Pop2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Pop2);
            return this;
        }

        /// <summary>
        /// Encodes the 'dup' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dup()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dup);
            return this;
        }

        /// <summary>
        /// Encodes the 'dup_x1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder DupX1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.DupX1);
            return this;
        }

        /// <summary>
        /// Encodes the 'dup_x2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder DupX2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.DupX2);
            return this;
        }

        /// <summary>
        /// Encodes the 'dup2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dup2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dup2);
            return this;
        }

        /// <summary>
        /// Encodes the 'dup2_x1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dup2X1()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dup2X1);
            return this;
        }

        /// <summary>
        /// Encodes the 'dup2_x2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dup2X2()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dup2X2);
            return this;
        }

        /// <summary>
        /// Encodes the 'swap' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Swap()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Swap);
            return this;
        }

        /// <summary>
        /// Encodes the 'iadd' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iadd()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iadd);
            return this;
        }

        /// <summary>
        /// Encodes the 'ladd' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ladd()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Ladd);
            return this;
        }

        /// <summary>
        /// Encodes the 'fadd' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fadd()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fadd);
            return this;
        }

        /// <summary>
        /// Encodes the 'dadd' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dadd()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dadd);
            return this;
        }

        /// <summary>
        /// Encodes the 'isub' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Isub()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Isub);
            return this;
        }

        /// <summary>
        /// Encodes the 'lsub' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lsub()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lsub);
            return this;
        }

        /// <summary>
        /// Encodes the 'fsub' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fsub()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fsub);
            return this;
        }

        /// <summary>
        /// Encodes the 'dsub' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dsub()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dsub);
            return this;
        }

        /// <summary>
        /// Encodes the 'imul' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Imul()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Imul);
            return this;
        }

        /// <summary>
        /// Encodes the 'lmul' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lmul()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lmul);
            return this;
        }

        /// <summary>
        /// Encodes the 'fmul' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fmul()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fmul);
            return this;
        }

        /// <summary>
        /// Encodes the 'dmul' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dmul()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dmul);
            return this;
        }

        /// <summary>
        /// Encodes the 'idiv' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Idiv()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Idiv);
            return this;
        }

        /// <summary>
        /// Encodes the 'ldiv' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ldiv()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Ldiv);
            return this;
        }

        /// <summary>
        /// Encodes the 'fdiv' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fdiv()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fdiv);
            return this;
        }

        /// <summary>
        /// Encodes the 'ddiv' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ddiv()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Ddiv);
            return this;
        }

        /// <summary>
        /// Encodes the 'irem' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Irem()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Irem);
            return this;
        }

        /// <summary>
        /// Encodes the 'lrem' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lrem()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lrem);
            return this;
        }

        /// <summary>
        /// Encodes the 'frem' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Frem()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Frem);
            return this;
        }

        /// <summary>
        /// Encodes the 'drem' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Drem()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Drem);
            return this;
        }

        /// <summary>
        /// Encodes the 'ineg' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ineg()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Ineg);
            return this;
        }

        /// <summary>
        /// Encodes the 'lneg' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lneg()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lneg);
            return this;
        }

        /// <summary>
        /// Encodes the 'fneg' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fneg()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fneg);
            return this;
        }

        /// <summary>
        /// Encodes the 'dneg' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dneg()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dneg);
            return this;
        }

        /// <summary>
        /// Encodes the 'ishl' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ishl()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Ishl);
            return this;
        }

        /// <summary>
        /// Encodes the 'lshl' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lshl()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lshl);
            return this;
        }

        /// <summary>
        /// Encodes the 'ishr' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ishr()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Ishr);
            return this;
        }

        /// <summary>
        /// Encodes the 'lshr' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lshr()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lshr);
            return this;
        }

        /// <summary>
        /// Encodes the 'iushr' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iushr()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iushr);
            return this;
        }

        /// <summary>
        /// Encodes the 'lushr' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lushr()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lushr);
            return this;
        }

        /// <summary>
        /// Encodes the 'iand' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iand()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Iand);
            return this;
        }

        /// <summary>
        /// Encodes the 'land' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Land()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Land);
            return this;
        }

        /// <summary>
        /// Encodes the 'ior' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ior()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Ior);
            return this;
        }

        /// <summary>
        /// Encodes the 'lor' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lor()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lor);
            return this;
        }

        /// <summary>
        /// Encodes the 'ixor' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ixor()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Ixor);
            return this;
        }

        /// <summary>
        /// Encodes the 'lxor' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lxor()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lxor);
            return this;
        }

        /// <summary>
        /// Encodes the 'iinc' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iinc(ushort local, short value)
        {
            if (local > byte.MaxValue || value > sbyte.MaxValue)
            {
                this.OpCode(IKVM.ByteCode.OpCode.Wide);
                this.OpCode(IKVM.ByteCode.OpCode.Iinc);
                this.WriteUInt16(local);
                this.WriteInt16(value);
                return this;
            }
            else
            {
                this.OpCode(IKVM.ByteCode.OpCode.Iinc);
                this.WriteByte((byte)local);
                this.WriteSByte((sbyte)value);
                return this;
            }
        }
        /// <summary>
        /// Encodes the 'i2l' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder I2l()
        {
            this.OpCode(IKVM.ByteCode.OpCode.I2l);
            return this;
        }

        /// <summary>
        /// Encodes the 'i2f' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder I2f()
        {
            this.OpCode(IKVM.ByteCode.OpCode.I2f);
            return this;
        }

        /// <summary>
        /// Encodes the 'i2d' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder I2d()
        {
            this.OpCode(IKVM.ByteCode.OpCode.I2d);
            return this;
        }

        /// <summary>
        /// Encodes the 'l2i' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder L2i()
        {
            this.OpCode(IKVM.ByteCode.OpCode.L2i);
            return this;
        }

        /// <summary>
        /// Encodes the 'l2f' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder L2f()
        {
            this.OpCode(IKVM.ByteCode.OpCode.L2f);
            return this;
        }

        /// <summary>
        /// Encodes the 'l2d' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder L2d()
        {
            this.OpCode(IKVM.ByteCode.OpCode.L2d);
            return this;
        }

        /// <summary>
        /// Encodes the 'f2i' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder F2i()
        {
            this.OpCode(IKVM.ByteCode.OpCode.F2i);
            return this;
        }

        /// <summary>
        /// Encodes the 'f2l' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder F2l()
        {
            this.OpCode(IKVM.ByteCode.OpCode.F2l);
            return this;
        }

        /// <summary>
        /// Encodes the 'f2d' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder F2d()
        {
            this.OpCode(IKVM.ByteCode.OpCode.F2d);
            return this;
        }

        /// <summary>
        /// Encodes the 'd2i' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder D2i()
        {
            this.OpCode(IKVM.ByteCode.OpCode.D2i);
            return this;
        }

        /// <summary>
        /// Encodes the 'd2l' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder D2l()
        {
            this.OpCode(IKVM.ByteCode.OpCode.D2l);
            return this;
        }

        /// <summary>
        /// Encodes the 'd2f' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder D2f()
        {
            this.OpCode(IKVM.ByteCode.OpCode.D2f);
            return this;
        }

        /// <summary>
        /// Encodes the 'i2b' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder I2b()
        {
            this.OpCode(IKVM.ByteCode.OpCode.I2b);
            return this;
        }

        /// <summary>
        /// Encodes the 'i2c' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder I2c()
        {
            this.OpCode(IKVM.ByteCode.OpCode.I2c);
            return this;
        }

        /// <summary>
        /// Encodes the 'i2s' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder I2s()
        {
            this.OpCode(IKVM.ByteCode.OpCode.I2s);
            return this;
        }

        /// <summary>
        /// Encodes the 'lcmp' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lcmp()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lcmp);
            return this;
        }

        /// <summary>
        /// Encodes the 'fcmpl' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fcmpl()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fcmpl);
            return this;
        }

        /// <summary>
        /// Encodes the 'fcmpg' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fcmpg()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Fcmpg);
            return this;
        }

        /// <summary>
        /// Encodes the 'dcmpl' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dcmpl()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dcmpl);
            return this;
        }

        /// <summary>
        /// Encodes the 'dcmpg' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dcmpg()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dcmpg);
            return this;
        }

        /// <summary>
        /// Encodes the 'ifeq' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ifeq(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.Ifeq, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'ifne' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ifne(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.Ifne, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'iflt' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iflt(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.Iflt, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'ifge' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ifge(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.Ifge, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'ifgt' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ifgt(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.Ifgt, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'ifle' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ifle(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.Ifle, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'if_icmpeq' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfIcmpeq(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.IfIcmpeq, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'if_icmpne' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfIcmpne(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.IfIcmpne, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'if_icmplt' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfIcmplt(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.IfIcmplt, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'if_icmpge' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfIcmpge(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.IfIcmpge, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'if_icmpgt' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfIcmpgt(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.IfIcmpgt, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'if_icmple' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfIcmple(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.IfIcmple, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'if_acmpeq' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfAcmpeq(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.IfAcmpeq, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'if_acmpne' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfAcmpne(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.IfAcmpne, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'goto' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Goto(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.Goto, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'jsr' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Jsr(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.Jsr, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'ret' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ret(ushort local)
        {
            if (local > byte.MaxValue)
            {
                this.OpCode(IKVM.ByteCode.OpCode.Wide);
                this.OpCode(IKVM.ByteCode.OpCode.Ret);
                this.WriteUInt16(local);
                return this;
            }
            else
            {
                this.OpCode(IKVM.ByteCode.OpCode.Ret);
                this.WriteByte((byte)local);
                return this;
            }
        }
        /// <summary>
        /// Encodes the 'ireturn' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ireturn()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Ireturn);
            return this;
        }

        /// <summary>
        /// Encodes the 'lreturn' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lreturn()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Lreturn);
            return this;
        }

        /// <summary>
        /// Encodes the 'freturn' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Freturn()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Freturn);
            return this;
        }

        /// <summary>
        /// Encodes the 'dreturn' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dreturn()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Dreturn);
            return this;
        }

        /// <summary>
        /// Encodes the 'areturn' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Areturn()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Areturn);
            return this;
        }

        /// <summary>
        /// Encodes the 'return' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Return()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Return);
            return this;
        }

        /// <summary>
        /// Encodes the 'getstatic' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Getstatic(ConstantHandle handle)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Getstatic);
            this.WriteUInt16(handle.Slot);
            return this;
        }

        /// <summary>
        /// Encodes the 'putstatic' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Putstatic(ConstantHandle handle)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Putstatic);
            this.WriteUInt16(handle.Slot);
            return this;
        }

        /// <summary>
        /// Encodes the 'getfield' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Getfield(ConstantHandle handle)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Getfield);
            this.WriteUInt16(handle.Slot);
            return this;
        }

        /// <summary>
        /// Encodes the 'putfield' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Putfield(ConstantHandle handle)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Putfield);
            this.WriteUInt16(handle.Slot);
            return this;
        }

        /// <summary>
        /// Encodes the 'invokevirtual' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Invokevirtual(ConstantHandle handle)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Invokevirtual);
            this.WriteUInt16(handle.Slot);
            return this;
        }

        /// <summary>
        /// Encodes the 'invokespecial' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Invokespecial(ConstantHandle handle)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Invokespecial);
            this.WriteUInt16(handle.Slot);
            return this;
        }

        /// <summary>
        /// Encodes the 'invokestatic' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Invokestatic(ConstantHandle handle)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Invokestatic);
            this.WriteUInt16(handle.Slot);
            return this;
        }

        /// <summary>
        /// Encodes the 'new' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder New(ConstantHandle handle)
        {
            this.OpCode(IKVM.ByteCode.OpCode.New);
            this.WriteUInt16(handle.Slot);
            return this;
        }

        /// <summary>
        /// Encodes the 'newarray' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Newarray(sbyte value)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Newarray);
            this.WriteSByte(value);
            return this;
        }

        /// <summary>
        /// Encodes the 'anewarray' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Anewarray(ConstantHandle handle)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Anewarray);
            this.WriteUInt16(handle.Slot);
            return this;
        }

        /// <summary>
        /// Encodes the 'arraylength' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Arraylength()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Arraylength);
            return this;
        }

        /// <summary>
        /// Encodes the 'athrow' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Athrow()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Athrow);
            return this;
        }

        /// <summary>
        /// Encodes the 'checkcast' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Checkcast(ConstantHandle handle)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Checkcast);
            this.WriteUInt16(handle.Slot);
            return this;
        }

        /// <summary>
        /// Encodes the 'instanceof' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Instanceof(ConstantHandle handle)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Instanceof);
            this.WriteUInt16(handle.Slot);
            return this;
        }

        /// <summary>
        /// Encodes the 'monitorenter' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Monitorenter()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Monitorenter);
            return this;
        }

        /// <summary>
        /// Encodes the 'monitorexit' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Monitorexit()
        {
            this.OpCode(IKVM.ByteCode.OpCode.Monitorexit);
            return this;
        }

        /// <summary>
        /// Encodes the 'multianewarray' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Multianewarray(ConstantHandle handle, sbyte value)
        {
            this.OpCode(IKVM.ByteCode.OpCode.Multianewarray);
            this.WriteUInt16(handle.Slot);
            this.WriteSByte(value);
            return this;
        }

        /// <summary>
        /// Encodes the 'ifnull' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ifnull(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.Ifnull, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'ifnonnull' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ifnonnull(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.Ifnonnull, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'goto_w' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder GotoW(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.GotoW, target);
            return this;
        }

        /// <summary>
        /// Encodes the 'jsr_w' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder JsrW(LabelHandle target)
        {
            this.Branch(IKVM.ByteCode.OpCode.JsrW, target);
            return this;
        }

    
    }

}
