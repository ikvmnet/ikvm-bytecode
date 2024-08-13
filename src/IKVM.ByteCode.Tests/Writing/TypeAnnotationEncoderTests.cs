using FluentAssertions;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Decoding;
using IKVM.ByteCode.Encoding;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Writing
{

    [TestClass]
    public class TypeAnnotationEncoderTests
    {

        [TestMethod]
        public void CanEncodeClassTypeParameter()
        {
            var builder = new BlobBuilder();
            new TypeAnnotationEncoder(builder)
                .ClassTypeParameter(
                    0,
                    path => path.Array(),
                    new Utf8ConstantHandle(1),
                    elements => elements
                        .Element(
                            new Utf8ConstantHandle(2),
                            value => value.Integer(new IntegerConstantHandle(3))));

            var r = new ClassFormatReader(builder.ToArray());
            r.TryReadU1(out var targetType).Should().BeTrue();
            targetType.Should().Be((byte)TypeAnnotationTargetType.ClassTypeParameter);
            r.TryReadU1(out var typeParameterIndex).Should().BeTrue();
            typeParameterIndex.Should().Be(0);
            r.TryReadU1(out var typePathCount).Should().BeTrue();
            typePathCount.Should().Be(1);
            r.TryReadU1(out var typePathKind).Should().BeTrue();
            typePathKind.Should().Be((byte)TypePathKind.Array);
            r.TryReadU1(out var typePathArgumentIndex).Should().BeTrue();
            typePathArgumentIndex.Should().Be(0);
            r.TryReadU2(out var typeIndex).Should().BeTrue();
            typeIndex.Should().Be(1);
            r.TryReadU2(out var elementValueCount).Should().BeTrue();
            elementValueCount.Should().Be(1);
            r.TryReadU2(out var elementNameIndex).Should().BeTrue();
            elementNameIndex.Should().Be(2);
            r.TryReadU1(out var elementTag).Should().BeTrue();
            elementTag.Should().Be((byte)'I');
            r.TryReadU2(out var elementValue).Should().BeTrue();
            elementValue.Should().Be(3);
        }

    }

}
