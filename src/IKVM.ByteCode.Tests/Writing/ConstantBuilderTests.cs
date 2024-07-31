using System;
using System.Buffers;
using System.Collections.Generic;

using FluentAssertions;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;
using IKVM.ByteCode.Text;
using IKVM.ByteCode.Writing;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Writing
{

    [TestClass]
    public class ConstantBuilderTests
    {

        [TestMethod]
        public void CanEncodeUtf8ConstantSE10()
        {
            var cp = new ConstantBuilder(new ClassFormatVersion(0, 1));
            cp.AddUtf8Constant("TEST").Index.Should().Be(1);

            // output to array
            var _blob = new BlobBuilder();
            cp.Serialize(_blob);
            var blob = _blob.ToArray();

            // read constant pool
            var rd = new ClassFormatReader(blob);
            rd.TryReadU2(out var constant_pool_count).Should().BeTrue();
            constant_pool_count.Should().Be(2);
            rd.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ConstantTag.Utf8);
            rd.TryReadU2(out var length).Should().BeTrue();
            length.Should().Be(4);
            rd.TryReadManyU1(4, out var text).Should().BeTrue();
            text.Length.Should().Be(4);

            // contents of string should decode to TEST
            var _text = new byte[4];
            text.CopyTo(_text);
            MUTF8Encoding.GetMUTF8(1).GetString(_text).Should().Be("TEST");
        }

        [TestMethod]
        public void CanEncodeUtf8Constant()
        {
            var cp = new ConstantBuilder(new ClassFormatVersion(0, 48));
            cp.AddUtf8Constant("TEST").Index.Should().Be(1);

            // output to array
            var _blob = new BlobBuilder();
            cp.Serialize(_blob);
            var blob = _blob.ToArray();

            // read constant pool
            var rd = new ClassFormatReader(blob);
            rd.TryReadU2(out var constant_pool_count).Should().BeTrue();
            constant_pool_count.Should().Be(2);
            rd.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ConstantTag.Utf8);
            rd.TryReadU2(out var length).Should().BeTrue();
            length.Should().Be(4);
            rd.TryReadManyU1(4, out var text).Should().BeTrue();
            text.Length.Should().Be(4);

            // contents of string should decode to TEST
            var _text = new byte[4];
            text.CopyTo(_text);
            MUTF8Encoding.GetMUTF8(48).GetString(_text).Should().Be("TEST");
        }

        [TestMethod]
        public void ShouldNotEncodeDuplicateUtf8Values()
        {
            var cp = new ConstantBuilder(new ClassFormatVersion(0, 48));
            cp.GetOrAddUtf8Constant("TEST").Index.Should().Be(1);
            cp.GetOrAddUtf8Constant("TEST").Index.Should().Be(1);

            // output to array
            var _blob = new BlobBuilder();
            cp.Serialize(_blob);
            var blob = _blob.ToArray();

            // read constant pool
            var rd = new ClassFormatReader(blob);
            rd.TryReadU2(out var constant_pool_count).Should().BeTrue();
            constant_pool_count.Should().Be(2);

            // ignore the rest
        }

        [TestMethod]
        public void CanEncodeTwoDistinctUtf8Values()
        {
            var cp = new ConstantBuilder(new ClassFormatVersion(0, 48));
            cp.GetOrAddUtf8Constant("TEST1").Index.Should().Be(1);
            cp.GetOrAddUtf8Constant("TEST2").Index.Should().Be(2);

            // output to array
            var _blob = new BlobBuilder();
            cp.Serialize(_blob);
            var blob = _blob.ToArray();

            // read constant pool
            var rd = new ClassFormatReader(blob);
            rd.TryReadU2(out var constant_pool_count).Should().BeTrue();
            constant_pool_count.Should().Be(3);

            for (int i = 1; i < 2; i++)
            {
                rd.TryReadU1(out var tag).Should().BeTrue();
                tag.Should().Be((byte)ConstantTag.Utf8);
                rd.TryReadU2(out var length).Should().BeTrue();
                length.Should().Be(5);
                rd.TryReadManyU1(5, out var text).Should().BeTrue();
                text.Length.Should().Be(5);

                // contents of string should decode to TEST
                var _text = new byte[5];
                text.CopyTo(_text);
                MUTF8Encoding.GetMUTF8(48).GetString(_text).Should().Be("TEST" + i);
            }
        }

        [TestMethod]
        public void CanEncodeIntegerConstant()
        {
            var cp = new ConstantBuilder(new ClassFormatVersion(0, 48));
            cp.AddIntegerConstant(65536).Index.Should().Be(1);

            // output to array
            var _blob = new BlobBuilder();
            cp.Serialize(_blob);
            var blob = _blob.ToArray();

            // read constant pool
            var rd = new ClassFormatReader(blob);
            rd.TryReadU2(out var constant_pool_count).Should().BeTrue();
            constant_pool_count.Should().Be(2);
            rd.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ConstantTag.Integer);
            rd.TryReadU4(out var value).Should().BeTrue();
            value.Should().Be(65536);
        }

        [TestMethod]
        public unsafe void CanEncodeFloatConstant()
        {
            var cp = new ConstantBuilder(new ClassFormatVersion(0, 48));
            cp.AddFloatConstant(float.MaxValue - 1).Index.Should().Be(1);

            // output to array
            var _blob = new BlobBuilder();
            cp.Serialize(_blob);
            var blob = _blob.ToArray();

            // read constant pool
            var rd = new ClassFormatReader(blob);
            rd.TryReadU2(out var constant_pool_count).Should().BeTrue();
            constant_pool_count.Should().Be(2);
            rd.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ConstantTag.Float);
            rd.TryReadU4(out var value).Should().BeTrue();
            (*(float*)&value).Should().Be(float.MaxValue - 1);
        }

        [TestMethod]
        public void CanEncodeLongConstant()
        {
            var v = (long)int.MaxValue + 256;
            var h = (uint)(v >> 32);
            var l = (uint)v;

            var cp = new ConstantBuilder(new ClassFormatVersion(0, 48));
            cp.AddLongConstant(v).Index.Should().Be(1);

            // output to array
            var _blob = new BlobBuilder();
            cp.Serialize(_blob);
            var blob = _blob.ToArray();

            // read constant pool
            var rd = new ClassFormatReader(blob);
            rd.TryReadU2(out var constant_pool_count).Should().BeTrue();
            constant_pool_count.Should().Be(3);
            rd.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ConstantTag.Long);
            rd.TryReadU4(out var hv).Should().BeTrue();
            hv.Should().Be(h);
            rd.TryReadU4(out var lv).Should().BeTrue();
            lv.Should().Be(l);
        }

        [TestMethod]
        public unsafe void CanEncodeDoubleConstant()
        {
            var v = (double)float.MaxValue + 256;
            var h = (uint)((*(long*)&v) >> 32);
            var l = (uint)(*(long*)&v);

            var cp = new ConstantBuilder(new ClassFormatVersion(0, 48));
            cp.AddDoubleConstant(v).Index.Should().Be(1);

            // output to array
            var _blob = new BlobBuilder();
            cp.Serialize(_blob);
            var blob = _blob.ToArray();

            // read constant pool
            var rd = new ClassFormatReader(blob);
            rd.TryReadU2(out var constant_pool_count).Should().BeTrue();
            constant_pool_count.Should().Be(3);
            rd.TryReadU1(out var tag).Should().BeTrue();
            tag.Should().Be((byte)ConstantTag.Double);
            rd.TryReadU4(out var hv).Should().BeTrue();
            hv.Should().Be(h);
            rd.TryReadU4(out var lv).Should().BeTrue();
            lv.Should().Be(l);
        }

    }

}
