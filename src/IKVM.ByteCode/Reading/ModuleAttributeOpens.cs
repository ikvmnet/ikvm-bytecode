using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleAttributeOpens(PackageConstantHandle Package, ModuleOpensFlag Flags, ReadOnlyMemory<ModuleConstantHandle> Modules);

}
