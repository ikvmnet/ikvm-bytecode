using FluentAssertions;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;
using IKVM.ByteCode.Writing;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Writing
{

    [TestClass]
    public class TypePathEncoderTests
    {

        [TestMethod]
        public void CanEncodeArray()
        {
            var builder = new BlobBuilder();
            new TypePathEncoder(builder).Array();

            var w = new ClassFormatReader(builder.ToArray());
            w.TryReadU1(out var l).Should().BeTrue();
            l.Should().Be(1);
            w.TryReadU1(out var k).Should().BeTrue();
            k.Should().Be(0);
            w.TryReadU1(out var a).Should().BeTrue();
            a.Should().Be(0);
        }

        [TestMethod]
        public void CanEncodeInnerType()
        {
            var builder = new BlobBuilder();
            new TypePathEncoder(builder).InnerType();

            var w = new ClassFormatReader(builder.ToArray());
            w.TryReadU1(out var l).Should().BeTrue();
            l.Should().Be(1);
            w.TryReadU1(out var k).Should().BeTrue();
            k.Should().Be(1);
            w.TryReadU1(out var a).Should().BeTrue();
            a.Should().Be(0);
        }

        [TestMethod]
        public void CanEncodeWildcard()
        {
            var builder = new BlobBuilder();
            new TypePathEncoder(builder).Wildcard();

            var w = new ClassFormatReader(builder.ToArray());
            w.TryReadU1(out var l).Should().BeTrue();
            l.Should().Be(1);
            w.TryReadU1(out var k).Should().BeTrue();
            k.Should().Be(2);
            w.TryReadU1(out var a).Should().BeTrue();
            a.Should().Be(0);
        }

        [TestMethod]
        public void CanEncodeTypeArgument()
        {
            var builder = new BlobBuilder();
            new TypePathEncoder(builder).TypeArgument(1);

            var w = new ClassFormatReader(builder.ToArray());
            w.TryReadU1(out var l).Should().BeTrue();
            l.Should().Be(1);
            w.TryReadU1(out var k).Should().BeTrue();
            k.Should().Be(3);
            w.TryReadU1(out var a).Should().BeTrue();
            a.Should().Be(1);
        }

        [TestMethod]
        public void CanEncodeMultiple()
        {
            var builder = new BlobBuilder();
            new TypePathEncoder(builder).Array().Array();

            var w = new ClassFormatReader(builder.ToArray());
            w.TryReadU1(out var l).Should().BeTrue();
            l.Should().Be(2);
            w.TryReadU1(out var k1).Should().BeTrue();
            k1.Should().Be(0);
            w.TryReadU1(out var a1).Should().BeTrue();
            a1.Should().Be(0);
            w.TryReadU1(out var k2).Should().BeTrue();
            k2.Should().Be(0);
            w.TryReadU1(out var a2).Should().BeTrue();
            a2.Should().Be(0);
        }

        [TestMethod]
        public void CanEncodeRecord()
        {
            var builder = new BlobBuilder();
            new TypePathEncoder(builder).Encode(new TypePathRecord([
                new TypePathItemRecord(TypePathKind.Array, 0),
                new TypePathItemRecord(TypePathKind.Array, 0),
            ]));

            var w = new ClassFormatReader(builder.ToArray());
            w.TryReadU1(out var l).Should().BeTrue();
            l.Should().Be(2);
            w.TryReadU1(out var k1).Should().BeTrue();
            k1.Should().Be(0);
            w.TryReadU1(out var a1).Should().BeTrue();
            a1.Should().Be(0);
            w.TryReadU1(out var k2).Should().BeTrue();
            k2.Should().Be(0);
            w.TryReadU1(out var a2).Should().BeTrue();
            a2.Should().Be(0);
        }

        [TestMethod]
        public void CanEncodeRecordAndParse()
        {
            var builder = new BlobBuilder();
            new TypePathEncoder(builder).Encode(new TypePathRecord([
                new TypePathItemRecord(TypePathKind.Array, 0),
                new TypePathItemRecord(TypePathKind.Array, 0),
            ]));

            var r = new ClassFormatReader(builder.ToArray());
            TypePathRecord.TryRead(ref r, out var record).Should().BeTrue();
            record.Path.Should().HaveCount(2);
            record.Path[0].Kind.Should().Be(TypePathKind.Array);
            record.Path[1].Kind.Should().Be(TypePathKind.Array);
        }

    }

}
