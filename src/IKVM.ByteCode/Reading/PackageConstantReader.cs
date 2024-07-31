using IKVM.ByteCode.Parsing;

using static IKVM.ByteCode.Util;

namespace IKVM.ByteCode.Reading
{

    public sealed class PackageConstantReader : ConstantReader<PackageConstantRecord>
    {

        Utf8ConstantReader name;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="record"></param>
        internal PackageConstantReader(ClassReader owner, PackageConstantHandle handle, PackageConstantRecord record) :
            base(owner, handle, record)
        {

        }

        /// <summary>
        /// Gest the name of this package.
        /// </summary>
        public Utf8ConstantReader Name => LazyGet(ref name, () => DeclaringClass.Constants.Get<Utf8ConstantReader>(Record.Name));

    }

}
