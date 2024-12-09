using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct TypeAnnotation(TypeAnnotationTarget Target, TypePath TargetPath, Utf8ConstantHandle Type, ElementValuePairTable Elements)
    {

        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            if (TypeAnnotationTarget.TryMeasure(ref reader, ref size) == false)
                return false;

            if (TypePath.TryMeasure(ref reader, ref size) == false)
                return false;

            size += ClassFormatReader.U2;
            if (reader.TryAdvance(ClassFormatReader.U2) == false)
                return false;

            if (ElementValuePairTable.TryMeasure(ref reader, ref size) == false)
                return false;

            return true;
        }

        public static bool TryRead(ref ClassFormatReader reader, out TypeAnnotation annotation)
        {
            annotation = default;

            if (TypeAnnotationTarget.TryReadData(ref reader, out var target) == false)
                return false;
            if (TypePath.TryRead(ref reader, out var targetPath) == false)
                return false;
            if (reader.TryReadU2(out ushort typeIndex) == false)
                return false;
            if (ElementValuePairTable.TryRead(ref reader, out var elements) == false)
                return false;

            annotation = new TypeAnnotation(target, targetPath, new(typeIndex), elements);
            return true;
        }

        public readonly TypeAnnotationTarget Target = Target;
        public readonly TypePath TargetPath = TargetPath;
        public readonly Utf8ConstantHandle Type = Type;
        public readonly ElementValuePairTable Elements = Elements;
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
        /// Copies this annotation to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref TypeAnnotationTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.TypeAnnotation(e => self.CopyTo(constantView, constantPool, ref e));
        }

        /// <summary>
        /// Copies this annotation to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        /// <exception cref="ByteCodeException"></exception>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref TypeAnnotationEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;

            switch (Target.Type)
            {
                case TypeAnnotationTargetType.ClassTypeParameter:
                    var _classTypeParameter = Target.AsTypeParameterTarget();
                    encoder.ClassTypeParameter(_classTypeParameter.ParameterIndex, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodTypeParameter:
                    var _methodTypeParameter = Target.AsTypeParameterTarget();
                    encoder.MethodTypeParameter(_methodTypeParameter.ParameterIndex, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.ClassExtends:
                    var superTypeTarget = Target.AsSuperTypeTarget();
                    encoder.ClassExtends(superTypeTarget.SuperTypeIndex, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.ClassTypeParameterBound:
                    var classTypeParameterBound = Target.AsTypeParameterBoundTarget();
                    encoder.ClassTypeParameterBound(classTypeParameterBound.ParameterIndex, classTypeParameterBound.BoundIndex, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodTypeParameterBound:
                    var methodTypeParameterBound = Target.AsTypeParameterBoundTarget();
                    encoder.MethodTypeParameterBound(methodTypeParameterBound.ParameterIndex, methodTypeParameterBound.BoundIndex, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.Field:
                    var field = Target.AsEmptyTarget();
                    encoder.Field(e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReturn:
                    var methodReturn = Target.AsEmptyTarget();
                    encoder.MethodReturn(e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReceiver:
                    var methodReceiver = Target.AsEmptyTarget();
                    encoder.MethodReceiver(e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodFormalParameter:
                    var methodFormalParameter = Target.AsFormalParameterTarget();
                    encoder.MethodFormalParameter(methodFormalParameter.ParameterIndex, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.Throws:
                    var throws = Target.AsThrowsTarget();
                    encoder.Throws(throws.ThrowsTypeIndex, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.LocalVar:
                    var localVar = Target.AsLocalVarTarget();
                    encoder.LocalVariable(e => localVar.CopyTo(constantView, constantPool, ref e), e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.ResourceVariable:
                    var resourceVariable = Target.AsLocalVarTarget();
                    encoder.ResourceVariable(e => resourceVariable.CopyTo(constantView, constantPool, ref e), e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.ExceptionParameter:
                    var catchTarget = Target.AsCatchTarget();
                    encoder.ExceptionParameter(catchTarget.ExceptionTableIndex, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.InstanceOf:
                    var instanceOf = Target.AsOffsetTarget();
                    encoder.InstanceOf(instanceOf.Offset, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.New:
                    var new_ = Target.AsOffsetTarget();
                    encoder.New(new_.Offset, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorReference:
                    var constructorReference = Target.AsOffsetTarget();
                    encoder.ConstructorReference(constructorReference.Offset, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReference:
                    var methodReference = Target.AsOffsetTarget();
                    encoder.MethodReference(methodReference.Offset, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.Cast:
                    var cast = Target.AsTypeArgumentTarget();
                    encoder.Cast(cast.Offset, cast.TypeArgumentIndex, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorInvocationTypeArgument:
                    var constructorInvocationTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorInvocationTypeArgument(constructorInvocationTypeArgument.Offset, constructorInvocationTypeArgument.TypeArgumentIndex, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodInvocationTypeArgument:
                    var methodInvocationTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.MethodInvocationTypeArgument(methodInvocationTypeArgument.Offset, methodInvocationTypeArgument.TypeArgumentIndex, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorReferenceTypeArgument:
                    var constructorReferenceTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorReferenceTypeArgument(constructorReferenceTypeArgument.Offset, constructorReferenceTypeArgument.TypeArgumentIndex, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReferenceTypeArgument:
                    var methodReferenceTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorReferenceTypeArgument(methodReferenceTypeArgument.Offset, methodReferenceTypeArgument.TypeArgumentIndex, e => self.TargetPath.CopyTo(constantView, constantPool, ref e), constantPool.Get(constantView.Get(self.Type)), e => self.Elements.CopyTo(constantView, constantPool, ref e));
                    break;
                default:
                    throw new ByteCodeException("Invalid type annotation target type.");
            }
        }

        /// <summary>
        /// Writes this data class to the encoder.
        /// </summary>
        /// <param name="encoder"></param>
        public readonly void WriteTo(ref TypeAnnotationTableEncoder encoder)
        {
            var self = this;
            encoder.TypeAnnotation(e => self.WriteTo(ref e));
        }

        /// <summary>
        /// Writes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void WriteTo(ref TypeAnnotationEncoder encoder)
        {
            var self = this;

            switch (Target.Type)
            {
                case TypeAnnotationTargetType.ClassTypeParameter:
                    var classTypeParameter = Target.AsTypeParameterTarget();
                    encoder.ClassTypeParameter(classTypeParameter.ParameterIndex, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.MethodTypeParameter:
                    var methodTypeParameter = Target.AsTypeParameterTarget();
                    encoder.MethodTypeParameter(methodTypeParameter.ParameterIndex, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.ClassExtends:
                    var superTypeTarget = Target.AsSuperTypeTarget();
                    encoder.ClassExtends(superTypeTarget.SuperTypeIndex, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.ClassTypeParameterBound:
                    var classTypeParameterBound = Target.AsTypeParameterBoundTarget();
                    encoder.ClassTypeParameterBound(classTypeParameterBound.ParameterIndex, classTypeParameterBound.BoundIndex, e => self.TargetPath.WriteTo(ref e), (self.Type), e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.MethodTypeParameterBound:
                    var methodTypeParameterBound = Target.AsTypeParameterBoundTarget();
                    encoder.MethodTypeParameterBound(methodTypeParameterBound.ParameterIndex, methodTypeParameterBound.BoundIndex, e => self.TargetPath.WriteTo(ref e), (self.Type), e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.Field:
                    var field = Target.AsEmptyTarget();
                    encoder.Field(e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.MethodReturn:
                    var methodReturn = Target.AsEmptyTarget();
                    encoder.MethodReturn(e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.MethodReceiver:
                    var methodReceiver = Target.AsEmptyTarget();
                    encoder.MethodReceiver(e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.MethodFormalParameter:
                    var methodFormalParameter = Target.AsFormalParameterTarget();
                    encoder.MethodFormalParameter(methodFormalParameter.ParameterIndex, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.Throws:
                    var throws = Target.AsThrowsTarget();
                    encoder.Throws(throws.ThrowsTypeIndex, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.LocalVar:
                    var localVar = Target.AsLocalVarTarget();
                    encoder.LocalVariable(e => localVar.WriteTo(ref e), e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.ResourceVariable:
                    var resourceVariable = Target.AsLocalVarTarget();
                    encoder.ResourceVariable(e => resourceVariable.WriteTo(ref e), e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.ExceptionParameter:
                    var catchTarget = Target.AsCatchTarget();
                    encoder.ExceptionParameter(catchTarget.ExceptionTableIndex, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.InstanceOf:
                    var instanceOf = Target.AsOffsetTarget();
                    encoder.InstanceOf(instanceOf.Offset, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.New:
                    var new_ = Target.AsOffsetTarget();
                    encoder.New(new_.Offset, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorReference:
                    var constructorReference = Target.AsOffsetTarget();
                    encoder.ConstructorReference(constructorReference.Offset, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.MethodReference:
                    var methodReference = Target.AsOffsetTarget();
                    encoder.MethodReference(methodReference.Offset, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.Cast:
                    var cast = Target.AsTypeArgumentTarget();
                    encoder.Cast(cast.Offset, cast.TypeArgumentIndex, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorInvocationTypeArgument:
                    var constructorInvocationTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorInvocationTypeArgument(constructorInvocationTypeArgument.Offset, constructorInvocationTypeArgument.TypeArgumentIndex, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.MethodInvocationTypeArgument:
                    var methodInvocationTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.MethodInvocationTypeArgument(methodInvocationTypeArgument.Offset, methodInvocationTypeArgument.TypeArgumentIndex, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorReferenceTypeArgument:
                    var constructorReferenceTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorReferenceTypeArgument(constructorReferenceTypeArgument.Offset, constructorReferenceTypeArgument.TypeArgumentIndex, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                case TypeAnnotationTargetType.MethodReferenceTypeArgument:
                    var methodReferenceTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorReferenceTypeArgument(methodReferenceTypeArgument.Offset, methodReferenceTypeArgument.TypeArgumentIndex, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo(ref e));
                    break;
                default:
                    throw new ByteCodeException("Invalid type annotation target type.");
            }
        }

    }

}
