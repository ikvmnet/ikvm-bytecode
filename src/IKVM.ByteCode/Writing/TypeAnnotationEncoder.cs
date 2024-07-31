using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes a 'type_annotation' structure.
    /// </summary>
    public struct TypeAnnotationEncoder
    {

        readonly BlobBuilder _builder;
        byte _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public TypeAnnotationEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        /// <summary>
        /// Encodes the footer of the structure.
        /// </summary>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        void Footer(Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            targetPath(new TypePathEncoder(_builder));
            var w2 = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w2.TryWriteU2(type.Index);
            elementValues(new ElementValuePairTableEncoder(_builder));
            _count++;
        }

        /// <summary>
        /// Implements the logic for all methods that write a 'type_parameter_target' structure.
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="typeParameterIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        void TypeParameterTarget(TypeAnnotationTargetType targetType, byte typeParameterIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            if (_count > 0)
                throw new InvalidOperationException("Encoder can only encode a single type annotation.");

            var w1 = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U1).GetBytes());
            w1.TryWriteU1((byte)targetType);
            w1.TryWriteU1(typeParameterIndex);
            Footer(targetPath, type, elementValues);
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
            TypeParameterTarget(TypeAnnotationTargetType.ClassTypeParameter, typeParameterIndex, targetPath, type, elementValues);
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
            TypeParameterTarget(TypeAnnotationTargetType.MethodTypeParameter, typeParameterIndex, targetPath, type, elementValues);
        }

        /// <summary>
        /// Implements the logic for all methods that write a 'supertype_target' structure.
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="superTypeIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        void SuperTypeTarget(TypeAnnotationTargetType targetType, byte superTypeIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            if (_count > 0)
                throw new InvalidOperationException("Encoder can only encode a single type annotation.");

            var w1 = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w1.TryWriteU1((byte)targetType);
            w1.TryWriteU2(superTypeIndex);
            Footer(targetPath, type, elementValues);
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
            SuperTypeTarget(TypeAnnotationTargetType.ClassExtends, superTypeIndex, targetPath, type, elementValues);
        }

        /// <summary>
        /// Implements the logic for all methods that write a 'type_parameter_bound_target' structure.
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="superTypeIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        void TypeParameterBoundTarget(TypeAnnotationTargetType targetType, byte typeParameterIndex, byte boundIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            if (_count > 0)
                throw new InvalidOperationException("Encoder can only encode a single type annotation.");

            var w1 = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U1 + ClassFormatWriter.U1).GetBytes());
            w1.TryWriteU1((byte)targetType);
            w1.TryWriteU1(typeParameterIndex);
            w1.TryWriteU1(boundIndex);
            Footer(targetPath, type, elementValues);
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
            TypeParameterBoundTarget(TypeAnnotationTargetType.ClassTypeParameterBound, typeParameterIndex, boundIndex, targetPath, type, elementValues);
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
            TypeParameterBoundTarget(TypeAnnotationTargetType.MethodTypeParameterBound, typeParameterIndex, boundIndex, targetPath, type, elementValues);
        }

        /// <summary>
        /// Implements the logic for all methods that write a 'type_parameter_bound_target' structure.
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        void EmptyTarget(TypeAnnotationTargetType targetType, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            if (_count > 0)
                throw new InvalidOperationException("Encoder can only encode a single type annotation.");

            var w1 = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w1.TryWriteU1((byte)targetType);
            Footer(targetPath, type, elementValues);
        }

        /// <summary>
        /// The sort of type references that target the type of a field.
        /// </summary>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void Field(Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            EmptyTarget(TypeAnnotationTargetType.Field, targetPath, type, elementValues);
        }

        /// <summary>
        /// The sort of type references that target the return type of a method.
        /// </summary>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void MethodReturn(Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            EmptyTarget(TypeAnnotationTargetType.MethodReturn, targetPath, type, elementValues);
        }

        /// <summary>
        /// The sort of type references that target the receiver type of a method.
        /// </summary>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void MethodReceiver(Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            EmptyTarget(TypeAnnotationTargetType.MethodReceiver, targetPath, type, elementValues);
        }

        /// <summary>
        /// Implements the logic for all methods that write a 'formal_parameter_target' structure.
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        void FormalParameterTarget(TypeAnnotationTargetType targetType, byte formalParameterIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            if (_count > 0)
                throw new InvalidOperationException("Encoder can only encode a single type annotation.");

            var w1 = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U1).GetBytes());
            w1.TryWriteU1((byte)targetType);
            w1.TryWriteU1(formalParameterIndex);
            Footer(targetPath, type, elementValues);
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
            FormalParameterTarget(TypeAnnotationTargetType.MethodFormalParameter, formalParameterIndex, targetPath, type, elementValues);
        }

        /// <summary>
        /// Implements the logic for all methods that write a 'throws_target' structure.
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        void ThrowsTarget(TypeAnnotationTargetType targetType, ushort throwsTypeIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            if (_count > 0)
                throw new InvalidOperationException("Encoder can only encode a single type annotation.");

            var w1 = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w1.TryWriteU1((byte)targetType);
            w1.TryWriteU2(throwsTypeIndex);
            Footer(targetPath, type, elementValues);
        }

        /// <summary>
        /// The sort of type references that target the type of a formal parameter of a method.
        /// </summary>
        /// <param name="throwsTypeIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void MethodFormalParameter(ushort throwsTypeIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            ThrowsTarget(TypeAnnotationTargetType.Throws, throwsTypeIndex, targetPath, type, elementValues);
        }

        /// <summary>
        /// Implements the logic for all methods that write a 'throws_target' structure.
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="localVars"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        void LocalVarTarget(TypeAnnotationTargetType targetType, Action<LocalVariableTargetTableEncoder> localVars, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            if (_count > 0)
                throw new InvalidOperationException("Encoder can only encode a single type annotation.");

            var w1 = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w1.TryWriteU1((byte)targetType);
            localVars(new LocalVariableTargetTableEncoder(_builder));
            Footer(targetPath, type, elementValues);
        }

        /// <summary>
        /// The sort of type references that target the type of a local variable in a method.
        /// </summary>
        /// <param name="localVars"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void LocalVarTarget(Action<LocalVariableTargetTableEncoder> localVars, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            LocalVarTarget(TypeAnnotationTargetType.LocalVariable, localVars, targetPath, type, elementValues);
        }

        /// <summary>
        /// The sort of type references that target the type of a resource variable in a method.
        /// </summary>
        /// <param name="localVars"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        public void ResourceVariable(Action<LocalVariableTargetTableEncoder> localVars, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            LocalVarTarget(TypeAnnotationTargetType.ResourceVariable, localVars, targetPath, type, elementValues);
        }

        /// <summary>
        /// Implements the logic for all methods that write a 'catch_target' structure.
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="exceptionTableIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        void CatchTarget(TypeAnnotationTargetType targetType, ushort exceptionTableIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            if (_count > 0)
                throw new InvalidOperationException("Encoder can only encode a single type annotation.");

            var w1 = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w1.TryWriteU1((byte)targetType);
            w1.TryWriteU2(exceptionTableIndex);
            Footer(targetPath, type, elementValues);
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
            CatchTarget(TypeAnnotationTargetType.ExceptionParameter, exceptionTableIndex, targetPath, type, elementValues);
        }

        /// <summary>
        /// Implements the logic for all methods that write a 'offset_target' structure.
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="offset"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        void OffsetTarget(TypeAnnotationTargetType targetType, ushort offset, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            if (_count > 0)
                throw new InvalidOperationException("Encoder can only encode a single type annotation.");

            var w1 = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w1.TryWriteU1((byte)targetType);
            w1.TryWriteU2(offset);
            Footer(targetPath, type, elementValues);
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
            OffsetTarget(TypeAnnotationTargetType.InstanceOf, offset, targetPath, type, elementValues);
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
            OffsetTarget(TypeAnnotationTargetType.New, offset, targetPath, type, elementValues);
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
            OffsetTarget(TypeAnnotationTargetType.ConstructorReference, offset, targetPath, type, elementValues);
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
            OffsetTarget(TypeAnnotationTargetType.MethodReference, offset, targetPath, type, elementValues);
        }

        /// <summary>
        /// Implements the logic for all methods that write a 'type_argument_target' structure.
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="offset"></param>
        /// <param name="typeArgumentIndex"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="elementValues"></param>
        void TypeArgumentTarget(TypeAnnotationTargetType targetType, ushort offset, byte typeArgumentIndex, Action<TypePathEncoder> targetPath, Utf8ConstantHandle type, Action<ElementValuePairTableEncoder> elementValues)
        {
            if (_count > 0)
                throw new InvalidOperationException("Encoder can only encode a single type annotation.");

            var w1 = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2 + ClassFormatWriter.U1).GetBytes());
            w1.TryWriteU1((byte)targetType);
            w1.TryWriteU2(offset);
            w1.TryWriteU1(typeArgumentIndex);
            Footer(targetPath, type, elementValues);
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
            TypeArgumentTarget(TypeAnnotationTargetType.Cast, offset, typeArgumentIndex, targetPath, type, elementValues);
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
            TypeArgumentTarget(TypeAnnotationTargetType.ConstructorInvocationTypeArgument, offset, typeArgumentIndex, targetPath, type, elementValues);
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
            TypeArgumentTarget(TypeAnnotationTargetType.MethodInvocationTypeArgument, offset, typeArgumentIndex, targetPath, type, elementValues);
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
            TypeArgumentTarget(TypeAnnotationTargetType.ConstructorReferenceTypeArgument, offset, typeArgumentIndex, targetPath, type, elementValues);
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
            TypeArgumentTarget(TypeAnnotationTargetType.MethodReferenceTypeArgument, offset, typeArgumentIndex, targetPath, type, elementValues);
        }

    }

}
