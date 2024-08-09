using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleAttribute(ModuleConstantHandle Name, ModuleFlag Flags, Utf8ConstantHandle Version, ModuleRequiresTable Requires, ModuleExportsTable Exports, ModuleOpensTable Opens, ClassConstantHandleTable Uses, ModuleProvidesTable Provides)
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

            var requires = requiresCount == 0 ? [] : new ModuleRequireInfo[requiresCount];
            for (int i = 0; i < requiresCount; i++)
            {
                if (reader.TryReadU2(out ushort requiresIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort requiresFlags) == false)
                    return false;
                if (reader.TryReadU2(out ushort requiresVersionIndex) == false)
                    return false;

                requires[i] = new ModuleRequireInfo(new(requiresIndex), (ModuleRequiresFlag)requiresFlags, new(requiresVersionIndex));
            }

            if (reader.TryReadU2(out ushort exportsCount) == false)
                return false;

            var exports = new ModuleExportInfo[exportsCount];
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

                exports[i] = new ModuleExportInfo(new(exportsIndex), (ModuleExportsFlag)exportsFlags, new(exportsModules));
            }

            if (reader.TryReadU2(out ushort opensCount) == false)
                return false;

            var opens = opensCount == 0 ? [] : new ModuleOpenInfo[opensCount];
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

                opens[i] = new ModuleOpenInfo(new(opensIndex), (ModuleOpensFlag)opensFlags, new(opensModules));
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

            var provides = providesCount == 0 ? [] : new ModuleProvideInfo[providesCount];
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

                provides[i] = new ModuleProvideInfo(new(providesIndex), new(providesModules));
            }

            attribute = new ModuleAttribute(new(moduleNameIndex), (ModuleFlag)moduleFlags, new(moduleVersionIndex), new(requires), new(exports), new(opens), new(uses), new(provides));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="builder"></param>
        public void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, AttributeTableBuilder builder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            var self = this;
            builder.Module(
                pool.Import(view, Name),
                Flags,
                pool.Import(view, Version),
                e => self.Requires.EncodeTo(view, pool, ref e),
                e => self.Exports.EncodeTo(view, pool, ref e),
                e => self.Opens.EncodeTo(view, pool, ref e),
                e => self.Uses.EncodeTo(view, pool, ref e),
                e => self.Provides.EncodeTo(view, pool, ref e));
        }

    }

}
