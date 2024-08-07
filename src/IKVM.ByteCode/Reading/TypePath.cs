using System;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct TypePath(ReadOnlyMemory<TypePathItem> Items)
    {

        public static bool TryRead(ref ClassFormatReader reader, out TypePath typePath)
        {
            typePath = default;

            if (reader.TryReadU1(out byte length) == false)
                return false;

            var path = new TypePathItem[length];
            for (int i = 0; i < length; i++)
            {
                if (TypePathItem.TryRead(ref reader, out var item) == false)
                    return false;

                path[i] = item;
            }

            typePath = new TypePath(path);
            return true;
        }

    }

}
