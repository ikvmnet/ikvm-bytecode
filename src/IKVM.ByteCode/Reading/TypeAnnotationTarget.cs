using System;
using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public readonly record struct TypeAnnotationTarget(TypeAnnotationTargetType Type, ReadOnlySequence<byte> Data)
    {

        public static explicit operator TypeParameterTarget(TypeAnnotationTarget value) => value.AsTypeParameterTarget();

        public static explicit operator SuperTypeTarget(TypeAnnotationTarget value) => value.AsSuperTypeTarget();

        public static explicit operator TypeParameterBoundTarget(TypeAnnotationTarget value) => value.AsTypeParameterBoundTarget();

        public static explicit operator EmptyTarget(TypeAnnotationTarget value) => value.AsEmptyTarget();

        public static explicit operator FormalParameterTarget(TypeAnnotationTarget value) => value.AsFormalParameterTarget();

        public static explicit operator ThrowsTarget(TypeAnnotationTarget value) => value.AsThrowsTarget();

        public static explicit operator LocalVarTarget(TypeAnnotationTarget value) => value.AsLocalVarTarget();

        public static explicit operator CatchTarget(TypeAnnotationTarget value) => value.AsCatchTarget();

        public static explicit operator OffsetTarget(TypeAnnotationTarget value) => value.AsOffsetTarget();

        public static explicit operator TypeArgumentTarget(TypeAnnotationTarget value) => value.AsTypeArgumentTarget();

        /// <summary>
        /// Attempts to measure the size of the type annotation target.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U1;
            if (reader.TryReadU1(out byte type) == false)
                return false;

            if (TryMeasureValue(ref reader, (TypeAnnotationTargetType)type, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to measure the size of the target with the given tag.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="kind"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        static bool TryMeasureValue(ref ClassFormatReader reader, TypeAnnotationTargetType kind, ref int size) => kind switch
        {
            TypeAnnotationTargetType.ClassTypeParameter => TypeParameterTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.MethodTypeParameter => TypeParameterTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.ClassExtends => SuperTypeTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.ClassTypeParameterBound => TypeParameterBoundTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.MethodTypeParameterBound => TypeParameterBoundTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.Field => EmptyTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.MethodReturn => EmptyTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.MethodReceiver => EmptyTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.MethodFormalParameter => FormalParameterTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.Throws => ThrowsTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.LocalVar => LocalVarTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.ResourceVariable => LocalVarTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.ExceptionParameter => CatchTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.InstanceOf => OffsetTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.New => OffsetTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.ConstructorReference => OffsetTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.MethodReference => OffsetTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.Cast => TypeArgumentTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.ConstructorInvocationTypeArgument => TypeArgumentTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.MethodInvocationTypeArgument => TypeArgumentTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.ConstructorReferenceTypeArgument => TypeArgumentTarget.TryMeasure(ref reader, ref size),
            TypeAnnotationTargetType.MethodReferenceTypeArgument => TypeArgumentTarget.TryMeasure(ref reader, ref size),
            _ => throw new ByteCodeException($"Invalid target tag: '{(char)kind}'."),
        };

        /// <summary>
        /// Attempts to read the data for the annotation target.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool TryReadData(ref ClassFormatReader reader, out TypeAnnotationTarget data)
        {
            data = default;

            if (reader.TryReadU1(out byte kind) == false)
                return false;

            return (TypeAnnotationTargetType)kind switch
            {
                TypeAnnotationTargetType.ClassTypeParameter => TryReadTypeParameterTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.MethodTypeParameter => TryReadTypeParameterTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.ClassExtends => TryReadSuperTypeTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.ClassTypeParameterBound => TryReadTypeParameterBoundTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.MethodTypeParameterBound => TryReadTypeParameterBoundTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.Field => TryReadEmptyTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.MethodReturn => TryReadEmptyTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.MethodReceiver => TryReadEmptyTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.MethodFormalParameter => TryReadFormalParameterTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.Throws => TryReadThrowsTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.LocalVar => TryReadLocalVarTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.ResourceVariable => TryReadLocalVarTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.ExceptionParameter => TryReadCatchTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.InstanceOf => TryReadOffsetTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.New => TryReadOffsetTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.ConstructorReference => TryReadOffsetTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.MethodReference => TryReadOffsetTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.Cast => TryReadTypeArgumentTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.ConstructorInvocationTypeArgument => TryReadTypeArgumentTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.MethodInvocationTypeArgument => TryReadTypeArgumentTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.ConstructorReferenceTypeArgument => TryReadTypeArgumentTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                TypeAnnotationTargetType.MethodReferenceTypeArgument => TryReadTypeArgumentTargetData(ref reader, (TypeAnnotationTargetType)kind, out data),
                _ => false,
            };
        }

        static bool TryReadTypeParameterTargetData(ref ClassFormatReader reader, TypeAnnotationTargetType kind, out TypeAnnotationTarget data)
        {
            data = default;

            if (TypeParameterTarget.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new TypeAnnotationTarget(kind, _data);
            return true;
        }

        static bool TryReadSuperTypeTargetData(ref ClassFormatReader reader, TypeAnnotationTargetType kind, out TypeAnnotationTarget data)
        {
            data = default;

            if (SuperTypeTarget.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new TypeAnnotationTarget(kind, _data);
            return true;
        }

        static bool TryReadTypeParameterBoundTargetData(ref ClassFormatReader reader, TypeAnnotationTargetType kind, out TypeAnnotationTarget data)
        {
            data = default;

            if (TypeParameterBoundTarget.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new TypeAnnotationTarget(kind, _data);
            return true;
        }

        static bool TryReadEmptyTargetData(ref ClassFormatReader reader, TypeAnnotationTargetType kind, out TypeAnnotationTarget data)
        {
            data = default;

            if (EmptyTarget.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new TypeAnnotationTarget(kind, _data);
            return true;
        }

        static bool TryReadFormalParameterTargetData(ref ClassFormatReader reader, TypeAnnotationTargetType kind, out TypeAnnotationTarget data)
        {
            data = default;

            if (FormalParameterTarget.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new TypeAnnotationTarget(kind, _data);
            return true;
        }

        static bool TryReadThrowsTargetData(ref ClassFormatReader reader, TypeAnnotationTargetType kind, out TypeAnnotationTarget data)
        {
            data = default;

            if (ThrowsTarget.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new TypeAnnotationTarget(kind, _data);
            return true;
        }

        static bool TryReadLocalVarTargetData(ref ClassFormatReader reader, TypeAnnotationTargetType kind, out TypeAnnotationTarget data)
        {
            data = default;

            if (LocalVarTarget.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new TypeAnnotationTarget(kind, _data);
            return true;
        }

        static bool TryReadCatchTargetData(ref ClassFormatReader reader, TypeAnnotationTargetType kind, out TypeAnnotationTarget data)
        {
            data = default;

            if (CatchTarget.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new TypeAnnotationTarget(kind, _data);
            return true;
        }

        static bool TryReadOffsetTargetData(ref ClassFormatReader reader, TypeAnnotationTargetType kind, out TypeAnnotationTarget data)
        {
            data = default;

            if (OffsetTarget.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new TypeAnnotationTarget(kind, _data);
            return true;
        }

        static bool TryReadTypeArgumentTargetData(ref ClassFormatReader reader, TypeAnnotationTargetType kind, out TypeAnnotationTarget data)
        {
            data = default;

            if (TypeArgumentTarget.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new TypeAnnotationTarget(kind, _data);
            return true;
        }

        public readonly TypeAnnotationTargetType Type = Type;
        public readonly ReadOnlySequence<byte> Data = Data;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        public TypeParameterTarget AsTypeParameterTarget()
        {
            if (Type is not TypeAnnotationTargetType.ClassTypeParameter and not TypeAnnotationTargetType.MethodTypeParameter)
                throw new InvalidCastException($"Cannot cast TypeAnnotationTarget of type {Type} to TypeParameterTarget.");

            var reader = new ClassFormatReader(Data);
            if (TypeParameterTarget.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting target of kind {Type} to TypeParameterTarget.");

            return value;
        }

        public SuperTypeTarget AsSuperTypeTarget()
        {
            if (Type is not TypeAnnotationTargetType.ClassExtends)
                throw new InvalidCastException($"Cannot cast TypeAnnotationTarget of type {Type} to TypeParameterTarget.");

            var reader = new ClassFormatReader(Data);
            if (SuperTypeTarget.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting target of kind {Type} to TypeParameterTarget.");

            return value;
        }

        public TypeParameterBoundTarget AsTypeParameterBoundTarget()
        {
            if (Type is not TypeAnnotationTargetType.ClassTypeParameterBound and not TypeAnnotationTargetType.MethodTypeParameterBound)
                throw new InvalidCastException($"Cannot cast TypeAnnotationTarget of type {Type} to TypeParameterBoundTarget.");

            var reader = new ClassFormatReader(Data);
            if (TypeParameterBoundTarget.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting target of kind {Type} to TypeParameterBoundTarget.");

            return value;
        }

        public EmptyTarget AsEmptyTarget()
        {
            if (Type is not TypeAnnotationTargetType.Field and not TypeAnnotationTargetType.MethodReturn and not TypeAnnotationTargetType.MethodReceiver)
                throw new InvalidCastException($"Cannot cast TypeAnnotationTarget of type {Type} to EmptyTarget.");

            var reader = new ClassFormatReader(Data);
            if (EmptyTarget.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting target of kind {Type} to EmptyTarget.");

            return value;
        }

        public FormalParameterTarget AsFormalParameterTarget()
        {
            if (Type is not TypeAnnotationTargetType.MethodFormalParameter)
                throw new InvalidCastException($"Cannot cast TypeAnnotationTarget of type {Type} to FormalParameterTarget.");

            var reader = new ClassFormatReader(Data);
            if (FormalParameterTarget.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting target of kind {Type} to FormalParameterTarget.");

            return value;
        }

        public ThrowsTarget AsThrowsTarget()
        {
            if (Type is not TypeAnnotationTargetType.Throws)
                throw new InvalidCastException($"Cannot cast TypeAnnotationTarget of type {Type} to ThrowsTarget.");

            var reader = new ClassFormatReader(Data);
            if (ThrowsTarget.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting target of kind {Type} to ThrowsTarget.");

            return value;
        }

        public LocalVarTarget AsLocalVarTarget()
        {
            if (Type is not TypeAnnotationTargetType.LocalVar and not TypeAnnotationTargetType.ResourceVariable)
                throw new InvalidCastException($"Cannot cast TypeAnnotationTarget of type {Type} to LocalVarTarget.");

            var reader = new ClassFormatReader(Data);
            if (LocalVarTarget.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting target of kind {Type} to LocalVarTarget.");

            return value;
        }

        public CatchTarget AsCatchTarget()
        {
            if (Type is not TypeAnnotationTargetType.ExceptionParameter)
                throw new InvalidCastException($"Cannot cast TypeAnnotationTarget of type {Type} to CatchTarget.");

            var reader = new ClassFormatReader(Data);
            if (CatchTarget.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting target of kind {Type} to CatchTarget.");

            return value;
        }

        public OffsetTarget AsOffsetTarget()
        {
            if (Type is not TypeAnnotationTargetType.InstanceOf and not TypeAnnotationTargetType.New and not TypeAnnotationTargetType.ConstructorReference and not TypeAnnotationTargetType.MethodReference)
                throw new InvalidCastException($"Cannot cast TypeAnnotationTarget of type {Type} to OffsetTarget.");

            var reader = new ClassFormatReader(Data);
            if (OffsetTarget.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting target of kind {Type} to OffsetTarget.");

            return value;
        }

        public TypeArgumentTarget AsTypeArgumentTarget()
        {
            if (Type is not TypeAnnotationTargetType.Cast and not TypeAnnotationTargetType.ConstructorInvocationTypeArgument and not TypeAnnotationTargetType.MethodInvocationTypeArgument and not TypeAnnotationTargetType.ConstructorReferenceTypeArgument and not TypeAnnotationTargetType.MethodReferenceTypeArgument)
                throw new InvalidCastException($"Cannot cast TypeAnnotationTarget of type {Type} to TypeArgumentTarget.");

            var reader = new ClassFormatReader(Data);
            if (TypeArgumentTarget.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting target of kind {Type} to TypeArgumentTarget.");

            return value;
        }

    }

}
