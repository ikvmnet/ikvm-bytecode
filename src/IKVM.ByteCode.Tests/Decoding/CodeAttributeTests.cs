using System.Buffers;
using System.Buffers.Binary;

using FluentAssertions;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Decoding;
using IKVM.ByteCode.Encoding;
using IKVM.ByteCode.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Decoding
{

    [TestClass]
    public class CodeAttributeTests
    {

        [TestMethod]
        public void CanRewriteLoadConstant()
        {
            var int32 = new byte[4];
            BinaryPrimitives.WriteInt32BigEndian(int32, 1234);

            var codeName = new byte[6];
            BinaryPrimitives.WriteInt16BigEndian(codeName, 4);
            MUTF8Encoding.GetMUTF8(50).GetBytes("Code").CopyTo(codeName, 2);

            var constants = new ConstantTable(new ClassFormatVersion(50, 0), [
                new(ConstantKind.Unknown, new ReadOnlySequence<byte>()),
                new(ConstantKind.Integer, new ReadOnlySequence<byte>(int32)),
                new(ConstantKind.Utf8, new ReadOnlySequence<byte>(codeName)),
            ]);

            var codeBuffer1 = new BlobBuilder();
            var excpBuffer1 = new BlobBuilder();
            new CodeBuilder(codeBuffer1)
                .DefineLabel(out var end)
                .BeginExceptionBlock(ClassConstantHandle.Nil, out var handler)
                    .LoadConstant(new IntegerConstantHandle(1))
                    .Pop()
                .EndExceptionBlock()
                .MarkLabel(handler)
                .MarkLabel(end)
                .Return()
                .SerializeExceptions(excpBuffer1);

            // fake up a code attribute
            var excpReader1 = new ClassFormatReader(excpBuffer1.ToArray());
            ExceptionHandlerTable.TryRead(ref excpReader1, out var excpTable1).Should().BeTrue();
            var codeAttr1 = new CodeAttribute(10, 10, new ReadOnlySequence<byte>(codeBuffer1.ToArray()), excpTable1, new AttributeTable([]));

            // copy code attribute to new attribute table encoder
            var attrTable2 = new BlobBuilder();
            var attrEncoder2 = new AttributeTableEncoder(attrTable2);
            codeAttr1.CopyTo(constants, constants, ref attrEncoder2);
        }

    }

}
