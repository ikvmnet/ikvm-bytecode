using System;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Encoding
{

    /// <summary>
    /// Encodes a table of 'element_value_pair' structures.
    /// </summary>
    public struct ElementValuePairTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public ElementValuePairTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds an element value pair.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="elementValue"></param>
        public ElementValuePairTableEncoder Element(Utf8ConstantHandle elementName, Action<ElementValueEncoder> elementValue)
        {
            if (elementValue is null)
                throw new ArgumentNullException(nameof(elementValue));

            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.WriteU2(elementName.Slot);
            elementValue(new ElementValueEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Constant of the primitive type byte as the value of this element-value pair.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="constantValue"></param>
        public ElementValuePairTableEncoder Byte(Utf8ConstantHandle elementName, IntegerConstantHandle constantValue)
        {
            return Element(elementName, e => e.Byte(constantValue));
        }

        /// <summary>
        /// Constant of the primitive type char as the value of this element-value pair.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="constantValue"></param>
        public ElementValuePairTableEncoder Char(Utf8ConstantHandle elementName, IntegerConstantHandle constantValue)
        {
            return Element(elementName, e => e.Char(constantValue));
        }

        /// <summary>
        /// Constant of the primitive type double as the value of this element-value pair.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="constantValue"></param>
        public ElementValuePairTableEncoder Double(Utf8ConstantHandle elementName, DoubleConstantHandle constantValue)
        {
            return Element(elementName, e => e.Double(constantValue));
        }

        /// <summary>
        /// Constant of the primitive type float as the value of this element-value pair.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="constantValue"></param>
        public ElementValuePairTableEncoder Float(Utf8ConstantHandle elementName, FloatConstantHandle constantValue)
        {
            return Element(elementName, e => e.Float(constantValue));
        }

        /// <summary>
        /// Constant of the primitive type int as the value of this element-value pair.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="constantValue"></param>
        public ElementValuePairTableEncoder Integer(Utf8ConstantHandle elementName, IntegerConstantHandle constantValue)
        {
            return Element(elementName, e => e.Integer(constantValue));
        }

        /// <summary>
        /// Constant of the primitive type long as the value of this element-value pair.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="constantValue"></param>
        public ElementValuePairTableEncoder Long(Utf8ConstantHandle elementName, LongConstantHandle constantValue)
        {
            return Element(elementName, e => e.Long(constantValue));
        }

        /// <summary>
        /// Constant of the primitive type short as the value of this element-value pair.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="constantValue"></param>
        public ElementValuePairTableEncoder Short(Utf8ConstantHandle elementName, IntegerConstantHandle constantValue)
        {
            return Element(elementName, e => e.Short(constantValue));
        }

        /// <summary>
        /// Constant of the primitive type boolean as the value of this element-value pair.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="constantValue"></param>
        public ElementValuePairTableEncoder Boolean(Utf8ConstantHandle elementName, IntegerConstantHandle constantValue)
        {
            return Element(elementName, e => e.Boolean(constantValue));
        }

        /// <summary>
        /// Constant of the type String as the value of this element-value pair.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="constantValue"></param>
        public ElementValuePairTableEncoder String(Utf8ConstantHandle elementName, Utf8ConstantHandle constantValue)
        {
            return Element(elementName, e => e.String(constantValue));
        }

        /// <summary>
        /// Denotes an enum constant as the value of this element-value pair.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="typeName"></param>
        /// <param name="constName"></param>
        public ElementValuePairTableEncoder Enum(Utf8ConstantHandle elementName, Utf8ConstantHandle typeName, Utf8ConstantHandle constName)
        {
            return Element(elementName, e => e.Enum(typeName, constName));
        }

        /// <summary>
        /// Denotes a class literal as the value of this element-value pair.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="classInfo"></param>
        public ElementValuePairTableEncoder Class(Utf8ConstantHandle elementName, Utf8ConstantHandle classInfo)
        {
            return Element(elementName, e => e.Class(classInfo));
        }

        /// <summary>
        /// Denotes a "nested" annotation as the value of this element-value pair.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="annotationValue"></param>
        public ElementValuePairTableEncoder Annotation(Utf8ConstantHandle elementName, Action<AnnotationEncoder> annotationValue)
        {
            return Element(elementName, e => e.Annotation(annotationValue));
        }

    }

}