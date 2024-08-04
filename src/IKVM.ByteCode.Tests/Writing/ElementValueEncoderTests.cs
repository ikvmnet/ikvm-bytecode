﻿using System;

using FluentAssertions;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;
using IKVM.ByteCode.Writing;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Writing
{

    [TestClass]
    public class ElementValueEncoderTests
    {

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowOnEncodeTwo()
        {
            var builder = new BlobBuilder();
            var encoder = new ElementValueEncoder(builder);
            encoder.Byte(new IntegerConstantHandle(1));
            encoder.Byte(new IntegerConstantHandle(1));
        }

        [TestMethod]
        public void CanEncodeByte()
        {
            var builder = new BlobBuilder();
            var encoder = new ElementValueEncoder(builder);
            encoder.Byte(new IntegerConstantHandle(1));

            var r = new ClassFormatReader(builder.ToArray());
            r.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ElementValueTag.Byte);
            r.TryReadU2(out var constValueIndex).Should().BeTrue();
            constValueIndex.Should().Be(1);
        }

        [TestMethod]
        public void CanEncodeChar()
        {
            var builder = new BlobBuilder();
            var encoder = new ElementValueEncoder(builder);
            encoder.Char(new IntegerConstantHandle(1));

            var r = new ClassFormatReader(builder.ToArray());
            r.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ElementValueTag.Char);
            r.TryReadU2(out var constValueIndex).Should().BeTrue();
            constValueIndex.Should().Be(1);
        }

        [TestMethod]
        public void CanEncodeDouble()
        {
            var builder = new BlobBuilder();
            var encoder = new ElementValueEncoder(builder);
            encoder.Double(new DoubleConstantHandle(1));

            var r = new ClassFormatReader(builder.ToArray());
            r.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ElementValueTag.Double);
            r.TryReadU2(out var constValueIndex).Should().BeTrue();
            constValueIndex.Should().Be(1);
        }

        [TestMethod]
        public void CanEncodeFloat()
        {
            var builder = new BlobBuilder();
            var encoder = new ElementValueEncoder(builder);
            encoder.Float(new FloatConstantHandle(1));

            var r = new ClassFormatReader(builder.ToArray());
            r.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ElementValueTag.Float);
            r.TryReadU2(out var constValueIndex).Should().BeTrue();
            constValueIndex.Should().Be(1);
        }

        [TestMethod]
        public void CanEncodeInteger()
        {
            var builder = new BlobBuilder();
            var encoder = new ElementValueEncoder(builder);
            encoder.Integer(new IntegerConstantHandle(1));

            var r = new ClassFormatReader(builder.ToArray());
            r.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ElementValueTag.Integer);
            r.TryReadU2(out var constValueIndex).Should().BeTrue();
            constValueIndex.Should().Be(1);
        }

        [TestMethod]
        public void CanEncodeLong()
        {
            var builder = new BlobBuilder();
            var encoder = new ElementValueEncoder(builder);
            encoder.Long(new LongConstantHandle(1));

            var r = new ClassFormatReader(builder.ToArray());
            r.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ElementValueTag.Long);
            r.TryReadU2(out var constValueIndex).Should().BeTrue();
            constValueIndex.Should().Be(1);
        }

        [TestMethod]
        public void CanEncodeShort()
        {
            var builder = new BlobBuilder();
            var encoder = new ElementValueEncoder(builder);
            encoder.Short(new IntegerConstantHandle(1));

            var r = new ClassFormatReader(builder.ToArray());
            r.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ElementValueTag.Short);
            r.TryReadU2(out var constValueIndex).Should().BeTrue();
            constValueIndex.Should().Be(1);
        }

        [TestMethod]
        public void CanEncodeBoolean()
        {
            var builder = new BlobBuilder();
            var encoder = new ElementValueEncoder(builder);
            encoder.Boolean(new IntegerConstantHandle(1));

            var r = new ClassFormatReader(builder.ToArray());
            r.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ElementValueTag.Boolean);
            r.TryReadU2(out var constValueIndex).Should().BeTrue();
            constValueIndex.Should().Be(1);
        }

        [TestMethod]
        public void CanEncodeString()
        {
            var builder = new BlobBuilder();
            var encoder = new ElementValueEncoder(builder);
            encoder.String(new Utf8ConstantHandle(1));

            var r = new ClassFormatReader(builder.ToArray());
            r.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ElementValueTag.String);
            r.TryReadU2(out var constValueIndex).Should().BeTrue();
            constValueIndex.Should().Be(1);
        }

    }

}