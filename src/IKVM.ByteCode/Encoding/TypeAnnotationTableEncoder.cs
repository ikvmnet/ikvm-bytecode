using System;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Encoding
{

    /// <summary>
    /// Encodes a table of 'type_annotation' structures.
    /// </summary>
    public struct TypeAnnotationTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public TypeAnnotationTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds an annotation.
        /// </summary>
        /// <param name="annotation"></param>
        public TypeAnnotationTableEncoder TypeAnnotation(Action<TypeAnnotationEncoder> annotation)
        {
            if (annotation is null)
                throw new ArgumentNullException(nameof(annotation));

            annotation(new TypeAnnotationEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

        /// <summary>
        /// The sort of type references that target a type parameter of a generic class.
        /// </summary>
        /// <param name="typeParameterIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void ClassTypeParameter(byte typeParameterIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.ClassTypeParameter(typeParameterIndex, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target a type parameter of a generic method.
        /// </summary>
        /// <param name="typeParameterIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void MethodTypeParameter(byte typeParameterIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.MethodTypeParameter(typeParameterIndex, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target the super class of a class or one of the interfaces it
        /// implements.
        /// </summary>
        /// <param name="superTypeIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void ClassExtends(byte superTypeIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.ClassExtends(superTypeIndex, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target a bound of a type parameter of a generic class.
        /// </summary>
        /// <param name="typeParameterIndex"></param>
        /// <param name="boundIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void ClassTypeParameterBound(byte typeParameterIndex, byte boundIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.ClassTypeParameterBound(typeParameterIndex, boundIndex, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target a bound of a type parameter of a generic method.
        /// </summary>
        /// <param name="typeParameterIndex"></param>
        /// <param name="boundIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void MethodTypeParameterBound(byte typeParameterIndex, byte boundIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.MethodTypeParameterBound(typeParameterIndex, boundIndex, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target the type of a field.
        /// </summary>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void Field(Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.Field(targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target the return type of a method.
        /// </summary>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void MethodReturn(Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.MethodReturn(targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target the receiver type of a method.
        /// </summary>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void MethodReceiver(Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.MethodReceiver(targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target the type of a formal parameter of a method.
        /// </summary>
        /// <param name="formalParameterIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void MethodFormalParameter(byte formalParameterIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.MethodFormalParameter(formalParameterIndex, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target the type of a formal parameter of a method.
        /// </summary>
        /// <param name="throwsTypeIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void Throws(ushort throwsTypeIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.Throws(throwsTypeIndex, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target the type of a local variable in a method.
        /// </summary>
        /// <param name="localVars"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void LocalVarTarget(Action<LocalVarTargetTableEncoder> localVars, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.LocalVariable(localVars, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target the type of a resource variable in a method.
        /// </summary>
        /// <param name="localVars"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void ResourceVariable(Action<LocalVarTargetTableEncoder> localVars, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.ResourceVariable(localVars, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target the type of the exception of a 'catch' clause in a
        /// method.
        /// </summary>
        /// <param name="exceptionTableIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void ExceptionParameter(ushort exceptionTableIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.ExceptionParameter(exceptionTableIndex, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target the type declared in an 'instanceof' instruction.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void InstanceOf(ushort offset, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.InstanceOf(offset, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target the type of the object created by a 'new' instruction.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void New(ushort offset, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.New(offset, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target the receiver type of a constructor reference.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void ConstructorReference(ushort offset, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.ConstructorReference(offset, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target the receiver type of a method reference.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void MethodReference(ushort offset, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.MethodReference(offset, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target the type declared in an explicit or implicit cast
        /// instruction.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="typeArgumentIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void Cast(ushort offset, byte typeArgumentIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.Cast(offset, typeArgumentIndex, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target a type parameter of a generic constructor in a
        /// constructor call.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="typeArgumentIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void ConstructorInvocationTypeArgument(ushort offset, byte typeArgumentIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.ConstructorInvocationTypeArgument(offset, typeArgumentIndex, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target a type parameter of a generic method in a method call.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="typeArgumentIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void MethodInvocationTypeArgument(ushort offset, byte typeArgumentIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.MethodInvocationTypeArgument(offset, typeArgumentIndex, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target a type parameter of a generic constructor in a
        /// constructor reference.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="typeArgumentIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void ConstructorReferenceTypeArgument(ushort offset, byte typeArgumentIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.ConstructorReferenceTypeArgument(offset, typeArgumentIndex, targetPath, type, elementValues));
        }

        /// <summary>
        /// The sort of type references that target a type parameter of a generic method in a method
        /// reference.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="typeArgumentIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void MethodReferenceTypeArgument(ushort offset, byte typeArgumentIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            TypeAnnotation(encoder => encoder.MethodReferenceTypeArgument(offset, typeArgumentIndex, targetPath, type, elementValues));
        }

    }

}
