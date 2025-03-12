using System;
using System.Buffers.Binary;
using System.Linq;

using FluentAssertions;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Decoding;
using IKVM.ByteCode.Encoding;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Tests.Encoding
{

    [TestClass]
    public class AttributeTableEncoderTests
    {

        [TestMethod]
        public void CanEncodeModuleAttribute()
        {
            var b = new BlobBuilder();
            var e = new AttributeTableEncoder(b);
            e.Module(
                new Utf8ConstantHandle(1),
                new ModuleConstantHandle(2),
                default,
                new Utf8ConstantHandle(3),
                static a => { },
                static a => { },
                static a => { },
                static a => { },
                static a => { });

            var s = b.ToArray();
            s.Should().BeEquivalentTo((byte[])[
                0x00, 0x01, // attribute_count
                0x00, 0x01, // attribute_name_index
                0x00, 0x00, 0x00, 0x10, // attribute_length
                0x00, 0x02, // module_name_index
                0x00, 0x00, // module_flags
                0x00, 0x03, // module_version_index
                0x00, 0x00, // requires_count
                // requires
                0x00, 0x00, // exports_count
                // exports
                0x00, 0x00, // opens_count
                // opens
                0x00, 0x00, // uses_count
                // uses
                0x00, 0x00, // provides_count
            ]);
        }

    }

}
