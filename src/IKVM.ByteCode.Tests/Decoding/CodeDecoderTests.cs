﻿using System.Buffers;
using System.Buffers.Binary;

using FluentAssertions;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Decoding;
using IKVM.ByteCode.Encoding;
using IKVM.ByteCode.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Decoding
{

    [TestClass]
    public class CodeDecoderTests
    {

        [TestMethod]
        public void CanRead()
        {
            var code = new BlobBuilder();
            new CodeBuilder(code)
                .Bipush(64)
                .StoreLocalInteger(0)
                .LoadLocalInteger(0)
                .DefineLabel(out var iftrue)
                .Ifne(iftrue)
                .Return()
                .MarkLabel(iftrue)
                .Return();

            var buf = code.ToArray();
            var dec = new CodeDecoder(buf);

            dec.TryReadNext(out var inst1).Should().BeTrue();
            inst1.OpCode.Should().Be(OpCode.Bipush);
            inst1.IsWide.Should().BeFalse();
            var inst1T = inst1.AsBipush();
            inst1T.Value.Should().Be(64);

            dec.TryReadNext(out var inst2).Should().BeTrue();
            inst2.OpCode.Should().Be(OpCode.Istore0);
            inst2.IsWide.Should().BeFalse();
            var inst2T = inst2.AsIstore0();

            dec.TryReadNext(out var inst3).Should().BeTrue();
            inst3.OpCode.Should().Be(OpCode.Iload0);
            inst3.IsWide.Should().BeFalse();
            var inst3T = inst3.AsIload0();

            dec.TryReadNext(out var inst4).Should().BeTrue();
            inst4.OpCode.Should().Be(OpCode.Ifne);
            inst4.IsWide.Should().BeFalse();
            var inst4T = inst4.AsIfne();

            dec.TryReadNext(out var inst5).Should().BeTrue();
            inst5.OpCode.Should().Be(OpCode.Return);
            inst5.IsWide.Should().BeFalse();
            var inst5T = inst5.AsReturn();

            dec.TryReadNext(out var inst6).Should().BeTrue();
            inst6.OpCode.Should().Be(OpCode.Return);
            inst6.IsWide.Should().BeFalse();
            var inst6T = inst6.AsReturn();

            inst4T.Target.Should().Be((short)(inst6.Offset - inst4.Offset));
        }

        [TestMethod]
        public void CanDecodeTableSwitch()
        {
            var code = new BlobBuilder();
            new CodeBuilder(code)
                .DefineLabel(out var defaultLabel)
                .DefineLabel(out var case1)
                .DefineLabel(out var case2)
                .DefineLabel(out var case3)
                .TableSwitch(defaultLabel, 1, [case1, case2, case3])
                .MarkLabel(defaultLabel)
                .MarkLabel(case1)
                .MarkLabel(case2)
                .MarkLabel(case3)
                .Return();

            var buf = code.ToArray();
            var dec = new CodeDecoder(buf);

            dec.TryReadNext(out var inst1).Should().BeTrue();
            inst1.OpCode.Should().Be(OpCode.TableSwitch);
            inst1.IsWide.Should().BeFalse();
            var inst1T = inst1.AsTableSwitch();
            inst1T.Cases.Count.Should().Be(3);

            inst1T.Low.Should().Be(1);
            inst1T.High.Should().Be(3);

            dec.TryReadNext(out var inst2).Should().BeTrue();
            inst2.OpCode.Should().Be(OpCode.Return);
            inst2.IsWide.Should().BeFalse();
            var inst2T = inst2.AsReturn();

            inst1T.DefaultTarget.Should().Be(inst2.Offset - inst1.Offset);
            inst1T.Cases[0].Should().Be(inst2.Offset - inst1.Offset);
            inst1T.Cases[1].Should().Be(inst2.Offset - inst1.Offset);
            inst1T.Cases[2].Should().Be(inst2.Offset - inst1.Offset);
        }

        [TestMethod]
        public void CanDecodeLookupSwitch()
        {
            var code = new BlobBuilder();
            new CodeBuilder(code)
                .DefineLabel(out var defaultLabel)
                .DefineLabel(out var case1)
                .DefineLabel(out var case2)
                .DefineLabel(out var case3)
                .LookupSwitch(defaultLabel, [(1, case1), (2, case2), (3, case3)])
                .MarkLabel(defaultLabel)
                .MarkLabel(case1)
                .MarkLabel(case2)
                .MarkLabel(case3)
                .Return();

            var buf = code.ToArray();
            var dec = new CodeDecoder(buf);

            dec.TryReadNext(out var inst1).Should().BeTrue();
            inst1.OpCode.Should().Be(OpCode.LookupSwitch);
            inst1.IsWide.Should().BeFalse();
            var inst1T = inst1.AsLookupSwitch();
            inst1T.Cases.Count.Should().Be(3);

            dec.TryReadNext(out var inst2).Should().BeTrue();
            inst2.OpCode.Should().Be(OpCode.Return);
            inst2.IsWide.Should().BeFalse();
            var inst2T = inst2.AsReturn();

            inst1T.DefaultTarget.Should().Be(inst2.Offset - inst1.Offset);
            inst1T.Cases[0].Target.Should().Be(inst2.Offset - inst1.Offset);
            inst1T.Cases[0].Key.Should().Be(1);
            inst1T.Cases[1].Target.Should().Be(inst2.Offset - inst1.Offset);
            inst1T.Cases[1].Key.Should().Be(2);
            inst1T.Cases[2].Target.Should().Be(inst2.Offset - inst1.Offset);
            inst1T.Cases[2].Key.Should().Be(3);
        }

        [TestMethod]
        public void CanCopyToWithConstant()
        {
            var int32 = new byte[4];
            BinaryPrimitives.WriteInt32BigEndian(int32, 1234);

            var constants = new ConstantTable(new ClassFormatVersion(50, 0), [
                new(ConstantKind.Unknown, new ReadOnlySequence<byte>()),
                new(ConstantKind.Integer, new ReadOnlySequence<byte>(int32)),
            ]);

            var buffer1 = new BlobBuilder();
            new CodeBuilder(buffer1).LoadConstant(new IntegerConstantHandle(1)).Pop().Return();
            var code1 = new CodeDecoder(buffer1.ToArray());

            // copy from decoder into new builder
            var buffer2 = new BlobBuilder();
            code1.CopyTo(constants, constants, new CodeBuilder(buffer2));
            var code2 = new CodeDecoder(buffer2.ToArray());

            code2.TryReadNext(out var inst1).Should().BeTrue();
            inst1.OpCode.Should().Be(OpCode.Ldc);
            inst1.IsWide.Should().BeFalse();
            var inst1T = inst1.AsLdc();
            inst1T.Constant.Slot.Should().Be(1);

            code2.TryReadNext(out var inst2).Should().BeTrue();
            inst2.OpCode.Should().Be(OpCode.Pop);
            inst2.IsWide.Should().BeFalse();
            var inst2T = inst2.AsPop();

            code2.TryReadNext(out var inst3).Should().BeTrue();
            inst3.OpCode.Should().Be(OpCode.Return);
            inst3.IsWide.Should().BeFalse();
            var inst3T = inst3.AsReturn();
        }

    }

}
