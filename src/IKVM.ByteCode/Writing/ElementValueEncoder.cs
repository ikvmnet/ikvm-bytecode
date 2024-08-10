using System;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Provides methods to encode a single 'element_value' item.
    /// </summary>
    public struct ElementValueEncoder
    {

        readonly BlobBuilder _builder;
        byte _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public ElementValueEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        /// <summary>
        /// Constant of the primitive type byte as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public void Byte(IntegerConstantHandle constantValue)
        {
            if (_count > 0)
                throw new InvalidOperationException("Only a single element value can be encoded by this encoder.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ElementValueKind.Byte);
            w.WriteU2(constantValue.Slot);
            _count++;
        }

        /// <summary>
        /// Constant of the primitive type char as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public void Char(IntegerConstantHandle constantValue)
        {
            if (_count > 0)
                throw new InvalidOperationException("Only a single element value can be encoded by this encoder.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ElementValueKind.Char);
            w.WriteU2(constantValue.Slot);
            _count++;
        }

        /// <summary>
        /// Constant of the primitive type double as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public void Double(DoubleConstantHandle constantValue)
        {
            if (_count > 0)
                throw new InvalidOperationException("Only a single element value can be encoded by this encoder.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ElementValueKind.Double);
            w.WriteU2(constantValue.Slot);
            _count++;
        }

        /// <summary>
        /// Constant of the primitive type float as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public void Float(FloatConstantHandle constantValue)
        {
            if (_count > 0)
                throw new InvalidOperationException("Only a single element value can be encoded by this encoder.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ElementValueKind.Float);
            w.WriteU2(constantValue.Slot);
            _count++;
        }

        /// <summary>
        /// Constant of the primitive type int as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public void Integer(IntegerConstantHandle constantValue)
        {
            if (_count > 0)
                throw new InvalidOperationException("Only a single element value can be encoded by this encoder.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ElementValueKind.Integer);
            w.WriteU2(constantValue.Slot);
            _count++;
        }

        /// <summary>
        /// Constant of the primitive type long as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public void Long(LongConstantHandle constantValue)
        {
            if (_count > 0)
                throw new InvalidOperationException("Only a single element value can be encoded by this encoder.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ElementValueKind.Long);
            w.WriteU2(constantValue.Slot);
            _count++;
        }

        /// <summary>
        /// Constant of the primitive type short as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public void Short(IntegerConstantHandle constantValue)
        {
            if (_count > 0)
                throw new InvalidOperationException("Only a single element value can be encoded by this encoder.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ElementValueKind.Short);
            w.WriteU2(constantValue.Slot);
            _count++;
        }

        /// <summary>
        /// Constant of the primitive type boolean as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public void Boolean(IntegerConstantHandle constantValue)
        {
            if (_count > 0)
                throw new InvalidOperationException("Only a single element value can be encoded by this encoder.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ElementValueKind.Boolean);
            w.WriteU2(constantValue.Slot);
            _count++;
        }

        /// <summary>
        /// Constant of the type String as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public void String(Utf8ConstantHandle constantValue)
        {
            if (_count > 0)
                throw new InvalidOperationException("Only a single element value can be encoded by this encoder.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ElementValueKind.String);
            w.WriteU2(constantValue.Slot);
            _count++;
        }

        /// <summary>
        /// Denotes an enum constant as the value of this element-value pair.
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="constName"></param>
        public void Enum(Utf8ConstantHandle typeName, Utf8ConstantHandle constName)
        {
            if (_count > 0)
                throw new InvalidOperationException("Only a single element value can be encoded by this encoder.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ElementValueKind.Enum);
            w.WriteU2(typeName.Slot);
            w.WriteU2(constName.Slot);
            _count++;
        }

        /// <summary>
        /// Denotes a class literal as the value of this element-value pair.
        /// </summary>
        /// <param name="classInfo"></param>
        public void Class(Utf8ConstantHandle classInfo)
        {
            if (_count > 0)
                throw new InvalidOperationException("Only a single element value can be encoded by this encoder.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ElementValueKind.Class);
            w.WriteU2(classInfo.Slot);
            _count++;
        }

        /// <summary>
        /// Denotes a "nested" annotation as the value of this element-value pair.
        /// </summary>
        /// <param name="annotations"></param>
        public void Annotation(Action<AnnotationEncoder> annotationValue)
        {
            if (_count > 0)
                throw new InvalidOperationException("Only a single element value can be encoded by this encoder.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.WriteU1((byte)ElementValueKind.Annotation);
            annotationValue(new AnnotationEncoder(_builder));
            _count++;
        }

        /// <summary>
        /// Denotes an array as the value of this element-value pair.
        /// </summary>
        /// <param name="arrayValue"></param>
        public void Array(Action<ElementValueTableEncoder> arrayValue)
        {
            if (_count > 0)
                throw new InvalidOperationException("Only a single element value can be encoded by this encoder.");

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1).GetBytes());
            w.WriteU1((byte)ElementValueKind.Array);
            arrayValue(new ElementValueTableEncoder(_builder));
            _count++;
        }

    }

}
