using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct ModuleExportInfo(PackageConstantHandle Package, ModuleExportsFlag Flags, ModuleConstantHandleTable Modules)
    {

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref ModuleExportsTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            var self = this;
            encoder.Exports(map.Map(Package), Flags, e => Encode(self.Modules, ref e));

            void Encode(in ModuleConstantHandleTable table, ref ModuleTableEncoder e)
            {
                foreach (var i in table)
                    e.Module(map.Map(i));
            }
        }

    }

}
