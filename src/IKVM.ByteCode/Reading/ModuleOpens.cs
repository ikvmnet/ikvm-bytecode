using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleOpens(PackageConstantHandle Package, ModuleOpensFlag Flags, ModuleConstantHandleTable Modules);

}
