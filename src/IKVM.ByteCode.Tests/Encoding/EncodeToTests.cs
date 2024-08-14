using System;
using System.Buffers;
using System.IO;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Decoding;
using IKVM.ByteCode.Encoding;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Encoding
{

    [TestClass]
    public class ClassFileImporterTests
    {

        [TestMethod]
        public void OpenBigClass()
        {
            using var src = ClassFile.Read(Path.Combine(Path.GetDirectoryName(typeof(ClassFileImporterTests).Assembly.Location), "Encoding", "ChatMessageCell.class"));

            foreach (var m in src.Methods)
                foreach (var a in m.Attributes)
                    if (src.Constants.Get(a.Name).Value == AttributeName.Code)
                        Decode(src, m, ((CodeAttribute)a).Code);
        }

        void Decode(ClassFile src, Method m, ReadOnlySequence<byte> code)
        {
            var dec = new CodeDecoder(code);

            foreach (var instruction in dec)
            {

            }
        }

    }

}
