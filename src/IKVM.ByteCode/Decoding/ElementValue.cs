using System;
using System.Buffers;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct ElementValue(ElementValueKind Kind, ReadOnlySequence<byte> Data)
    {

        public static ElementValue Nil => default;

        public static explicit operator ConstantElementValue(ElementValue value) => value.AsConstant();

        public static explicit operator EnumElementValue(ElementValue value) => value.AsEnum();

        public static explicit operator ClassElementValue(ElementValue value) => value.AsClass();

        public static explicit operator AnnotationElementValue(ElementValue value) => value.AsAnnotation();

        public static explicit operator ArrayElementValue(ElementValue value) => value.AsArray();

        /// <summary>
        /// Attempts to measure the size of the element value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool TryMeasure(ref ClassFormatReader reader, ref int size)
        {
            size += ClassFormatReader.U1;
            if (reader.TryReadU1(out byte kind) == false)
                return false;

            if (TryMeasureValue(ref reader, (ElementValueKind)kind, ref size) == false)
                return false;

            return true;
        }

        /// <summary>
        /// Attempts to measure the size of the element value with the given tag.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="kind"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        static bool TryMeasureValue(ref ClassFormatReader reader, ElementValueKind kind, ref int size) => kind switch
        {
            ElementValueKind.Byte => ConstantElementValue.TryMeasure(ref reader, ref size),
            ElementValueKind.Char => ConstantElementValue.TryMeasure(ref reader, ref size),
            ElementValueKind.Double => ConstantElementValue.TryMeasure(ref reader, ref size),
            ElementValueKind.Float => ConstantElementValue.TryMeasure(ref reader, ref size),
            ElementValueKind.Integer => ConstantElementValue.TryMeasure(ref reader, ref size),
            ElementValueKind.Long => ConstantElementValue.TryMeasure(ref reader, ref size),
            ElementValueKind.Short => ConstantElementValue.TryMeasure(ref reader, ref size),
            ElementValueKind.Boolean => ConstantElementValue.TryMeasure(ref reader, ref size),
            ElementValueKind.String => ConstantElementValue.TryMeasure(ref reader, ref size),
            ElementValueKind.Enum => EnumElementValue.TryMeasure(ref reader, ref size),
            ElementValueKind.Class => ClassElementValue.TryMeasure(ref reader, ref size),
            ElementValueKind.Annotation => AnnotationElementValue.TryMeasure(ref reader, ref size),
            ElementValueKind.Array => ArrayElementValue.TryMeasure(ref reader, ref size),
            _ => throw new ByteCodeException($"Invalid element value tag: '{(char)kind}'."),
        };

        /// <summary>
        /// Attempts to read the data for the element value.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, out ElementValue data)
        {
            data = default;

            if (reader.TryReadU1(out byte kind) == false)
                return false;

            return (ElementValueKind)kind switch
            {
                ElementValueKind.Byte => TryReadConstantData(ref reader, (ElementValueKind)kind, out data),
                ElementValueKind.Char => TryReadConstantData(ref reader, (ElementValueKind)kind, out data),
                ElementValueKind.Double => TryReadConstantData(ref reader, (ElementValueKind)kind, out data),
                ElementValueKind.Float => TryReadConstantData(ref reader, (ElementValueKind)kind, out data),
                ElementValueKind.Integer => TryReadConstantData(ref reader, (ElementValueKind)kind, out data),
                ElementValueKind.Long => TryReadConstantData(ref reader, (ElementValueKind)kind, out data),
                ElementValueKind.Short => TryReadConstantData(ref reader, (ElementValueKind)kind, out data),
                ElementValueKind.Boolean => TryReadConstantData(ref reader, (ElementValueKind)kind, out data),
                ElementValueKind.String => TryReadConstantData(ref reader, (ElementValueKind)kind, out data),
                ElementValueKind.Enum => TryReadEnumData(ref reader, out data),
                ElementValueKind.Class => TryReadClassData(ref reader, out data),
                ElementValueKind.Annotation => TryReadAnnotationData(ref reader, out data),
                ElementValueKind.Array => TryReadArrayData(ref reader, out data),
                _ => throw new ByteCodeException($"Unknown ElementValueKind {kind}."),
            };
        }

        static bool TryReadConstantData(ref ClassFormatReader reader, ElementValueKind kind, out ElementValue data)
        {
            data = default;

            if (ConstantElementValue.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new ElementValue(kind, _data);
            return true;
        }

        static bool TryReadEnumData(ref ClassFormatReader reader, out ElementValue data)
        {
            data = default;

            if (EnumElementValue.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new ElementValue(ElementValueKind.Enum, _data);
            return true;
        }

        static bool TryReadClassData(ref ClassFormatReader reader, out ElementValue data)
        {
            data = default;

            if (ClassElementValue.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new ElementValue(ElementValueKind.Class, _data);
            return true;
        }

        static bool TryReadAnnotationData(ref ClassFormatReader reader, out ElementValue data)
        {
            data = default;

            if (AnnotationElementValue.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new ElementValue(ElementValueKind.Annotation, _data);
            return true;
        }

        static bool TryReadArrayData(ref ClassFormatReader reader, out ElementValue data)
        {
            data = default;

            if (ArrayElementValue.TryReadData(ref reader, out var _data) == false)
                return false;

            data = new ElementValue(ElementValueKind.Array, _data);
            return true;
        }

        public readonly ElementValueKind Kind = Kind;
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

        public readonly ConstantElementValue AsConstant()
        {
            if (Kind is not ElementValueKind.Byte and not ElementValueKind.Char and not ElementValueKind.Double and not ElementValueKind.Float and not ElementValueKind.Integer and not ElementValueKind.Long and not ElementValueKind.Short and not ElementValueKind.Boolean and not ElementValueKind.String)
                throw new InvalidCastException($"Cannot cast ElementValue of kind {Kind} to Constant.");

            var reader = new ClassFormatReader(Data);
            if (ConstantElementValue.TryRead(ref reader, Kind, out var value) == false)
                throw new InvalidCastException($"End of data reached casting element value of kind {Kind} to Constant.");

            return value;
        }

        public readonly EnumElementValue AsEnum()
        {
            if (Kind is not ElementValueKind.Enum)
                throw new InvalidCastException($"Cannot cast ElementValue of kind {Kind} to Enum.");

            var reader = new ClassFormatReader(Data);
            if (EnumElementValue.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting element value of kind {Kind} to Enum.");

            return value;
        }

        public readonly ClassElementValue AsClass()
        {
            if (Kind is not ElementValueKind.Class)
                throw new InvalidCastException($"Cannot cast ElementValue of kind {Kind} to Class.");

            var reader = new ClassFormatReader(Data);
            if (ClassElementValue.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting element value of kind {Kind} to Class.");

            return value;
        }

        public readonly AnnotationElementValue AsAnnotation()
        {
            if (Kind is not ElementValueKind.Annotation)
                throw new InvalidCastException($"Cannot cast ElementValue of kind {Kind} to Annotation.");

            var reader = new ClassFormatReader(Data);
            if (AnnotationElementValue.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting element value of kind {Kind} to Annotation.");

            return value;
        }

        public readonly ArrayElementValue AsArray()
        {
            if (Kind is not ElementValueKind.Array)
                throw new InvalidCastException($"Cannot cast ElementValue of kind {Kind} to Array.");

            var reader = new ClassFormatReader(Data);
            if (ArrayElementValue.TryRead(ref reader, out var value) == false)
                throw new InvalidCastException($"End of data reached casting element value of kind {Kind} to Array.");

            return value;
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantMap>(TConstantMap map, ref ElementValueEncoder encoder)
            where TConstantMap : IConstantMap
        {
            switch (Kind)
            {
                case ElementValueKind.Byte:
                    var _byte = AsConstant();
                    encoder.Byte(map.Map((IntegerConstantHandle)_byte.Handle));
                    break;
                case ElementValueKind.Char:
                    var _char = AsConstant();
                    encoder.Char(map.Map((IntegerConstantHandle)_char.Handle));
                    break;
                case ElementValueKind.Double:
                    var _double = AsConstant();
                    encoder.Double(map.Map((DoubleConstantHandle)_double.Handle));
                    break;
                case ElementValueKind.Float:
                    var _float = AsConstant();
                    encoder.Float(map.Map((FloatConstantHandle)_float.Handle));
                    break;
                case ElementValueKind.Integer:
                    var _integer = AsConstant();
                    encoder.Integer(map.Map((IntegerConstantHandle)_integer.Handle));
                    break;
                case ElementValueKind.Long:
                    var _long = AsConstant();
                    encoder.Long(map.Map((LongConstantHandle)_long.Handle));
                    break;
                case ElementValueKind.Short:
                    var _short = AsConstant();
                    encoder.Short(map.Map((IntegerConstantHandle)_short.Handle));
                    break;
                case ElementValueKind.Boolean:
                    var _boolean = AsConstant();
                    encoder.Boolean(map.Map((IntegerConstantHandle)_boolean.Handle));
                    break;
                case ElementValueKind.String:
                    var _string = AsConstant();
                    encoder.String(map.Map((Utf8ConstantHandle)_string.Handle));
                    break;
                case ElementValueKind.Enum:
                    var _enum = AsEnum();
                    encoder.Enum(map.Map(_enum.TypeName), map.Map(_enum.ConstantName));
                    break;
                case ElementValueKind.Class:
                    var _class = AsClass();
                    encoder.Class(map.Map(_class.Class));
                    break;
                case ElementValueKind.Annotation:
                    var _annotation = AsAnnotation();
                    encoder.Annotation(e => _annotation.Annotation.CopyTo(map, ref e));
                    break;
                case ElementValueKind.Array:
                    break;
            }
        }

        /// <summary>
        /// Wrirtes this data class to the encoder.
        /// </summary>
        /// <param name="encoder"></param>
        public readonly void WriteTo(ref ElementValueEncoder encoder)
        {
            switch (Kind)
            {
                case ElementValueKind.Byte:
                    var _byte = AsConstant();
                    encoder.Byte(((IntegerConstantHandle)_byte.Handle));
                    break;
                case ElementValueKind.Char:
                    var _char = AsConstant();
                    encoder.Char(((IntegerConstantHandle)_char.Handle));
                    break;
                case ElementValueKind.Double:
                    var _double = AsConstant();
                    encoder.Double(((DoubleConstantHandle)_double.Handle));
                    break;
                case ElementValueKind.Float:
                    var _float = AsConstant();
                    encoder.Float(((FloatConstantHandle)_float.Handle));
                    break;
                case ElementValueKind.Integer:
                    var _integer = AsConstant();
                    encoder.Integer(((IntegerConstantHandle)_integer.Handle));
                    break;
                case ElementValueKind.Long:
                    var _long = AsConstant();
                    encoder.Long(((LongConstantHandle)_long.Handle));
                    break;
                case ElementValueKind.Short:
                    var _short = AsConstant();
                    encoder.Short(((IntegerConstantHandle)_short.Handle));
                    break;
                case ElementValueKind.Boolean:
                    var _boolean = AsConstant();
                    encoder.Boolean(((IntegerConstantHandle)_boolean.Handle));
                    break;
                case ElementValueKind.String:
                    var _string = AsConstant();
                    encoder.String(((Utf8ConstantHandle)_string.Handle));
                    break;
                case ElementValueKind.Enum:
                    var _enum = AsEnum();
                    encoder.Enum((_enum.TypeName), (_enum.ConstantName));
                    break;
                case ElementValueKind.Class:
                    var _class = AsClass();
                    encoder.Class((_class.Class));
                    break;
                case ElementValueKind.Annotation:
                    var _annotation = AsAnnotation();
                    encoder.Annotation(e => _annotation.Annotation.WriteTo(ref e));
                    break;
                case ElementValueKind.Array:
                    break;
            }
        }

    }

}
