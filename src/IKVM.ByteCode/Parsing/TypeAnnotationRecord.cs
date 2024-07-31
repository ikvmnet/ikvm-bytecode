namespace IKVM.ByteCode.Parsing
{

    public record struct TypeAnnotationRecord(TypeAnnotationTargetType TargetType, TypeAnnotationTargetRecord Target, TypePathRecord TargetPath, Utf8ConstantHandle Type, params ElementValuePairRecord[] Elements)
    {

        public static bool TryReadTypeAnnotation(ref ClassFormatReader reader, out TypeAnnotationRecord annotation)
        {
            annotation = default;

            if (reader.TryReadU1(out byte targetType) == false)
                return false;
            if (TryReadTarget(ref reader, (TypeAnnotationTargetType)targetType, out var target) == false)
                return false;
            if (TypePathRecord.TryRead(ref reader, out var targetPath) == false)
                return false;
            if (reader.TryReadU2(out ushort typeIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort pairCount) == false)
                return false;

            var elements = new ElementValuePairRecord[pairCount];
            for (int i = 0; i < pairCount; i++)
                if (ElementValuePairRecord.TryRead(ref reader, out elements[i]) == false)
                    return false;

            annotation = new TypeAnnotationRecord((TypeAnnotationTargetType)targetType, target, targetPath, new(typeIndex), elements);
            return true;
        }

        public static bool TryReadTarget(ref ClassFormatReader reader, TypeAnnotationTargetType targetType, out TypeAnnotationTargetRecord targetInfo) => targetType switch
        {
            TypeAnnotationTargetType.ClassTypeParameter => TypeParameterTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.MethodTypeParameter => TypeParameterTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.ClassExtends => SuperTypeTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.ClassTypeParameterBound => TypeParameterBoundTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.MethodTypeParameterBound => TypeParameterBoundTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.Field => EmptyTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.MethodReturn => EmptyTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.MethodReceiver => EmptyTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.MethodFormalParameter => FormalParameterTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.Throws => ThrowsTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.LocalVariable => LocalVariableTargetTableRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.ResourceVariable => LocalVariableTargetTableRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.ExceptionParameter => CatchTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.InstanceOf => OffsetTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.New => OffsetTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.ConstructorReference => OffsetTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.MethodReference => OffsetTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.Cast => TypeArgumentTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.ConstructorInvocationTypeArgument => TypeArgumentTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.MethodInvocationTypeArgument => TypeArgumentTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.ConstructorReferenceTypeArgument => TypeArgumentTargetRecord.TryRead(ref reader, out targetInfo),
            TypeAnnotationTargetType.MethodReferenceTypeArgument => TypeArgumentTargetRecord.TryRead(ref reader, out targetInfo),
            _ => throw new ByteCodeException($"Invalid type annotation target type: '0x{targetType:X}'."),
        };

    }

}
