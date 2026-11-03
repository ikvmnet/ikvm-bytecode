using System;
using System.IO;

using FluentAssertions;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Decoding;
using IKVM.ByteCode.Encoding;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Encoding
{

    [TestClass]
    public class StackMapTableEncoderTests
    {

        static byte[] Encode(Action<StackMapTableEncoder> frames)
        {
            var builder = new BlobBuilder();
            frames(new StackMapTableEncoder(builder));
            return builder.ToArray();
        }

        [TestMethod]
        public void CanEncodeSameFrame()
        {
            Encode(e => e.Same(5)).Should().Equal(
                0x00, 0x01, // number_of_entries
                0x05); // same_frame, offset_delta 5
        }

        [TestMethod]
        public void CanEncodeSameLocalsOneStackItemFrame()
        {
            Encode(e => e.SameLocalsOneStackItem(69, s => s.Integer())).Should().Equal(
                0x00, 0x01, // number_of_entries
                0x45, // same_locals_1_stack_item_frame, offset_delta 5
                0x01); // stack: Integer
        }

        [TestMethod]
        public void CanEncodeSameLocalsOneStackItemExtendedFrame()
        {
            Encode(e => e.SameLocalsOneStackItemExtended(0x0100, s => s.Object(new ClassConstantHandle(3)))).Should().Equal(
                0x00, 0x01, // number_of_entries
                0xF7, // same_locals_1_stack_item_frame_extended
                0x01, 0x00, // offset_delta
                0x07, 0x00, 0x03); // stack: Object, cpool_index 3
        }

        [TestMethod]
        public void CanEncodeChopFrame()
        {
            Encode(e => e.Chop(249, 0x0100)).Should().Equal(
                0x00, 0x01, // number_of_entries
                0xF9, // chop_frame, two locals
                0x01, 0x00); // offset_delta
        }

        [TestMethod]
        public void CanEncodeSameExtendedFrame()
        {
            Encode(e => e.SameExtended(0x0100)).Should().Equal(
                0x00, 0x01, // number_of_entries
                0xFB, // same_frame_extended
                0x01, 0x00); // offset_delta
        }

        [TestMethod]
        public void CanEncodeAppendFrame()
        {
            Encode(e => e.Append(253, 5, l => l.Integer().Object(new ClassConstantHandle(3)))).Should().Equal(
                0x00, 0x01, // number_of_entries
                0xFD, // append_frame, two locals
                0x00, 0x05, // offset_delta
                0x01, // locals: Integer
                0x07, 0x00, 0x03); // locals: Object, cpool_index 3
        }

        [TestMethod]
        public void CanEncodeFullFrame()
        {
            Encode(e => e.Full(5, l => l.Integer().Long(), s => s.Uninitialized(7))).Should().Equal(
                0x00, 0x01, // number_of_entries
                0xFF, // full_frame
                0x00, 0x05, // offset_delta
                0x00, 0x02, // number_of_locals
                0x01, // locals: Integer
                0x04, // locals: Long
                0x00, 0x01, // number_of_stack_items
                0x08, 0x00, 0x07); // stack: Uninitialized, offset 7
        }

        [TestMethod]
        public void CanEncodeFullFrameWithoutLocalsOrStack()
        {
            Encode(e => e.Full(5, l => { }, s => { })).Should().Equal(
                0x00, 0x01, // number_of_entries
                0xFF, // full_frame
                0x00, 0x05, // offset_delta
                0x00, 0x00, // number_of_locals
                0x00, 0x00); // number_of_stack_items
        }

        [TestMethod]
        public void AppendFrameCannotHaveMoreLocalsThanItsTypeAdds()
        {
            FluentActions.Invoking(() => Encode(e => e.Append(252, 5, l => l.Integer().Integer()))).Should().Throw<InvalidOperationException>();
        }

        [TestMethod]
        public void SameLocalsOneStackItemFrameCannotHaveTwoStackItems()
        {
            FluentActions.Invoking(() => Encode(e => e.SameLocalsOneStackItem(64, s => s.Integer().Integer()))).Should().Throw<InvalidOperationException>();
        }

        [TestMethod]
        public void EncodedFramesCanBeDecoded()
        {
            var bytes = Encode(e => e
                .Same(5)
                .SameLocalsOneStackItem(64, s => s.Float())
                .SameLocalsOneStackItemExtended(0x0100, s => s.Null())
                .Chop(250, 2)
                .SameExtended(0x0100)
                .Append(254, 3, l => l.Double().Top().UninitializedThis())
                .Full(4, l => l.Integer().Object(new ClassConstantHandle(3)), s => s.Long().Uninitialized(7)));

            var reader = new ClassFormatReader(bytes);
            StackMapTableAttribute.TryRead(ref reader, out var attribute).Should().BeTrue();
            reader.Remaining.Should().Be(0);

            var frames = attribute.Frames;
            frames.Count.Should().Be(7);

            frames[0].AsSameStackMap().FrameType.Should().Be(5);

            var sameLocalsOne = frames[1].AsSameLocalsOneStackMap();
            sameLocalsOne.FrameType.Should().Be(64);
            sameLocalsOne.Stack.Kind.Should().Be(VerificationTypeInfoKind.Float);

            var sameLocalsOneExtended = frames[2].AsSameLocalsOneExtendedStackMap();
            sameLocalsOneExtended.OffsetDelta.Should().Be(0x0100);
            sameLocalsOneExtended.Stack.Kind.Should().Be(VerificationTypeInfoKind.Null);

            var chop = frames[3].AsChopStackMap();
            chop.FrameType.Should().Be(250);
            chop.OffsetDelta.Should().Be(2);

            frames[4].AsSameExtendedStackMap().OffsetDelta.Should().Be(0x0100);

            var append = frames[5].AsAppendStackMap();
            append.FrameType.Should().Be(254);
            append.OffsetDelta.Should().Be(3);
            append.Locals.Count.Should().Be(3);
            append.Locals[0].Kind.Should().Be(VerificationTypeInfoKind.Double);
            append.Locals[1].Kind.Should().Be(VerificationTypeInfoKind.Top);
            append.Locals[2].Kind.Should().Be(VerificationTypeInfoKind.UninitializedThis);

            var full = frames[6].AsFullStackMap();
            full.OffsetDelta.Should().Be(4);
            full.Locals.Count.Should().Be(2);
            full.Locals[0].Kind.Should().Be(VerificationTypeInfoKind.Integer);
            full.Locals[1].AsObject().Class.Slot.Should().Be(3);
            full.Stack.Count.Should().Be(2);
            full.Stack[0].Kind.Should().Be(VerificationTypeInfoKind.Long);
            full.Stack[1].AsUninitialized().Offset.Should().Be(7);
        }

        [TestMethod]
        public void CanEncodeFullFrameWithoutLocalsOrStackIntoReusedBuilder()
        {
            // a cleared builder keeps its old bytes, so a count that never grows must still be written
            var builder = new BlobBuilder();
            builder.WriteBytes(0xFF, 16);
            builder.Clear();

            new StackMapTableEncoder(builder).Full(5, l => { }, s => { });
            builder.ToArray().Should().Equal(
                0x00, 0x01, // number_of_entries
                0xFF, // full_frame
                0x00, 0x05, // offset_delta
                0x00, 0x00, // number_of_locals
                0x00, 0x00); // number_of_stack_items
        }

        [TestMethod]
        public void CopiedStackMapTableHasTheSameFrames()
        {
            // javac wrote same, same_locals_1_stack_item, chop, append and full frames in this class
            using var clazz = ClassFile.Read(Path.Combine(Path.GetDirectoryName(typeof(StackMapTableEncoderTests).Assembly.Location), "resources", "ColorEditor.class"));

            var tables = 0;
            foreach (var method in clazz.Methods)
            {
                foreach (var attribute in method.Attributes)
                {
                    if (clazz.Constants.Get(attribute.Name).Value != AttributeName.Code)
                        continue;

                    foreach (var codeAttribute in ((CodeAttribute)attribute).Attributes)
                    {
                        if (clazz.Constants.Get(codeAttribute.Name).Value != AttributeName.StackMapTable)
                            continue;

                        var original = (StackMapTableAttribute)codeAttribute;
                        var builder = new BlobBuilder();
                        var encoder = new StackMapTableEncoder(builder);
                        original.CopyTo(clazz.Constants, clazz.Constants, ref encoder);

                        // the class has duplicate class constants, which the copy replaces with the first equal one, so
                        // the frames are compared by the names of the classes they refer to rather than byte for byte
                        var reader = new ClassFormatReader(builder.ToArray());
                        StackMapTableAttribute.TryRead(ref reader, out var copy).Should().BeTrue();
                        reader.Remaining.Should().Be(0);
                        DescribeFrames(clazz, copy).Should().Equal(DescribeFrames(clazz, original));
                        tables++;
                    }
                }
            }

            tables.Should().BeGreaterThan(0);
        }

        static string[] DescribeFrames(ClassFile clazz, StackMapTableAttribute table)
        {
            var frames = new string[table.Frames.Count];
            for (int i = 0; i < frames.Length; i++)
            {
                var frame = table.Frames[i];
                frames[i] = frame.FrameType switch
                {
                    <= 63 => $"same {frame.FrameType}",
                    >= 64 and <= 127 => $"same_locals_1_stack_item {frame.FrameType} {DescribeType(clazz, frame.AsSameLocalsOneStackMap().Stack)}",
                    247 => $"same_locals_1_stack_item_extended {frame.AsSameLocalsOneExtendedStackMap().OffsetDelta} {DescribeType(clazz, frame.AsSameLocalsOneExtendedStackMap().Stack)}",
                    >= 248 and <= 250 => $"chop {frame.FrameType} {frame.AsChopStackMap().OffsetDelta}",
                    251 => $"same_extended {frame.AsSameExtendedStackMap().OffsetDelta}",
                    >= 252 and <= 254 => $"append {frame.FrameType} {frame.AsAppendStackMap().OffsetDelta} {DescribeTypes(clazz, frame.AsAppendStackMap().Locals)}",
                    255 => $"full {frame.AsFullStackMap().OffsetDelta} {DescribeTypes(clazz, frame.AsFullStackMap().Locals)} | {DescribeTypes(clazz, frame.AsFullStackMap().Stack)}",
                    _ => throw new InvalidOperationException(),
                };
            }

            return frames;
        }

        static string DescribeTypes(ClassFile clazz, VerificationTypeInfoTable types)
        {
            var names = new string[types.Count];
            for (int i = 0; i < names.Length; i++)
                names[i] = DescribeType(clazz, types[i]);

            return string.Join(", ", names);
        }

        static string DescribeType(ClassFile clazz, VerificationTypeInfo type)
        {
            return type.Kind switch
            {
                VerificationTypeInfoKind.Object => clazz.Constants.Get(type.AsObject().Class).Name,
                VerificationTypeInfoKind.Uninitialized => $"Uninitialized {type.AsUninitialized().Offset}",
                _ => type.Kind.ToString(),
            };
        }

    }

}
