using FluentAssertions;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Decoding;
using IKVM.ByteCode.Encoding;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Encoding
{

    [TestClass]
    public class ClassBuilderTests
    {

        [TestMethod]
        public void CanBuildSimpleClass()
        {
            var b = new ClassFileBuilder(new ClassFormatVersion(53, 0), AccessFlag.ACC_PUBLIC, "TestClass", "java/lang/Object");
            var f = b.AddField(AccessFlag.ACC_PUBLIC, "_field", "Z");
            var m = b.AddMethod(AccessFlag.ACC_PUBLIC, "method", "()Z");

            var z = new BlobBuilder();
            b.Serialize(z);
            var a = z.ToArray();

            var cls = ClassFile.Read(a);
            cls.AccessFlags.Should().Be(AccessFlag.ACC_PUBLIC);
            cls.Constants.Get(cls.This).Name.Should().Be("TestClass");
            cls.Constants.Get(cls.Super).Name.Should().Be("java/lang/Object");
            cls.Fields.Should().HaveCount(1);
            cls.Fields[0].AccessFlags.Should().Be(AccessFlag.ACC_PUBLIC);
            cls.Constants.Get(cls.Fields[0].Name).Value.Should().Be("_field");
            cls.Constants.Get(cls.Fields[0].Descriptor).Value.Should().Be("Z");
            cls.Methods.Should().HaveCount(1);
            cls.Constants.Get(cls.Methods[0].Name).Value.Should().Be("method");
            cls.Constants.Get(cls.Methods[0].Descriptor).Value.Should().Be("()Z");
        }

    }

}
