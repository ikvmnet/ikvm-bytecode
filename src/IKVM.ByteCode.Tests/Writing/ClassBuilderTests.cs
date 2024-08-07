using FluentAssertions;

using IKVM.ByteCode.Buffers;
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
            var f = b.AddField(AccessFlag.ACC_PUBLIC, "_field", "Z");
            var m = b.AddMethod(AccessFlag.ACC_PUBLIC, "method", "()Z");

            var z = new BlobBuilder();
            b.Serialize(z);
            var a = z.ToArray();

            var cls = ClassFile.Read(a);
            cls.AccessFlags.Should().Be(AccessFlag.ACC_PUBLIC);
            cls.Constants.GetClassName(cls.This).Should().Be("TestClass");
            cls.Constants.GetClassName(cls.Super).Should().Be("java/lang/Object");
            cls.Fields.Should().HaveCount(1);
            cls.Fields[0].AccessFlags.Should().Be(AccessFlag.ACC_PUBLIC);
            cls.Constants.GetUtf8Value(cls.Fields[0].Name).Should().Be("_field");
            cls.Constants.GetUtf8Value(cls.Fields[0].Descriptor).Should().Be("Z");
            cls.Methods.Should().HaveCount(1);
            cls.Constants.GetUtf8Value(cls.Methods[0].Name).Should().Be("method");
            cls.Constants.GetUtf8Value(cls.Methods[0].Descriptor).Should().Be("()Z");
        }

        public void Foo()
        {
            var p = new ConstantBuilder(new ClassFormatVersion(53, 0));
            var a = new AttributeTableBuilder(p);
        }

    }

}
