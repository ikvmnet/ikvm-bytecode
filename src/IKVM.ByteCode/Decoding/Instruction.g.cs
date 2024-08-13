using System;
using System.Buffers;
using System.Runtime.CompilerServices;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Decoding
{

    public readonly partial record struct Instruction
    {
    
        /// <summary>
        /// Attempts to measure the instruction at the current position.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="opcode"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasureInstruction(ref SequenceReader<byte> reader, OpCode opcode, ref int size)
        {
            switch (opcode)
            {
                case OpCode.Nop:
                    return NopInstruction.TryMeasure(ref reader, ref size);
                case OpCode.AconstNull:
                    return AconstNullInstruction.TryMeasure(ref reader, ref size);
                case OpCode.IconstM1:
                    return IconstM1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Iconst0:
                    return Iconst0Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Iconst1:
                    return Iconst1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Iconst2:
                    return Iconst2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Iconst3:
                    return Iconst3Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Iconst4:
                    return Iconst4Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Iconst5:
                    return Iconst5Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Lconst0:
                    return Lconst0Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Lconst1:
                    return Lconst1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Fconst0:
                    return Fconst0Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Fconst1:
                    return Fconst1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Fconst2:
                    return Fconst2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Dconst0:
                    return Dconst0Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Dconst1:
                    return Dconst1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Bipush:
                    return BipushInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Sipush:
                    return SipushInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ldc:
                    return LdcInstruction.TryMeasure(ref reader, ref size);
                case OpCode.LdcW:
                    return LdcWInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ldc2W:
                    return Ldc2WInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Iload:
                    return IloadInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Lload:
                    return LloadInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Fload:
                    return FloadInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Dload:
                    return DloadInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Aload:
                    return AloadInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Iload0:
                    return Iload0Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Iload1:
                    return Iload1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Iload2:
                    return Iload2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Iload3:
                    return Iload3Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Lload0:
                    return Lload0Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Lload1:
                    return Lload1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Lload2:
                    return Lload2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Lload3:
                    return Lload3Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Fload0:
                    return Fload0Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Fload1:
                    return Fload1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Fload2:
                    return Fload2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Fload3:
                    return Fload3Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Dload0:
                    return Dload0Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Dload1:
                    return Dload1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Dload2:
                    return Dload2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Dload3:
                    return Dload3Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Aload0:
                    return Aload0Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Aload1:
                    return Aload1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Aload2:
                    return Aload2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Aload3:
                    return Aload3Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Iaload:
                    return IaloadInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Laload:
                    return LaloadInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Faload:
                    return FaloadInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Daload:
                    return DaloadInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Aaload:
                    return AaloadInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Baload:
                    return BaloadInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Caload:
                    return CaloadInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Saload:
                    return SaloadInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Istore:
                    return IstoreInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Lstore:
                    return LstoreInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Fstore:
                    return FstoreInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Dstore:
                    return DstoreInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Astore:
                    return AstoreInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Istore0:
                    return Istore0Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Istore1:
                    return Istore1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Istore2:
                    return Istore2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Istore3:
                    return Istore3Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Lstore0:
                    return Lstore0Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Lstore1:
                    return Lstore1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Lstore2:
                    return Lstore2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Lstore3:
                    return Lstore3Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Fstore0:
                    return Fstore0Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Fstore1:
                    return Fstore1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Fstore2:
                    return Fstore2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Fstore3:
                    return Fstore3Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Dstore0:
                    return Dstore0Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Dstore1:
                    return Dstore1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Dstore2:
                    return Dstore2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Dstore3:
                    return Dstore3Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Astore0:
                    return Astore0Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Astore1:
                    return Astore1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Astore2:
                    return Astore2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Astore3:
                    return Astore3Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Iastore:
                    return IastoreInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Lastore:
                    return LastoreInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Fastore:
                    return FastoreInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Dastore:
                    return DastoreInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Aastore:
                    return AastoreInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Bastore:
                    return BastoreInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Castore:
                    return CastoreInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Sastore:
                    return SastoreInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Pop:
                    return PopInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Pop2:
                    return Pop2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Dup:
                    return DupInstruction.TryMeasure(ref reader, ref size);
                case OpCode.DupX1:
                    return DupX1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.DupX2:
                    return DupX2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Dup2:
                    return Dup2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Dup2X1:
                    return Dup2X1Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Dup2X2:
                    return Dup2X2Instruction.TryMeasure(ref reader, ref size);
                case OpCode.Swap:
                    return SwapInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Iadd:
                    return IaddInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ladd:
                    return LaddInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Fadd:
                    return FaddInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Dadd:
                    return DaddInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Isub:
                    return IsubInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Lsub:
                    return LsubInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Fsub:
                    return FsubInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Dsub:
                    return DsubInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Imul:
                    return ImulInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Lmul:
                    return LmulInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Fmul:
                    return FmulInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Dmul:
                    return DmulInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Idiv:
                    return IdivInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ldiv:
                    return LdivInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Fdiv:
                    return FdivInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ddiv:
                    return DdivInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Irem:
                    return IremInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Lrem:
                    return LremInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Frem:
                    return FremInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Drem:
                    return DremInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ineg:
                    return InegInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Lneg:
                    return LnegInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Fneg:
                    return FnegInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Dneg:
                    return DnegInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ishl:
                    return IshlInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Lshl:
                    return LshlInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ishr:
                    return IshrInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Lshr:
                    return LshrInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Iushr:
                    return IushrInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Lushr:
                    return LushrInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Iand:
                    return IandInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Land:
                    return LandInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ior:
                    return IorInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Lor:
                    return LorInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ixor:
                    return IxorInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Lxor:
                    return LxorInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Iinc:
                    return IincInstruction.TryMeasure(ref reader, ref size);
                case OpCode.I2l:
                    return I2lInstruction.TryMeasure(ref reader, ref size);
                case OpCode.I2f:
                    return I2fInstruction.TryMeasure(ref reader, ref size);
                case OpCode.I2d:
                    return I2dInstruction.TryMeasure(ref reader, ref size);
                case OpCode.L2i:
                    return L2iInstruction.TryMeasure(ref reader, ref size);
                case OpCode.L2f:
                    return L2fInstruction.TryMeasure(ref reader, ref size);
                case OpCode.L2d:
                    return L2dInstruction.TryMeasure(ref reader, ref size);
                case OpCode.F2i:
                    return F2iInstruction.TryMeasure(ref reader, ref size);
                case OpCode.F2l:
                    return F2lInstruction.TryMeasure(ref reader, ref size);
                case OpCode.F2d:
                    return F2dInstruction.TryMeasure(ref reader, ref size);
                case OpCode.D2i:
                    return D2iInstruction.TryMeasure(ref reader, ref size);
                case OpCode.D2l:
                    return D2lInstruction.TryMeasure(ref reader, ref size);
                case OpCode.D2f:
                    return D2fInstruction.TryMeasure(ref reader, ref size);
                case OpCode.I2b:
                    return I2bInstruction.TryMeasure(ref reader, ref size);
                case OpCode.I2c:
                    return I2cInstruction.TryMeasure(ref reader, ref size);
                case OpCode.I2s:
                    return I2sInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Lcmp:
                    return LcmpInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Fcmpl:
                    return FcmplInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Fcmpg:
                    return FcmpgInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Dcmpl:
                    return DcmplInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Dcmpg:
                    return DcmpgInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ifeq:
                    return IfeqInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ifne:
                    return IfneInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Iflt:
                    return IfltInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ifge:
                    return IfgeInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ifgt:
                    return IfgtInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ifle:
                    return IfleInstruction.TryMeasure(ref reader, ref size);
                case OpCode.IfIcmpeq:
                    return IfIcmpeqInstruction.TryMeasure(ref reader, ref size);
                case OpCode.IfIcmpne:
                    return IfIcmpneInstruction.TryMeasure(ref reader, ref size);
                case OpCode.IfIcmplt:
                    return IfIcmpltInstruction.TryMeasure(ref reader, ref size);
                case OpCode.IfIcmpge:
                    return IfIcmpgeInstruction.TryMeasure(ref reader, ref size);
                case OpCode.IfIcmpgt:
                    return IfIcmpgtInstruction.TryMeasure(ref reader, ref size);
                case OpCode.IfIcmple:
                    return IfIcmpleInstruction.TryMeasure(ref reader, ref size);
                case OpCode.IfAcmpeq:
                    return IfAcmpeqInstruction.TryMeasure(ref reader, ref size);
                case OpCode.IfAcmpne:
                    return IfAcmpneInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Goto:
                    return GotoInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Jsr:
                    return JsrInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ret:
                    return RetInstruction.TryMeasure(ref reader, ref size);
                case OpCode.TableSwitch:
                    return TableSwitchInstruction.TryMeasure(ref reader, ref size);
                case OpCode.LookupSwitch:
                    return LookupSwitchInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Ireturn:
                    return IreturnInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Lreturn:
                    return LreturnInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Freturn:
                    return FreturnInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Dreturn:
                    return DreturnInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Areturn:
                    return AreturnInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Return:
                    return ReturnInstruction.TryMeasure(ref reader, ref size);
                case OpCode.GetStatic:
                    return GetStaticInstruction.TryMeasure(ref reader, ref size);
                case OpCode.PutStatic:
                    return PutStaticInstruction.TryMeasure(ref reader, ref size);
                case OpCode.GetField:
                    return GetFieldInstruction.TryMeasure(ref reader, ref size);
                case OpCode.PutField:
                    return PutFieldInstruction.TryMeasure(ref reader, ref size);
                case OpCode.InvokeVirtual:
                    return InvokeVirtualInstruction.TryMeasure(ref reader, ref size);
                case OpCode.InvokeSpecial:
                    return InvokeSpecialInstruction.TryMeasure(ref reader, ref size);
                case OpCode.InvokeStatic:
                    return InvokeStaticInstruction.TryMeasure(ref reader, ref size);
                case OpCode.InvokeInterface:
                    return InvokeInterfaceInstruction.TryMeasure(ref reader, ref size);
                case OpCode.InvokeDynamic:
                    return InvokeDynamicInstruction.TryMeasure(ref reader, ref size);
                case OpCode.New:
                    return NewInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Newarray:
                    return NewarrayInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Anewarray:
                    return AnewarrayInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Arraylength:
                    return ArraylengthInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Athrow:
                    return AthrowInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Checkcast:
                    return CheckcastInstruction.TryMeasure(ref reader, ref size);
                case OpCode.InstanceOf:
                    return InstanceOfInstruction.TryMeasure(ref reader, ref size);
                case OpCode.MonitorEnter:
                    return MonitorEnterInstruction.TryMeasure(ref reader, ref size);
                case OpCode.MonitorExit:
                    return MonitorExitInstruction.TryMeasure(ref reader, ref size);
                case OpCode.Multianewarray:
                    return MultianewarrayInstruction.TryMeasure(ref reader, ref size);
                case OpCode.IfNull:
                    return IfNullInstruction.TryMeasure(ref reader, ref size);
                case OpCode.IfNonNull:
                    return IfNonNullInstruction.TryMeasure(ref reader, ref size);
                case OpCode.GotoW:
                    return GotoWInstruction.TryMeasure(ref reader, ref size);
                case OpCode.JsrW:
                    return JsrWInstruction.TryMeasure(ref reader, ref size);
                default:
                    throw new InvalidCodeException("Unsupported or unexpected instruction.");
            }
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="NopInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NopInstruction AsNop()
        {
            if (OpCode != OpCode.Nop)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Nop'.");

            if (NopInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AconstNullInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AconstNullInstruction AsAconstNull()
        {
            if (OpCode != OpCode.AconstNull)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'AconstNull'.");

            if (AconstNullInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IconstM1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IconstM1Instruction AsIconstM1()
        {
            if (OpCode != OpCode.IconstM1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'IconstM1'.");

            if (IconstM1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iconst0Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Iconst0Instruction AsIconst0()
        {
            if (OpCode != OpCode.Iconst0)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iconst0'.");

            if (Iconst0Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iconst1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Iconst1Instruction AsIconst1()
        {
            if (OpCode != OpCode.Iconst1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iconst1'.");

            if (Iconst1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iconst2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Iconst2Instruction AsIconst2()
        {
            if (OpCode != OpCode.Iconst2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iconst2'.");

            if (Iconst2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iconst3Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Iconst3Instruction AsIconst3()
        {
            if (OpCode != OpCode.Iconst3)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iconst3'.");

            if (Iconst3Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iconst4Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Iconst4Instruction AsIconst4()
        {
            if (OpCode != OpCode.Iconst4)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iconst4'.");

            if (Iconst4Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iconst5Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Iconst5Instruction AsIconst5()
        {
            if (OpCode != OpCode.Iconst5)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iconst5'.");

            if (Iconst5Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lconst0Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Lconst0Instruction AsLconst0()
        {
            if (OpCode != OpCode.Lconst0)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lconst0'.");

            if (Lconst0Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lconst1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Lconst1Instruction AsLconst1()
        {
            if (OpCode != OpCode.Lconst1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lconst1'.");

            if (Lconst1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fconst0Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Fconst0Instruction AsFconst0()
        {
            if (OpCode != OpCode.Fconst0)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fconst0'.");

            if (Fconst0Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fconst1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Fconst1Instruction AsFconst1()
        {
            if (OpCode != OpCode.Fconst1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fconst1'.");

            if (Fconst1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fconst2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Fconst2Instruction AsFconst2()
        {
            if (OpCode != OpCode.Fconst2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fconst2'.");

            if (Fconst2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dconst0Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dconst0Instruction AsDconst0()
        {
            if (OpCode != OpCode.Dconst0)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dconst0'.");

            if (Dconst0Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dconst1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dconst1Instruction AsDconst1()
        {
            if (OpCode != OpCode.Dconst1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dconst1'.");

            if (Dconst1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="BipushInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BipushInstruction AsBipush()
        {
            if (OpCode != OpCode.Bipush)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Bipush'.");

            if (BipushInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="SipushInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SipushInstruction AsSipush()
        {
            if (OpCode != OpCode.Sipush)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Sipush'.");

            if (SipushInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LdcInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LdcInstruction AsLdc()
        {
            if (OpCode != OpCode.Ldc)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ldc'.");

            if (LdcInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LdcWInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LdcWInstruction AsLdcW()
        {
            if (OpCode != OpCode.LdcW)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'LdcW'.");

            if (LdcWInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Ldc2WInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Ldc2WInstruction AsLdc2W()
        {
            if (OpCode != OpCode.Ldc2W)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ldc2W'.");

            if (Ldc2WInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IloadInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IloadInstruction AsIload()
        {
            if (OpCode != OpCode.Iload)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iload'.");

            if (IloadInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LloadInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LloadInstruction AsLload()
        {
            if (OpCode != OpCode.Lload)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lload'.");

            if (LloadInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FloadInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FloadInstruction AsFload()
        {
            if (OpCode != OpCode.Fload)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fload'.");

            if (FloadInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DloadInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DloadInstruction AsDload()
        {
            if (OpCode != OpCode.Dload)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dload'.");

            if (DloadInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AloadInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AloadInstruction AsAload()
        {
            if (OpCode != OpCode.Aload)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Aload'.");

            if (AloadInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iload0Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Iload0Instruction AsIload0()
        {
            if (OpCode != OpCode.Iload0)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iload0'.");

            if (Iload0Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iload1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Iload1Instruction AsIload1()
        {
            if (OpCode != OpCode.Iload1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iload1'.");

            if (Iload1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iload2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Iload2Instruction AsIload2()
        {
            if (OpCode != OpCode.Iload2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iload2'.");

            if (Iload2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iload3Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Iload3Instruction AsIload3()
        {
            if (OpCode != OpCode.Iload3)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iload3'.");

            if (Iload3Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lload0Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Lload0Instruction AsLload0()
        {
            if (OpCode != OpCode.Lload0)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lload0'.");

            if (Lload0Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lload1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Lload1Instruction AsLload1()
        {
            if (OpCode != OpCode.Lload1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lload1'.");

            if (Lload1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lload2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Lload2Instruction AsLload2()
        {
            if (OpCode != OpCode.Lload2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lload2'.");

            if (Lload2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lload3Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Lload3Instruction AsLload3()
        {
            if (OpCode != OpCode.Lload3)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lload3'.");

            if (Lload3Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fload0Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Fload0Instruction AsFload0()
        {
            if (OpCode != OpCode.Fload0)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fload0'.");

            if (Fload0Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fload1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Fload1Instruction AsFload1()
        {
            if (OpCode != OpCode.Fload1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fload1'.");

            if (Fload1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fload2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Fload2Instruction AsFload2()
        {
            if (OpCode != OpCode.Fload2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fload2'.");

            if (Fload2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fload3Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Fload3Instruction AsFload3()
        {
            if (OpCode != OpCode.Fload3)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fload3'.");

            if (Fload3Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dload0Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dload0Instruction AsDload0()
        {
            if (OpCode != OpCode.Dload0)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dload0'.");

            if (Dload0Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dload1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dload1Instruction AsDload1()
        {
            if (OpCode != OpCode.Dload1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dload1'.");

            if (Dload1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dload2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dload2Instruction AsDload2()
        {
            if (OpCode != OpCode.Dload2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dload2'.");

            if (Dload2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dload3Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dload3Instruction AsDload3()
        {
            if (OpCode != OpCode.Dload3)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dload3'.");

            if (Dload3Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Aload0Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Aload0Instruction AsAload0()
        {
            if (OpCode != OpCode.Aload0)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Aload0'.");

            if (Aload0Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Aload1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Aload1Instruction AsAload1()
        {
            if (OpCode != OpCode.Aload1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Aload1'.");

            if (Aload1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Aload2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Aload2Instruction AsAload2()
        {
            if (OpCode != OpCode.Aload2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Aload2'.");

            if (Aload2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Aload3Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Aload3Instruction AsAload3()
        {
            if (OpCode != OpCode.Aload3)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Aload3'.");

            if (Aload3Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IaloadInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IaloadInstruction AsIaload()
        {
            if (OpCode != OpCode.Iaload)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iaload'.");

            if (IaloadInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LaloadInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LaloadInstruction AsLaload()
        {
            if (OpCode != OpCode.Laload)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Laload'.");

            if (LaloadInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FaloadInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FaloadInstruction AsFaload()
        {
            if (OpCode != OpCode.Faload)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Faload'.");

            if (FaloadInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DaloadInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DaloadInstruction AsDaload()
        {
            if (OpCode != OpCode.Daload)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Daload'.");

            if (DaloadInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AaloadInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AaloadInstruction AsAaload()
        {
            if (OpCode != OpCode.Aaload)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Aaload'.");

            if (AaloadInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="BaloadInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BaloadInstruction AsBaload()
        {
            if (OpCode != OpCode.Baload)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Baload'.");

            if (BaloadInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="CaloadInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CaloadInstruction AsCaload()
        {
            if (OpCode != OpCode.Caload)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Caload'.");

            if (CaloadInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="SaloadInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SaloadInstruction AsSaload()
        {
            if (OpCode != OpCode.Saload)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Saload'.");

            if (SaloadInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IstoreInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IstoreInstruction AsIstore()
        {
            if (OpCode != OpCode.Istore)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Istore'.");

            if (IstoreInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LstoreInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LstoreInstruction AsLstore()
        {
            if (OpCode != OpCode.Lstore)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lstore'.");

            if (LstoreInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FstoreInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FstoreInstruction AsFstore()
        {
            if (OpCode != OpCode.Fstore)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fstore'.");

            if (FstoreInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DstoreInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DstoreInstruction AsDstore()
        {
            if (OpCode != OpCode.Dstore)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dstore'.");

            if (DstoreInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AstoreInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AstoreInstruction AsAstore()
        {
            if (OpCode != OpCode.Astore)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Astore'.");

            if (AstoreInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Istore0Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Istore0Instruction AsIstore0()
        {
            if (OpCode != OpCode.Istore0)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Istore0'.");

            if (Istore0Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Istore1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Istore1Instruction AsIstore1()
        {
            if (OpCode != OpCode.Istore1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Istore1'.");

            if (Istore1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Istore2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Istore2Instruction AsIstore2()
        {
            if (OpCode != OpCode.Istore2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Istore2'.");

            if (Istore2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Istore3Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Istore3Instruction AsIstore3()
        {
            if (OpCode != OpCode.Istore3)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Istore3'.");

            if (Istore3Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lstore0Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Lstore0Instruction AsLstore0()
        {
            if (OpCode != OpCode.Lstore0)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lstore0'.");

            if (Lstore0Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lstore1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Lstore1Instruction AsLstore1()
        {
            if (OpCode != OpCode.Lstore1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lstore1'.");

            if (Lstore1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lstore2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Lstore2Instruction AsLstore2()
        {
            if (OpCode != OpCode.Lstore2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lstore2'.");

            if (Lstore2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lstore3Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Lstore3Instruction AsLstore3()
        {
            if (OpCode != OpCode.Lstore3)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lstore3'.");

            if (Lstore3Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fstore0Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Fstore0Instruction AsFstore0()
        {
            if (OpCode != OpCode.Fstore0)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fstore0'.");

            if (Fstore0Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fstore1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Fstore1Instruction AsFstore1()
        {
            if (OpCode != OpCode.Fstore1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fstore1'.");

            if (Fstore1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fstore2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Fstore2Instruction AsFstore2()
        {
            if (OpCode != OpCode.Fstore2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fstore2'.");

            if (Fstore2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fstore3Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Fstore3Instruction AsFstore3()
        {
            if (OpCode != OpCode.Fstore3)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fstore3'.");

            if (Fstore3Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dstore0Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dstore0Instruction AsDstore0()
        {
            if (OpCode != OpCode.Dstore0)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dstore0'.");

            if (Dstore0Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dstore1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dstore1Instruction AsDstore1()
        {
            if (OpCode != OpCode.Dstore1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dstore1'.");

            if (Dstore1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dstore2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dstore2Instruction AsDstore2()
        {
            if (OpCode != OpCode.Dstore2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dstore2'.");

            if (Dstore2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dstore3Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dstore3Instruction AsDstore3()
        {
            if (OpCode != OpCode.Dstore3)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dstore3'.");

            if (Dstore3Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Astore0Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Astore0Instruction AsAstore0()
        {
            if (OpCode != OpCode.Astore0)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Astore0'.");

            if (Astore0Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Astore1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Astore1Instruction AsAstore1()
        {
            if (OpCode != OpCode.Astore1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Astore1'.");

            if (Astore1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Astore2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Astore2Instruction AsAstore2()
        {
            if (OpCode != OpCode.Astore2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Astore2'.");

            if (Astore2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Astore3Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Astore3Instruction AsAstore3()
        {
            if (OpCode != OpCode.Astore3)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Astore3'.");

            if (Astore3Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IastoreInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IastoreInstruction AsIastore()
        {
            if (OpCode != OpCode.Iastore)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iastore'.");

            if (IastoreInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LastoreInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LastoreInstruction AsLastore()
        {
            if (OpCode != OpCode.Lastore)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lastore'.");

            if (LastoreInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FastoreInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FastoreInstruction AsFastore()
        {
            if (OpCode != OpCode.Fastore)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fastore'.");

            if (FastoreInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DastoreInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DastoreInstruction AsDastore()
        {
            if (OpCode != OpCode.Dastore)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dastore'.");

            if (DastoreInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AastoreInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AastoreInstruction AsAastore()
        {
            if (OpCode != OpCode.Aastore)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Aastore'.");

            if (AastoreInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="BastoreInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BastoreInstruction AsBastore()
        {
            if (OpCode != OpCode.Bastore)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Bastore'.");

            if (BastoreInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="CastoreInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CastoreInstruction AsCastore()
        {
            if (OpCode != OpCode.Castore)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Castore'.");

            if (CastoreInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="SastoreInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SastoreInstruction AsSastore()
        {
            if (OpCode != OpCode.Sastore)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Sastore'.");

            if (SastoreInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="PopInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PopInstruction AsPop()
        {
            if (OpCode != OpCode.Pop)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Pop'.");

            if (PopInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Pop2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Pop2Instruction AsPop2()
        {
            if (OpCode != OpCode.Pop2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Pop2'.");

            if (Pop2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DupInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DupInstruction AsDup()
        {
            if (OpCode != OpCode.Dup)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dup'.");

            if (DupInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DupX1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DupX1Instruction AsDupX1()
        {
            if (OpCode != OpCode.DupX1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'DupX1'.");

            if (DupX1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DupX2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DupX2Instruction AsDupX2()
        {
            if (OpCode != OpCode.DupX2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'DupX2'.");

            if (DupX2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dup2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dup2Instruction AsDup2()
        {
            if (OpCode != OpCode.Dup2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dup2'.");

            if (Dup2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dup2X1Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dup2X1Instruction AsDup2X1()
        {
            if (OpCode != OpCode.Dup2X1)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dup2X1'.");

            if (Dup2X1Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dup2X2Instruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dup2X2Instruction AsDup2X2()
        {
            if (OpCode != OpCode.Dup2X2)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dup2X2'.");

            if (Dup2X2Instruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="SwapInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SwapInstruction AsSwap()
        {
            if (OpCode != OpCode.Swap)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Swap'.");

            if (SwapInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IaddInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IaddInstruction AsIadd()
        {
            if (OpCode != OpCode.Iadd)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iadd'.");

            if (IaddInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LaddInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LaddInstruction AsLadd()
        {
            if (OpCode != OpCode.Ladd)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ladd'.");

            if (LaddInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FaddInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FaddInstruction AsFadd()
        {
            if (OpCode != OpCode.Fadd)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fadd'.");

            if (FaddInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DaddInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DaddInstruction AsDadd()
        {
            if (OpCode != OpCode.Dadd)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dadd'.");

            if (DaddInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IsubInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IsubInstruction AsIsub()
        {
            if (OpCode != OpCode.Isub)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Isub'.");

            if (IsubInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LsubInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LsubInstruction AsLsub()
        {
            if (OpCode != OpCode.Lsub)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lsub'.");

            if (LsubInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FsubInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FsubInstruction AsFsub()
        {
            if (OpCode != OpCode.Fsub)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fsub'.");

            if (FsubInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DsubInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DsubInstruction AsDsub()
        {
            if (OpCode != OpCode.Dsub)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dsub'.");

            if (DsubInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="ImulInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ImulInstruction AsImul()
        {
            if (OpCode != OpCode.Imul)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Imul'.");

            if (ImulInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LmulInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LmulInstruction AsLmul()
        {
            if (OpCode != OpCode.Lmul)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lmul'.");

            if (LmulInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FmulInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FmulInstruction AsFmul()
        {
            if (OpCode != OpCode.Fmul)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fmul'.");

            if (FmulInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DmulInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DmulInstruction AsDmul()
        {
            if (OpCode != OpCode.Dmul)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dmul'.");

            if (DmulInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IdivInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IdivInstruction AsIdiv()
        {
            if (OpCode != OpCode.Idiv)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Idiv'.");

            if (IdivInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LdivInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LdivInstruction AsLdiv()
        {
            if (OpCode != OpCode.Ldiv)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ldiv'.");

            if (LdivInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FdivInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FdivInstruction AsFdiv()
        {
            if (OpCode != OpCode.Fdiv)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fdiv'.");

            if (FdivInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DdivInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DdivInstruction AsDdiv()
        {
            if (OpCode != OpCode.Ddiv)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ddiv'.");

            if (DdivInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IremInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IremInstruction AsIrem()
        {
            if (OpCode != OpCode.Irem)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Irem'.");

            if (IremInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LremInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LremInstruction AsLrem()
        {
            if (OpCode != OpCode.Lrem)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lrem'.");

            if (LremInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FremInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FremInstruction AsFrem()
        {
            if (OpCode != OpCode.Frem)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Frem'.");

            if (FremInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DremInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DremInstruction AsDrem()
        {
            if (OpCode != OpCode.Drem)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Drem'.");

            if (DremInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="InegInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InegInstruction AsIneg()
        {
            if (OpCode != OpCode.Ineg)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ineg'.");

            if (InegInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LnegInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LnegInstruction AsLneg()
        {
            if (OpCode != OpCode.Lneg)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lneg'.");

            if (LnegInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FnegInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FnegInstruction AsFneg()
        {
            if (OpCode != OpCode.Fneg)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fneg'.");

            if (FnegInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DnegInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DnegInstruction AsDneg()
        {
            if (OpCode != OpCode.Dneg)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dneg'.");

            if (DnegInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IshlInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IshlInstruction AsIshl()
        {
            if (OpCode != OpCode.Ishl)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ishl'.");

            if (IshlInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LshlInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LshlInstruction AsLshl()
        {
            if (OpCode != OpCode.Lshl)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lshl'.");

            if (LshlInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IshrInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IshrInstruction AsIshr()
        {
            if (OpCode != OpCode.Ishr)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ishr'.");

            if (IshrInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LshrInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LshrInstruction AsLshr()
        {
            if (OpCode != OpCode.Lshr)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lshr'.");

            if (LshrInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IushrInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IushrInstruction AsIushr()
        {
            if (OpCode != OpCode.Iushr)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iushr'.");

            if (IushrInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LushrInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LushrInstruction AsLushr()
        {
            if (OpCode != OpCode.Lushr)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lushr'.");

            if (LushrInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IandInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IandInstruction AsIand()
        {
            if (OpCode != OpCode.Iand)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iand'.");

            if (IandInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LandInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LandInstruction AsLand()
        {
            if (OpCode != OpCode.Land)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Land'.");

            if (LandInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IorInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IorInstruction AsIor()
        {
            if (OpCode != OpCode.Ior)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ior'.");

            if (IorInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LorInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LorInstruction AsLor()
        {
            if (OpCode != OpCode.Lor)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lor'.");

            if (LorInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IxorInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IxorInstruction AsIxor()
        {
            if (OpCode != OpCode.Ixor)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ixor'.");

            if (IxorInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LxorInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LxorInstruction AsLxor()
        {
            if (OpCode != OpCode.Lxor)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lxor'.");

            if (LxorInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IincInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IincInstruction AsIinc()
        {
            if (OpCode != OpCode.Iinc)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iinc'.");

            if (IincInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="I2lInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public I2lInstruction AsI2l()
        {
            if (OpCode != OpCode.I2l)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'I2l'.");

            if (I2lInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="I2fInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public I2fInstruction AsI2f()
        {
            if (OpCode != OpCode.I2f)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'I2f'.");

            if (I2fInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="I2dInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public I2dInstruction AsI2d()
        {
            if (OpCode != OpCode.I2d)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'I2d'.");

            if (I2dInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="L2iInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public L2iInstruction AsL2i()
        {
            if (OpCode != OpCode.L2i)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'L2i'.");

            if (L2iInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="L2fInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public L2fInstruction AsL2f()
        {
            if (OpCode != OpCode.L2f)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'L2f'.");

            if (L2fInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="L2dInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public L2dInstruction AsL2d()
        {
            if (OpCode != OpCode.L2d)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'L2d'.");

            if (L2dInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="F2iInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public F2iInstruction AsF2i()
        {
            if (OpCode != OpCode.F2i)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'F2i'.");

            if (F2iInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="F2lInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public F2lInstruction AsF2l()
        {
            if (OpCode != OpCode.F2l)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'F2l'.");

            if (F2lInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="F2dInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public F2dInstruction AsF2d()
        {
            if (OpCode != OpCode.F2d)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'F2d'.");

            if (F2dInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="D2iInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2iInstruction AsD2i()
        {
            if (OpCode != OpCode.D2i)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'D2i'.");

            if (D2iInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="D2lInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2lInstruction AsD2l()
        {
            if (OpCode != OpCode.D2l)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'D2l'.");

            if (D2lInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="D2fInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2fInstruction AsD2f()
        {
            if (OpCode != OpCode.D2f)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'D2f'.");

            if (D2fInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="I2bInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public I2bInstruction AsI2b()
        {
            if (OpCode != OpCode.I2b)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'I2b'.");

            if (I2bInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="I2cInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public I2cInstruction AsI2c()
        {
            if (OpCode != OpCode.I2c)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'I2c'.");

            if (I2cInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="I2sInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public I2sInstruction AsI2s()
        {
            if (OpCode != OpCode.I2s)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'I2s'.");

            if (I2sInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LcmpInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LcmpInstruction AsLcmp()
        {
            if (OpCode != OpCode.Lcmp)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lcmp'.");

            if (LcmpInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FcmplInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FcmplInstruction AsFcmpl()
        {
            if (OpCode != OpCode.Fcmpl)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fcmpl'.");

            if (FcmplInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FcmpgInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FcmpgInstruction AsFcmpg()
        {
            if (OpCode != OpCode.Fcmpg)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Fcmpg'.");

            if (FcmpgInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DcmplInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DcmplInstruction AsDcmpl()
        {
            if (OpCode != OpCode.Dcmpl)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dcmpl'.");

            if (DcmplInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DcmpgInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DcmpgInstruction AsDcmpg()
        {
            if (OpCode != OpCode.Dcmpg)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dcmpg'.");

            if (DcmpgInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfeqInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfeqInstruction AsIfeq()
        {
            if (OpCode != OpCode.Ifeq)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ifeq'.");

            if (IfeqInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfneInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfneInstruction AsIfne()
        {
            if (OpCode != OpCode.Ifne)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ifne'.");

            if (IfneInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfltInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfltInstruction AsIflt()
        {
            if (OpCode != OpCode.Iflt)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Iflt'.");

            if (IfltInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfgeInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfgeInstruction AsIfge()
        {
            if (OpCode != OpCode.Ifge)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ifge'.");

            if (IfgeInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfgtInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfgtInstruction AsIfgt()
        {
            if (OpCode != OpCode.Ifgt)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ifgt'.");

            if (IfgtInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfleInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfleInstruction AsIfle()
        {
            if (OpCode != OpCode.Ifle)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ifle'.");

            if (IfleInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfIcmpeqInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfIcmpeqInstruction AsIfIcmpeq()
        {
            if (OpCode != OpCode.IfIcmpeq)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'IfIcmpeq'.");

            if (IfIcmpeqInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfIcmpneInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfIcmpneInstruction AsIfIcmpne()
        {
            if (OpCode != OpCode.IfIcmpne)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'IfIcmpne'.");

            if (IfIcmpneInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfIcmpltInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfIcmpltInstruction AsIfIcmplt()
        {
            if (OpCode != OpCode.IfIcmplt)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'IfIcmplt'.");

            if (IfIcmpltInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfIcmpgeInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfIcmpgeInstruction AsIfIcmpge()
        {
            if (OpCode != OpCode.IfIcmpge)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'IfIcmpge'.");

            if (IfIcmpgeInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfIcmpgtInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfIcmpgtInstruction AsIfIcmpgt()
        {
            if (OpCode != OpCode.IfIcmpgt)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'IfIcmpgt'.");

            if (IfIcmpgtInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfIcmpleInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfIcmpleInstruction AsIfIcmple()
        {
            if (OpCode != OpCode.IfIcmple)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'IfIcmple'.");

            if (IfIcmpleInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfAcmpeqInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfAcmpeqInstruction AsIfAcmpeq()
        {
            if (OpCode != OpCode.IfAcmpeq)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'IfAcmpeq'.");

            if (IfAcmpeqInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfAcmpneInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfAcmpneInstruction AsIfAcmpne()
        {
            if (OpCode != OpCode.IfAcmpne)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'IfAcmpne'.");

            if (IfAcmpneInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="GotoInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public GotoInstruction AsGoto()
        {
            if (OpCode != OpCode.Goto)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Goto'.");

            if (GotoInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="JsrInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public JsrInstruction AsJsr()
        {
            if (OpCode != OpCode.Jsr)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Jsr'.");

            if (JsrInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="RetInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RetInstruction AsRet()
        {
            if (OpCode != OpCode.Ret)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ret'.");

            if (RetInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="TableSwitchInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TableSwitchInstruction AsTableSwitch()
        {
            if (OpCode != OpCode.TableSwitch)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'TableSwitch'.");

            if (TableSwitchInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LookupSwitchInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LookupSwitchInstruction AsLookupSwitch()
        {
            if (OpCode != OpCode.LookupSwitch)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'LookupSwitch'.");

            if (LookupSwitchInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IreturnInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IreturnInstruction AsIreturn()
        {
            if (OpCode != OpCode.Ireturn)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Ireturn'.");

            if (IreturnInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LreturnInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LreturnInstruction AsLreturn()
        {
            if (OpCode != OpCode.Lreturn)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Lreturn'.");

            if (LreturnInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FreturnInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FreturnInstruction AsFreturn()
        {
            if (OpCode != OpCode.Freturn)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Freturn'.");

            if (FreturnInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DreturnInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DreturnInstruction AsDreturn()
        {
            if (OpCode != OpCode.Dreturn)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Dreturn'.");

            if (DreturnInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AreturnInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AreturnInstruction AsAreturn()
        {
            if (OpCode != OpCode.Areturn)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Areturn'.");

            if (AreturnInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="ReturnInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ReturnInstruction AsReturn()
        {
            if (OpCode != OpCode.Return)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Return'.");

            if (ReturnInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="GetStaticInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public GetStaticInstruction AsGetStatic()
        {
            if (OpCode != OpCode.GetStatic)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'GetStatic'.");

            if (GetStaticInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="PutStaticInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PutStaticInstruction AsPutStatic()
        {
            if (OpCode != OpCode.PutStatic)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'PutStatic'.");

            if (PutStaticInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="GetFieldInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public GetFieldInstruction AsGetField()
        {
            if (OpCode != OpCode.GetField)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'GetField'.");

            if (GetFieldInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="PutFieldInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PutFieldInstruction AsPutField()
        {
            if (OpCode != OpCode.PutField)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'PutField'.");

            if (PutFieldInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="InvokeVirtualInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InvokeVirtualInstruction AsInvokeVirtual()
        {
            if (OpCode != OpCode.InvokeVirtual)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'InvokeVirtual'.");

            if (InvokeVirtualInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="InvokeSpecialInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InvokeSpecialInstruction AsInvokeSpecial()
        {
            if (OpCode != OpCode.InvokeSpecial)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'InvokeSpecial'.");

            if (InvokeSpecialInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="InvokeStaticInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InvokeStaticInstruction AsInvokeStatic()
        {
            if (OpCode != OpCode.InvokeStatic)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'InvokeStatic'.");

            if (InvokeStaticInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="InvokeInterfaceInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InvokeInterfaceInstruction AsInvokeInterface()
        {
            if (OpCode != OpCode.InvokeInterface)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'InvokeInterface'.");

            if (InvokeInterfaceInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="InvokeDynamicInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InvokeDynamicInstruction AsInvokeDynamic()
        {
            if (OpCode != OpCode.InvokeDynamic)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'InvokeDynamic'.");

            if (InvokeDynamicInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="NewInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NewInstruction AsNew()
        {
            if (OpCode != OpCode.New)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'New'.");

            if (NewInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="NewarrayInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NewarrayInstruction AsNewarray()
        {
            if (OpCode != OpCode.Newarray)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Newarray'.");

            if (NewarrayInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AnewarrayInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnewarrayInstruction AsAnewarray()
        {
            if (OpCode != OpCode.Anewarray)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Anewarray'.");

            if (AnewarrayInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="ArraylengthInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ArraylengthInstruction AsArraylength()
        {
            if (OpCode != OpCode.Arraylength)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Arraylength'.");

            if (ArraylengthInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AthrowInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AthrowInstruction AsAthrow()
        {
            if (OpCode != OpCode.Athrow)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Athrow'.");

            if (AthrowInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="CheckcastInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CheckcastInstruction AsCheckcast()
        {
            if (OpCode != OpCode.Checkcast)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Checkcast'.");

            if (CheckcastInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="InstanceOfInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public InstanceOfInstruction AsInstanceOf()
        {
            if (OpCode != OpCode.InstanceOf)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'InstanceOf'.");

            if (InstanceOfInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="MonitorEnterInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MonitorEnterInstruction AsMonitorEnter()
        {
            if (OpCode != OpCode.MonitorEnter)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'MonitorEnter'.");

            if (MonitorEnterInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="MonitorExitInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MonitorExitInstruction AsMonitorExit()
        {
            if (OpCode != OpCode.MonitorExit)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'MonitorExit'.");

            if (MonitorExitInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="MultianewarrayInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MultianewarrayInstruction AsMultianewarray()
        {
            if (OpCode != OpCode.Multianewarray)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'Multianewarray'.");

            if (MultianewarrayInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfNullInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfNullInstruction AsIfNull()
        {
            if (OpCode != OpCode.IfNull)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'IfNull'.");

            if (IfNullInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfNonNullInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IfNonNullInstruction AsIfNonNull()
        {
            if (OpCode != OpCode.IfNonNull)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'IfNonNull'.");

            if (IfNonNullInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="GotoWInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public GotoWInstruction AsGotoW()
        {
            if (OpCode != OpCode.GotoW)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'GotoW'.");

            if (GotoWInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="JsrWInstruction" /> if possible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public JsrWInstruction AsJsrW()
        {
            if (OpCode != OpCode.JsrW)
                throw new InvalidCastException($"Cannot convert instruction of opcode '{OpCode}' to 'JsrW'.");

            if (JsrWInstruction.TryRead(Data, out var instruction) == false)
                throw new InvalidCodeException("Unexpected end of data trying to read instruction.");

            return instruction;
        }

    
    }

    /// <summary>
    /// Describes the 'nop' instruction.
    /// </summary>
    public partial record struct NopInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="NopInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator NopInstruction(Instruction value) => value.AsNop();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Nop)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out NopInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out NopInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Nop)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new NopInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'aconst_null' instruction.
    /// </summary>
    public partial record struct AconstNullInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AconstNullInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator AconstNullInstruction(Instruction value) => value.AsAconstNull();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.AconstNull)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out AconstNullInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out AconstNullInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.AconstNull)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new AconstNullInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iconst_m1' instruction.
    /// </summary>
    public partial record struct IconstM1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IconstM1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IconstM1Instruction(Instruction value) => value.AsIconstM1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IconstM1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IconstM1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IconstM1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IconstM1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new IconstM1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iconst_0' instruction.
    /// </summary>
    public partial record struct Iconst0Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iconst0Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Iconst0Instruction(Instruction value) => value.AsIconst0();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Iconst0Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Iconst0Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Iconst0Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iconst_1' instruction.
    /// </summary>
    public partial record struct Iconst1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iconst1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Iconst1Instruction(Instruction value) => value.AsIconst1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Iconst1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Iconst1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Iconst1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iconst_2' instruction.
    /// </summary>
    public partial record struct Iconst2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iconst2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Iconst2Instruction(Instruction value) => value.AsIconst2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Iconst2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Iconst2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Iconst2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iconst_3' instruction.
    /// </summary>
    public partial record struct Iconst3Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iconst3Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Iconst3Instruction(Instruction value) => value.AsIconst3();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Iconst3Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Iconst3Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Iconst3Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iconst_4' instruction.
    /// </summary>
    public partial record struct Iconst4Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iconst4Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Iconst4Instruction(Instruction value) => value.AsIconst4();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst4)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Iconst4Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Iconst4Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst4)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Iconst4Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iconst_5' instruction.
    /// </summary>
    public partial record struct Iconst5Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iconst5Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Iconst5Instruction(Instruction value) => value.AsIconst5();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst5)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Iconst5Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Iconst5Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst5)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Iconst5Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lconst_0' instruction.
    /// </summary>
    public partial record struct Lconst0Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lconst0Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Lconst0Instruction(Instruction value) => value.AsLconst0();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lconst0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Lconst0Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Lconst0Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lconst0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Lconst0Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lconst_1' instruction.
    /// </summary>
    public partial record struct Lconst1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lconst1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Lconst1Instruction(Instruction value) => value.AsLconst1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lconst1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Lconst1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Lconst1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lconst1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Lconst1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fconst_0' instruction.
    /// </summary>
    public partial record struct Fconst0Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fconst0Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Fconst0Instruction(Instruction value) => value.AsFconst0();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fconst0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Fconst0Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Fconst0Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fconst0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Fconst0Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fconst_1' instruction.
    /// </summary>
    public partial record struct Fconst1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fconst1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Fconst1Instruction(Instruction value) => value.AsFconst1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fconst1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Fconst1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Fconst1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fconst1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Fconst1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fconst_2' instruction.
    /// </summary>
    public partial record struct Fconst2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fconst2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Fconst2Instruction(Instruction value) => value.AsFconst2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fconst2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Fconst2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Fconst2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fconst2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Fconst2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dconst_0' instruction.
    /// </summary>
    public partial record struct Dconst0Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dconst0Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Dconst0Instruction(Instruction value) => value.AsDconst0();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dconst0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Dconst0Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Dconst0Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dconst0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Dconst0Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dconst_1' instruction.
    /// </summary>
    public partial record struct Dconst1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dconst1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Dconst1Instruction(Instruction value) => value.AsDconst1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dconst1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Dconst1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Dconst1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dconst1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Dconst1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'bipush' instruction.
    /// </summary>
    /// <param name="Value"></param>
    public partial record struct BipushInstruction(sbyte Value)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="BipushInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator BipushInstruction(Instruction value) => value.AsBipush();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Bipush)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Value
            if (Instruction.TryMeasureS1(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out BipushInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out BipushInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Bipush)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Value
            if (Instruction.TryReadS1(ref reader, out var value) == false)
                return false;

            instruction = new BipushInstruction(value);

            return true;
        }

        // arg1: Value
        public readonly sbyte Value = Value;

    }

    /// <summary>
    /// Describes the 'sipush' instruction.
    /// </summary>
    /// <param name="Value"></param>
    public partial record struct SipushInstruction(short Value)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="SipushInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator SipushInstruction(Instruction value) => value.AsSipush();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Sipush)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Value
            if (Instruction.TryMeasureS2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out SipushInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out SipushInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Sipush)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Value
            if (Instruction.TryReadS2(ref reader, out var value) == false)
                return false;

            instruction = new SipushInstruction(value);

            return true;
        }

        // arg1: Value
        public readonly short Value = Value;

    }

    /// <summary>
    /// Describes the 'ldc' instruction.
    /// </summary>
    /// <param name="Constant"></param>
    public partial record struct LdcInstruction(ConstantHandle Constant)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LdcInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LdcInstruction(Instruction value) => value.AsLdc();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ldc)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Constant
            if (Instruction.TryMeasureC1(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LdcInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LdcInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ldc)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Constant
            if (Instruction.TryReadC1(ref reader, out var constant) == false)
                return false;

            instruction = new LdcInstruction(constant);

            return true;
        }

        // arg1: Constant
        public readonly ConstantHandle Constant = Constant;

    }

    /// <summary>
    /// Describes the 'ldc_w' instruction.
    /// </summary>
    /// <param name="Constant"></param>
    public partial record struct LdcWInstruction(ConstantHandle Constant)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LdcWInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LdcWInstruction(Instruction value) => value.AsLdcW();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.LdcW)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Constant
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LdcWInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LdcWInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.LdcW)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Constant
            if (Instruction.TryReadC2(ref reader, out var constant) == false)
                return false;

            instruction = new LdcWInstruction(constant);

            return true;
        }

        // arg1: Constant
        public readonly ConstantHandle Constant = Constant;

    }

    /// <summary>
    /// Describes the 'ldc2_w' instruction.
    /// </summary>
    /// <param name="Constant"></param>
    public partial record struct Ldc2WInstruction(ConstantHandle Constant)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Ldc2WInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Ldc2WInstruction(Instruction value) => value.AsLdc2W();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ldc2W)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Constant
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Ldc2WInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Ldc2WInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ldc2W)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Constant
            if (Instruction.TryReadC2(ref reader, out var constant) == false)
                return false;

            instruction = new Ldc2WInstruction(constant);

            return true;
        }

        // arg1: Constant
        public readonly ConstantHandle Constant = Constant;

    }

    /// <summary>
    /// Describes the 'iload' instruction.
    /// </summary>
    /// <param name="Local"></param>
    public partial record struct IloadInstruction(ushort Local)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IloadInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IloadInstruction(Instruction value) => value.AsIload();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {
                // advance by opcode and prefix
                size += 2;

                // arg1: Local
                if (Instruction.TryMeasureL2(ref reader, ref size) == false)
                    return false;
            }
            else
            {
                // advance by opcode size
                size += 1;

                // arg1: Local
                if (Instruction.TryMeasureL1(ref reader, ref size) == false)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IloadInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IloadInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new IloadInstruction(local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new IloadInstruction(local);
            }

            return true;
        }

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'lload' instruction.
    /// </summary>
    /// <param name="Local"></param>
    public partial record struct LloadInstruction(ushort Local)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LloadInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LloadInstruction(Instruction value) => value.AsLload();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {
                // advance by opcode and prefix
                size += 2;

                // arg1: Local
                if (Instruction.TryMeasureL2(ref reader, ref size) == false)
                    return false;
            }
            else
            {
                // advance by opcode size
                size += 1;

                // arg1: Local
                if (Instruction.TryMeasureL1(ref reader, ref size) == false)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LloadInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LloadInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new LloadInstruction(local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new LloadInstruction(local);
            }

            return true;
        }

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'fload' instruction.
    /// </summary>
    /// <param name="Local"></param>
    public partial record struct FloadInstruction(ushort Local)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FloadInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FloadInstruction(Instruction value) => value.AsFload();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {
                // advance by opcode and prefix
                size += 2;

                // arg1: Local
                if (Instruction.TryMeasureL2(ref reader, ref size) == false)
                    return false;
            }
            else
            {
                // advance by opcode size
                size += 1;

                // arg1: Local
                if (Instruction.TryMeasureL1(ref reader, ref size) == false)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out FloadInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out FloadInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new FloadInstruction(local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new FloadInstruction(local);
            }

            return true;
        }

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'dload' instruction.
    /// </summary>
    /// <param name="Local"></param>
    public partial record struct DloadInstruction(ushort Local)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DloadInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DloadInstruction(Instruction value) => value.AsDload();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {
                // advance by opcode and prefix
                size += 2;

                // arg1: Local
                if (Instruction.TryMeasureL2(ref reader, ref size) == false)
                    return false;
            }
            else
            {
                // advance by opcode size
                size += 1;

                // arg1: Local
                if (Instruction.TryMeasureL1(ref reader, ref size) == false)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DloadInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DloadInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new DloadInstruction(local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new DloadInstruction(local);
            }

            return true;
        }

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'aload' instruction.
    /// </summary>
    /// <param name="Local"></param>
    public partial record struct AloadInstruction(ushort Local)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AloadInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator AloadInstruction(Instruction value) => value.AsAload();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {
                // advance by opcode and prefix
                size += 2;

                // arg1: Local
                if (Instruction.TryMeasureL2(ref reader, ref size) == false)
                    return false;
            }
            else
            {
                // advance by opcode size
                size += 1;

                // arg1: Local
                if (Instruction.TryMeasureL1(ref reader, ref size) == false)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out AloadInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out AloadInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new AloadInstruction(local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new AloadInstruction(local);
            }

            return true;
        }

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'iload_0' instruction.
    /// </summary>
    public partial record struct Iload0Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iload0Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Iload0Instruction(Instruction value) => value.AsIload0();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Iload0Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Iload0Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Iload0Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iload_1' instruction.
    /// </summary>
    public partial record struct Iload1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iload1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Iload1Instruction(Instruction value) => value.AsIload1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Iload1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Iload1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Iload1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iload_2' instruction.
    /// </summary>
    public partial record struct Iload2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iload2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Iload2Instruction(Instruction value) => value.AsIload2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Iload2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Iload2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Iload2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iload_3' instruction.
    /// </summary>
    public partial record struct Iload3Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Iload3Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Iload3Instruction(Instruction value) => value.AsIload3();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Iload3Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Iload3Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Iload3Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lload_0' instruction.
    /// </summary>
    public partial record struct Lload0Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lload0Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Lload0Instruction(Instruction value) => value.AsLload0();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Lload0Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Lload0Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Lload0Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lload_1' instruction.
    /// </summary>
    public partial record struct Lload1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lload1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Lload1Instruction(Instruction value) => value.AsLload1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Lload1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Lload1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Lload1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lload_2' instruction.
    /// </summary>
    public partial record struct Lload2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lload2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Lload2Instruction(Instruction value) => value.AsLload2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Lload2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Lload2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Lload2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lload_3' instruction.
    /// </summary>
    public partial record struct Lload3Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lload3Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Lload3Instruction(Instruction value) => value.AsLload3();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Lload3Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Lload3Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Lload3Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fload_0' instruction.
    /// </summary>
    public partial record struct Fload0Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fload0Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Fload0Instruction(Instruction value) => value.AsFload0();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Fload0Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Fload0Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Fload0Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fload_1' instruction.
    /// </summary>
    public partial record struct Fload1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fload1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Fload1Instruction(Instruction value) => value.AsFload1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Fload1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Fload1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Fload1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fload_2' instruction.
    /// </summary>
    public partial record struct Fload2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fload2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Fload2Instruction(Instruction value) => value.AsFload2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Fload2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Fload2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Fload2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fload_3' instruction.
    /// </summary>
    public partial record struct Fload3Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fload3Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Fload3Instruction(Instruction value) => value.AsFload3();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Fload3Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Fload3Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Fload3Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dload_0' instruction.
    /// </summary>
    public partial record struct Dload0Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dload0Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Dload0Instruction(Instruction value) => value.AsDload0();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Dload0Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Dload0Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Dload0Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dload_1' instruction.
    /// </summary>
    public partial record struct Dload1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dload1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Dload1Instruction(Instruction value) => value.AsDload1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Dload1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Dload1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Dload1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dload_2' instruction.
    /// </summary>
    public partial record struct Dload2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dload2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Dload2Instruction(Instruction value) => value.AsDload2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Dload2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Dload2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Dload2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dload_3' instruction.
    /// </summary>
    public partial record struct Dload3Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dload3Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Dload3Instruction(Instruction value) => value.AsDload3();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Dload3Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Dload3Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Dload3Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'aload_0' instruction.
    /// </summary>
    public partial record struct Aload0Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Aload0Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Aload0Instruction(Instruction value) => value.AsAload0();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Aload0Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Aload0Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Aload0Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'aload_1' instruction.
    /// </summary>
    public partial record struct Aload1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Aload1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Aload1Instruction(Instruction value) => value.AsAload1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Aload1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Aload1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Aload1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'aload_2' instruction.
    /// </summary>
    public partial record struct Aload2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Aload2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Aload2Instruction(Instruction value) => value.AsAload2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Aload2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Aload2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Aload2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'aload_3' instruction.
    /// </summary>
    public partial record struct Aload3Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Aload3Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Aload3Instruction(Instruction value) => value.AsAload3();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Aload3Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Aload3Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Aload3Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iaload' instruction.
    /// </summary>
    public partial record struct IaloadInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IaloadInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IaloadInstruction(Instruction value) => value.AsIaload();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iaload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IaloadInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IaloadInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iaload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new IaloadInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'laload' instruction.
    /// </summary>
    public partial record struct LaloadInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LaloadInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LaloadInstruction(Instruction value) => value.AsLaload();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Laload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LaloadInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LaloadInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Laload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LaloadInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'faload' instruction.
    /// </summary>
    public partial record struct FaloadInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FaloadInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FaloadInstruction(Instruction value) => value.AsFaload();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Faload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out FaloadInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out FaloadInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Faload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new FaloadInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'daload' instruction.
    /// </summary>
    public partial record struct DaloadInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DaloadInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DaloadInstruction(Instruction value) => value.AsDaload();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Daload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DaloadInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DaloadInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Daload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new DaloadInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'aaload' instruction.
    /// </summary>
    public partial record struct AaloadInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AaloadInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator AaloadInstruction(Instruction value) => value.AsAaload();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aaload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out AaloadInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out AaloadInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aaload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new AaloadInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'baload' instruction.
    /// </summary>
    public partial record struct BaloadInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="BaloadInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator BaloadInstruction(Instruction value) => value.AsBaload();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Baload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out BaloadInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out BaloadInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Baload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new BaloadInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'caload' instruction.
    /// </summary>
    public partial record struct CaloadInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="CaloadInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator CaloadInstruction(Instruction value) => value.AsCaload();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Caload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out CaloadInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out CaloadInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Caload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new CaloadInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'saload' instruction.
    /// </summary>
    public partial record struct SaloadInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="SaloadInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator SaloadInstruction(Instruction value) => value.AsSaload();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Saload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out SaloadInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out SaloadInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Saload)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new SaloadInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'istore' instruction.
    /// </summary>
    /// <param name="Local"></param>
    public partial record struct IstoreInstruction(ushort Local)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IstoreInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IstoreInstruction(Instruction value) => value.AsIstore();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {
                // advance by opcode and prefix
                size += 2;

                // arg1: Local
                if (Instruction.TryMeasureL2(ref reader, ref size) == false)
                    return false;
            }
            else
            {
                // advance by opcode size
                size += 1;

                // arg1: Local
                if (Instruction.TryMeasureL1(ref reader, ref size) == false)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IstoreInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IstoreInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new IstoreInstruction(local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new IstoreInstruction(local);
            }

            return true;
        }

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'lstore' instruction.
    /// </summary>
    /// <param name="Local"></param>
    public partial record struct LstoreInstruction(ushort Local)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LstoreInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LstoreInstruction(Instruction value) => value.AsLstore();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {
                // advance by opcode and prefix
                size += 2;

                // arg1: Local
                if (Instruction.TryMeasureL2(ref reader, ref size) == false)
                    return false;
            }
            else
            {
                // advance by opcode size
                size += 1;

                // arg1: Local
                if (Instruction.TryMeasureL1(ref reader, ref size) == false)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LstoreInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LstoreInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new LstoreInstruction(local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new LstoreInstruction(local);
            }

            return true;
        }

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'fstore' instruction.
    /// </summary>
    /// <param name="Local"></param>
    public partial record struct FstoreInstruction(ushort Local)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FstoreInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FstoreInstruction(Instruction value) => value.AsFstore();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {
                // advance by opcode and prefix
                size += 2;

                // arg1: Local
                if (Instruction.TryMeasureL2(ref reader, ref size) == false)
                    return false;
            }
            else
            {
                // advance by opcode size
                size += 1;

                // arg1: Local
                if (Instruction.TryMeasureL1(ref reader, ref size) == false)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out FstoreInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out FstoreInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new FstoreInstruction(local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new FstoreInstruction(local);
            }

            return true;
        }

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'dstore' instruction.
    /// </summary>
    /// <param name="Local"></param>
    public partial record struct DstoreInstruction(ushort Local)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DstoreInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DstoreInstruction(Instruction value) => value.AsDstore();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {
                // advance by opcode and prefix
                size += 2;

                // arg1: Local
                if (Instruction.TryMeasureL2(ref reader, ref size) == false)
                    return false;
            }
            else
            {
                // advance by opcode size
                size += 1;

                // arg1: Local
                if (Instruction.TryMeasureL1(ref reader, ref size) == false)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DstoreInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DstoreInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new DstoreInstruction(local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new DstoreInstruction(local);
            }

            return true;
        }

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'astore' instruction.
    /// </summary>
    /// <param name="Local"></param>
    public partial record struct AstoreInstruction(ushort Local)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AstoreInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator AstoreInstruction(Instruction value) => value.AsAstore();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {
                // advance by opcode and prefix
                size += 2;

                // arg1: Local
                if (Instruction.TryMeasureL2(ref reader, ref size) == false)
                    return false;
            }
            else
            {
                // advance by opcode size
                size += 1;

                // arg1: Local
                if (Instruction.TryMeasureL1(ref reader, ref size) == false)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out AstoreInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out AstoreInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new AstoreInstruction(local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new AstoreInstruction(local);
            }

            return true;
        }

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'istore_0' instruction.
    /// </summary>
    public partial record struct Istore0Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Istore0Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Istore0Instruction(Instruction value) => value.AsIstore0();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Istore0Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Istore0Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Istore0Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'istore_1' instruction.
    /// </summary>
    public partial record struct Istore1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Istore1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Istore1Instruction(Instruction value) => value.AsIstore1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Istore1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Istore1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Istore1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'istore_2' instruction.
    /// </summary>
    public partial record struct Istore2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Istore2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Istore2Instruction(Instruction value) => value.AsIstore2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Istore2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Istore2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Istore2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'istore_3' instruction.
    /// </summary>
    public partial record struct Istore3Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Istore3Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Istore3Instruction(Instruction value) => value.AsIstore3();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Istore3Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Istore3Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Istore3Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lstore_0' instruction.
    /// </summary>
    public partial record struct Lstore0Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lstore0Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Lstore0Instruction(Instruction value) => value.AsLstore0();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Lstore0Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Lstore0Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Lstore0Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lstore_1' instruction.
    /// </summary>
    public partial record struct Lstore1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lstore1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Lstore1Instruction(Instruction value) => value.AsLstore1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Lstore1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Lstore1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Lstore1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lstore_2' instruction.
    /// </summary>
    public partial record struct Lstore2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lstore2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Lstore2Instruction(Instruction value) => value.AsLstore2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Lstore2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Lstore2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Lstore2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lstore_3' instruction.
    /// </summary>
    public partial record struct Lstore3Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Lstore3Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Lstore3Instruction(Instruction value) => value.AsLstore3();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Lstore3Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Lstore3Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Lstore3Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fstore_0' instruction.
    /// </summary>
    public partial record struct Fstore0Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fstore0Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Fstore0Instruction(Instruction value) => value.AsFstore0();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Fstore0Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Fstore0Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Fstore0Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fstore_1' instruction.
    /// </summary>
    public partial record struct Fstore1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fstore1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Fstore1Instruction(Instruction value) => value.AsFstore1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Fstore1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Fstore1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Fstore1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fstore_2' instruction.
    /// </summary>
    public partial record struct Fstore2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fstore2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Fstore2Instruction(Instruction value) => value.AsFstore2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Fstore2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Fstore2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Fstore2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fstore_3' instruction.
    /// </summary>
    public partial record struct Fstore3Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Fstore3Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Fstore3Instruction(Instruction value) => value.AsFstore3();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Fstore3Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Fstore3Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Fstore3Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dstore_0' instruction.
    /// </summary>
    public partial record struct Dstore0Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dstore0Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Dstore0Instruction(Instruction value) => value.AsDstore0();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Dstore0Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Dstore0Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Dstore0Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dstore_1' instruction.
    /// </summary>
    public partial record struct Dstore1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dstore1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Dstore1Instruction(Instruction value) => value.AsDstore1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Dstore1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Dstore1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Dstore1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dstore_2' instruction.
    /// </summary>
    public partial record struct Dstore2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dstore2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Dstore2Instruction(Instruction value) => value.AsDstore2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Dstore2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Dstore2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Dstore2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dstore_3' instruction.
    /// </summary>
    public partial record struct Dstore3Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dstore3Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Dstore3Instruction(Instruction value) => value.AsDstore3();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Dstore3Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Dstore3Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Dstore3Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'astore_0' instruction.
    /// </summary>
    public partial record struct Astore0Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Astore0Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Astore0Instruction(Instruction value) => value.AsAstore0();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Astore0Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Astore0Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore0)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Astore0Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'astore_1' instruction.
    /// </summary>
    public partial record struct Astore1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Astore1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Astore1Instruction(Instruction value) => value.AsAstore1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Astore1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Astore1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Astore1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'astore_2' instruction.
    /// </summary>
    public partial record struct Astore2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Astore2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Astore2Instruction(Instruction value) => value.AsAstore2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Astore2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Astore2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Astore2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'astore_3' instruction.
    /// </summary>
    public partial record struct Astore3Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Astore3Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Astore3Instruction(Instruction value) => value.AsAstore3();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Astore3Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Astore3Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore3)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Astore3Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iastore' instruction.
    /// </summary>
    public partial record struct IastoreInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IastoreInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IastoreInstruction(Instruction value) => value.AsIastore();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iastore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IastoreInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IastoreInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iastore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new IastoreInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lastore' instruction.
    /// </summary>
    public partial record struct LastoreInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LastoreInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LastoreInstruction(Instruction value) => value.AsLastore();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lastore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LastoreInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LastoreInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lastore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LastoreInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fastore' instruction.
    /// </summary>
    public partial record struct FastoreInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FastoreInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FastoreInstruction(Instruction value) => value.AsFastore();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fastore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out FastoreInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out FastoreInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fastore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new FastoreInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dastore' instruction.
    /// </summary>
    public partial record struct DastoreInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DastoreInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DastoreInstruction(Instruction value) => value.AsDastore();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dastore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DastoreInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DastoreInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dastore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new DastoreInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'aastore' instruction.
    /// </summary>
    public partial record struct AastoreInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AastoreInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator AastoreInstruction(Instruction value) => value.AsAastore();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aastore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out AastoreInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out AastoreInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aastore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new AastoreInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'bastore' instruction.
    /// </summary>
    public partial record struct BastoreInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="BastoreInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator BastoreInstruction(Instruction value) => value.AsBastore();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Bastore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out BastoreInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out BastoreInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Bastore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new BastoreInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'castore' instruction.
    /// </summary>
    public partial record struct CastoreInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="CastoreInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator CastoreInstruction(Instruction value) => value.AsCastore();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Castore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out CastoreInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out CastoreInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Castore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new CastoreInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'sastore' instruction.
    /// </summary>
    public partial record struct SastoreInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="SastoreInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator SastoreInstruction(Instruction value) => value.AsSastore();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Sastore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out SastoreInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out SastoreInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Sastore)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new SastoreInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'pop' instruction.
    /// </summary>
    public partial record struct PopInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="PopInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PopInstruction(Instruction value) => value.AsPop();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Pop)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out PopInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out PopInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Pop)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new PopInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'pop2' instruction.
    /// </summary>
    public partial record struct Pop2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Pop2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Pop2Instruction(Instruction value) => value.AsPop2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Pop2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Pop2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Pop2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Pop2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Pop2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dup' instruction.
    /// </summary>
    public partial record struct DupInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DupInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DupInstruction(Instruction value) => value.AsDup();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DupInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DupInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new DupInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dup_x1' instruction.
    /// </summary>
    public partial record struct DupX1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DupX1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DupX1Instruction(Instruction value) => value.AsDupX1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.DupX1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DupX1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DupX1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.DupX1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new DupX1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dup_x2' instruction.
    /// </summary>
    public partial record struct DupX2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DupX2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DupX2Instruction(Instruction value) => value.AsDupX2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.DupX2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DupX2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DupX2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.DupX2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new DupX2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dup2' instruction.
    /// </summary>
    public partial record struct Dup2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dup2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Dup2Instruction(Instruction value) => value.AsDup2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Dup2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Dup2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Dup2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dup2_x1' instruction.
    /// </summary>
    public partial record struct Dup2X1Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dup2X1Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Dup2X1Instruction(Instruction value) => value.AsDup2X1();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup2X1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Dup2X1Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Dup2X1Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup2X1)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Dup2X1Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dup2_x2' instruction.
    /// </summary>
    public partial record struct Dup2X2Instruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="Dup2X2Instruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Dup2X2Instruction(Instruction value) => value.AsDup2X2();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup2X2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out Dup2X2Instruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out Dup2X2Instruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup2X2)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new Dup2X2Instruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'swap' instruction.
    /// </summary>
    public partial record struct SwapInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="SwapInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator SwapInstruction(Instruction value) => value.AsSwap();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Swap)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out SwapInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out SwapInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Swap)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new SwapInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iadd' instruction.
    /// </summary>
    public partial record struct IaddInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IaddInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IaddInstruction(Instruction value) => value.AsIadd();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iadd)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IaddInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IaddInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iadd)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new IaddInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'ladd' instruction.
    /// </summary>
    public partial record struct LaddInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LaddInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LaddInstruction(Instruction value) => value.AsLadd();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ladd)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LaddInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LaddInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ladd)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LaddInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fadd' instruction.
    /// </summary>
    public partial record struct FaddInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FaddInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FaddInstruction(Instruction value) => value.AsFadd();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fadd)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out FaddInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out FaddInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fadd)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new FaddInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dadd' instruction.
    /// </summary>
    public partial record struct DaddInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DaddInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DaddInstruction(Instruction value) => value.AsDadd();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dadd)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DaddInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DaddInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dadd)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new DaddInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'isub' instruction.
    /// </summary>
    public partial record struct IsubInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IsubInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IsubInstruction(Instruction value) => value.AsIsub();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Isub)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IsubInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IsubInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Isub)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new IsubInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lsub' instruction.
    /// </summary>
    public partial record struct LsubInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LsubInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LsubInstruction(Instruction value) => value.AsLsub();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lsub)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LsubInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LsubInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lsub)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LsubInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fsub' instruction.
    /// </summary>
    public partial record struct FsubInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FsubInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FsubInstruction(Instruction value) => value.AsFsub();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fsub)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out FsubInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out FsubInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fsub)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new FsubInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dsub' instruction.
    /// </summary>
    public partial record struct DsubInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DsubInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DsubInstruction(Instruction value) => value.AsDsub();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dsub)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DsubInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DsubInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dsub)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new DsubInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'imul' instruction.
    /// </summary>
    public partial record struct ImulInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="ImulInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ImulInstruction(Instruction value) => value.AsImul();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Imul)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out ImulInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out ImulInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Imul)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new ImulInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lmul' instruction.
    /// </summary>
    public partial record struct LmulInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LmulInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LmulInstruction(Instruction value) => value.AsLmul();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lmul)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LmulInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LmulInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lmul)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LmulInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fmul' instruction.
    /// </summary>
    public partial record struct FmulInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FmulInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FmulInstruction(Instruction value) => value.AsFmul();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fmul)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out FmulInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out FmulInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fmul)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new FmulInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dmul' instruction.
    /// </summary>
    public partial record struct DmulInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DmulInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DmulInstruction(Instruction value) => value.AsDmul();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dmul)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DmulInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DmulInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dmul)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new DmulInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'idiv' instruction.
    /// </summary>
    public partial record struct IdivInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IdivInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IdivInstruction(Instruction value) => value.AsIdiv();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Idiv)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IdivInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IdivInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Idiv)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new IdivInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'ldiv' instruction.
    /// </summary>
    public partial record struct LdivInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LdivInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LdivInstruction(Instruction value) => value.AsLdiv();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ldiv)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LdivInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LdivInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ldiv)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LdivInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fdiv' instruction.
    /// </summary>
    public partial record struct FdivInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FdivInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FdivInstruction(Instruction value) => value.AsFdiv();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fdiv)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out FdivInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out FdivInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fdiv)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new FdivInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'ddiv' instruction.
    /// </summary>
    public partial record struct DdivInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DdivInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DdivInstruction(Instruction value) => value.AsDdiv();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ddiv)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DdivInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DdivInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ddiv)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new DdivInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'irem' instruction.
    /// </summary>
    public partial record struct IremInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IremInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IremInstruction(Instruction value) => value.AsIrem();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Irem)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IremInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IremInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Irem)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new IremInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lrem' instruction.
    /// </summary>
    public partial record struct LremInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LremInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LremInstruction(Instruction value) => value.AsLrem();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lrem)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LremInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LremInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lrem)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LremInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'frem' instruction.
    /// </summary>
    public partial record struct FremInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FremInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FremInstruction(Instruction value) => value.AsFrem();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Frem)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out FremInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out FremInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Frem)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new FremInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'drem' instruction.
    /// </summary>
    public partial record struct DremInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DremInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DremInstruction(Instruction value) => value.AsDrem();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Drem)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DremInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DremInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Drem)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new DremInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'ineg' instruction.
    /// </summary>
    public partial record struct InegInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="InegInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator InegInstruction(Instruction value) => value.AsIneg();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ineg)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out InegInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out InegInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ineg)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new InegInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lneg' instruction.
    /// </summary>
    public partial record struct LnegInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LnegInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LnegInstruction(Instruction value) => value.AsLneg();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lneg)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LnegInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LnegInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lneg)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LnegInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fneg' instruction.
    /// </summary>
    public partial record struct FnegInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FnegInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FnegInstruction(Instruction value) => value.AsFneg();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fneg)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out FnegInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out FnegInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fneg)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new FnegInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dneg' instruction.
    /// </summary>
    public partial record struct DnegInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DnegInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DnegInstruction(Instruction value) => value.AsDneg();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dneg)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DnegInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DnegInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dneg)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new DnegInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'ishl' instruction.
    /// </summary>
    public partial record struct IshlInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IshlInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IshlInstruction(Instruction value) => value.AsIshl();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ishl)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IshlInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IshlInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ishl)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new IshlInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lshl' instruction.
    /// </summary>
    public partial record struct LshlInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LshlInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LshlInstruction(Instruction value) => value.AsLshl();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lshl)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LshlInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LshlInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lshl)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LshlInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'ishr' instruction.
    /// </summary>
    public partial record struct IshrInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IshrInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IshrInstruction(Instruction value) => value.AsIshr();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ishr)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IshrInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IshrInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ishr)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new IshrInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lshr' instruction.
    /// </summary>
    public partial record struct LshrInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LshrInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LshrInstruction(Instruction value) => value.AsLshr();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lshr)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LshrInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LshrInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lshr)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LshrInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iushr' instruction.
    /// </summary>
    public partial record struct IushrInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IushrInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IushrInstruction(Instruction value) => value.AsIushr();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iushr)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IushrInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IushrInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iushr)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new IushrInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lushr' instruction.
    /// </summary>
    public partial record struct LushrInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LushrInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LushrInstruction(Instruction value) => value.AsLushr();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lushr)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LushrInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LushrInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lushr)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LushrInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iand' instruction.
    /// </summary>
    public partial record struct IandInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IandInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IandInstruction(Instruction value) => value.AsIand();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iand)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IandInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IandInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iand)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new IandInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'land' instruction.
    /// </summary>
    public partial record struct LandInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LandInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LandInstruction(Instruction value) => value.AsLand();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Land)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LandInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LandInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Land)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LandInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'ior' instruction.
    /// </summary>
    public partial record struct IorInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IorInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IorInstruction(Instruction value) => value.AsIor();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ior)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IorInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IorInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ior)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new IorInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lor' instruction.
    /// </summary>
    public partial record struct LorInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LorInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LorInstruction(Instruction value) => value.AsLor();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lor)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LorInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LorInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lor)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LorInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'ixor' instruction.
    /// </summary>
    public partial record struct IxorInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IxorInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IxorInstruction(Instruction value) => value.AsIxor();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ixor)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IxorInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IxorInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ixor)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new IxorInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lxor' instruction.
    /// </summary>
    public partial record struct LxorInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LxorInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LxorInstruction(Instruction value) => value.AsLxor();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lxor)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LxorInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LxorInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lxor)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LxorInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'iinc' instruction.
    /// </summary>
    /// <param name="Local"></param>
    /// <param name="Value"></param>
    public partial record struct IincInstruction(ushort Local, short Value)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IincInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IincInstruction(Instruction value) => value.AsIinc();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iinc)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {
                // advance by opcode and prefix
                size += 2;

                // arg1: Local
                if (Instruction.TryMeasureL2(ref reader, ref size) == false)
                    return false;

                // arg2: Value
                if (Instruction.TryMeasureS2(ref reader, ref size) == false)
                    return false;
            }
            else
            {
                // advance by opcode size
                size += 1;

                // arg1: Local
                if (Instruction.TryMeasureL1(ref reader, ref size) == false)
                    return false;

                // arg2: Value
                if (Instruction.TryMeasureS1(ref reader, ref size) == false)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IincInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IincInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iinc)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                // arg2: Value
                if (Instruction.TryReadS2(ref reader, out var value) == false)
                    return false;

                instruction = new IincInstruction(local, value);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                // arg2: Value
                if (Instruction.TryReadS1(ref reader, out var value) == false)
                    return false;

                instruction = new IincInstruction(local, value);
            }

            return true;
        }

        // arg1: Local
        public readonly ushort Local = Local;

        // arg2: Value
        public readonly short Value = Value;

    }

    /// <summary>
    /// Describes the 'i2l' instruction.
    /// </summary>
    public partial record struct I2lInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="I2lInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator I2lInstruction(Instruction value) => value.AsI2l();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2l)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out I2lInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out I2lInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2l)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new I2lInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'i2f' instruction.
    /// </summary>
    public partial record struct I2fInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="I2fInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator I2fInstruction(Instruction value) => value.AsI2f();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2f)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out I2fInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out I2fInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2f)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new I2fInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'i2d' instruction.
    /// </summary>
    public partial record struct I2dInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="I2dInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator I2dInstruction(Instruction value) => value.AsI2d();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2d)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out I2dInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out I2dInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2d)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new I2dInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'l2i' instruction.
    /// </summary>
    public partial record struct L2iInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="L2iInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator L2iInstruction(Instruction value) => value.AsL2i();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.L2i)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out L2iInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out L2iInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.L2i)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new L2iInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'l2f' instruction.
    /// </summary>
    public partial record struct L2fInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="L2fInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator L2fInstruction(Instruction value) => value.AsL2f();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.L2f)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out L2fInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out L2fInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.L2f)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new L2fInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'l2d' instruction.
    /// </summary>
    public partial record struct L2dInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="L2dInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator L2dInstruction(Instruction value) => value.AsL2d();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.L2d)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out L2dInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out L2dInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.L2d)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new L2dInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'f2i' instruction.
    /// </summary>
    public partial record struct F2iInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="F2iInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator F2iInstruction(Instruction value) => value.AsF2i();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.F2i)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out F2iInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out F2iInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.F2i)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new F2iInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'f2l' instruction.
    /// </summary>
    public partial record struct F2lInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="F2lInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator F2lInstruction(Instruction value) => value.AsF2l();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.F2l)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out F2lInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out F2lInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.F2l)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new F2lInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'f2d' instruction.
    /// </summary>
    public partial record struct F2dInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="F2dInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator F2dInstruction(Instruction value) => value.AsF2d();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.F2d)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out F2dInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out F2dInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.F2d)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new F2dInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'd2i' instruction.
    /// </summary>
    public partial record struct D2iInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="D2iInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator D2iInstruction(Instruction value) => value.AsD2i();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.D2i)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out D2iInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out D2iInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.D2i)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new D2iInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'd2l' instruction.
    /// </summary>
    public partial record struct D2lInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="D2lInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator D2lInstruction(Instruction value) => value.AsD2l();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.D2l)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out D2lInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out D2lInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.D2l)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new D2lInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'd2f' instruction.
    /// </summary>
    public partial record struct D2fInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="D2fInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator D2fInstruction(Instruction value) => value.AsD2f();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.D2f)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out D2fInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out D2fInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.D2f)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new D2fInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'i2b' instruction.
    /// </summary>
    public partial record struct I2bInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="I2bInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator I2bInstruction(Instruction value) => value.AsI2b();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2b)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out I2bInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out I2bInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2b)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new I2bInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'i2c' instruction.
    /// </summary>
    public partial record struct I2cInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="I2cInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator I2cInstruction(Instruction value) => value.AsI2c();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2c)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out I2cInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out I2cInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2c)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new I2cInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'i2s' instruction.
    /// </summary>
    public partial record struct I2sInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="I2sInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator I2sInstruction(Instruction value) => value.AsI2s();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2s)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out I2sInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out I2sInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2s)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new I2sInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lcmp' instruction.
    /// </summary>
    public partial record struct LcmpInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LcmpInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LcmpInstruction(Instruction value) => value.AsLcmp();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lcmp)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LcmpInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LcmpInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lcmp)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LcmpInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fcmpl' instruction.
    /// </summary>
    public partial record struct FcmplInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FcmplInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FcmplInstruction(Instruction value) => value.AsFcmpl();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fcmpl)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out FcmplInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out FcmplInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fcmpl)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new FcmplInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'fcmpg' instruction.
    /// </summary>
    public partial record struct FcmpgInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FcmpgInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FcmpgInstruction(Instruction value) => value.AsFcmpg();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fcmpg)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out FcmpgInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out FcmpgInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fcmpg)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new FcmpgInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dcmpl' instruction.
    /// </summary>
    public partial record struct DcmplInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DcmplInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DcmplInstruction(Instruction value) => value.AsDcmpl();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dcmpl)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DcmplInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DcmplInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dcmpl)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new DcmplInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dcmpg' instruction.
    /// </summary>
    public partial record struct DcmpgInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DcmpgInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DcmpgInstruction(Instruction value) => value.AsDcmpg();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dcmpg)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DcmpgInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DcmpgInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dcmpg)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new DcmpgInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'ifeq' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfeqInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfeqInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfeqInstruction(Instruction value) => value.AsIfeq();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifeq)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfeqInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfeqInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifeq)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfeqInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'ifne' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfneInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfneInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfneInstruction(Instruction value) => value.AsIfne();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifne)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfneInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfneInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifne)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfneInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'iflt' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfltInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfltInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfltInstruction(Instruction value) => value.AsIflt();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iflt)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfltInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfltInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iflt)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfltInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'ifge' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfgeInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfgeInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfgeInstruction(Instruction value) => value.AsIfge();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifge)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfgeInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfgeInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifge)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfgeInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'ifgt' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfgtInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfgtInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfgtInstruction(Instruction value) => value.AsIfgt();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifgt)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfgtInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfgtInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifgt)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfgtInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'ifle' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfleInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfleInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfleInstruction(Instruction value) => value.AsIfle();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifle)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfleInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfleInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifle)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfleInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_icmpeq' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfIcmpeqInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfIcmpeqInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfIcmpeqInstruction(Instruction value) => value.AsIfIcmpeq();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpeq)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfIcmpeqInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfIcmpeqInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpeq)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfIcmpeqInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_icmpne' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfIcmpneInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfIcmpneInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfIcmpneInstruction(Instruction value) => value.AsIfIcmpne();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpne)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfIcmpneInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfIcmpneInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpne)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfIcmpneInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_icmplt' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfIcmpltInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfIcmpltInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfIcmpltInstruction(Instruction value) => value.AsIfIcmplt();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmplt)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfIcmpltInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfIcmpltInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmplt)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfIcmpltInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_icmpge' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfIcmpgeInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfIcmpgeInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfIcmpgeInstruction(Instruction value) => value.AsIfIcmpge();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpge)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfIcmpgeInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfIcmpgeInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpge)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfIcmpgeInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_icmpgt' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfIcmpgtInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfIcmpgtInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfIcmpgtInstruction(Instruction value) => value.AsIfIcmpgt();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpgt)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfIcmpgtInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfIcmpgtInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpgt)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfIcmpgtInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_icmple' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfIcmpleInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfIcmpleInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfIcmpleInstruction(Instruction value) => value.AsIfIcmple();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmple)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfIcmpleInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfIcmpleInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmple)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfIcmpleInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_acmpeq' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfAcmpeqInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfAcmpeqInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfAcmpeqInstruction(Instruction value) => value.AsIfAcmpeq();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfAcmpeq)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfAcmpeqInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfAcmpeqInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfAcmpeq)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfAcmpeqInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_acmpne' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfAcmpneInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfAcmpneInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfAcmpneInstruction(Instruction value) => value.AsIfAcmpne();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfAcmpne)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfAcmpneInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfAcmpneInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfAcmpne)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfAcmpneInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'goto' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct GotoInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="GotoInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator GotoInstruction(Instruction value) => value.AsGoto();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Goto)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out GotoInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out GotoInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Goto)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new GotoInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'jsr' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct JsrInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="JsrInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator JsrInstruction(Instruction value) => value.AsJsr();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Jsr)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out JsrInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out JsrInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Jsr)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new JsrInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'ret' instruction.
    /// </summary>
    /// <param name="Local"></param>
    public partial record struct RetInstruction(ushort Local)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="RetInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator RetInstruction(Instruction value) => value.AsRet();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ret)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {
                // advance by opcode and prefix
                size += 2;

                // arg1: Local
                if (Instruction.TryMeasureL2(ref reader, ref size) == false)
                    return false;
            }
            else
            {
                // advance by opcode size
                size += 1;

                // arg1: Local
                if (Instruction.TryMeasureL1(ref reader, ref size) == false)
                    return false;
            }

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out RetInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out RetInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ret)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new RetInstruction(local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new RetInstruction(local);
            }

            return true;
        }

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'ireturn' instruction.
    /// </summary>
    public partial record struct IreturnInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IreturnInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IreturnInstruction(Instruction value) => value.AsIreturn();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ireturn)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IreturnInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IreturnInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ireturn)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new IreturnInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'lreturn' instruction.
    /// </summary>
    public partial record struct LreturnInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="LreturnInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator LreturnInstruction(Instruction value) => value.AsLreturn();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lreturn)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out LreturnInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out LreturnInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lreturn)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new LreturnInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'freturn' instruction.
    /// </summary>
    public partial record struct FreturnInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="FreturnInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator FreturnInstruction(Instruction value) => value.AsFreturn();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Freturn)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out FreturnInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out FreturnInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Freturn)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new FreturnInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'dreturn' instruction.
    /// </summary>
    public partial record struct DreturnInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="DreturnInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator DreturnInstruction(Instruction value) => value.AsDreturn();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dreturn)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out DreturnInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out DreturnInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dreturn)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new DreturnInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'areturn' instruction.
    /// </summary>
    public partial record struct AreturnInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AreturnInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator AreturnInstruction(Instruction value) => value.AsAreturn();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Areturn)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out AreturnInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out AreturnInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Areturn)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new AreturnInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'return' instruction.
    /// </summary>
    public partial record struct ReturnInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="ReturnInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ReturnInstruction(Instruction value) => value.AsReturn();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Return)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out ReturnInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out ReturnInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Return)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new ReturnInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'getstatic' instruction.
    /// </summary>
    /// <param name="Field"></param>
    public partial record struct GetStaticInstruction(ConstantHandle Field)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="GetStaticInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator GetStaticInstruction(Instruction value) => value.AsGetStatic();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.GetStatic)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Field
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out GetStaticInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out GetStaticInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.GetStatic)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Field
            if (Instruction.TryReadC2(ref reader, out var field) == false)
                return false;

            instruction = new GetStaticInstruction(field);

            return true;
        }

        // arg1: Field
        public readonly ConstantHandle Field = Field;

    }

    /// <summary>
    /// Describes the 'putstatic' instruction.
    /// </summary>
    /// <param name="Field"></param>
    public partial record struct PutStaticInstruction(ConstantHandle Field)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="PutStaticInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PutStaticInstruction(Instruction value) => value.AsPutStatic();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.PutStatic)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Field
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out PutStaticInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out PutStaticInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.PutStatic)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Field
            if (Instruction.TryReadC2(ref reader, out var field) == false)
                return false;

            instruction = new PutStaticInstruction(field);

            return true;
        }

        // arg1: Field
        public readonly ConstantHandle Field = Field;

    }

    /// <summary>
    /// Describes the 'getfield' instruction.
    /// </summary>
    /// <param name="Field"></param>
    public partial record struct GetFieldInstruction(ConstantHandle Field)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="GetFieldInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator GetFieldInstruction(Instruction value) => value.AsGetField();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.GetField)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Field
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out GetFieldInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out GetFieldInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.GetField)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Field
            if (Instruction.TryReadC2(ref reader, out var field) == false)
                return false;

            instruction = new GetFieldInstruction(field);

            return true;
        }

        // arg1: Field
        public readonly ConstantHandle Field = Field;

    }

    /// <summary>
    /// Describes the 'putfield' instruction.
    /// </summary>
    /// <param name="Field"></param>
    public partial record struct PutFieldInstruction(ConstantHandle Field)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="PutFieldInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator PutFieldInstruction(Instruction value) => value.AsPutField();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.PutField)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Field
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out PutFieldInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out PutFieldInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.PutField)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Field
            if (Instruction.TryReadC2(ref reader, out var field) == false)
                return false;

            instruction = new PutFieldInstruction(field);

            return true;
        }

        // arg1: Field
        public readonly ConstantHandle Field = Field;

    }

    /// <summary>
    /// Describes the 'invokevirtual' instruction.
    /// </summary>
    /// <param name="Method"></param>
    public partial record struct InvokeVirtualInstruction(ConstantHandle Method)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="InvokeVirtualInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator InvokeVirtualInstruction(Instruction value) => value.AsInvokeVirtual();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeVirtual)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Method
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out InvokeVirtualInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out InvokeVirtualInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeVirtual)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Method
            if (Instruction.TryReadC2(ref reader, out var method) == false)
                return false;

            instruction = new InvokeVirtualInstruction(method);

            return true;
        }

        // arg1: Method
        public readonly ConstantHandle Method = Method;

    }

    /// <summary>
    /// Describes the 'invokespecial' instruction.
    /// </summary>
    /// <param name="Method"></param>
    public partial record struct InvokeSpecialInstruction(ConstantHandle Method)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="InvokeSpecialInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator InvokeSpecialInstruction(Instruction value) => value.AsInvokeSpecial();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeSpecial)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Method
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out InvokeSpecialInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out InvokeSpecialInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeSpecial)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Method
            if (Instruction.TryReadC2(ref reader, out var method) == false)
                return false;

            instruction = new InvokeSpecialInstruction(method);

            return true;
        }

        // arg1: Method
        public readonly ConstantHandle Method = Method;

    }

    /// <summary>
    /// Describes the 'invokestatic' instruction.
    /// </summary>
    /// <param name="Method"></param>
    public partial record struct InvokeStaticInstruction(ConstantHandle Method)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="InvokeStaticInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator InvokeStaticInstruction(Instruction value) => value.AsInvokeStatic();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeStatic)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Method
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out InvokeStaticInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out InvokeStaticInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeStatic)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Method
            if (Instruction.TryReadC2(ref reader, out var method) == false)
                return false;

            instruction = new InvokeStaticInstruction(method);

            return true;
        }

        // arg1: Method
        public readonly ConstantHandle Method = Method;

    }

    /// <summary>
    /// Describes the 'invokeinterface' instruction.
    /// </summary>
    /// <param name="Method"></param>
    /// <param name="Count"></param>
    /// <param name="Zero"></param>
    public partial record struct InvokeInterfaceInstruction(ConstantHandle Method, byte Count, byte Zero)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="InvokeInterfaceInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator InvokeInterfaceInstruction(Instruction value) => value.AsInvokeInterface();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeInterface)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Method
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            // arg2: Count
            if (Instruction.TryMeasureU1(ref reader, ref size) == false)
                return false;

            // arg3: Zero
            if (Instruction.TryMeasureU1(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out InvokeInterfaceInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out InvokeInterfaceInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeInterface)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Method
            if (Instruction.TryReadC2(ref reader, out var method) == false)
                return false;

            // arg2: Count
            if (Instruction.TryReadU1(ref reader, out var count) == false)
                return false;

            // arg3: Zero
            if (Instruction.TryReadU1(ref reader, out var zero) == false)
                return false;

            instruction = new InvokeInterfaceInstruction(method, count, zero);

            return true;
        }

        // arg1: Method
        public readonly ConstantHandle Method = Method;

        // arg2: Count
        public readonly byte Count = Count;

        // arg3: Zero
        public readonly byte Zero = Zero;

    }

    /// <summary>
    /// Describes the 'invokedynamic' instruction.
    /// </summary>
    /// <param name="Method"></param>
    /// <param name="Zero"></param>
    /// <param name="Zero2"></param>
    public partial record struct InvokeDynamicInstruction(ConstantHandle Method, byte Zero, byte Zero2)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="InvokeDynamicInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator InvokeDynamicInstruction(Instruction value) => value.AsInvokeDynamic();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeDynamic)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Method
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            // arg2: Zero
            if (Instruction.TryMeasureU1(ref reader, ref size) == false)
                return false;

            // arg3: Zero2
            if (Instruction.TryMeasureU1(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out InvokeDynamicInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out InvokeDynamicInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeDynamic)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Method
            if (Instruction.TryReadC2(ref reader, out var method) == false)
                return false;

            // arg2: Zero
            if (Instruction.TryReadU1(ref reader, out var zero) == false)
                return false;

            // arg3: Zero2
            if (Instruction.TryReadU1(ref reader, out var zero2) == false)
                return false;

            instruction = new InvokeDynamicInstruction(method, zero, zero2);

            return true;
        }

        // arg1: Method
        public readonly ConstantHandle Method = Method;

        // arg2: Zero
        public readonly byte Zero = Zero;

        // arg3: Zero2
        public readonly byte Zero2 = Zero2;

    }

    /// <summary>
    /// Describes the 'new' instruction.
    /// </summary>
    /// <param name="Constant"></param>
    public partial record struct NewInstruction(ConstantHandle Constant)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="NewInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator NewInstruction(Instruction value) => value.AsNew();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.New)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Constant
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out NewInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out NewInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.New)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Constant
            if (Instruction.TryReadC2(ref reader, out var constant) == false)
                return false;

            instruction = new NewInstruction(constant);

            return true;
        }

        // arg1: Constant
        public readonly ConstantHandle Constant = Constant;

    }

    /// <summary>
    /// Describes the 'newarray' instruction.
    /// </summary>
    /// <param name="Value"></param>
    public partial record struct NewarrayInstruction(byte Value)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="NewarrayInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator NewarrayInstruction(Instruction value) => value.AsNewarray();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Newarray)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Value
            if (Instruction.TryMeasureU1(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out NewarrayInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out NewarrayInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Newarray)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Value
            if (Instruction.TryReadU1(ref reader, out var value) == false)
                return false;

            instruction = new NewarrayInstruction(value);

            return true;
        }

        // arg1: Value
        public readonly byte Value = Value;

    }

    /// <summary>
    /// Describes the 'anewarray' instruction.
    /// </summary>
    /// <param name="Constant"></param>
    public partial record struct AnewarrayInstruction(ConstantHandle Constant)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AnewarrayInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator AnewarrayInstruction(Instruction value) => value.AsAnewarray();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Anewarray)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Constant
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out AnewarrayInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out AnewarrayInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Anewarray)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Constant
            if (Instruction.TryReadC2(ref reader, out var constant) == false)
                return false;

            instruction = new AnewarrayInstruction(constant);

            return true;
        }

        // arg1: Constant
        public readonly ConstantHandle Constant = Constant;

    }

    /// <summary>
    /// Describes the 'arraylength' instruction.
    /// </summary>
    public partial record struct ArraylengthInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="ArraylengthInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ArraylengthInstruction(Instruction value) => value.AsArraylength();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Arraylength)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out ArraylengthInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out ArraylengthInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Arraylength)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new ArraylengthInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'athrow' instruction.
    /// </summary>
    public partial record struct AthrowInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="AthrowInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator AthrowInstruction(Instruction value) => value.AsAthrow();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Athrow)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out AthrowInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out AthrowInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Athrow)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new AthrowInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'checkcast' instruction.
    /// </summary>
    /// <param name="Type"></param>
    public partial record struct CheckcastInstruction(ConstantHandle Type)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="CheckcastInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator CheckcastInstruction(Instruction value) => value.AsCheckcast();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Checkcast)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Type
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out CheckcastInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out CheckcastInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Checkcast)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Type
            if (Instruction.TryReadC2(ref reader, out var type) == false)
                return false;

            instruction = new CheckcastInstruction(type);

            return true;
        }

        // arg1: Type
        public readonly ConstantHandle Type = Type;

    }

    /// <summary>
    /// Describes the 'instanceof' instruction.
    /// </summary>
    /// <param name="Type"></param>
    public partial record struct InstanceOfInstruction(ConstantHandle Type)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="InstanceOfInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator InstanceOfInstruction(Instruction value) => value.AsInstanceOf();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InstanceOf)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Type
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out InstanceOfInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out InstanceOfInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InstanceOf)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Type
            if (Instruction.TryReadC2(ref reader, out var type) == false)
                return false;

            instruction = new InstanceOfInstruction(type);

            return true;
        }

        // arg1: Type
        public readonly ConstantHandle Type = Type;

    }

    /// <summary>
    /// Describes the 'monitorenter' instruction.
    /// </summary>
    public partial record struct MonitorEnterInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="MonitorEnterInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator MonitorEnterInstruction(Instruction value) => value.AsMonitorEnter();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.MonitorEnter)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out MonitorEnterInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out MonitorEnterInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.MonitorEnter)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new MonitorEnterInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'monitorexit' instruction.
    /// </summary>
    public partial record struct MonitorExitInstruction()
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="MonitorExitInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator MonitorExitInstruction(Instruction value) => value.AsMonitorExit();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.MonitorExit)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out MonitorExitInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out MonitorExitInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.MonitorExit)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            instruction = new MonitorExitInstruction();

            return true;
        }

    }

    /// <summary>
    /// Describes the 'multianewarray' instruction.
    /// </summary>
    /// <param name="Type"></param>
    /// <param name="Dimensions"></param>
    public partial record struct MultianewarrayInstruction(ConstantHandle Type, byte Dimensions)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="MultianewarrayInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator MultianewarrayInstruction(Instruction value) => value.AsMultianewarray();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Multianewarray)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Type
            if (Instruction.TryMeasureC2(ref reader, ref size) == false)
                return false;

            // arg2: Dimensions
            if (Instruction.TryMeasureU1(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out MultianewarrayInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out MultianewarrayInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Multianewarray)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Type
            if (Instruction.TryReadC2(ref reader, out var type) == false)
                return false;

            // arg2: Dimensions
            if (Instruction.TryReadU1(ref reader, out var dimensions) == false)
                return false;

            instruction = new MultianewarrayInstruction(type, dimensions);

            return true;
        }

        // arg1: Type
        public readonly ConstantHandle Type = Type;

        // arg2: Dimensions
        public readonly byte Dimensions = Dimensions;

    }

    /// <summary>
    /// Describes the 'ifnull' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfNullInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfNullInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfNullInstruction(Instruction value) => value.AsIfNull();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfNull)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfNullInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfNullInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfNull)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfNullInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'ifnonnull' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct IfNonNullInstruction(short Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="IfNonNullInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator IfNonNullInstruction(Instruction value) => value.AsIfNonNull();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfNonNull)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ2(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out IfNonNullInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out IfNonNullInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfNonNull)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfNonNullInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'goto_w' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct GotoWInstruction(int Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="GotoWInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator GotoWInstruction(Instruction value) => value.AsGotoW();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.GotoW)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ4(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out GotoWInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out GotoWInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.GotoW)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ4(ref reader, out var target) == false)
                return false;

            instruction = new GotoWInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly int Target = Target;

    }

    /// <summary>
    /// Describes the 'jsr_w' instruction.
    /// </summary>
    /// <param name="Target"></param>
    public partial record struct JsrWInstruction(int Target)
    {
    
        /// <summary>
        /// Converts the <see cref="Instruction" /> to a <see cref="JsrWInstruction" />.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator JsrWInstruction(Instruction value) => value.AsJsrW();
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.JsrW)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            // arg1: Target
            if (Instruction.TryMeasureJ4(ref reader, ref size) == false)
                return false;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ReadOnlySequence<byte> data, out JsrWInstruction instruction)
        {
            var reader = new SequenceReader<byte>(data);
            return TryRead(ref reader, out instruction);
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool TryRead(ref SequenceReader<byte> reader, out JsrWInstruction instruction)
        {
            instruction = default;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.JsrW)
                throw new InvalidCodeException($"Unexpected opcode '{opcode:X}' at {reader.Position}.");

            if (wide)
                throw new InvalidCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ4(ref reader, out var target) == false)
                return false;

            instruction = new JsrWInstruction(target);

            return true;
        }

        // arg1: Target
        public readonly int Target = Target;

    }

}
