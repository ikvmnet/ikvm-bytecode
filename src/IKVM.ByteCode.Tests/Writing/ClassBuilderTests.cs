using FluentAssertions;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;
using IKVM.ByteCode.Reading;
using IKVM.ByteCode.Writing;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Writing
{

    [TestClass]
    public class ClassBuilderTests
    {

        [TestMethod]
        public void CanBuildSimpleClass()
        {
            var b = new ClassBuilder(new ClassFormatVersion(53, 0), AccessFlag.ACC_PUBLIC, "TestClass", "java/lang/Object");
            var f = b.AddField(AccessFlag.ACC_PUBLIC, "_field", "Z", new AttributeBuilder(b));
            var m = b.AddMethod(AccessFlag.ACC_PUBLIC, "method", "()Z", new AttributeBuilder(b));

            var z = new BlobBuilder();
            b.Serialize(z);
            var a = z.ToArray();

            var cls = ClassReader.Read(a);
            cls.AccessFlags.Should().Be(AccessFlag.ACC_PUBLIC);
            cls.This.Name.Value.Should().Be("TestClass");
            cls.Super.Name.Value.Should().Be("java/lang/Object");
            cls.Fields.Should().HaveCount(1);
            cls.Fields[0].AccessFlags.Should().Be(AccessFlag.ACC_PUBLIC);
            cls.Fields[0].Name.Value.Should().Be("_field");
            cls.Fields[0].Descriptor.Value.Should().Be("Z");
            cls.Methods.Should().HaveCount(1);
            cls.Methods[0].Name.Value.Should().Be("method");
            cls.Methods[0].Descriptor.Value.Should().Be("()Z");
        }

    }

}
