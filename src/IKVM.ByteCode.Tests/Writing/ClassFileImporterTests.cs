using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Reading;
using IKVM.ByteCode.Writing;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Writing
{

    [TestClass]
    public class ClassFileImporterTests
    {

        [TestMethod]
        public void Foo()
        {
            var srcBuilder = new ClassFileBuilder(new ClassFormatVersion(53, 0), AccessFlag.ACC_PUBLIC, "com/test/Test", null);

            srcBuilder.Attributes
                .RuntimeVisibleAnnotations(e => e
                    .Annotation(e2 => e2
                        .Annotation(srcBuilder.Constants.GetOrAdd("test"), e3 => e3
                            .Boolean(srcBuilder.Constants.GetOrAdd("test"), srcBuilder.Constants.GetOrAdd(Constant.Integer(true))))));

            var srcBlob = new BlobBuilder();
            srcBuilder.Serialize(srcBlob);

            var src = ClassFile.Read(srcBlob.ToArray());

            // create a copy of the attributes on the original loaded class
            var dstBuilder = new ClassFileBuilder(new ClassFormatVersion(53, 0), AccessFlag.ACC_PUBLIC, "com/test/Test", null);
            src.Attributes.EncodeTo(new IdentityConstantMap<ConstantTable>(src.Constants), ref dstBuilder.Attributes.Encoder);

            var dstBlob = new BlobBuilder();
            dstBuilder.Serialize(dstBlob);

            var dst = ClassFile.Read(dstBlob.ToArray());
        }

    }

}
