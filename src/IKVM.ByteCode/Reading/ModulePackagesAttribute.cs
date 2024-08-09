using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModulePackagesAttribute(PackageConstantHandleTable Packages)
    {

        public static ModulePackagesAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out ModulePackagesAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var packages = count == 0 ? [] : new PackageConstantHandle[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort packageIndex) == false)
                    return false;

                packages[i] = new(packageIndex);
            }

            attribute = new ModulePackagesAttribute(new(packages));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}