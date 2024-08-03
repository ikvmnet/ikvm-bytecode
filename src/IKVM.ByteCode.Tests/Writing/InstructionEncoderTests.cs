using System.Buffers;

using FluentAssertions;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Writing;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Writing
{

    [TestClass]
    public class InstructionEncoderTests
    {

        [TestMethod]
        public void CanMarkShortLabel()
        {
            var blob = new BlobBuilder();
            var code = new InstructionEncoder(blob);
            var label = code.DefineLabel();

            var branchOffset = code.Offset;
            code.Branch(OpCode._goto, label);

            var labelOffset = code.Offset;
            code.MarkLabel(label);
            code.OpCode(OpCode._return);

            var b = new SequenceReader<byte>(new ReadOnlySequence<byte>(blob.ToArray()));

            // start with instruction
            b.TryRead(out byte opcode).Should().BeTrue();
            opcode.Should().Be((byte)OpCode._goto);

            // argument of branch instruction should be offset to label
            b.TryReadBigEndian(out short argument).Should().BeTrue();
            argument.Should().Be(checked((short)(labelOffset - branchOffset)));

            // last value should be return instruction
            b.TryRead(out byte returnInstruction).Should().BeTrue();
            returnInstruction.Should().Be((byte)OpCode._return);
        }

        [TestMethod]
        public void CanMarkLongLabel()
        {
            var blob = new BlobBuilder();
            var code = new InstructionEncoder(blob);
            var label = code.DefineLabel();

            var branchOffset = code.Offset;
            code.Branch(OpCode._goto_w, label);

            var labelOffset = code.Offset;
            code.MarkLabel(label);
            code.OpCode(OpCode._return);

            var b = new SequenceReader<byte>(new ReadOnlySequence<byte>(blob.ToArray()));

            // start with instruction
            b.TryRead(out byte opcode).Should().BeTrue();
            opcode.Should().Be((byte)OpCode._goto_w);

            // argument of branch instruction should be offset to label
            b.TryReadBigEndian(out int argument).Should().BeTrue();
            argument.Should().Be(labelOffset - branchOffset);

            // last value should be return instruction
            b.TryRead(out byte returnInstruction).Should().BeTrue();
            returnInstruction.Should().Be((byte)OpCode._return);
        }

        [TestMethod]
        public void CanRepeatLabel()
        {
            var blob = new BlobBuilder();
            new InstructionEncoder(blob)
                .DefineLabel(out var label)
                .Label(label, 4)
                .Label(label, 4)
                .Label(label, 4)
                .Label(label, 4)
                .MarkLabel(label);

            var b = new SequenceReader<byte>(new ReadOnlySequence<byte>(blob.ToArray()));

            b.TryReadBigEndian(out int l1).Should().BeTrue();
            b.TryReadBigEndian(out int l2).Should().BeTrue();
            b.TryReadBigEndian(out int l3).Should().BeTrue();
            b.TryReadBigEndian(out int l4).Should().BeTrue();

            // labels values should be progrssively lower as we approach the end
            l1.Should().Be(16);
            l2.Should().Be(12);
            l3.Should().Be(8);
            l4.Should().Be(4);
        }

        [TestMethod]
        public void CanEncodeTableSwitch()
        {
            var blob = new BlobBuilder();
            var code = new InstructionEncoder(blob);

            var defaultLabel = code.DefineLabel();
            var case1Label = code.DefineLabel();
            var case2Label = code.DefineLabel();

            // tableswitch
            var tableOffset = code.Offset;
            code.TableSwitch(defaultLabel, 0, t => t.Case(case1Label).Case(case2Label));

            // return code, all labels arrive here
            var labelOffset = code.Offset;
            code.MarkLabel(defaultLabel);
            code.MarkLabel(case1Label);
            code.MarkLabel(case2Label);
            code.OpCode(OpCode._return);

            var b = new SequenceReader<byte>(new ReadOnlySequence<byte>(blob.ToArray()));

            // start with instruction
            b.TryRead(out byte opcode).Should().BeTrue();
            opcode.Should().Be((byte)OpCode._tableswitch);

            // advance past padding
            b.TryRead(out byte _).Should().BeTrue();
            b.TryRead(out byte _).Should().BeTrue();
            b.TryRead(out byte _).Should().BeTrue();

            // default value should be 32 bit signed integer which is offset from instruction to label
            b.TryReadBigEndian(out int defaultValue).Should().BeTrue();
            defaultValue.Should().Be(labelOffset - tableOffset);

            // low should be starting value: 0
            b.TryReadBigEndian(out int low).Should().BeTrue();
            low.Should().Be(0);

            // high should be ending value: 1
            b.TryReadBigEndian(out int high).Should().BeTrue();
            high.Should().Be(1);

            // first case should be distance from instruction to return
            b.TryReadBigEndian(out int case1Offset).Should().BeTrue();
            case1Offset.Should().Be(labelOffset - tableOffset);

            // second case should be distance from instruction to return
            b.TryReadBigEndian(out int case2Offset).Should().BeTrue();
            case2Offset.Should().Be(labelOffset - tableOffset);

            // last value should be return instruction
            b.TryRead(out byte returnInstruction).Should().BeTrue();
            returnInstruction.Should().Be((byte)OpCode._return);
        }

        [TestMethod]
        public void CanEncodeLookupSwitch()
        {
            var blob = new BlobBuilder();
            var code = new InstructionEncoder(blob);

            var defaultLabel = code.DefineLabel();
            var case1Label = code.DefineLabel();
            var case2Label = code.DefineLabel();

            // tableswitch
            var lookupOffset = code.Offset;
            code.LookupSwitch(defaultLabel, e => e.Case(1, case1Label).Case(2, case2Label));

            // return code, all labels arrive here
            var labelOffset = code.Offset;
            code.MarkLabel(defaultLabel);
            code.MarkLabel(case1Label);
            code.MarkLabel(case2Label);
            code.OpCode(OpCode._return);

            var b = new SequenceReader<byte>(new ReadOnlySequence<byte>(blob.ToArray()));

            // start with instruction
            b.TryRead(out byte opcode).Should().BeTrue();
            opcode.Should().Be((byte)OpCode._lookupswitch);

            // advance past padding
            b.TryRead(out byte _).Should().BeTrue();
            b.TryRead(out byte _).Should().BeTrue();
            b.TryRead(out byte _).Should().BeTrue();

            // default value should be 32 bit signed integer which is offset from instruction to label
            b.TryReadBigEndian(out int defaultValue).Should().BeTrue();
            defaultValue.Should().Be(labelOffset - lookupOffset);

            // npairs, count of pairs
            b.TryReadBigEndian(out int npairs).Should().BeTrue();
            npairs.Should().Be(2);

            // first case key
            b.TryReadBigEndian(out int case1Key).Should().BeTrue();
            case1Key.Should().Be(1);

            // first case offset should be distance from instruction to return
            b.TryReadBigEndian(out int case1Offset).Should().BeTrue();
            case1Offset.Should().Be(labelOffset - lookupOffset);

            // second case key
            b.TryReadBigEndian(out int case2Key).Should().BeTrue();
            case2Key.Should().Be(2);

            // second case offset should be distance from instruction to return
            b.TryReadBigEndian(out int case2Offset).Should().BeTrue();
            case2Offset.Should().Be(labelOffset - lookupOffset);

            // last value should be return instruction
            b.TryRead(out byte returnInstruction).Should().BeTrue();
            returnInstruction.Should().Be((byte)OpCode._return);
        }

    }

}
