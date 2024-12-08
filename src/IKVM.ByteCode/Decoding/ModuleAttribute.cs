using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
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

        public readonly ModuleConstantHandle Name = Name;
        public readonly ModuleFlag Flags = Flags;
        public readonly Utf8ConstantHandle Version = Version;
        public readonly ModuleRequiresTable Requires = Requires;
        public readonly ModuleExportsTable Exports = Exports;
        public readonly ModuleOpensTable Opens = Opens;
        public readonly ClassConstantHandleTable Uses = Uses;
        public readonly ModuleProvidesTable Provides = Provides;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="attributeName"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantMap>(TConstantMap map, Utf8ConstantHandle attributeName, ref AttributeTableEncoder encoder)
            where TConstantMap : IConstantMap
        {
            var self = this;
            encoder.Module(
                attributeName,
                map.Map(Name),
                Flags,
                map.Map(Version),
                e => self.Requires.EncodeTo(map, ref e),
                e => self.Exports.EncodeTo(map, ref e),
                e => self.Opens.EncodeTo(map, ref e),
                e => self.Uses.EncodeTo(map, ref e),
                e => self.Provides.EncodeTo(map, ref e));
        }

    }

}
