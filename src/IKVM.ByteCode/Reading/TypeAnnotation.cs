﻿using IKVM.ByteCode.Writing;

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
                    var superTypeTarget = Target.AsSuperTypeTarget();
                    encoder.ClassExtends(superTypeTarget.SuperTypeIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.ClassTypeParameterBound:
                    var classTypeParameterBound = Target.AsTypeParameterBoundTarget();
                    encoder.ClassTypeParameterBound(classTypeParameterBound.ParameterIndex, classTypeParameterBound.BoundIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodTypeParameterBound:
                    var methodTypeParameterBound = Target.AsTypeParameterBoundTarget();
                    encoder.MethodTypeParameterBound(methodTypeParameterBound.ParameterIndex, methodTypeParameterBound.BoundIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.Field:
                    var field = Target.AsEmptyTarget();
                    encoder.Field(e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReturn:
                    var methodReturn = Target.AsEmptyTarget();
                    encoder.MethodReturn(e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReceiver:
                    var methodReceiver = Target.AsEmptyTarget();
                    encoder.MethodReceiver(e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodFormalParameter:
                    var methodFormalParameter = Target.AsFormalParameterTarget();
                    encoder.MethodFormalParameter(methodFormalParameter.ParameterIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.Throws:
                    var throws = Target.AsThrowsTarget();
                    encoder.Throws(throws.ThrowsTypeIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.LocalVar:
                    var localVar = Target.AsLocalVarTarget();
                    encoder.LocalVariable(e => localVar.EncodeTo(map, ref e), e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.ResourceVariable:
                    var resourceVariable = Target.AsLocalVarTarget();
                    encoder.ResourceVariable(e => resourceVariable.EncodeTo(map, ref e), e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.ExceptionParameter:
                    var catchTarget = Target.AsCatchTarget();
                    encoder.ExceptionParameter(catchTarget.ExceptionTableIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.InstanceOf:
                    var instanceOf = Target.AsOffsetTarget();
                    encoder.InstanceOf(instanceOf.Offset, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.New:
                    var new_ = Target.AsOffsetTarget();
                    encoder.New(new_.Offset, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorReference:
                    var constructorReference = Target.AsOffsetTarget();
                    encoder.ConstructorReference(constructorReference.Offset, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReference:
                    var methodReference = Target.AsOffsetTarget();
                    encoder.MethodReference(methodReference.Offset, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.Cast:
                    var cast = Target.AsTypeArgumentTarget();
                    encoder.Cast(cast.Offset, cast.TypeArgumentIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorInvocationTypeArgument:
                    var constructorInvocationTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorInvocationTypeArgument(constructorInvocationTypeArgument.Offset, constructorInvocationTypeArgument.TypeArgumentIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodInvocationTypeArgument:
                    var methodInvocationTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.MethodInvocationTypeArgument(methodInvocationTypeArgument.Offset, methodInvocationTypeArgument.TypeArgumentIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorReferenceTypeArgument:
                    var constructorReferenceTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorReferenceTypeArgument(constructorReferenceTypeArgument.Offset, constructorReferenceTypeArgument.TypeArgumentIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReferenceTypeArgument:
                    var methodReferenceTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorReferenceTypeArgument(methodReferenceTypeArgument.Offset, methodReferenceTypeArgument.TypeArgumentIndex, e => self.TargetPath.EncodeTo(map, ref e), map.Map(self.Type), e => self.Elements.EncodeTo(map, ref e));
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
                    encoder.MethodReceiver(e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo( ref e));
                    break;
                case TypeAnnotationTargetType.MethodFormalParameter:
                    var methodFormalParameter = Target.AsFormalParameterTarget();
                    encoder.MethodFormalParameter(methodFormalParameter.ParameterIndex, e => self.TargetPath.WriteTo( ref e), self.Type, e => self.Elements.WriteTo(ref e));
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
                    encoder.MethodReference(methodReference.Offset, e => self.TargetPath.WriteTo(ref e), self.Type, e => self.Elements.WriteTo( ref e));
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
