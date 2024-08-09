using IKVM.ByteCode.Writing;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Writing
{

    [TestClass]
    public class ClassFileImporterTests
    {

        public void Foo()
        {
            var b = new ClassFileBuilder(new ClassFormatVersion(53, 0), AccessFlag.ACC_PUBLIC, "TestClass", "java/lang/Object");
            var f = b.AddField(AccessFlag.ACC_PUBLIC, "_field", "Z");
            var m = b.AddMethod(AccessFlag.ACC_PUBLIC, "method", "()Z");

            var i = new ClassFileImporter
        }

    }

}
