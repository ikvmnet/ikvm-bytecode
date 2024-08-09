using System.IO;
using System.Linq;

using FluentAssertions;

using IKVM.ByteCode.Reading;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Reading
{

    [TestClass]
    public class ConstantReaderTests
    {

        ClassFile ReadClass()
        {
            return ClassFile.Read(Path.Combine(Path.GetDirectoryName(typeof(ConstantReaderTests).Assembly.Location), "Reading", "ConstantReaderTests.class"));
        }

        [TestMethod]
        public void CanReadIntegerConstant()
        {
            var c = ReadClass();
            c.Constants.Where(i => i.Kind == ConstantKind.Integer).Select(i => c.Constants.Read((IntegerConstantHandle)i)).Should().Contain(i => i.Value == 394892);
        }

        [TestMethod]
        public void CanReadLongConstant()
        {
            var c = ReadClass();
            c.Constants.Where(i => i.Kind == ConstantKind.Long).Select(i => c.Constants.Read((LongConstantHandle)i)).Should().Contain(i => i.Value == 34182132);
        }

        [TestMethod]
        public void CanReadFloatConstant()
        {
            var c = ReadClass();
            c.Constants.Where(i => i.Kind == ConstantKind.Float).Select(i => c.Constants.Read((FloatConstantHandle)i)).Should().Contain(i => i.Value == 221.03f);
        }

        [TestMethod]
        public void CanReadDoubleConstant()
        {
            var c = ReadClass();
            c.Constants.Where(i => i.Kind == ConstantKind.Double).Select(i => c.Constants.Read((DoubleConstantHandle)i)).Should().Contain(i => i.Value == 2212133.1d);
        }

        [TestMethod]
        public void CanReadStringConstant()
        {
            var c = ReadClass();
            c.Constants.Where(i => i.Kind == ConstantKind.Utf8).Select(i => c.Constants.Get((Utf8ConstantHandle)i)).Should().Contain(i => i == "STRING");
        }

        [TestMethod]
        public void CanReadClassConstant()
        {
            var c = ReadClass();
            c.Constants.Where(i => i.Kind == ConstantKind.Class).Select(i => c.Constants.Get((ClassConstantHandle)i)).Should().Contain(i => i == "java/lang/Object");
        }

        [TestMethod]
        public void CanReadMethodrefConstant()
        {
            var c = ReadClass();
            c.Constants.Where(i => i.Kind == ConstantKind.Methodref).Select(i => c.Constants.Read((MethodrefConstantHandle)i)).Should().Contain(i => c.Constants.Get(i.Class) == "java/lang/Object" && c.Constants.Get(c.Constants.Read(i.NameAndType).Name) == "<init>" && c.Constants.Get(c.Constants.Read(i.NameAndType).Descriptor) == "()V");
        }

    }

}
