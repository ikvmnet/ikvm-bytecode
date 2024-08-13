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
                case OpCode.Wide:
                    return WideInstruction.TryMeasure(ref reader, ref size);
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
                    throw new ByteCodeException("Unsupported or unexpected instruction.");
            }
        }
    
    }

    /// <summary>
    /// Describes the 'nop' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct NopInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Nop;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Nop)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out NopInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Nop)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new NopInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'aconst_null' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct AconstNullInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.AconstNull;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.AconstNull)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out AconstNullInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.AconstNull)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new AconstNullInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iconst_m1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct IconstM1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.IconstM1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IconstM1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IconstM1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IconstM1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new IconstM1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iconst_0' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Iconst0Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iconst0;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Iconst0Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Iconst0Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iconst_1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Iconst1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iconst1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Iconst1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Iconst1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iconst_2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Iconst2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iconst2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Iconst2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Iconst2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iconst_3' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Iconst3Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iconst3;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Iconst3Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Iconst3Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iconst_4' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Iconst4Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iconst4;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst4)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Iconst4Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst4)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Iconst4Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iconst_5' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Iconst5Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iconst5;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst5)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Iconst5Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iconst5)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Iconst5Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lconst_0' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Lconst0Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lconst0;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lconst0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Lconst0Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lconst0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Lconst0Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lconst_1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Lconst1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lconst1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lconst1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Lconst1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lconst1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Lconst1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fconst_0' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Fconst0Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fconst0;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fconst0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Fconst0Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fconst0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Fconst0Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fconst_1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Fconst1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fconst1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fconst1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Fconst1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fconst1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Fconst1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fconst_2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Fconst2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fconst2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fconst2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Fconst2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fconst2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Fconst2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dconst_0' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Dconst0Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dconst0;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dconst0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Dconst0Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dconst0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Dconst0Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dconst_1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Dconst1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dconst1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dconst1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Dconst1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dconst1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Dconst1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'bipush' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Value"></param>
    public partial record struct BipushInstruction(int Offset, sbyte Value)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Bipush;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Bipush)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out BipushInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Bipush)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Value
            if (Instruction.TryReadS1(ref reader, out var value) == false)
                return false;

            instruction = new BipushInstruction(position.GetInteger(), value);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Value
        public readonly sbyte Value = Value;

    }

    /// <summary>
    /// Describes the 'sipush' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Value"></param>
    public partial record struct SipushInstruction(int Offset, short Value)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Sipush;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Sipush)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out SipushInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Sipush)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Value
            if (Instruction.TryReadS2(ref reader, out var value) == false)
                return false;

            instruction = new SipushInstruction(position.GetInteger(), value);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Value
        public readonly short Value = Value;

    }

    /// <summary>
    /// Describes the 'ldc' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Constant"></param>
    public partial record struct LdcInstruction(int Offset, ConstantHandle Constant)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ldc;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ldc)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LdcInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ldc)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Constant
            if (Instruction.TryReadC1(ref reader, out var constant) == false)
                return false;

            instruction = new LdcInstruction(position.GetInteger(), constant);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Constant
        public readonly ConstantHandle Constant = Constant;

    }

    /// <summary>
    /// Describes the 'ldc_w' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Constant"></param>
    public partial record struct LdcWInstruction(int Offset, ConstantHandle Constant)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.LdcW;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.LdcW)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LdcWInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.LdcW)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Constant
            if (Instruction.TryReadC2(ref reader, out var constant) == false)
                return false;

            instruction = new LdcWInstruction(position.GetInteger(), constant);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Constant
        public readonly ConstantHandle Constant = Constant;

    }

    /// <summary>
    /// Describes the 'ldc2_w' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Constant"></param>
    public partial record struct Ldc2WInstruction(int Offset, ConstantHandle Constant)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ldc2W;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ldc2W)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Ldc2WInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ldc2W)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Constant
            if (Instruction.TryReadC2(ref reader, out var constant) == false)
                return false;

            instruction = new Ldc2WInstruction(position.GetInteger(), constant);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Constant
        public readonly ConstantHandle Constant = Constant;

    }

    /// <summary>
    /// Describes the 'iload' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Local"></param>
    public partial record struct IloadInstruction(int Offset, ushort Local)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iload;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IloadInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new IloadInstruction(position.GetInteger(), local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new IloadInstruction(position.GetInteger(), local);
            }

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'lload' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Local"></param>
    public partial record struct LloadInstruction(int Offset, ushort Local)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lload;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LloadInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new LloadInstruction(position.GetInteger(), local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new LloadInstruction(position.GetInteger(), local);
            }

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'fload' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Local"></param>
    public partial record struct FloadInstruction(int Offset, ushort Local)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fload;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out FloadInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new FloadInstruction(position.GetInteger(), local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new FloadInstruction(position.GetInteger(), local);
            }

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'dload' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Local"></param>
    public partial record struct DloadInstruction(int Offset, ushort Local)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dload;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DloadInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new DloadInstruction(position.GetInteger(), local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new DloadInstruction(position.GetInteger(), local);
            }

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'aload' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Local"></param>
    public partial record struct AloadInstruction(int Offset, ushort Local)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Aload;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out AloadInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new AloadInstruction(position.GetInteger(), local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new AloadInstruction(position.GetInteger(), local);
            }

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'iload_0' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Iload0Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iload0;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Iload0Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Iload0Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iload_1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Iload1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iload1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Iload1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Iload1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iload_2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Iload2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iload2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Iload2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Iload2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iload_3' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Iload3Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iload3;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Iload3Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iload3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Iload3Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lload_0' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Lload0Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lload0;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Lload0Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Lload0Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lload_1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Lload1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lload1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Lload1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Lload1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lload_2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Lload2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lload2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Lload2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Lload2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lload_3' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Lload3Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lload3;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Lload3Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lload3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Lload3Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fload_0' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Fload0Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fload0;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Fload0Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Fload0Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fload_1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Fload1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fload1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Fload1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Fload1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fload_2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Fload2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fload2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Fload2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Fload2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fload_3' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Fload3Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fload3;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Fload3Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fload3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Fload3Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dload_0' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Dload0Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dload0;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Dload0Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Dload0Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dload_1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Dload1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dload1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Dload1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Dload1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dload_2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Dload2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dload2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Dload2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Dload2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dload_3' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Dload3Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dload3;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Dload3Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dload3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Dload3Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'aload_0' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Aload0Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Aload0;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Aload0Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Aload0Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'aload_1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Aload1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Aload1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Aload1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Aload1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'aload_2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Aload2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Aload2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Aload2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Aload2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'aload_3' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Aload3Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Aload3;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Aload3Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aload3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Aload3Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iaload' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct IaloadInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iaload;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iaload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IaloadInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iaload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new IaloadInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'laload' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LaloadInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Laload;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Laload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LaloadInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Laload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LaloadInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'faload' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct FaloadInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Faload;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Faload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out FaloadInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Faload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new FaloadInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'daload' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct DaloadInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Daload;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Daload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DaloadInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Daload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new DaloadInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'aaload' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct AaloadInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Aaload;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aaload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out AaloadInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aaload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new AaloadInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'baload' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct BaloadInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Baload;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Baload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out BaloadInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Baload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new BaloadInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'caload' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct CaloadInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Caload;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Caload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out CaloadInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Caload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new CaloadInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'saload' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct SaloadInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Saload;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Saload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out SaloadInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Saload)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new SaloadInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'istore' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Local"></param>
    public partial record struct IstoreInstruction(int Offset, ushort Local)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Istore;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IstoreInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new IstoreInstruction(position.GetInteger(), local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new IstoreInstruction(position.GetInteger(), local);
            }

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'lstore' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Local"></param>
    public partial record struct LstoreInstruction(int Offset, ushort Local)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lstore;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LstoreInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new LstoreInstruction(position.GetInteger(), local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new LstoreInstruction(position.GetInteger(), local);
            }

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'fstore' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Local"></param>
    public partial record struct FstoreInstruction(int Offset, ushort Local)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fstore;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out FstoreInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new FstoreInstruction(position.GetInteger(), local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new FstoreInstruction(position.GetInteger(), local);
            }

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'dstore' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Local"></param>
    public partial record struct DstoreInstruction(int Offset, ushort Local)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dstore;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DstoreInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new DstoreInstruction(position.GetInteger(), local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new DstoreInstruction(position.GetInteger(), local);
            }

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'astore' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Local"></param>
    public partial record struct AstoreInstruction(int Offset, ushort Local)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Astore;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out AstoreInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new AstoreInstruction(position.GetInteger(), local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new AstoreInstruction(position.GetInteger(), local);
            }

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'istore_0' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Istore0Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Istore0;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Istore0Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Istore0Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'istore_1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Istore1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Istore1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Istore1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Istore1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'istore_2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Istore2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Istore2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Istore2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Istore2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'istore_3' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Istore3Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Istore3;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Istore3Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Istore3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Istore3Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lstore_0' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Lstore0Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lstore0;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Lstore0Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Lstore0Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lstore_1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Lstore1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lstore1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Lstore1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Lstore1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lstore_2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Lstore2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lstore2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Lstore2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Lstore2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lstore_3' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Lstore3Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lstore3;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Lstore3Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lstore3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Lstore3Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fstore_0' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Fstore0Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fstore0;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Fstore0Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Fstore0Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fstore_1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Fstore1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fstore1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Fstore1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Fstore1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fstore_2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Fstore2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fstore2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Fstore2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Fstore2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fstore_3' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Fstore3Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fstore3;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Fstore3Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fstore3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Fstore3Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dstore_0' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Dstore0Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dstore0;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Dstore0Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Dstore0Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dstore_1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Dstore1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dstore1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Dstore1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Dstore1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dstore_2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Dstore2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dstore2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Dstore2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Dstore2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dstore_3' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Dstore3Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dstore3;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Dstore3Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dstore3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Dstore3Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'astore_0' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Astore0Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Astore0;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Astore0Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore0)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Astore0Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'astore_1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Astore1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Astore1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Astore1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Astore1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'astore_2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Astore2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Astore2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Astore2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Astore2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'astore_3' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Astore3Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Astore3;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Astore3Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Astore3)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Astore3Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iastore' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct IastoreInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iastore;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iastore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IastoreInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iastore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new IastoreInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lastore' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LastoreInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lastore;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lastore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LastoreInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lastore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LastoreInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fastore' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct FastoreInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fastore;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fastore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out FastoreInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fastore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new FastoreInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dastore' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct DastoreInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dastore;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dastore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DastoreInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dastore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new DastoreInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'aastore' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct AastoreInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Aastore;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aastore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out AastoreInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Aastore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new AastoreInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'bastore' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct BastoreInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Bastore;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Bastore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out BastoreInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Bastore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new BastoreInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'castore' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct CastoreInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Castore;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Castore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out CastoreInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Castore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new CastoreInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'sastore' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct SastoreInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Sastore;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Sastore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out SastoreInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Sastore)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new SastoreInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'pop' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct PopInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Pop;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Pop)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out PopInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Pop)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new PopInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'pop2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Pop2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Pop2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Pop2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Pop2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Pop2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Pop2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dup' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct DupInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dup;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DupInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new DupInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dup_x1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct DupX1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.DupX1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.DupX1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DupX1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.DupX1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new DupX1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dup_x2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct DupX2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.DupX2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.DupX2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DupX2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.DupX2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new DupX2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dup2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Dup2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dup2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Dup2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Dup2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dup2_x1' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Dup2X1Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dup2X1;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup2X1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Dup2X1Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup2X1)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Dup2X1Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dup2_x2' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct Dup2X2Instruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dup2X2;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup2X2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out Dup2X2Instruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dup2X2)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new Dup2X2Instruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'swap' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct SwapInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Swap;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Swap)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out SwapInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Swap)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new SwapInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iadd' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct IaddInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iadd;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iadd)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IaddInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iadd)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new IaddInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'ladd' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LaddInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ladd;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ladd)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LaddInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ladd)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LaddInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fadd' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct FaddInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fadd;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fadd)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out FaddInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fadd)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new FaddInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dadd' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct DaddInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dadd;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dadd)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DaddInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dadd)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new DaddInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'isub' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct IsubInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Isub;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Isub)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IsubInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Isub)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new IsubInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lsub' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LsubInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lsub;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lsub)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LsubInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lsub)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LsubInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fsub' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct FsubInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fsub;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fsub)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out FsubInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fsub)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new FsubInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dsub' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct DsubInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dsub;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dsub)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DsubInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dsub)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new DsubInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'imul' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct ImulInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Imul;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Imul)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out ImulInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Imul)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new ImulInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lmul' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LmulInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lmul;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lmul)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LmulInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lmul)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LmulInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fmul' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct FmulInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fmul;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fmul)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out FmulInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fmul)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new FmulInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dmul' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct DmulInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dmul;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dmul)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DmulInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dmul)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new DmulInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'idiv' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct IdivInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Idiv;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Idiv)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IdivInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Idiv)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new IdivInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'ldiv' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LdivInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ldiv;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ldiv)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LdivInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ldiv)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LdivInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fdiv' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct FdivInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fdiv;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fdiv)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out FdivInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fdiv)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new FdivInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'ddiv' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct DdivInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ddiv;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ddiv)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DdivInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ddiv)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new DdivInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'irem' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct IremInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Irem;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Irem)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IremInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Irem)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new IremInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lrem' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LremInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lrem;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lrem)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LremInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lrem)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LremInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'frem' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct FremInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Frem;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Frem)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out FremInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Frem)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new FremInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'drem' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct DremInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Drem;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Drem)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DremInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Drem)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new DremInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'ineg' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct InegInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ineg;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ineg)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out InegInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ineg)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new InegInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lneg' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LnegInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lneg;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lneg)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LnegInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lneg)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LnegInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fneg' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct FnegInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fneg;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fneg)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out FnegInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fneg)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new FnegInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dneg' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct DnegInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dneg;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dneg)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DnegInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dneg)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new DnegInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'ishl' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct IshlInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ishl;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ishl)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IshlInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ishl)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new IshlInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lshl' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LshlInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lshl;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lshl)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LshlInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lshl)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LshlInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'ishr' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct IshrInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ishr;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ishr)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IshrInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ishr)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new IshrInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lshr' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LshrInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lshr;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lshr)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LshrInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lshr)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LshrInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iushr' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct IushrInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iushr;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iushr)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IushrInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iushr)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new IushrInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lushr' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LushrInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lushr;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lushr)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LushrInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lushr)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LushrInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iand' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct IandInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iand;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iand)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IandInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iand)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new IandInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'land' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LandInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Land;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Land)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LandInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Land)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LandInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'ior' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct IorInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ior;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ior)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IorInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ior)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new IorInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lor' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LorInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lor;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lor)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LorInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lor)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LorInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'ixor' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct IxorInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ixor;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ixor)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IxorInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ixor)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new IxorInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lxor' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LxorInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lxor;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lxor)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LxorInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lxor)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LxorInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'iinc' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Local"></param>
    /// <param name="Value"></param>
    public partial record struct IincInstruction(int Offset, ushort Local, short Value)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iinc;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iinc)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IincInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iinc)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                // arg2: Value
                if (Instruction.TryReadS2(ref reader, out var value) == false)
                    return false;

                instruction = new IincInstruction(position.GetInteger(), local, value);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                // arg2: Value
                if (Instruction.TryReadS1(ref reader, out var value) == false)
                    return false;

                instruction = new IincInstruction(position.GetInteger(), local, value);
            }

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Local
        public readonly ushort Local = Local;

        // arg2: Value
        public readonly short Value = Value;

    }

    /// <summary>
    /// Describes the 'i2l' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct I2lInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.I2l;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2l)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out I2lInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2l)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new I2lInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'i2f' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct I2fInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.I2f;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2f)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out I2fInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2f)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new I2fInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'i2d' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct I2dInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.I2d;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2d)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out I2dInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2d)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new I2dInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'l2i' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct L2iInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.L2i;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.L2i)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out L2iInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.L2i)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new L2iInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'l2f' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct L2fInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.L2f;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.L2f)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out L2fInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.L2f)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new L2fInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'l2d' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct L2dInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.L2d;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.L2d)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out L2dInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.L2d)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new L2dInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'f2i' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct F2iInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.F2i;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.F2i)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out F2iInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.F2i)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new F2iInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'f2l' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct F2lInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.F2l;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.F2l)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out F2lInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.F2l)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new F2lInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'f2d' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct F2dInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.F2d;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.F2d)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out F2dInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.F2d)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new F2dInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'd2i' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct D2iInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.D2i;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.D2i)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out D2iInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.D2i)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new D2iInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'd2l' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct D2lInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.D2l;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.D2l)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out D2lInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.D2l)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new D2lInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'd2f' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct D2fInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.D2f;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.D2f)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out D2fInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.D2f)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new D2fInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'i2b' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct I2bInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.I2b;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2b)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out I2bInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2b)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new I2bInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'i2c' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct I2cInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.I2c;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2c)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out I2cInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2c)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new I2cInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'i2s' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct I2sInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.I2s;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2s)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out I2sInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.I2s)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new I2sInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lcmp' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LcmpInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lcmp;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lcmp)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LcmpInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lcmp)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LcmpInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fcmpl' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct FcmplInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fcmpl;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fcmpl)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out FcmplInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fcmpl)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new FcmplInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'fcmpg' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct FcmpgInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Fcmpg;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fcmpg)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out FcmpgInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Fcmpg)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new FcmpgInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dcmpl' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct DcmplInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dcmpl;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dcmpl)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DcmplInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dcmpl)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new DcmplInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dcmpg' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct DcmpgInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dcmpg;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dcmpg)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DcmpgInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dcmpg)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new DcmpgInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'ifeq' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfeqInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ifeq;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifeq)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfeqInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifeq)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfeqInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'ifne' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfneInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ifne;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifne)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfneInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifne)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfneInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'iflt' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfltInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Iflt;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iflt)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfltInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Iflt)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfltInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'ifge' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfgeInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ifge;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifge)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfgeInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifge)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfgeInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'ifgt' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfgtInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ifgt;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifgt)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfgtInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifgt)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfgtInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'ifle' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfleInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ifle;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifle)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfleInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ifle)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfleInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_icmpeq' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfIcmpeqInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.IfIcmpeq;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpeq)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfIcmpeqInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpeq)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfIcmpeqInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_icmpne' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfIcmpneInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.IfIcmpne;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpne)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfIcmpneInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpne)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfIcmpneInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_icmplt' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfIcmpltInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.IfIcmplt;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmplt)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfIcmpltInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmplt)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfIcmpltInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_icmpge' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfIcmpgeInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.IfIcmpge;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpge)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfIcmpgeInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpge)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfIcmpgeInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_icmpgt' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfIcmpgtInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.IfIcmpgt;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpgt)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfIcmpgtInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmpgt)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfIcmpgtInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_icmple' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfIcmpleInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.IfIcmple;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmple)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfIcmpleInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfIcmple)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfIcmpleInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_acmpeq' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfAcmpeqInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.IfAcmpeq;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfAcmpeq)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfAcmpeqInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfAcmpeq)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfAcmpeqInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'if_acmpne' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfAcmpneInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.IfAcmpne;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfAcmpne)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfAcmpneInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfAcmpne)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfAcmpneInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'goto' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct GotoInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Goto;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Goto)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out GotoInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Goto)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new GotoInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'jsr' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct JsrInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Jsr;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Jsr)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out JsrInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Jsr)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new JsrInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'ret' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Local"></param>
    public partial record struct RetInstruction(int Offset, ushort Local)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ret;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ret)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out RetInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ret)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
            {

                // arg1: Local
                if (Instruction.TryReadL2(ref reader, out var local) == false)
                    return false;

                instruction = new RetInstruction(position.GetInteger(), local);
            }
            else
            {

                // arg1: Local
                if (Instruction.TryReadL1(ref reader, out var local) == false)
                    return false;

                instruction = new RetInstruction(position.GetInteger(), local);
            }

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Local
        public readonly ushort Local = Local;

    }

    /// <summary>
    /// Describes the 'ireturn' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct IreturnInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Ireturn;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ireturn)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IreturnInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Ireturn)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new IreturnInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'lreturn' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct LreturnInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Lreturn;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lreturn)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out LreturnInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Lreturn)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new LreturnInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'freturn' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct FreturnInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Freturn;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Freturn)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out FreturnInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Freturn)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new FreturnInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'dreturn' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct DreturnInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Dreturn;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dreturn)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out DreturnInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Dreturn)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new DreturnInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'areturn' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct AreturnInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Areturn;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Areturn)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out AreturnInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Areturn)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new AreturnInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'return' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct ReturnInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Return;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Return)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out ReturnInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Return)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new ReturnInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'getstatic' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Field"></param>
    public partial record struct GetStaticInstruction(int Offset, ConstantHandle Field)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.GetStatic;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.GetStatic)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out GetStaticInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.GetStatic)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Field
            if (Instruction.TryReadC2(ref reader, out var field) == false)
                return false;

            instruction = new GetStaticInstruction(position.GetInteger(), field);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Field
        public readonly ConstantHandle Field = Field;

    }

    /// <summary>
    /// Describes the 'putstatic' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Field"></param>
    public partial record struct PutStaticInstruction(int Offset, ConstantHandle Field)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.PutStatic;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.PutStatic)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out PutStaticInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.PutStatic)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Field
            if (Instruction.TryReadC2(ref reader, out var field) == false)
                return false;

            instruction = new PutStaticInstruction(position.GetInteger(), field);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Field
        public readonly ConstantHandle Field = Field;

    }

    /// <summary>
    /// Describes the 'getfield' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Field"></param>
    public partial record struct GetFieldInstruction(int Offset, ConstantHandle Field)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.GetField;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.GetField)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out GetFieldInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.GetField)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Field
            if (Instruction.TryReadC2(ref reader, out var field) == false)
                return false;

            instruction = new GetFieldInstruction(position.GetInteger(), field);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Field
        public readonly ConstantHandle Field = Field;

    }

    /// <summary>
    /// Describes the 'putfield' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Field"></param>
    public partial record struct PutFieldInstruction(int Offset, ConstantHandle Field)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.PutField;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.PutField)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out PutFieldInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.PutField)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Field
            if (Instruction.TryReadC2(ref reader, out var field) == false)
                return false;

            instruction = new PutFieldInstruction(position.GetInteger(), field);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Field
        public readonly ConstantHandle Field = Field;

    }

    /// <summary>
    /// Describes the 'invokevirtual' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Method"></param>
    public partial record struct InvokeVirtualInstruction(int Offset, ConstantHandle Method)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.InvokeVirtual;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeVirtual)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out InvokeVirtualInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeVirtual)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Method
            if (Instruction.TryReadC2(ref reader, out var method) == false)
                return false;

            instruction = new InvokeVirtualInstruction(position.GetInteger(), method);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Method
        public readonly ConstantHandle Method = Method;

    }

    /// <summary>
    /// Describes the 'invokespecial' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Method"></param>
    public partial record struct InvokeSpecialInstruction(int Offset, ConstantHandle Method)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.InvokeSpecial;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeSpecial)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out InvokeSpecialInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeSpecial)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Method
            if (Instruction.TryReadC2(ref reader, out var method) == false)
                return false;

            instruction = new InvokeSpecialInstruction(position.GetInteger(), method);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Method
        public readonly ConstantHandle Method = Method;

    }

    /// <summary>
    /// Describes the 'invokestatic' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Method"></param>
    public partial record struct InvokeStaticInstruction(int Offset, ConstantHandle Method)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.InvokeStatic;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeStatic)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out InvokeStaticInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeStatic)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Method
            if (Instruction.TryReadC2(ref reader, out var method) == false)
                return false;

            instruction = new InvokeStaticInstruction(position.GetInteger(), method);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Method
        public readonly ConstantHandle Method = Method;

    }

    /// <summary>
    /// Describes the 'invokeinterface' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Method"></param>
    /// <param name="Count"></param>
    /// <param name="Zero"></param>
    public partial record struct InvokeInterfaceInstruction(int Offset, ConstantHandle Method, byte Count, byte Zero)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.InvokeInterface;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeInterface)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out InvokeInterfaceInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeInterface)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Method
            if (Instruction.TryReadC2(ref reader, out var method) == false)
                return false;

            // arg2: Count
            if (Instruction.TryReadU1(ref reader, out var count) == false)
                return false;

            // arg3: Zero
            if (Instruction.TryReadU1(ref reader, out var zero) == false)
                return false;

            instruction = new InvokeInterfaceInstruction(position.GetInteger(), method, count, zero);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

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
    /// <param name="Offset"></param>
    /// <param name="Method"></param>
    /// <param name="Zero"></param>
    /// <param name="Zero2"></param>
    public partial record struct InvokeDynamicInstruction(int Offset, ConstantHandle Method, byte Zero, byte Zero2)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.InvokeDynamic;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeDynamic)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out InvokeDynamicInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InvokeDynamic)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Method
            if (Instruction.TryReadC2(ref reader, out var method) == false)
                return false;

            // arg2: Zero
            if (Instruction.TryReadU1(ref reader, out var zero) == false)
                return false;

            // arg3: Zero2
            if (Instruction.TryReadU1(ref reader, out var zero2) == false)
                return false;

            instruction = new InvokeDynamicInstruction(position.GetInteger(), method, zero, zero2);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

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
    /// <param name="Offset"></param>
    /// <param name="Constant"></param>
    public partial record struct NewInstruction(int Offset, ConstantHandle Constant)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.New;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.New)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out NewInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.New)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Constant
            if (Instruction.TryReadC2(ref reader, out var constant) == false)
                return false;

            instruction = new NewInstruction(position.GetInteger(), constant);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Constant
        public readonly ConstantHandle Constant = Constant;

    }

    /// <summary>
    /// Describes the 'newarray' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Value"></param>
    public partial record struct NewarrayInstruction(int Offset, byte Value)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Newarray;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Newarray)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out NewarrayInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Newarray)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Value
            if (Instruction.TryReadU1(ref reader, out var value) == false)
                return false;

            instruction = new NewarrayInstruction(position.GetInteger(), value);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Value
        public readonly byte Value = Value;

    }

    /// <summary>
    /// Describes the 'anewarray' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Constant"></param>
    public partial record struct AnewarrayInstruction(int Offset, ConstantHandle Constant)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Anewarray;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Anewarray)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out AnewarrayInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Anewarray)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Constant
            if (Instruction.TryReadC2(ref reader, out var constant) == false)
                return false;

            instruction = new AnewarrayInstruction(position.GetInteger(), constant);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Constant
        public readonly ConstantHandle Constant = Constant;

    }

    /// <summary>
    /// Describes the 'arraylength' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct ArraylengthInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Arraylength;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Arraylength)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out ArraylengthInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Arraylength)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new ArraylengthInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'athrow' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct AthrowInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Athrow;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Athrow)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out AthrowInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Athrow)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new AthrowInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'checkcast' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Type"></param>
    public partial record struct CheckcastInstruction(int Offset, ConstantHandle Type)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Checkcast;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Checkcast)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out CheckcastInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Checkcast)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Type
            if (Instruction.TryReadC2(ref reader, out var type) == false)
                return false;

            instruction = new CheckcastInstruction(position.GetInteger(), type);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Type
        public readonly ConstantHandle Type = Type;

    }

    /// <summary>
    /// Describes the 'instanceof' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Type"></param>
    public partial record struct InstanceOfInstruction(int Offset, ConstantHandle Type)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.InstanceOf;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InstanceOf)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out InstanceOfInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.InstanceOf)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Type
            if (Instruction.TryReadC2(ref reader, out var type) == false)
                return false;

            instruction = new InstanceOfInstruction(position.GetInteger(), type);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Type
        public readonly ConstantHandle Type = Type;

    }

    /// <summary>
    /// Describes the 'monitorenter' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct MonitorEnterInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.MonitorEnter;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.MonitorEnter)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out MonitorEnterInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.MonitorEnter)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new MonitorEnterInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'monitorexit' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct MonitorExitInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.MonitorExit;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.MonitorExit)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out MonitorExitInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.MonitorExit)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new MonitorExitInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'wide' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    public partial record struct WideInstruction(int Offset)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Wide;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Wide)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
            // advance by opcode size
            size += 1;

            return true;
        }
        
        /// <summary>
        /// Attempts to read this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out WideInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Wide)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            instruction = new WideInstruction(position.GetInteger());

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

    }

    /// <summary>
    /// Describes the 'multianewarray' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Type"></param>
    /// <param name="Dimensions"></param>
    public partial record struct MultianewarrayInstruction(int Offset, ConstantHandle Type, byte Dimensions)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.Multianewarray;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Multianewarray)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out MultianewarrayInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.Multianewarray)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Type
            if (Instruction.TryReadC2(ref reader, out var type) == false)
                return false;

            // arg2: Dimensions
            if (Instruction.TryReadU1(ref reader, out var dimensions) == false)
                return false;

            instruction = new MultianewarrayInstruction(position.GetInteger(), type, dimensions);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Type
        public readonly ConstantHandle Type = Type;

        // arg2: Dimensions
        public readonly byte Dimensions = Dimensions;

    }

    /// <summary>
    /// Describes the 'ifnull' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfNullInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.IfNull;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfNull)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfNullInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfNull)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfNullInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'ifnonnull' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct IfNonNullInstruction(int Offset, short Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.IfNonNull;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfNonNull)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out IfNonNullInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.IfNonNull)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ2(ref reader, out var target) == false)
                return false;

            instruction = new IfNonNullInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly short Target = Target;

    }

    /// <summary>
    /// Describes the 'goto_w' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct GotoWInstruction(int Offset, int Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.GotoW;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.GotoW)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out GotoWInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.GotoW)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ4(ref reader, out var target) == false)
                return false;

            instruction = new GotoWInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly int Target = Target;

    }

    /// <summary>
    /// Describes the 'jsr_w' instruction.
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="Target"></param>
    public partial record struct JsrWInstruction(int Offset, int Target)
    {
    
        /// <summary>
        /// Gets the <see cref="OpCode"/> associated with this instruction type.
        /// </summary>
        public static readonly OpCode OpCode = OpCode.JsrW;
        
        /// <summary>
        /// Attempts to measure this instruction.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryMeasure(ref SequenceReader<byte> reader, ref int size)
        {
            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.JsrW)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");
            
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
        /// <param name="reader"></param>
        /// <param name="instruction"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRead(ref SequenceReader<byte> reader, out JsrWInstruction instruction)
        {
            instruction = default;
            var position = reader.Position;

            if (Instruction.TryReadOpCode(ref reader, out var opcode, out var wide) == false)
                return false;

            if (opcode != OpCode.JsrW)
                throw new ByteCodeException($"Unexpected opcode '{opcode:XX}' at {reader.Position}.");

            if (wide)
                throw new ByteCodeException("OpCode does not support wide arguments.");

            // arg1: Target
            if (Instruction.TryReadJ4(ref reader, out var target) == false)
                return false;

            instruction = new JsrWInstruction(position.GetInteger(), target);

            return true;
        }
        
        /// <summary>
        /// Gets the position in the code stream of this instruction.
        /// </summary>
        public readonly int Offset = Offset;

        // arg1: Target
        public readonly int Target = Target;

    }

}
