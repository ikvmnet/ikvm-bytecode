namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleAttribute(ModuleConstantHandle Name, ModuleFlag Flags, Utf8ConstantHandle Version, ModuleRequiresTable Requires, ModuleExportsTable Exports, ModuleOpensTable Opens, ClassConstantHandleTable Uses, ModuleProvidesTable Provides, bool IsNotNil = true)
    {

        public static ModuleAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out ModuleAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort moduleNameIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort moduleFlags) == false)
                return false;
            if (reader.TryReadU2(out ushort moduleVersionIndex) == false)
                return false;

            if (reader.TryReadU2(out ushort requiresCount) == false)
                return false;

            var requires = requiresCount == 0 ? [] : new ModuleRequires[requiresCount];
            for (int i = 0; i < requiresCount; i++)
            {
                if (reader.TryReadU2(out ushort requiresIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort requiresFlags) == false)
                    return false;
                if (reader.TryReadU2(out ushort requiresVersionIndex) == false)
                    return false;

                requires[i] = new ModuleRequires(new(requiresIndex), (ModuleRequiresFlag)requiresFlags, new(requiresVersionIndex));
            }

            if (reader.TryReadU2(out ushort exportsCount) == false)
                return false;

            var exports = new ModuleExports[exportsCount];
            for (int i = 0; i < exportsCount; i++)
            {
                if (reader.TryReadU2(out ushort exportsIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort exportsFlags) == false)
                    return false;

                if (reader.TryReadU2(out ushort exportsModuleCount) == false)
                    return false;

                var exportsModules = exportsModuleCount == 0 ? [] : new ModuleConstantHandle[exportsModuleCount];
                for (int j = 0; j < exportsModuleCount; j++)
                {
                    if (reader.TryReadU2(out ushort exportsToModuleIndex) == false)
                        return false;

                    exportsModules[j] = new(exportsToModuleIndex);
                }

                exports[i] = new ModuleExports(new(exportsIndex), (ModuleExportsFlag)exportsFlags, new(exportsModules));
            }

            if (reader.TryReadU2(out ushort opensCount) == false)
                return false;

            var opens = opensCount == 0 ? [] : new ModuleOpens[opensCount];
            for (int i = 0; i < opensCount; i++)
            {
                if (reader.TryReadU2(out ushort opensIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort opensFlags) == false)
                    return false;

                if (reader.TryReadU2(out ushort opensModulesCount) == false)
                    return false;

                var opensModules = opensModulesCount == 0 ? [] : new ModuleConstantHandle[opensModulesCount];
                for (int j = 0; j < opensModulesCount; j++)
                {
                    if (reader.TryReadU2(out ushort opensModuleIndex) == false)
                        return false;

                    opensModules[j] = new(opensModuleIndex);
                }

                opens[i] = new ModuleOpens(new(opensIndex), (ModuleOpensFlag)opensFlags, new(opensModules));
            }

            if (reader.TryReadU2(out ushort usesCount) == false)
                return false;

            var uses = usesCount == 0 ? [] : new ClassConstantHandle[usesCount];
            for (int i = 0; i < usesCount; i++)
            {
                if (reader.TryReadU2(out ushort usesIndex) == false)
                    return false;

                uses[i] = new(usesIndex);
            }

            if (reader.TryReadU2(out ushort providesCount) == false)
                return false;

            var provides = providesCount == 0 ? [] : new ModuleProvides[providesCount];
            for (int i = 0; i < providesCount; i++)
            {
                if (reader.TryReadU2(out ushort providesIndex) == false)
                    return false;

                if (reader.TryReadU2(out ushort providesModulesCount) == false)
                    return false;

                var providesModules = providesModulesCount == 0 ? [] : new ClassConstantHandle[providesModulesCount];
                for (int j = 0; j < providesModulesCount; j++)
                {
                    if (reader.TryReadU2(out ushort providesModuleIndex) == false)
                        return false;

                    providesModules[j] = new(providesModuleIndex);
                }

                provides[i] = new ModuleProvides(new(providesIndex), new(providesModules));
            }

            attribute = new ModuleAttribute(new(moduleNameIndex), (ModuleFlag)moduleFlags, new(moduleVersionIndex), new(requires), new(exports), new(opens), new(uses), new(provides));
            return true;
        }

        public bool IsNil => !IsNotNil;

    }

}
