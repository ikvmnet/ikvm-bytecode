using System.Collections.Generic;

using IKVM.ByteCode.Reading;

namespace IKVM.ByteCode.Writing
{

    public static class ReadingExtensions
    {

        delegate void InvokeAction<T, TEncoder>(ClassFile src, ConstantBuilder constants, in T element, in TEncoder encoder);

        static void InvokeMany<T, TEncoder>(ClassFile src, ConstantBuilder constants, IEnumerable<T> o, in TEncoder encoder, InvokeAction<T, TEncoder> action)
        {
            foreach (var i in o)
                action(src, constants, i, encoder);
        }

        public static void WriteTo(ClassFile src, ConstantBuilder constants, in Annotation annotation, in AnnotationEncoder encoder)
        {
            encoder.Annotation(constants.GetOrAddUtf8Constant(src.GetUtf8Value(annotation.Type)), e => InvokeMany(src, constants, annotation, e, WriteTo));
        }

        public static void WriteTo(ClassFile src, ConstantBuilder constants, in ElementValuePair elementValuePair, in ElementValuePairTableEncoder encoder)
        {

        }

    }

}
