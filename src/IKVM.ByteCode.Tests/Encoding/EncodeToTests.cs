using System;
using System.Buffers;
using System.IO;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Decoding;
using IKVM.ByteCode.Encoding;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Encoding
{

    [TestClass]
    public class ClassFileImporterTests
    {

        [TestMethod]
        public void OpenBigClass()
        {
            using var src = ClassFile.Read(Path.Combine(Path.GetDirectoryName(typeof(ClassFileImporterTests).Assembly.Location), "Encoding", "ChatMessageCell.class"));

            foreach (var m in src.Methods)
                foreach (var a in m.Attributes)
                    if (src.Constants.Get(a.Name).Value == AttributeName.Code)
                        Decode(src, m, ((CodeAttribute)a).Code);
        }

        void Decode(ClassFile src, Method m, ReadOnlySequence<byte> code)
        {
            var dec = new CodeDecoder(code);

            foreach (var instruction in dec)
            {
                switch (instruction.OpCode)
                {
                    case OpCode.Nop:
                        instruction.AsNop();
                        break;
                    case OpCode.AconstNull:
                        instruction.AsAconstNull();
                        break;
                    case OpCode.IconstM1:
                        instruction.AsIconstM1();
                        break;
                    case OpCode.Iconst0:
                        instruction.AsIconst0();
                        break;
                    case OpCode.Iconst1:
                        instruction.AsIconst1();
                        break;
                    case OpCode.Iconst2:
                        instruction.AsIconst2();
                        break;
                    case OpCode.Iconst3:
                        instruction.AsIconst3();
                        break;
                    case OpCode.Iconst4:
                        instruction.AsIconst4();
                        break;
                    case OpCode.Iconst5:
                        instruction.AsIconst5();
                        break;
                    case OpCode.Lconst0:
                        instruction.AsLconst0();
                        break;
                    case OpCode.Lconst1:
                        instruction.AsLconst1();
                        break;
                    case OpCode.Fconst0:
                        instruction.AsFconst0();
                        break;
                    case OpCode.Fconst1:
                        instruction.AsFconst1();
                        break;
                    case OpCode.Fconst2:
                        instruction.AsFconst2();
                        break;
                    case OpCode.Dconst0:
                        instruction.AsDconst0();
                        break;
                    case OpCode.Dconst1:
                        instruction.AsDconst1();
                        break;
                    case OpCode.Bipush:
                        instruction.AsBipush();
                        break;
                    case OpCode.Sipush:
                        instruction.AsSipush();
                        break;
                    case OpCode.Ldc:
                        instruction.AsLdc();
                        break;
                    case OpCode.LdcW:
                        instruction.AsLdcW();
                        break;
                    case OpCode.Ldc2W:
                        instruction.AsLdc2W();
                        break;
                    case OpCode.Iload:
                        instruction.AsIload();
                        break;
                    case OpCode.Lload:
                        instruction.AsLload();
                        break;
                    case OpCode.Fload:
                        instruction.AsFload();
                        break;
                    case OpCode.Dload:
                        instruction.AsDload();
                        break;
                    case OpCode.Aload:
                        instruction.AsAload();
                        break;
                    case OpCode.Iload0:
                        instruction.AsIload0();
                        break;
                    case OpCode.Iload1:
                        instruction.AsIload1();
                        break;
                    case OpCode.Iload2:
                        instruction.AsIload2();
                        break;
                    case OpCode.Iload3:
                        instruction.AsIload3();
                        break;
                    case OpCode.Lload0:
                        instruction.AsLload0();
                        break;
                    case OpCode.Lload1:
                        instruction.AsLload1();
                        break;
                    case OpCode.Lload2:
                        instruction.AsLload2();
                        break;
                    case OpCode.Lload3:
                        instruction.AsLload3();
                        break;
                    case OpCode.Fload0:
                        instruction.AsFload0();
                        break;
                    case OpCode.Fload1:
                        instruction.AsFload1();
                        break;
                    case OpCode.Fload2:
                        instruction.AsFload2();
                        break;
                    case OpCode.Fload3:
                        instruction.AsFload3();
                        break;
                    case OpCode.Dload0:
                        instruction.AsDload0();
                        break;
                    case OpCode.Dload1:
                        instruction.AsDload1();
                        break;
                    case OpCode.Dload2:
                        instruction.AsDload2();
                        break;
                    case OpCode.Dload3:
                        instruction.AsDload3();
                        break;
                    case OpCode.Aload0:
                        instruction.AsAload0();
                        break;
                    case OpCode.Aload1:
                        instruction.AsAload1();
                        break;
                    case OpCode.Aload2:
                        instruction.AsAload2();
                        break;
                    case OpCode.Aload3:
                        instruction.AsAload3();
                        break;
                    case OpCode.Iaload:
                        instruction.AsIaload();
                        break;
                    case OpCode.Laload:
                        instruction.AsLaload();
                        break;
                    case OpCode.Faload:
                        instruction.AsFaload();
                        break;
                    case OpCode.Daload:
                        instruction.AsDaload();
                        break;
                    case OpCode.Aaload:
                        instruction.AsAaload();
                        break;
                    case OpCode.Baload:
                        instruction.AsBaload();
                        break;
                    case OpCode.Caload:
                        instruction.AsCaload();
                        break;
                    case OpCode.Saload:
                        instruction.AsSaload();
                        break;
                    case OpCode.Istore:
                        instruction.AsIstore();
                        break;
                    case OpCode.Lstore:
                        instruction.AsLstore();
                        break;
                    case OpCode.Fstore:
                        instruction.AsFstore();
                        break;
                    case OpCode.Dstore:
                        instruction.AsDstore();
                        break;
                    case OpCode.Astore:
                        instruction.AsAstore();
                        break;
                    case OpCode.Istore0:
                        instruction.AsIstore0();
                        break;
                    case OpCode.Istore1:
                        instruction.AsIstore1();
                        break;
                    case OpCode.Istore2:
                        instruction.AsIstore2();
                        break;
                    case OpCode.Istore3:
                        instruction.AsIstore3();
                        break;
                    case OpCode.Lstore0:
                        instruction.AsLstore0();
                        break;
                    case OpCode.Lstore1:
                        instruction.AsLstore1();
                        break;
                    case OpCode.Lstore2:
                        instruction.AsLstore2();
                        break;
                    case OpCode.Lstore3:
                        instruction.AsLstore3();
                        break;
                    case OpCode.Fstore0:
                        instruction.AsFstore0();
                        break;
                    case OpCode.Fstore1:
                        instruction.AsFstore1();
                        break;
                    case OpCode.Fstore2:
                        instruction.AsFstore2();
                        break;
                    case OpCode.Fstore3:
                        instruction.AsFstore3();
                        break;
                    case OpCode.Dstore0:
                        instruction.AsDstore0();
                        break;
                    case OpCode.Dstore1:
                        instruction.AsDstore1();
                        break;
                    case OpCode.Dstore2:
                        instruction.AsDstore2();
                        break;
                    case OpCode.Dstore3:
                        instruction.AsDstore3();
                        break;
                    case OpCode.Astore0:
                        instruction.AsAstore0();
                        break;
                    case OpCode.Astore1:
                        instruction.AsAstore1();
                        break;
                    case OpCode.Astore2:
                        instruction.AsAstore2();
                        break;
                    case OpCode.Astore3:
                        instruction.AsAstore3();
                        break;
                    case OpCode.Iastore:
                        instruction.AsIastore();
                        break;
                    case OpCode.Lastore:
                        instruction.AsLastore();
                        break;
                    case OpCode.Fastore:
                        instruction.AsFastore();
                        break;
                    case OpCode.Dastore:
                        instruction.AsDastore();
                        break;
                    case OpCode.Aastore:
                        instruction.AsAastore();
                        break;
                    case OpCode.Bastore:
                        instruction.AsBastore();
                        break;
                    case OpCode.Castore:
                        instruction.AsCastore();
                        break;
                    case OpCode.Sastore:
                        instruction.AsSastore();
                        break;
                    case OpCode.Pop:
                        instruction.AsPop();
                        break;
                    case OpCode.Pop2:
                        instruction.AsPop2();
                        break;
                    case OpCode.Dup:
                        instruction.AsDup();
                        break;
                    case OpCode.DupX1:
                        instruction.AsDupX1();
                        break;
                    case OpCode.DupX2:
                        instruction.AsDupX2();
                        break;
                    case OpCode.Dup2:
                        instruction.AsDup2();
                        break;
                    case OpCode.Dup2X1:
                        instruction.AsDup2X1();
                        break;
                    case OpCode.Dup2X2:
                        instruction.AsDup2X2();
                        break;
                    case OpCode.Swap:
                        instruction.AsSwap();
                        break;
                    case OpCode.Iadd:
                        instruction.AsIadd();
                        break;
                    case OpCode.Ladd:
                        instruction.AsLadd();
                        break;
                    case OpCode.Fadd:
                        instruction.AsFadd();
                        break;
                    case OpCode.Dadd:
                        instruction.AsDadd();
                        break;
                    case OpCode.Isub:
                        instruction.AsIsub();
                        break;
                    case OpCode.Lsub:
                        instruction.AsLsub();
                        break;
                    case OpCode.Fsub:
                        instruction.AsFsub();
                        break;
                    case OpCode.Dsub:
                        instruction.AsDsub();
                        break;
                    case OpCode.Imul:
                        instruction.AsImul();
                        break;
                    case OpCode.Lmul:
                        instruction.AsLmul();
                        break;
                    case OpCode.Fmul:
                        instruction.AsFmul();
                        break;
                    case OpCode.Dmul:
                        instruction.AsDmul();
                        break;
                    case OpCode.Idiv:
                        instruction.AsIdiv();
                        break;
                    case OpCode.Ldiv:
                        instruction.AsLdiv();
                        break;
                    case OpCode.Fdiv:
                        instruction.AsFdiv();
                        break;
                    case OpCode.Ddiv:
                        instruction.AsDdiv();
                        break;
                    case OpCode.Irem:
                        instruction.AsIrem();
                        break;
                    case OpCode.Lrem:
                        instruction.AsLrem();
                        break;
                    case OpCode.Frem:
                        instruction.AsFrem();
                        break;
                    case OpCode.Drem:
                        instruction.AsDrem();
                        break;
                    case OpCode.Ineg:
                        instruction.AsIneg();
                        break;
                    case OpCode.Lneg:
                        instruction.AsLneg();
                        break;
                    case OpCode.Fneg:
                        instruction.AsFneg();
                        break;
                    case OpCode.Dneg:
                        instruction.AsDneg();
                        break;
                    case OpCode.Ishl:
                        instruction.AsIshl();
                        break;
                    case OpCode.Lshl:
                        instruction.AsLshl();
                        break;
                    case OpCode.Ishr:
                        instruction.AsIshr();
                        break;
                    case OpCode.Lshr:
                        instruction.AsLshr();
                        break;
                    case OpCode.Iushr:
                        instruction.AsIushr();
                        break;
                    case OpCode.Lushr:
                        instruction.AsLushr();
                        break;
                    case OpCode.Iand:
                        instruction.AsIand();
                        break;
                    case OpCode.Land:
                        instruction.AsLand();
                        break;
                    case OpCode.Ior:
                        instruction.AsIor();
                        break;
                    case OpCode.Lor:
                        instruction.AsLor();
                        break;
                    case OpCode.Ixor:
                        instruction.AsIxor();
                        break;
                    case OpCode.Lxor:
                        instruction.AsLxor();
                        break;
                    case OpCode.Iinc:
                        instruction.AsIinc();
                        break;
                    case OpCode.I2l:
                        instruction.AsI2l();
                        break;
                    case OpCode.I2f:
                        instruction.AsI2f();
                        break;
                    case OpCode.I2d:
                        instruction.AsI2d();
                        break;
                    case OpCode.L2i:
                        instruction.AsL2i();
                        break;
                    case OpCode.L2f:
                        instruction.AsL2f();
                        break;
                    case OpCode.L2d:
                        instruction.AsL2d();
                        break;
                    case OpCode.F2i:
                        instruction.AsF2i();
                        break;
                    case OpCode.F2l:
                        instruction.AsF2l();
                        break;
                    case OpCode.F2d:
                        instruction.AsF2d();
                        break;
                    case OpCode.D2i:
                        instruction.AsD2i();
                        break;
                    case OpCode.D2l:
                        instruction.AsD2l();
                        break;
                    case OpCode.D2f:
                        instruction.AsD2f();
                        break;
                    case OpCode.I2b:
                        instruction.AsI2b();
                        break;
                    case OpCode.I2c:
                        instruction.AsI2c();
                        break;
                    case OpCode.I2s:
                        instruction.AsI2s();
                        break;
                    case OpCode.Lcmp:
                        instruction.AsLcmp();
                        break;
                    case OpCode.Fcmpl:
                        instruction.AsFcmpl();
                        break;
                    case OpCode.Fcmpg:
                        instruction.AsFcmpg();
                        break;
                    case OpCode.Dcmpl:
                        instruction.AsDcmpl();
                        break;
                    case OpCode.Dcmpg:
                        instruction.AsDcmpg();
                        break;
                    case OpCode.Ifeq:
                        instruction.AsIfeq();
                        break;
                    case OpCode.Ifne:
                        instruction.AsIfne();
                        break;
                    case OpCode.Iflt:
                        instruction.AsIflt();
                        break;
                    case OpCode.Ifge:
                        instruction.AsIfge();
                        break;
                    case OpCode.Ifgt:
                        instruction.AsIfgt();
                        break;
                    case OpCode.Ifle:
                        instruction.AsIfle();
                        break;
                    case OpCode.IfIcmpeq:
                        instruction.AsIfIcmpeq();
                        break;
                    case OpCode.IfIcmpne:
                        instruction.AsIfIcmpne();
                        break;
                    case OpCode.IfIcmplt:
                        instruction.AsIfIcmplt();
                        break;
                    case OpCode.IfIcmpge:
                        instruction.AsIfIcmpge();
                        break;
                    case OpCode.IfIcmpgt:
                        instruction.AsIfIcmpgt();
                        break;
                    case OpCode.IfIcmple:
                        instruction.AsIfIcmple();
                        break;
                    case OpCode.IfAcmpeq:
                        instruction.AsIfAcmpeq();
                        break;
                    case OpCode.IfAcmpne:
                        instruction.AsIfAcmpne();
                        break;
                    case OpCode.Goto:
                        instruction.AsGoto();
                        break;
                    case OpCode.Jsr:
                        instruction.AsJsr();
                        break;
                    case OpCode.Ret:
                        instruction.AsRet();
                        break;
                    case OpCode.TableSwitch:
                        instruction.AsTableSwitch();
                        break;
                    case OpCode.LookupSwitch:
                        instruction.AsLookupSwitch();
                        break;
                    case OpCode.Ireturn:
                        instruction.AsIreturn();
                        break;
                    case OpCode.Lreturn:
                        instruction.AsLreturn();
                        break;
                    case OpCode.Freturn:
                        instruction.AsFreturn();
                        break;
                    case OpCode.Dreturn:
                        instruction.AsDreturn();
                        break;
                    case OpCode.Areturn:
                        instruction.AsAreturn();
                        break;
                    case OpCode.Return:
                        instruction.AsReturn();
                        break;
                    case OpCode.GetStatic:
                        instruction.AsGetStatic();
                        break;
                    case OpCode.PutStatic:
                        instruction.AsPutStatic();
                        break;
                    case OpCode.GetField:
                        instruction.AsGetField();
                        break;
                    case OpCode.PutField:
                        instruction.AsPutField();
                        break;
                    case OpCode.InvokeVirtual:
                        instruction.AsInvokeVirtual();
                        break;
                    case OpCode.InvokeSpecial:
                        instruction.AsInvokeSpecial();
                        break;
                    case OpCode.InvokeStatic:
                        instruction.AsInvokeStatic();
                        break;
                    case OpCode.InvokeInterface:
                        instruction.AsInvokeInterface();
                        break;
                    case OpCode.InvokeDynamic:
                        instruction.AsInvokeDynamic();
                        break;
                    case OpCode.New:
                        instruction.AsNew();
                        break;
                    case OpCode.Newarray:
                        instruction.AsNewarray();
                        break;
                    case OpCode.Anewarray:
                        instruction.AsAnewarray();
                        break;
                    case OpCode.Arraylength:
                        instruction.AsArraylength();
                        break;
                    case OpCode.Athrow:
                        instruction.AsAthrow();
                        break;
                    case OpCode.Checkcast:
                        instruction.AsCheckcast();
                        break;
                    case OpCode.InstanceOf:
                        instruction.AsInstanceOf();
                        break;
                    case OpCode.MonitorEnter:
                        instruction.AsMonitorEnter();
                        break;
                    case OpCode.MonitorExit:
                        instruction.AsMonitorExit();
                        break;
                    case OpCode.Multianewarray:
                        instruction.AsMultianewarray();
                        break;
                    case OpCode.IfNull:
                        instruction.AsIfNull();
                        break;
                    case OpCode.IfNonNull:
                        instruction.AsIfNonNull();
                        break;
                    case OpCode.GotoW:
                        instruction.AsGotoW();
                        break;
                    case OpCode.JsrW:
                        instruction.AsJsrW();
                        break;
                }

            }
        }

    }

}
