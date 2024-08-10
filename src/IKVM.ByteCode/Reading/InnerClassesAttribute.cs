using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct InnerClassesAttribute(InnerClassTable Table)
    {

        public static InnerClassesAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out InnerClassesAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var table = count == 0 ? [] : new InnerClass[count];
            for (int i = 0; i < count; i++)
            {
                if (reader.TryReadU2(out ushort innerClassInfoIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort outerClassInfoIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort innerNameIndex) == false)
                    return false;
                if (reader.TryReadU2(out ushort innerClassAccessFlags) == false)
                    return false;

                table[i] = new InnerClass(new(innerClassInfoIndex), new(outerClassInfoIndex), new(innerNameIndex), (AccessFlag)innerClassAccessFlags);
            }

            attribute = new InnerClassesAttribute(new(table));
            return true;
        }

        readonly bool _isNotNil = true;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="attributeName"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, Utf8ConstantHandle attributeName, ref AttributeTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            var self = this;
            encoder.InnerClasses(attributeName, e => self.EncodeTo(map, ref e));
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref InnerClassTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            foreach (var i in Table)
                encoder.InnerClass(map.Map(i.Inner), map.Map(i.Outer), map.Map(i.InnerName), i.InnerAccessFlags);
        }

    }

}
