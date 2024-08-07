using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleAttributeProvides(ClassConstantHandle Class, ReadOnlyMemory<ClassConstantHandle> Classes);

}
