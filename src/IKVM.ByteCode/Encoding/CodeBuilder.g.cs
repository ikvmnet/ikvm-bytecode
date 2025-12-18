using System;
using System.Runtime.CompilerServices;

namespace IKVM.ByteCode.Encoding
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
            OpCode(IKVM.ByteCode.OpCode.Nop);

            return this;
        }

        /// <summary>
        /// Encodes the 'aconst_null' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder AconstNull()
        {
            OpCode(IKVM.ByteCode.OpCode.AconstNull);

            return this;
        }

        /// <summary>
        /// Encodes the 'iconst_m1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IconstM1()
        {
            OpCode(IKVM.ByteCode.OpCode.IconstM1);

            return this;
        }

        /// <summary>
        /// Encodes the 'iconst_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iconst0()
        {
            OpCode(IKVM.ByteCode.OpCode.Iconst0);

            return this;
        }

        /// <summary>
        /// Encodes the 'iconst_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iconst1()
        {
            OpCode(IKVM.ByteCode.OpCode.Iconst1);

            return this;
        }

        /// <summary>
        /// Encodes the 'iconst_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iconst2()
        {
            OpCode(IKVM.ByteCode.OpCode.Iconst2);

            return this;
        }

        /// <summary>
        /// Encodes the 'iconst_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iconst3()
        {
            OpCode(IKVM.ByteCode.OpCode.Iconst3);

            return this;
        }

        /// <summary>
        /// Encodes the 'iconst_4' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iconst4()
        {
            OpCode(IKVM.ByteCode.OpCode.Iconst4);

            return this;
        }

        /// <summary>
        /// Encodes the 'iconst_5' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iconst5()
        {
            OpCode(IKVM.ByteCode.OpCode.Iconst5);

            return this;
        }

        /// <summary>
        /// Encodes the 'lconst_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lconst0()
        {
            OpCode(IKVM.ByteCode.OpCode.Lconst0);

            return this;
        }

        /// <summary>
        /// Encodes the 'lconst_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lconst1()
        {
            OpCode(IKVM.ByteCode.OpCode.Lconst1);

            return this;
        }

        /// <summary>
        /// Encodes the 'fconst_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fconst0()
        {
            OpCode(IKVM.ByteCode.OpCode.Fconst0);

            return this;
        }

        /// <summary>
        /// Encodes the 'fconst_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fconst1()
        {
            OpCode(IKVM.ByteCode.OpCode.Fconst1);

            return this;
        }

        /// <summary>
        /// Encodes the 'fconst_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fconst2()
        {
            OpCode(IKVM.ByteCode.OpCode.Fconst2);

            return this;
        }

        /// <summary>
        /// Encodes the 'dconst_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dconst0()
        {
            OpCode(IKVM.ByteCode.OpCode.Dconst0);

            return this;
        }

        /// <summary>
        /// Encodes the 'dconst_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dconst1()
        {
            OpCode(IKVM.ByteCode.OpCode.Dconst1);

            return this;
        }

        /// <summary>
        /// Encodes the 'bipush' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Bipush(sbyte value)
        {
            OpCode(IKVM.ByteCode.OpCode.Bipush);
            WriteS1(checked((sbyte)value));

            return this;
        }

        /// <summary>
        /// Encodes the 'sipush' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Sipush(short value)
        {
            OpCode(IKVM.ByteCode.OpCode.Sipush);
            WriteS2((short)value);

            return this;
        }

        /// <summary>
        /// Encodes the 'ldc' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ldc(ConstantHandle constant)
        {
            OpCode(IKVM.ByteCode.OpCode.Ldc);
            WriteC1((ConstantHandle)constant);

            return this;
        }

        /// <summary>
        /// Encodes the 'ldc_w' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder LdcW(ConstantHandle constant)
        {
            OpCode(IKVM.ByteCode.OpCode.LdcW);
            WriteC2((ConstantHandle)constant);

            return this;
        }

        /// <summary>
        /// Encodes the 'ldc2_w' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ldc2W(ConstantHandle constant)
        {
            OpCode(IKVM.ByteCode.OpCode.Ldc2W);
            WriteC2((ConstantHandle)constant);

            return this;
        }

        /// <summary>
        /// Encodes the 'iload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iload(ushort local)
        {
            var wide = false;

            if (local > byte.MaxValue || local < byte.MinValue)
                wide = true;

            if (wide)
            {
                OpCode(IKVM.ByteCode.OpCode.Wide);
                OpCode(IKVM.ByteCode.OpCode.Iload);
                WriteL2((ushort)local);
            }
            else
            {
                OpCode(IKVM.ByteCode.OpCode.Iload);
                WriteL1(checked((byte)local));
            }

            return this;
        }

        /// <summary>
        /// Encodes the 'lload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lload(ushort local)
        {
            var wide = false;

            if (local > byte.MaxValue || local < byte.MinValue)
                wide = true;

            if (wide)
            {
                OpCode(IKVM.ByteCode.OpCode.Wide);
                OpCode(IKVM.ByteCode.OpCode.Lload);
                WriteL2((ushort)local);
            }
            else
            {
                OpCode(IKVM.ByteCode.OpCode.Lload);
                WriteL1(checked((byte)local));
            }

            return this;
        }

        /// <summary>
        /// Encodes the 'fload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fload(ushort local)
        {
            var wide = false;

            if (local > byte.MaxValue || local < byte.MinValue)
                wide = true;

            if (wide)
            {
                OpCode(IKVM.ByteCode.OpCode.Wide);
                OpCode(IKVM.ByteCode.OpCode.Fload);
                WriteL2((ushort)local);
            }
            else
            {
                OpCode(IKVM.ByteCode.OpCode.Fload);
                WriteL1(checked((byte)local));
            }

            return this;
        }

        /// <summary>
        /// Encodes the 'dload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dload(ushort local)
        {
            var wide = false;

            if (local > byte.MaxValue || local < byte.MinValue)
                wide = true;

            if (wide)
            {
                OpCode(IKVM.ByteCode.OpCode.Wide);
                OpCode(IKVM.ByteCode.OpCode.Dload);
                WriteL2((ushort)local);
            }
            else
            {
                OpCode(IKVM.ByteCode.OpCode.Dload);
                WriteL1(checked((byte)local));
            }

            return this;
        }

        /// <summary>
        /// Encodes the 'aload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Aload(ushort local)
        {
            var wide = false;

            if (local > byte.MaxValue || local < byte.MinValue)
                wide = true;

            if (wide)
            {
                OpCode(IKVM.ByteCode.OpCode.Wide);
                OpCode(IKVM.ByteCode.OpCode.Aload);
                WriteL2((ushort)local);
            }
            else
            {
                OpCode(IKVM.ByteCode.OpCode.Aload);
                WriteL1(checked((byte)local));
            }

            return this;
        }

        /// <summary>
        /// Encodes the 'iload_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iload0()
        {
            OpCode(IKVM.ByteCode.OpCode.Iload0);

            return this;
        }

        /// <summary>
        /// Encodes the 'iload_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iload1()
        {
            OpCode(IKVM.ByteCode.OpCode.Iload1);

            return this;
        }

        /// <summary>
        /// Encodes the 'iload_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iload2()
        {
            OpCode(IKVM.ByteCode.OpCode.Iload2);

            return this;
        }

        /// <summary>
        /// Encodes the 'iload_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iload3()
        {
            OpCode(IKVM.ByteCode.OpCode.Iload3);

            return this;
        }

        /// <summary>
        /// Encodes the 'lload_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lload0()
        {
            OpCode(IKVM.ByteCode.OpCode.Lload0);

            return this;
        }

        /// <summary>
        /// Encodes the 'lload_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lload1()
        {
            OpCode(IKVM.ByteCode.OpCode.Lload1);

            return this;
        }

        /// <summary>
        /// Encodes the 'lload_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lload2()
        {
            OpCode(IKVM.ByteCode.OpCode.Lload2);

            return this;
        }

        /// <summary>
        /// Encodes the 'lload_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lload3()
        {
            OpCode(IKVM.ByteCode.OpCode.Lload3);

            return this;
        }

        /// <summary>
        /// Encodes the 'fload_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fload0()
        {
            OpCode(IKVM.ByteCode.OpCode.Fload0);

            return this;
        }

        /// <summary>
        /// Encodes the 'fload_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fload1()
        {
            OpCode(IKVM.ByteCode.OpCode.Fload1);

            return this;
        }

        /// <summary>
        /// Encodes the 'fload_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fload2()
        {
            OpCode(IKVM.ByteCode.OpCode.Fload2);

            return this;
        }

        /// <summary>
        /// Encodes the 'fload_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fload3()
        {
            OpCode(IKVM.ByteCode.OpCode.Fload3);

            return this;
        }

        /// <summary>
        /// Encodes the 'dload_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dload0()
        {
            OpCode(IKVM.ByteCode.OpCode.Dload0);

            return this;
        }

        /// <summary>
        /// Encodes the 'dload_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dload1()
        {
            OpCode(IKVM.ByteCode.OpCode.Dload1);

            return this;
        }

        /// <summary>
        /// Encodes the 'dload_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dload2()
        {
            OpCode(IKVM.ByteCode.OpCode.Dload2);

            return this;
        }

        /// <summary>
        /// Encodes the 'dload_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dload3()
        {
            OpCode(IKVM.ByteCode.OpCode.Dload3);

            return this;
        }

        /// <summary>
        /// Encodes the 'aload_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Aload0()
        {
            OpCode(IKVM.ByteCode.OpCode.Aload0);

            return this;
        }

        /// <summary>
        /// Encodes the 'aload_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Aload1()
        {
            OpCode(IKVM.ByteCode.OpCode.Aload1);

            return this;
        }

        /// <summary>
        /// Encodes the 'aload_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Aload2()
        {
            OpCode(IKVM.ByteCode.OpCode.Aload2);

            return this;
        }

        /// <summary>
        /// Encodes the 'aload_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Aload3()
        {
            OpCode(IKVM.ByteCode.OpCode.Aload3);

            return this;
        }

        /// <summary>
        /// Encodes the 'iaload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iaload()
        {
            OpCode(IKVM.ByteCode.OpCode.Iaload);

            return this;
        }

        /// <summary>
        /// Encodes the 'laload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Laload()
        {
            OpCode(IKVM.ByteCode.OpCode.Laload);

            return this;
        }

        /// <summary>
        /// Encodes the 'faload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Faload()
        {
            OpCode(IKVM.ByteCode.OpCode.Faload);

            return this;
        }

        /// <summary>
        /// Encodes the 'daload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Daload()
        {
            OpCode(IKVM.ByteCode.OpCode.Daload);

            return this;
        }

        /// <summary>
        /// Encodes the 'aaload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Aaload()
        {
            OpCode(IKVM.ByteCode.OpCode.Aaload);

            return this;
        }

        /// <summary>
        /// Encodes the 'baload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Baload()
        {
            OpCode(IKVM.ByteCode.OpCode.Baload);

            return this;
        }

        /// <summary>
        /// Encodes the 'caload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Caload()
        {
            OpCode(IKVM.ByteCode.OpCode.Caload);

            return this;
        }

        /// <summary>
        /// Encodes the 'saload' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Saload()
        {
            OpCode(IKVM.ByteCode.OpCode.Saload);

            return this;
        }

        /// <summary>
        /// Encodes the 'istore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Istore(ushort local)
        {
            var wide = false;

            if (local > byte.MaxValue || local < byte.MinValue)
                wide = true;

            if (wide)
            {
                OpCode(IKVM.ByteCode.OpCode.Wide);
                OpCode(IKVM.ByteCode.OpCode.Istore);
                WriteL2((ushort)local);
            }
            else
            {
                OpCode(IKVM.ByteCode.OpCode.Istore);
                WriteL1(checked((byte)local));
            }

            return this;
        }

        /// <summary>
        /// Encodes the 'lstore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lstore(ushort local)
        {
            var wide = false;

            if (local > byte.MaxValue || local < byte.MinValue)
                wide = true;

            if (wide)
            {
                OpCode(IKVM.ByteCode.OpCode.Wide);
                OpCode(IKVM.ByteCode.OpCode.Lstore);
                WriteL2((ushort)local);
            }
            else
            {
                OpCode(IKVM.ByteCode.OpCode.Lstore);
                WriteL1(checked((byte)local));
            }

            return this;
        }

        /// <summary>
        /// Encodes the 'fstore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fstore(ushort local)
        {
            var wide = false;

            if (local > byte.MaxValue || local < byte.MinValue)
                wide = true;

            if (wide)
            {
                OpCode(IKVM.ByteCode.OpCode.Wide);
                OpCode(IKVM.ByteCode.OpCode.Fstore);
                WriteL2((ushort)local);
            }
            else
            {
                OpCode(IKVM.ByteCode.OpCode.Fstore);
                WriteL1(checked((byte)local));
            }

            return this;
        }

        /// <summary>
        /// Encodes the 'dstore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dstore(ushort local)
        {
            var wide = false;

            if (local > byte.MaxValue || local < byte.MinValue)
                wide = true;

            if (wide)
            {
                OpCode(IKVM.ByteCode.OpCode.Wide);
                OpCode(IKVM.ByteCode.OpCode.Dstore);
                WriteL2((ushort)local);
            }
            else
            {
                OpCode(IKVM.ByteCode.OpCode.Dstore);
                WriteL1(checked((byte)local));
            }

            return this;
        }

        /// <summary>
        /// Encodes the 'astore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Astore(ushort local)
        {
            var wide = false;

            if (local > byte.MaxValue || local < byte.MinValue)
                wide = true;

            if (wide)
            {
                OpCode(IKVM.ByteCode.OpCode.Wide);
                OpCode(IKVM.ByteCode.OpCode.Astore);
                WriteL2((ushort)local);
            }
            else
            {
                OpCode(IKVM.ByteCode.OpCode.Astore);
                WriteL1(checked((byte)local));
            }

            return this;
        }

        /// <summary>
        /// Encodes the 'istore_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Istore0()
        {
            OpCode(IKVM.ByteCode.OpCode.Istore0);

            return this;
        }

        /// <summary>
        /// Encodes the 'istore_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Istore1()
        {
            OpCode(IKVM.ByteCode.OpCode.Istore1);

            return this;
        }

        /// <summary>
        /// Encodes the 'istore_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Istore2()
        {
            OpCode(IKVM.ByteCode.OpCode.Istore2);

            return this;
        }

        /// <summary>
        /// Encodes the 'istore_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Istore3()
        {
            OpCode(IKVM.ByteCode.OpCode.Istore3);

            return this;
        }

        /// <summary>
        /// Encodes the 'lstore_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lstore0()
        {
            OpCode(IKVM.ByteCode.OpCode.Lstore0);

            return this;
        }

        /// <summary>
        /// Encodes the 'lstore_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lstore1()
        {
            OpCode(IKVM.ByteCode.OpCode.Lstore1);

            return this;
        }

        /// <summary>
        /// Encodes the 'lstore_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lstore2()
        {
            OpCode(IKVM.ByteCode.OpCode.Lstore2);

            return this;
        }

        /// <summary>
        /// Encodes the 'lstore_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lstore3()
        {
            OpCode(IKVM.ByteCode.OpCode.Lstore3);

            return this;
        }

        /// <summary>
        /// Encodes the 'fstore_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fstore0()
        {
            OpCode(IKVM.ByteCode.OpCode.Fstore0);

            return this;
        }

        /// <summary>
        /// Encodes the 'fstore_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fstore1()
        {
            OpCode(IKVM.ByteCode.OpCode.Fstore1);

            return this;
        }

        /// <summary>
        /// Encodes the 'fstore_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fstore2()
        {
            OpCode(IKVM.ByteCode.OpCode.Fstore2);

            return this;
        }

        /// <summary>
        /// Encodes the 'fstore_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fstore3()
        {
            OpCode(IKVM.ByteCode.OpCode.Fstore3);

            return this;
        }

        /// <summary>
        /// Encodes the 'dstore_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dstore0()
        {
            OpCode(IKVM.ByteCode.OpCode.Dstore0);

            return this;
        }

        /// <summary>
        /// Encodes the 'dstore_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dstore1()
        {
            OpCode(IKVM.ByteCode.OpCode.Dstore1);

            return this;
        }

        /// <summary>
        /// Encodes the 'dstore_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dstore2()
        {
            OpCode(IKVM.ByteCode.OpCode.Dstore2);

            return this;
        }

        /// <summary>
        /// Encodes the 'dstore_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dstore3()
        {
            OpCode(IKVM.ByteCode.OpCode.Dstore3);

            return this;
        }

        /// <summary>
        /// Encodes the 'astore_0' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Astore0()
        {
            OpCode(IKVM.ByteCode.OpCode.Astore0);

            return this;
        }

        /// <summary>
        /// Encodes the 'astore_1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Astore1()
        {
            OpCode(IKVM.ByteCode.OpCode.Astore1);

            return this;
        }

        /// <summary>
        /// Encodes the 'astore_2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Astore2()
        {
            OpCode(IKVM.ByteCode.OpCode.Astore2);

            return this;
        }

        /// <summary>
        /// Encodes the 'astore_3' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Astore3()
        {
            OpCode(IKVM.ByteCode.OpCode.Astore3);

            return this;
        }

        /// <summary>
        /// Encodes the 'iastore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iastore()
        {
            OpCode(IKVM.ByteCode.OpCode.Iastore);

            return this;
        }

        /// <summary>
        /// Encodes the 'lastore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lastore()
        {
            OpCode(IKVM.ByteCode.OpCode.Lastore);

            return this;
        }

        /// <summary>
        /// Encodes the 'fastore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fastore()
        {
            OpCode(IKVM.ByteCode.OpCode.Fastore);

            return this;
        }

        /// <summary>
        /// Encodes the 'dastore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dastore()
        {
            OpCode(IKVM.ByteCode.OpCode.Dastore);

            return this;
        }

        /// <summary>
        /// Encodes the 'aastore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Aastore()
        {
            OpCode(IKVM.ByteCode.OpCode.Aastore);

            return this;
        }

        /// <summary>
        /// Encodes the 'bastore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Bastore()
        {
            OpCode(IKVM.ByteCode.OpCode.Bastore);

            return this;
        }

        /// <summary>
        /// Encodes the 'castore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Castore()
        {
            OpCode(IKVM.ByteCode.OpCode.Castore);

            return this;
        }

        /// <summary>
        /// Encodes the 'sastore' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Sastore()
        {
            OpCode(IKVM.ByteCode.OpCode.Sastore);

            return this;
        }

        /// <summary>
        /// Encodes the 'pop' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Pop()
        {
            OpCode(IKVM.ByteCode.OpCode.Pop);

            return this;
        }

        /// <summary>
        /// Encodes the 'pop2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Pop2()
        {
            OpCode(IKVM.ByteCode.OpCode.Pop2);

            return this;
        }

        /// <summary>
        /// Encodes the 'dup' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dup()
        {
            OpCode(IKVM.ByteCode.OpCode.Dup);

            return this;
        }

        /// <summary>
        /// Encodes the 'dup_x1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder DupX1()
        {
            OpCode(IKVM.ByteCode.OpCode.DupX1);

            return this;
        }

        /// <summary>
        /// Encodes the 'dup_x2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder DupX2()
        {
            OpCode(IKVM.ByteCode.OpCode.DupX2);

            return this;
        }

        /// <summary>
        /// Encodes the 'dup2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dup2()
        {
            OpCode(IKVM.ByteCode.OpCode.Dup2);

            return this;
        }

        /// <summary>
        /// Encodes the 'dup2_x1' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dup2X1()
        {
            OpCode(IKVM.ByteCode.OpCode.Dup2X1);

            return this;
        }

        /// <summary>
        /// Encodes the 'dup2_x2' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dup2X2()
        {
            OpCode(IKVM.ByteCode.OpCode.Dup2X2);

            return this;
        }

        /// <summary>
        /// Encodes the 'swap' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Swap()
        {
            OpCode(IKVM.ByteCode.OpCode.Swap);

            return this;
        }

        /// <summary>
        /// Encodes the 'iadd' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iadd()
        {
            OpCode(IKVM.ByteCode.OpCode.Iadd);

            return this;
        }

        /// <summary>
        /// Encodes the 'ladd' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ladd()
        {
            OpCode(IKVM.ByteCode.OpCode.Ladd);

            return this;
        }

        /// <summary>
        /// Encodes the 'fadd' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fadd()
        {
            OpCode(IKVM.ByteCode.OpCode.Fadd);

            return this;
        }

        /// <summary>
        /// Encodes the 'dadd' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dadd()
        {
            OpCode(IKVM.ByteCode.OpCode.Dadd);

            return this;
        }

        /// <summary>
        /// Encodes the 'isub' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Isub()
        {
            OpCode(IKVM.ByteCode.OpCode.Isub);

            return this;
        }

        /// <summary>
        /// Encodes the 'lsub' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lsub()
        {
            OpCode(IKVM.ByteCode.OpCode.Lsub);

            return this;
        }

        /// <summary>
        /// Encodes the 'fsub' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fsub()
        {
            OpCode(IKVM.ByteCode.OpCode.Fsub);

            return this;
        }

        /// <summary>
        /// Encodes the 'dsub' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dsub()
        {
            OpCode(IKVM.ByteCode.OpCode.Dsub);

            return this;
        }

        /// <summary>
        /// Encodes the 'imul' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Imul()
        {
            OpCode(IKVM.ByteCode.OpCode.Imul);

            return this;
        }

        /// <summary>
        /// Encodes the 'lmul' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lmul()
        {
            OpCode(IKVM.ByteCode.OpCode.Lmul);

            return this;
        }

        /// <summary>
        /// Encodes the 'fmul' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fmul()
        {
            OpCode(IKVM.ByteCode.OpCode.Fmul);

            return this;
        }

        /// <summary>
        /// Encodes the 'dmul' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dmul()
        {
            OpCode(IKVM.ByteCode.OpCode.Dmul);

            return this;
        }

        /// <summary>
        /// Encodes the 'idiv' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Idiv()
        {
            OpCode(IKVM.ByteCode.OpCode.Idiv);

            return this;
        }

        /// <summary>
        /// Encodes the 'ldiv' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ldiv()
        {
            OpCode(IKVM.ByteCode.OpCode.Ldiv);

            return this;
        }

        /// <summary>
        /// Encodes the 'fdiv' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fdiv()
        {
            OpCode(IKVM.ByteCode.OpCode.Fdiv);

            return this;
        }

        /// <summary>
        /// Encodes the 'ddiv' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ddiv()
        {
            OpCode(IKVM.ByteCode.OpCode.Ddiv);

            return this;
        }

        /// <summary>
        /// Encodes the 'irem' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Irem()
        {
            OpCode(IKVM.ByteCode.OpCode.Irem);

            return this;
        }

        /// <summary>
        /// Encodes the 'lrem' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lrem()
        {
            OpCode(IKVM.ByteCode.OpCode.Lrem);

            return this;
        }

        /// <summary>
        /// Encodes the 'frem' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Frem()
        {
            OpCode(IKVM.ByteCode.OpCode.Frem);

            return this;
        }

        /// <summary>
        /// Encodes the 'drem' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Drem()
        {
            OpCode(IKVM.ByteCode.OpCode.Drem);

            return this;
        }

        /// <summary>
        /// Encodes the 'ineg' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ineg()
        {
            OpCode(IKVM.ByteCode.OpCode.Ineg);

            return this;
        }

        /// <summary>
        /// Encodes the 'lneg' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lneg()
        {
            OpCode(IKVM.ByteCode.OpCode.Lneg);

            return this;
        }

        /// <summary>
        /// Encodes the 'fneg' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fneg()
        {
            OpCode(IKVM.ByteCode.OpCode.Fneg);

            return this;
        }

        /// <summary>
        /// Encodes the 'dneg' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dneg()
        {
            OpCode(IKVM.ByteCode.OpCode.Dneg);

            return this;
        }

        /// <summary>
        /// Encodes the 'ishl' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ishl()
        {
            OpCode(IKVM.ByteCode.OpCode.Ishl);

            return this;
        }

        /// <summary>
        /// Encodes the 'lshl' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lshl()
        {
            OpCode(IKVM.ByteCode.OpCode.Lshl);

            return this;
        }

        /// <summary>
        /// Encodes the 'ishr' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ishr()
        {
            OpCode(IKVM.ByteCode.OpCode.Ishr);

            return this;
        }

        /// <summary>
        /// Encodes the 'lshr' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lshr()
        {
            OpCode(IKVM.ByteCode.OpCode.Lshr);

            return this;
        }

        /// <summary>
        /// Encodes the 'iushr' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iushr()
        {
            OpCode(IKVM.ByteCode.OpCode.Iushr);

            return this;
        }

        /// <summary>
        /// Encodes the 'lushr' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lushr()
        {
            OpCode(IKVM.ByteCode.OpCode.Lushr);

            return this;
        }

        /// <summary>
        /// Encodes the 'iand' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iand()
        {
            OpCode(IKVM.ByteCode.OpCode.Iand);

            return this;
        }

        /// <summary>
        /// Encodes the 'land' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Land()
        {
            OpCode(IKVM.ByteCode.OpCode.Land);

            return this;
        }

        /// <summary>
        /// Encodes the 'ior' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ior()
        {
            OpCode(IKVM.ByteCode.OpCode.Ior);

            return this;
        }

        /// <summary>
        /// Encodes the 'lor' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lor()
        {
            OpCode(IKVM.ByteCode.OpCode.Lor);

            return this;
        }

        /// <summary>
        /// Encodes the 'ixor' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ixor()
        {
            OpCode(IKVM.ByteCode.OpCode.Ixor);

            return this;
        }

        /// <summary>
        /// Encodes the 'lxor' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lxor()
        {
            OpCode(IKVM.ByteCode.OpCode.Lxor);

            return this;
        }

        /// <summary>
        /// Encodes the 'iinc' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iinc(ushort local, short value)
        {
            var wide = false;

            if (local > byte.MaxValue || local < byte.MinValue)
                wide = true;

            if (value > sbyte.MaxValue || value < sbyte.MinValue)
                wide = true;

            if (wide)
            {
                OpCode(IKVM.ByteCode.OpCode.Wide);
                OpCode(IKVM.ByteCode.OpCode.Iinc);
                WriteL2((ushort)local);
                WriteS2((short)value);
            }
            else
            {
                OpCode(IKVM.ByteCode.OpCode.Iinc);
                WriteL1(checked((byte)local));
                WriteS1(checked((sbyte)value));
            }

            return this;
        }

        /// <summary>
        /// Encodes the 'i2l' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder I2l()
        {
            OpCode(IKVM.ByteCode.OpCode.I2l);

            return this;
        }

        /// <summary>
        /// Encodes the 'i2f' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder I2f()
        {
            OpCode(IKVM.ByteCode.OpCode.I2f);

            return this;
        }

        /// <summary>
        /// Encodes the 'i2d' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder I2d()
        {
            OpCode(IKVM.ByteCode.OpCode.I2d);

            return this;
        }

        /// <summary>
        /// Encodes the 'l2i' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder L2i()
        {
            OpCode(IKVM.ByteCode.OpCode.L2i);

            return this;
        }

        /// <summary>
        /// Encodes the 'l2f' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder L2f()
        {
            OpCode(IKVM.ByteCode.OpCode.L2f);

            return this;
        }

        /// <summary>
        /// Encodes the 'l2d' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder L2d()
        {
            OpCode(IKVM.ByteCode.OpCode.L2d);

            return this;
        }

        /// <summary>
        /// Encodes the 'f2i' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder F2i()
        {
            OpCode(IKVM.ByteCode.OpCode.F2i);

            return this;
        }

        /// <summary>
        /// Encodes the 'f2l' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder F2l()
        {
            OpCode(IKVM.ByteCode.OpCode.F2l);

            return this;
        }

        /// <summary>
        /// Encodes the 'f2d' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder F2d()
        {
            OpCode(IKVM.ByteCode.OpCode.F2d);

            return this;
        }

        /// <summary>
        /// Encodes the 'd2i' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder D2i()
        {
            OpCode(IKVM.ByteCode.OpCode.D2i);

            return this;
        }

        /// <summary>
        /// Encodes the 'd2l' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder D2l()
        {
            OpCode(IKVM.ByteCode.OpCode.D2l);

            return this;
        }

        /// <summary>
        /// Encodes the 'd2f' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder D2f()
        {
            OpCode(IKVM.ByteCode.OpCode.D2f);

            return this;
        }

        /// <summary>
        /// Encodes the 'i2b' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder I2b()
        {
            OpCode(IKVM.ByteCode.OpCode.I2b);

            return this;
        }

        /// <summary>
        /// Encodes the 'i2c' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder I2c()
        {
            OpCode(IKVM.ByteCode.OpCode.I2c);

            return this;
        }

        /// <summary>
        /// Encodes the 'i2s' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder I2s()
        {
            OpCode(IKVM.ByteCode.OpCode.I2s);

            return this;
        }

        /// <summary>
        /// Encodes the 'lcmp' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lcmp()
        {
            OpCode(IKVM.ByteCode.OpCode.Lcmp);

            return this;
        }

        /// <summary>
        /// Encodes the 'fcmpl' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fcmpl()
        {
            OpCode(IKVM.ByteCode.OpCode.Fcmpl);

            return this;
        }

        /// <summary>
        /// Encodes the 'fcmpg' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Fcmpg()
        {
            OpCode(IKVM.ByteCode.OpCode.Fcmpg);

            return this;
        }

        /// <summary>
        /// Encodes the 'dcmpl' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dcmpl()
        {
            OpCode(IKVM.ByteCode.OpCode.Dcmpl);

            return this;
        }

        /// <summary>
        /// Encodes the 'dcmpg' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dcmpg()
        {
            OpCode(IKVM.ByteCode.OpCode.Dcmpg);

            return this;
        }

        /// <summary>
        /// Encodes the 'ifeq' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ifeq(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.Ifeq);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'ifne' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ifne(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.Ifne);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'iflt' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Iflt(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.Iflt);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'ifge' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ifge(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.Ifge);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'ifgt' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ifgt(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.Ifgt);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'ifle' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ifle(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.Ifle);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'if_icmpeq' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfIcmpeq(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.IfIcmpeq);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'if_icmpne' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfIcmpne(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.IfIcmpne);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'if_icmplt' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfIcmplt(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.IfIcmplt);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'if_icmpge' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfIcmpge(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.IfIcmpge);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'if_icmpgt' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfIcmpgt(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.IfIcmpgt);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'if_icmple' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfIcmple(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.IfIcmple);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'if_acmpeq' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfAcmpeq(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.IfAcmpeq);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'if_acmpne' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfAcmpne(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.IfAcmpne);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'goto' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Goto(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.Goto);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'jsr' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Jsr(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.Jsr);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'ret' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ret(ushort local)
        {
            var wide = false;

            if (local > byte.MaxValue || local < byte.MinValue)
                wide = true;

            if (wide)
            {
                OpCode(IKVM.ByteCode.OpCode.Wide);
                OpCode(IKVM.ByteCode.OpCode.Ret);
                WriteL2((ushort)local);
            }
            else
            {
                OpCode(IKVM.ByteCode.OpCode.Ret);
                WriteL1(checked((byte)local));
            }

            return this;
        }

        /// <summary>
        /// Encodes the 'ireturn' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Ireturn()
        {
            OpCode(IKVM.ByteCode.OpCode.Ireturn);

            return this;
        }

        /// <summary>
        /// Encodes the 'lreturn' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Lreturn()
        {
            OpCode(IKVM.ByteCode.OpCode.Lreturn);

            return this;
        }

        /// <summary>
        /// Encodes the 'freturn' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Freturn()
        {
            OpCode(IKVM.ByteCode.OpCode.Freturn);

            return this;
        }

        /// <summary>
        /// Encodes the 'dreturn' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Dreturn()
        {
            OpCode(IKVM.ByteCode.OpCode.Dreturn);

            return this;
        }

        /// <summary>
        /// Encodes the 'areturn' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Areturn()
        {
            OpCode(IKVM.ByteCode.OpCode.Areturn);

            return this;
        }

        /// <summary>
        /// Encodes the 'return' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Return()
        {
            OpCode(IKVM.ByteCode.OpCode.Return);

            return this;
        }

        /// <summary>
        /// Encodes the 'getstatic' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder GetStatic(ConstantHandle field)
        {
            OpCode(IKVM.ByteCode.OpCode.GetStatic);
            WriteC2((ConstantHandle)field);

            return this;
        }

        /// <summary>
        /// Encodes the 'putstatic' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder PutStatic(ConstantHandle field)
        {
            OpCode(IKVM.ByteCode.OpCode.PutStatic);
            WriteC2((ConstantHandle)field);

            return this;
        }

        /// <summary>
        /// Encodes the 'getfield' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder GetField(ConstantHandle field)
        {
            OpCode(IKVM.ByteCode.OpCode.GetField);
            WriteC2((ConstantHandle)field);

            return this;
        }

        /// <summary>
        /// Encodes the 'putfield' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder PutField(ConstantHandle field)
        {
            OpCode(IKVM.ByteCode.OpCode.PutField);
            WriteC2((ConstantHandle)field);

            return this;
        }

        /// <summary>
        /// Encodes the 'invokevirtual' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder InvokeVirtual(ConstantHandle method)
        {
            OpCode(IKVM.ByteCode.OpCode.InvokeVirtual);
            WriteC2((ConstantHandle)method);

            return this;
        }

        /// <summary>
        /// Encodes the 'invokespecial' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder InvokeSpecial(ConstantHandle method)
        {
            OpCode(IKVM.ByteCode.OpCode.InvokeSpecial);
            WriteC2((ConstantHandle)method);

            return this;
        }

        /// <summary>
        /// Encodes the 'invokestatic' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder InvokeStatic(ConstantHandle method)
        {
            OpCode(IKVM.ByteCode.OpCode.InvokeStatic);
            WriteC2((ConstantHandle)method);

            return this;
        }

        /// <summary>
        /// Encodes the 'invokeinterface' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder InvokeInterface(ConstantHandle method, byte count, byte zero)
        {
            OpCode(IKVM.ByteCode.OpCode.InvokeInterface);
            WriteC2((ConstantHandle)method);
            WriteU1((byte)count);
            WriteU1((byte)zero);

            return this;
        }

        /// <summary>
        /// Encodes the 'invokedynamic' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder InvokeDynamic(ConstantHandle method, byte zero, byte zero2)
        {
            OpCode(IKVM.ByteCode.OpCode.InvokeDynamic);
            WriteC2((ConstantHandle)method);
            WriteU1((byte)zero);
            WriteU1((byte)zero2);

            return this;
        }

        /// <summary>
        /// Encodes the 'new' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder New(ConstantHandle constant)
        {
            OpCode(IKVM.ByteCode.OpCode.New);
            WriteC2((ConstantHandle)constant);

            return this;
        }

        /// <summary>
        /// Encodes the 'newarray' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Newarray(byte value)
        {
            OpCode(IKVM.ByteCode.OpCode.Newarray);
            WriteU1((byte)value);

            return this;
        }

        /// <summary>
        /// Encodes the 'anewarray' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Anewarray(ConstantHandle constant)
        {
            OpCode(IKVM.ByteCode.OpCode.Anewarray);
            WriteC2((ConstantHandle)constant);

            return this;
        }

        /// <summary>
        /// Encodes the 'arraylength' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Arraylength()
        {
            OpCode(IKVM.ByteCode.OpCode.Arraylength);

            return this;
        }

        /// <summary>
        /// Encodes the 'athrow' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Athrow()
        {
            OpCode(IKVM.ByteCode.OpCode.Athrow);

            return this;
        }

        /// <summary>
        /// Encodes the 'checkcast' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Checkcast(ConstantHandle type)
        {
            OpCode(IKVM.ByteCode.OpCode.Checkcast);
            WriteC2((ConstantHandle)type);

            return this;
        }

        /// <summary>
        /// Encodes the 'instanceof' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder InstanceOf(ConstantHandle type)
        {
            OpCode(IKVM.ByteCode.OpCode.InstanceOf);
            WriteC2((ConstantHandle)type);

            return this;
        }

        /// <summary>
        /// Encodes the 'monitorenter' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder MonitorEnter()
        {
            OpCode(IKVM.ByteCode.OpCode.MonitorEnter);

            return this;
        }

        /// <summary>
        /// Encodes the 'monitorexit' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder MonitorExit()
        {
            OpCode(IKVM.ByteCode.OpCode.MonitorExit);

            return this;
        }

        /// <summary>
        /// Encodes the 'wide' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Wide()
        {
            OpCode(IKVM.ByteCode.OpCode.Wide);

            return this;
        }

        /// <summary>
        /// Encodes the 'multianewarray' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder Multianewarray(ConstantHandle type, byte dimensions)
        {
            OpCode(IKVM.ByteCode.OpCode.Multianewarray);
            WriteC2((ConstantHandle)type);
            WriteU1((byte)dimensions);

            return this;
        }

        /// <summary>
        /// Encodes the 'ifnull' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfNull(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.IfNull);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'ifnonnull' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder IfNonNull(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.IfNonNull);
            Label((LabelHandle)target, false, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'goto_w' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder GotoW(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.GotoW);
            Label((LabelHandle)target, true, _offset);

            return this;
        }

        /// <summary>
        /// Encodes the 'jsr_w' opcode.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CodeBuilder JsrW(LabelHandle target)
        {
            var _offset = Offset;
            OpCode(IKVM.ByteCode.OpCode.JsrW);
            Label((LabelHandle)target, true, _offset);

            return this;
        }


    }

}
