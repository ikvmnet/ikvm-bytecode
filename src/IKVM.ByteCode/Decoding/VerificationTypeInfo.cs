using System;
using System.Buffers;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct VerificationTypeInfo(VerificationTypeInfoKind Kind, ReadOnlySequence<byte> Data)
    {

        public static explicit operator TopVariableInfo(VerificationTypeInfo value) => value.AsTop();

        public static explicit operator IntegerVariableInfo(VerificationTypeInfo value) => value.AsInteger();

        public static explicit operator FloatVariableInfo(VerificationTypeInfo value) => value.AsFloat();

        public static explicit operator DoubleVariableInfo(VerificationTypeInfo value) => value.AsDouble();

        public static explicit operator LongVariableInfo(VerificationTypeInfo value) => value.AsLong();

        public static explicit operator NullVariableInfo(VerificationTypeInfo value) => value.AsNull();

        public static explicit operator UninitializedThisVariableInfo(VerificationTypeInfo value) => value.AsUninitializedThis();

        public static explicit operator ObjectVariableInfo(VerificationTypeInfo value) => value.AsObject();

        public static explicit operator UninitializedVariableInfo(VerificationTypeInfo value) => value.AsUninitialized();

        /// <summary>
        /// Attempts to measure the size of the verification info.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U1;
            if (reader.TryReadU1(out byte kind) == false)
                return false;

            if (TryMeasureData(ref reader, (VerificationTypeInfoKind)kind, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to measure the size of the stack map frame value with the given type.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="kind"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        static bool TryMeasureData(ref ClassFormatReader reader, VerificationTypeInfoKind kind, ref int size)
        {
            return kind switch
            {
                VerificationTypeInfoKind.Top => TopVariableInfo.TryMeasure(ref reader, ref size),
                VerificationTypeInfoKind.Integer => IntegerVariableInfo.TryMeasure(ref reader, ref size),
                VerificationTypeInfoKind.Float => FloatVariableInfo.TryMeasure(ref reader, ref size),
                VerificationTypeInfoKind.Double => DoubleVariableInfo.TryMeasure(ref reader, ref size),
                VerificationTypeInfoKind.Long => LongVariableInfo.TryMeasure(ref reader, ref size),
                VerificationTypeInfoKind.Null => NullVariableInfo.TryMeasure(ref reader, ref size),
                VerificationTypeInfoKind.UninitializedThis => UninitializedThisVariableInfo.TryMeasure(ref reader, ref size),
                VerificationTypeInfoKind.Object => ObjectVariableInfo.TryMeasure(ref reader, ref size),
                VerificationTypeInfoKind.Uninitialized => UninitializedVariableInfo.TryMeasure(ref reader, ref size),
                _ => throw new ByteCodeException($"Invalid verification info tag: '{kind}'."),
            };
        }

        public static bool TryRead(ref ClassFormatReader reader, out VerificationTypeInfo typeInfo)
        {
            typeInfo = default;

            if (reader.TryReadU1(out byte kind) == false)
                return false;

            return (VerificationTypeInfoKind)kind switch
            {
                VerificationTypeInfoKind.Top => TryReadTopVariableInfoData(ref reader, (VerificationTypeInfoKind)kind, out typeInfo),
                VerificationTypeInfoKind.Integer => TryReadIntegerVariableInfoData(ref reader, (VerificationTypeInfoKind)kind, out typeInfo),
                VerificationTypeInfoKind.Float => TryReadFloatVariableInfoData(ref reader, (VerificationTypeInfoKind)kind, out typeInfo),
                VerificationTypeInfoKind.Double => TryReadDoubleVariableInfoData(ref reader, (VerificationTypeInfoKind)kind, out typeInfo),
                VerificationTypeInfoKind.Long => TryReadLongVariableInfoData(ref reader, (VerificationTypeInfoKind)kind, out typeInfo),
                VerificationTypeInfoKind.Null => TryReadNullVariableInfoData(ref reader, (VerificationTypeInfoKind)kind, out typeInfo),
                VerificationTypeInfoKind.UninitializedThis => TryReadUninitializedThisVariableInfoData(ref reader, (VerificationTypeInfoKind)kind, out typeInfo),
                VerificationTypeInfoKind.Object => TryReadObjectVariableInfoData(ref reader, (VerificationTypeInfoKind)kind, out typeInfo),
                VerificationTypeInfoKind.Uninitialized => TryReadUninitializedVariableInfoData(ref reader, (VerificationTypeInfoKind)kind, out typeInfo),
                _ => throw new ByteCodeException($"Invalid verification info tag: '{kind}'."),
            };
        }

        static bool TryReadTopVariableInfoData(ref ClassFormatReader reader, VerificationTypeInfoKind kind, out VerificationTypeInfo data)
        {
            data = default;

            if (TopVariableInfo.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new VerificationTypeInfo(kind, _data);
            return true;
        }

        static bool TryReadIntegerVariableInfoData(ref ClassFormatReader reader, VerificationTypeInfoKind kind, out VerificationTypeInfo data)
        {
            data = default;

            if (IntegerVariableInfo.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new VerificationTypeInfo(kind, _data);
            return true;
        }

        static bool TryReadFloatVariableInfoData(ref ClassFormatReader reader, VerificationTypeInfoKind kind, out VerificationTypeInfo data)
        {
            data = default;

            if (FloatVariableInfo.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new VerificationTypeInfo(kind, _data);
            return true;
        }

        static bool TryReadDoubleVariableInfoData(ref ClassFormatReader reader, VerificationTypeInfoKind kind, out VerificationTypeInfo data)
        {
            data = default;

            if (DoubleVariableInfo.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new VerificationTypeInfo(kind, _data);
            return true;
        }

        static bool TryReadLongVariableInfoData(ref ClassFormatReader reader, VerificationTypeInfoKind kind, out VerificationTypeInfo data)
        {
            data = default;

            if (LongVariableInfo.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new VerificationTypeInfo(kind, _data);
            return true;
        }

        static bool TryReadNullVariableInfoData(ref ClassFormatReader reader, VerificationTypeInfoKind kind, out VerificationTypeInfo data)
        {
            data = default;

            if (NullVariableInfo.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new VerificationTypeInfo(kind, _data);
            return true;
        }

        static bool TryReadUninitializedThisVariableInfoData(ref ClassFormatReader reader, VerificationTypeInfoKind kind, out VerificationTypeInfo data)
        {
            data = default;

            if (UninitializedThisVariableInfo.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new VerificationTypeInfo(kind, _data);
            return true;
        }

        static bool TryReadObjectVariableInfoData(ref ClassFormatReader reader, VerificationTypeInfoKind kind, out VerificationTypeInfo data)
        {
            data = default;

            if (ObjectVariableInfo.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new VerificationTypeInfo(kind, _data);
            return true;
        }

        static bool TryReadUninitializedVariableInfoData(ref ClassFormatReader reader, VerificationTypeInfoKind kind, out VerificationTypeInfo data)
        {
            data = default;

            if (UninitializedVariableInfo.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new VerificationTypeInfo(kind, _data);
            return true;
        }

        public readonly VerificationTypeInfoKind Kind = Kind;
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

        public readonly TopVariableInfo AsTop()
        {
            if (Kind != VerificationTypeInfoKind.Top)
                throw new InvalidCastException($"Cannot cast VerificationTypeInfo of kind {Kind} to Top.");

            var reader = new ClassFormatReader(Data);
            if (TopVariableInfo.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting VerificationTypeInfo of kind {Kind} to Top.");

            return value;
        }

        public readonly IntegerVariableInfo AsInteger()
        {
            if (Kind != VerificationTypeInfoKind.Integer)
                throw new InvalidCastException($"Cannot cast VerificationTypeInfo of kind {Kind} to Integer.");

            var reader = new ClassFormatReader(Data);
            if (IntegerVariableInfo.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting VerificationTypeInfo of kind {Kind} to Integer.");

            return value;
        }

        public readonly FloatVariableInfo AsFloat()
        {
            if (Kind != VerificationTypeInfoKind.Float)
                throw new InvalidCastException($"Cannot cast VerificationTypeInfo of kind {Kind} to Float.");

            var reader = new ClassFormatReader(Data);
            if (FloatVariableInfo.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting VerificationTypeInfo of kind {Kind} to Float.");

            return value;
        }

        public readonly DoubleVariableInfo AsDouble()
        {
            if (Kind != VerificationTypeInfoKind.Double)
                throw new InvalidCastException($"Cannot cast VerificationTypeInfo of kind {Kind} to Double.");

            var reader = new ClassFormatReader(Data);
            if (DoubleVariableInfo.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting VerificationTypeInfo of kind {Kind} to Double.");

            return value;
        }

        public readonly LongVariableInfo AsLong()
        {
            if (Kind != VerificationTypeInfoKind.Long)
                throw new InvalidCastException($"Cannot cast VerificationTypeInfo of kind {Kind} to Long.");

            var reader = new ClassFormatReader(Data);
            if (LongVariableInfo.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting VerificationTypeInfo of kind {Kind} to Long.");

            return value;
        }

        public readonly NullVariableInfo AsNull()
        {
            if (Kind != VerificationTypeInfoKind.Null)
                throw new InvalidCastException($"Cannot cast VerificationTypeInfo of kind {Kind} to Null.");

            var reader = new ClassFormatReader(Data);
            if (NullVariableInfo.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting VerificationTypeInfo of kind {Kind} to Null.");

            return value;
        }

        public readonly UninitializedThisVariableInfo AsUninitializedThis()
        {
            if (Kind != VerificationTypeInfoKind.UninitializedThis)
                throw new InvalidCastException($"Cannot cast VerificationTypeInfo of kind {Kind} to UninitializedThis.");

            var reader = new ClassFormatReader(Data);
            if (UninitializedThisVariableInfo.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting VerificationTypeInfo of kind {Kind} to UninitializedThis.");

            return value;
        }

        public readonly ObjectVariableInfo AsObject()
        {
            if (Kind != VerificationTypeInfoKind.Object)
                throw new InvalidCastException($"Cannot cast VerificationTypeInfo of kind {Kind} to Object.");

            var reader = new ClassFormatReader(Data);
            if (ObjectVariableInfo.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting VerificationTypeInfo of kind {Kind} to Object.");

            return value;
        }

        public readonly UninitializedVariableInfo AsUninitialized()
        {
            if (Kind != VerificationTypeInfoKind.Uninitialized)
                throw new InvalidCastException($"Cannot cast VerificationTypeInfo of kind {Kind} to Uninitialized.");

            var reader = new ClassFormatReader(Data);
            if (UninitializedVariableInfo.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting VerificationTypeInfo of kind {Kind} to Uninitialized.");

            return value;
        }

        /// <summary>
        /// Copies this info to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref VerificationTypeInfoEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            switch (Kind)
            {
                case VerificationTypeInfoKind.Top:
                    encoder.Top();
                    break;
                case VerificationTypeInfoKind.Integer:
                    encoder.Integer();
                    break;
                case VerificationTypeInfoKind.Float:
                    encoder.Float();
                    break;
                case VerificationTypeInfoKind.Double:
                    encoder.Double();
                    break;
                case VerificationTypeInfoKind.Long:
                    encoder.Long();
                    break;
                case VerificationTypeInfoKind.Null:
                    encoder.Null();
                    break;
                case VerificationTypeInfoKind.UninitializedThis:
                    encoder.UninitializedThis();
                    break;
                case VerificationTypeInfoKind.Object:
                    encoder.Object(constantPool.Get(constantView.Get(AsObject().Class)));
                    break;
                case VerificationTypeInfoKind.Uninitialized:
                    encoder.Uninitialized(AsUninitialized().Offset);
                    break;
            }
        }

    }

}
