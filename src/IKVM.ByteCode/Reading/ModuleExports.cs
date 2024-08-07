using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleExports(PackageConstantHandle Package, ModuleExportsFlag Flags, ModuleConstantHandleTable Modules);

}
