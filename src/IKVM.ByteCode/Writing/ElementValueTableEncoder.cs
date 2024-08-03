using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Encodes an 'element_value_table' structure.
    /// </summary>
    public struct ElementValueTableEncoder
    {

        readonly BlobBuilder _builder;
        readonly Blob _countBlob;
        ushort _count;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        public ElementValueTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Adds an element value pair.
        /// </summary>
        /// <param name="value"></param>
        public ElementValueTableEncoder Add(Action<ElementValueEncoder> value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            value(new ElementValueEncoder(_builder));
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2(++_count);
            return this;
        }

        /// <summary>
        /// Encodes an existing set of elements.
        /// </summary>
        /// <param name="elements"></param>
        public ElementValueTableEncoder AddMany(ReadOnlySpan<ElementValueRecord> elements)
        {
            foreach (var i in elements)
                Add(e => e.Encode(i));

            return this;
        }

        /// <summary>
        /// Encodes an existing set of elements.
        /// </summary>
        /// <param name="elements"></param>
        public ElementValueTableEncoder AddMany(IEnumerable<ElementValueRecord> elements)
        {
            foreach (var i in elements)
                Add(e => e.Encode(i));

            return this;
        }

        /// <summary>
        /// Constant of the primitive type byte as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public ElementValueTableEncoder Byte(IntegerConstantHandle constantValue)
        {
            return Add(e => e.Byte(constantValue));
        }

        /// <summary>
        /// Constant of the primitive type char as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public ElementValueTableEncoder Char(IntegerConstantHandle constantValue)
        {
            return Add(e => e.Char(constantValue));
        }

        /// <summary>
        /// Constant of the primitive type double as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public ElementValueTableEncoder Double(DoubleConstantHandle constantValue)
        {
            return Add(e => e.Double(constantValue));
        }

        /// <summary>
        /// Constant of the primitive type float as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public ElementValueTableEncoder Float(FloatConstantHandle constantValue)
        {
            return Add(e => e.Float(constantValue));
        }

        /// <summary>
        /// Constant of the primitive type int as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public ElementValueTableEncoder Integer(IntegerConstantHandle constantValue)
        {
            return Add(e => e.Integer(constantValue));
        }

        /// <summary>
        /// Constant of the primitive type long as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public ElementValueTableEncoder Long(LongConstantHandle constantValue)
        {
            return Add(e => e.Long(constantValue));
        }

        /// <summary>
        /// Constant of the primitive type short as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public ElementValueTableEncoder Short(IntegerConstantHandle constantValue)
        {
            return Add(e => e.Short(constantValue));
        }

        /// <summary>
        /// Constant of the primitive type boolean as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public ElementValueTableEncoder Boolean(IntegerConstantHandle constantValue)
        {
            return Add(e => e.Boolean(constantValue));
        }

        /// <summary>
        /// Constant of the type String as the value of this element-value pair.
        /// </summary>
        /// <param name="constantValue"></param>
        public ElementValueTableEncoder String(Utf8ConstantHandle constantValue)
        {
            return Add(e => e.String(constantValue));
        }

        /// <summary>
        /// Denotes an enum constant as the value of this element-value pair.
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="constName"></param>
        public ElementValueTableEncoder Enum(Utf8ConstantHandle typeName, Utf8ConstantHandle constName)
        {
            return Add(e => e.Enum(typeName, constName));
        }

        /// <summary>
        /// Denotes a class literal as the value of this element-value pair.
        /// </summary>
        /// <param name="classInfo"></param>
        public ElementValueTableEncoder Class(Utf8ConstantHandle classInfo)
        {
            return Add(e => e.Class(classInfo));
        }

        /// <summary>
        /// Denotes a "nested" annotation as the value of this element-value pair.
        /// </summary>
        /// <param name="annotationValue"></param>
        public ElementValueTableEncoder Annotation(Action<AnnotationEncoder> annotationValue)
        {
            return Add(e => e.Annotation(annotationValue));
        }

    }

}