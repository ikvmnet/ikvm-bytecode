using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleAttributeExports(PackageConstantHandle Package, ModuleExportsFlag Flags, ReadOnlyMemory<ModuleConstantHandle> Modules);

}
