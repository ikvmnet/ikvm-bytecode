using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct TypeAnnotation(TypeAnnotationTarget Target, TypePath TargetPath, Utf8ConstantHandle Type, ElementValuePairTable Elements)
    {

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

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref TypeAnnotationTableEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            var self = this;
            encoder.TypeAnnotation(e => self.EncodeTo(map, ref e));
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void EncodeTo<TConstantHandleMap>(TConstantHandleMap map, ref TypeAnnotationEncoder encoder)
            where TConstantHandleMap : IConstantHandleMap
        {
            var self = this;

            switch (Target.Type)
            {
                case TypeAnnotationTargetType.ClassTypeParameter:
                    var _classTypeParameter = Target.AsTypeParameterTarget();
                    encoder.ClassTypeParameter(_classTypeParameter.ParameterIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodTypeParameter:
                    var _methodTypeParameter = Target.AsTypeParameterTarget();
                    encoder.MethodTypeParameter(_methodTypeParameter.ParameterIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.ClassExtends:
                    var _superTypeTarget = Target.AsSuperTypeTarget();
                    encoder.ClassExtends(_superTypeTarget.SuperTypeIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.ClassTypeParameterBound:
                    var _classTypeParameterBound = Target.AsTypeParameterBoundTarget();
                    encoder.ClassTypeParameterBound(_classTypeParameterBound.ParameterIndex, _classTypeParameterBound.BoundIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodTypeParameterBound:
                    var _methodTypeParameterBound = Target.AsTypeParameterBoundTarget();
                    encoder.MethodTypeParameterBound(_methodTypeParameterBound.ParameterIndex, _methodTypeParameterBound.BoundIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.Field:
                    var _field = Target.AsEmptyTarget();
                    encoder.Field(e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReturn:
                    var _methodReturn = Target.AsEmptyTarget();
                    encoder.MethodReturn(e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReceiver:
                    var _methodReceiver = Target.AsEmptyTarget();
                    encoder.MethodReceiver(e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodFormalParameter:
                    var _methodFormalParameter = Target.AsFormalParameterTarget();
                    encoder.MethodFormalParameter(_methodFormalParameter.ParameterIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.Throws:
                    var _throws = Target.AsThrowsTarget();
                    encoder.Throws(_throws.ThrowsTypeIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.LocalVar:
                    var _localVar = Target.AsLocalVarTarget();
                    encoder.LocalVariable(e => _localVar.EncodeTo(map, ref e), e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.ResourceVariable:
                    var _resourceVariable = Target.AsLocalVarTarget();
                    encoder.ResourceVariable(e => _resourceVariable.EncodeTo(map, ref e), e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.ExceptionParameter:
                    var _catchTarget = Target.AsCatchTarget();
                    encoder.ExceptionParameter(_catchTarget.ExceptionTableIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.InstanceOf:
                    var _instanceOf = Target.AsOffsetTarget();
                    encoder.InstanceOf(_instanceOf.Offset, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.New:
                    var _new = Target.AsOffsetTarget();
                    encoder.New(_new.Offset, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorReference:
                    var _constructorReference = Target.AsOffsetTarget();
                    encoder.ConstructorReference(_constructorReference.Offset, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReference:
                    var _methodReference = Target.AsOffsetTarget();
                    encoder.MethodReference(_methodReference.Offset, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.Cast:
                    var _cast = Target.AsTypeArgumentTarget();
                    encoder.Cast(_cast.Offset, _cast.TypeArgumentIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorInvocationTypeArgument:
                    var _constructorInvocationTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorInvocationTypeArgument(_constructorInvocationTypeArgument.Offset, _constructorInvocationTypeArgument.TypeArgumentIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodInvocationTypeArgument:
                    var _methodInvocationTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.MethodInvocationTypeArgument(_methodInvocationTypeArgument.Offset, _methodInvocationTypeArgument.TypeArgumentIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorReferenceTypeArgument:
                    var _constructorReferenceTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorReferenceTypeArgument(_constructorReferenceTypeArgument.Offset, _constructorReferenceTypeArgument.TypeArgumentIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReferenceTypeArgument:
                    var _methodReferenceTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorReferenceTypeArgument(_methodReferenceTypeArgument.Offset, _methodReferenceTypeArgument.TypeArgumentIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                default:
                    throw new ByteCodeException("Invalid type annotation target type.");
            }
        }

    }

}
