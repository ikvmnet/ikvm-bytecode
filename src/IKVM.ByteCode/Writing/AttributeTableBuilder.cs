using System;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Provides an API for assembling a JVM attribute table.
    /// </summary>
    public class AttributeTableBuilder
    {

        readonly IConstantPool _constants;
        BlobBuilder? _builder;
        AttributeTableEncoder _encoder;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="constants"></param>
        public AttributeTableBuilder(IConstantPool constants)
        {
            _constants = constants ?? throw new ArgumentNullException(nameof(constants));
        }

        /// <summary>
        /// Gets the builder.
        /// </summary>
        ref AttributeTableEncoder Encoder => ref GetEncoder();

        /// <summary>
        /// Gets the builder.
        /// </summary>
        /// <returns></returns>
        ref AttributeTableEncoder GetEncoder()
        {
            if (_builder == null)
            {
                _builder = new BlobBuilder();
                _encoder = new AttributeTableEncoder(_builder);
            }

            return ref _encoder;
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public AttributeTableBuilder Attribute(string name, BlobBuilder data)
        {
            Encoder.Attribute(_constants.Get(Constant.Utf8(name)), data);
            return this;
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public AttributeTableBuilder Attribute(string name, ReadOnlySpan<byte> data)
        {
            Encoder.Attribute(_constants.Get(Constant.Utf8(name)), data);
            return this;
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        public AttributeTableBuilder Attribute(string name)
        {
            Encoder.Attribute(_constants.Get(Constant.Utf8(name)));
            return this;
        }

        /// <summary>
        /// Adds a new ConstantValue attribute.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(ConstantHandle value)
        {
            Encoder.ConstantValue(_constants.Get(Constant.Utf8(AttributeName.ConstantValue)), value);
            return this;
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(int value)
        {
            Encoder.ConstantValue(_constants.Get(Constant.Utf8(AttributeName.ConstantValue)), _constants.Get(Constant.Integer(value)));
            return this;
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(short value)
        {
            Encoder.ConstantValue(_constants.Get(Constant.Utf8(AttributeName.ConstantValue)), _constants.Get(Constant.Integer(value)));
            return this;
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(char value)
        {
            Encoder.ConstantValue(_constants.Get(Constant.Utf8(AttributeName.ConstantValue)), _constants.Get(Constant.Integer(value)));
            return this;
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(byte value)
        {
            Encoder.ConstantValue(_constants.Get(Constant.Utf8(AttributeName.ConstantValue)), _constants.Get(Constant.Integer(value)));
            return this;
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(bool value)
        {
            Encoder.ConstantValue(_constants.Get(Constant.Utf8(AttributeName.ConstantValue)), _constants.Get(Constant.Integer(value ? 1 : 0)));
            return this;
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(float value)
        {
            Encoder.ConstantValue(_constants.Get(Constant.Utf8(AttributeName.ConstantValue)), _constants.Get((FloatConstant)value));
            return this;
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(long value)
        {
            Encoder.ConstantValue(_constants.Get(AttributeName.ConstantValue), _constants.Get((LongConstant)value));
            return this;
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(double value)
        {
            Encoder.ConstantValue(_constants.Get(AttributeName.ConstantValue), _constants.Get((value)));
            return this;
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(string value)
        {
            Encoder.ConstantValue(_constants.Get(AttributeName.ConstantValue), _constants.Get(Constant.String(value)));
            return this;
        }

        /// <summary>
        /// Adds a new Code attribute.
        /// </summary>
        /// <param name="maxStack"></param>
        /// <param name="maxLocals"></param>
        /// <param name="code"></param>
        /// <param name="exceptions"></param>
        /// <param name="attributes"></param>
        public AttributeTableBuilder Code(ushort maxStack, ushort maxLocals, BlobBuilder code, Action<ExceptionTableEncoder> exceptions, AttributeTableBuilder attributes)
        {
            Encoder.Code(_constants.Get(AttributeName.Code), maxStack, maxLocals, code, exceptions, attributes);
            return this;
        }

        /// <summary>
        /// Adds a new StackMapTable attribute.
        /// </summary>
        public AttributeTableBuilder StackMapTable(Action<StackMapTableEncoder> stackMapTable)
        {
            Encoder.StackMapTable(_constants.Get(AttributeName.StackMapTable), stackMapTable);
            return this;
        }

        /// <summary>
        /// Adds a new Exceptions attribute.
        /// </summary>
        public AttributeTableBuilder Exceptions(Action<ClassConstantTableEncoder> exceptions)
        {
            Encoder.Exceptions(_constants.Get(AttributeName.Exceptions), exceptions);
            return this;
        }

        /// <summary>
        /// Adds a new InnerClasses attribute.
        /// </summary>
        /// <param name="classes"></param>
        public AttributeTableBuilder InnerClasses(Action<InnerClassTableEncoder> classes)
        {
            Encoder.InnerClasses(_constants.Get(AttributeName.InnerClasses), classes);
            return this;
        }

        /// <summary>
        /// Adds a new EnclosingMethod attribute.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        public AttributeTableBuilder EnclosingMethod(ClassConstantHandle clazz, NameAndTypeConstantHandle method)
        {
            Encoder.EnclosingMethod(_constants.Get(AttributeName.EnclosingMethod), clazz, method);
            return this;
        }

        /// <summary>
        /// Adds a new Synthetic attribute.
        /// </summary>
        public AttributeTableBuilder Synthetic()
        {
            Encoder.Synthetic(_constants.Get(AttributeName.Synthetic));
            return this;
        }

        /// <summary>
        /// Adds a new Signature attribute.
        /// </summary>
        /// <param name="signature"></param>
        public AttributeTableBuilder Signature(Utf8ConstantHandle signature)
        {
            Encoder.Signature(_constants.Get(AttributeName.Signature), signature);
            return this;
        }

        /// <summary>
        /// Adds a new Signature attribute.
        /// </summary>
        /// <param name="signature"></param>
        public AttributeTableBuilder Signature(string signature)
        {
            Encoder.Signature(_constants.Get(AttributeName.Signature), _constants.Get(signature));
            return this;
        }

        /// <summary>
        /// Adds a new SourceFile attribute.
        /// </summary>
        /// <param name="sourceFile"></param>
        public AttributeTableBuilder SourceFile(Utf8ConstantHandle sourceFile)
        {
            Encoder.SourceFile(_constants.Get(AttributeName.SourceFile), sourceFile);
            return this;
        }

        /// <summary>
        /// Adds a new SourceFile attribute.
        /// </summary>
        /// <param name="sourceFile"></param>
        public AttributeTableBuilder SourceFile(string sourceFile)
        {
            Encoder.SourceFile(_constants.Get(AttributeName.SourceFile), _constants.Get(sourceFile));
            return this;
        }

        /// <summary>
        /// Adds a new SourceDebugExtension attribute.
        /// </summary>
        /// <param name="debugExtension"></param>
        public AttributeTableBuilder SourceDebugExtension(BlobBuilder debugExtension)
        {
            Encoder.SourceDebugExtension(_constants.Get(AttributeName.SourceDebugExtension), debugExtension);
            return this;
        }

        /// <summary>
        /// Adds a new LineNumberTable attribute.
        /// </summary>
        public AttributeTableBuilder LineNumberTable(Action<LineNumberTableEncoder> lineNumbers)
        {
            Encoder.LineNumberTable(_constants.Get(AttributeName.LineNumberTable), lineNumbers);
            return this;
        }

        /// <summary>
        /// Adds a new LocalVariableTable attribute.
        /// </summary>
        public AttributeTableBuilder LocalVariableTable(Action<LocalVariableTableEncoder> localVars)
        {
            Encoder.LocalVariableTable(_constants.Get(AttributeName.LocalVariableTable), localVars);
            return this;
        }

        /// <summary>
        /// Adds a new LocalVariableTypeTable attribute.
        /// </summary>
        public AttributeTableBuilder LocalVariableTypeTable(Action<LocalVariableTypeTableEncoder> localVarTypes)
        {
            Encoder.LocalVariableTypeTable(_constants.Get(AttributeName.LocalVariableTypeTable), localVarTypes);
            return this;
        }

        /// <summary>
        /// Adds a new Deprecated attribute.
        /// </summary>
        public AttributeTableBuilder Deprecated()
        {
            Encoder.Deprecated(_constants.Get(AttributeName.Deprecated));
            return this;
        }

        /// <summary>
        /// Adds a new RuntimeVisibleAnnotations attribute.
        /// </summary>
        /// <param name="annotations"></param>
        public AttributeTableBuilder RuntimeVisibleAnnotations(Action<AnnotationTableEncoder> annotations)
        {
            Encoder.RuntimeVisibleAnnotations(_constants.Get(AttributeName.RuntimeVisibleAnnotations), annotations);
            return this;
        }

        /// <summary>
        /// Adds a new RuntimeInvisibleAnnotations attribute.
        /// </summary>
        public AttributeTableBuilder RuntimeInvisibleAnnotations(Action<AnnotationTableEncoder> annotations)
        {
            Encoder.RuntimeInvisibleAnnotations(_constants.Get(AttributeName.RuntimeInvisibleAnnotations), annotations);
            return this;
        }

        /// <summary>
        /// Adds a new RuntimeVisibleParameterAnnotations attribute.
        /// </summary>
        public AttributeTableBuilder RuntimeVisibleParameterAnnotations(Action<ParameterAnnotationTableEncoder> parameterAnnotations)
        {
            Encoder.RuntimeVisibleParameterAnnotations(_constants.Get(AttributeName.RuntimeVisibleParameterAnnotations), parameterAnnotations);
            return this;
        }

        /// <summary>
        /// Adds a new RuntimeInvisibleParameterAnnotations attribute.
        /// </summary>
        public AttributeTableBuilder RuntimeInvisibleParameterAnnotations(Action<ParameterAnnotationTableEncoder> parameterAnnotations)
        {
            Encoder.RuntimeInvisibleParameterAnnotations(_constants.Get(AttributeName.RuntimeInvisibleParameterAnnotations), parameterAnnotations);
            return this;
        }

        /// <summary>
        /// Adds a new RuntimeVisibleTypeAnnotations attribute.
        /// </summary>
        /// <param name="typeAnnotations"></param>
        public AttributeTableBuilder RuntimeVisibleTypeAnnotations(Action<TypeAnnotationTableEncoder> typeAnnotations)
        {
            Encoder.RuntimeVisibleTypeAnnotations(_constants.Get(AttributeName.RuntimeVisibleTypeAnnotations), typeAnnotations);
            return this;
        }

        /// <summary>
        /// Adds a new RuntimeInvisibleTypeAnnotations attribute.
        /// </summary>
        /// <param name="typeAnnotations"></param>
        public AttributeTableBuilder RuntimeInvisibleTypeAnnotations(Action<TypeAnnotationTableEncoder> typeAnnotations)
        {
            Encoder.RuntimeInvisibleTypeAnnotations(_constants.Get(AttributeName.RuntimeInvisibleTypeAnnotations), typeAnnotations);
            return this;
        }

        /// <summary>
        /// Adds a new AnnotationDefault attribute.
        /// </summary>
        /// <param name="defaultValue"></param>
        public AttributeTableBuilder AnnotationDefault(Action<ElementValueEncoder> defaultValue)
        {
            Encoder.AnnotationDefault(_constants.Get(AttributeName.AnnotationDefault), defaultValue);
            return this;
        }

        /// <summary>
        /// Adds a new BootstrapMethods attribute.
        /// </summary>
        /// <param name="bootstrapMethods"></param>
        public AttributeTableBuilder BootstrapMethods(Action<BootstrapMethodTableEncoder> bootstrapMethods)
        {
            Encoder.BootstrapMethods(_constants.Get(AttributeName.BootstrapMethods), bootstrapMethods);
            return this;
        }

        /// <summary>
        /// Adds a new MethodParameters attribute.
        /// </summary>
        public AttributeTableBuilder MethodParameters(Action<MethodParameterTableEncoder> parameters)
        {
            Encoder.MethodParameters(_constants.Get(AttributeName.MethodParameters), parameters);
            return this;
        }

        /// <summary>
        /// Adds a new Module attribute.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="flags"></param>
        /// <param name="version"></param>
        /// <param name="requires"></param>
        /// <param name="exports"></param>
        /// <param name="opens"></param>
        /// <param name="uses"></param>
        /// <param name="provides"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public AttributeTableBuilder Module(ModuleConstantHandle name, ModuleFlag flags, Utf8ConstantHandle version, Action<ModuleRequiresTableEncoder> requires, Action<ModuleExportsTableEncoder> exports, Action<ModuleOpensTableEncoder> opens, Action<ClassConstantTableEncoder> uses, Action<ModuleProvidesTableEncoder> provides)
        {
            Encoder.Module(_constants.Get(AttributeName.Module), name, flags, version, requires, exports, opens, uses, provides);
            return this;
        }

        /// <summary>
        /// Adds a new ModulePackages attribute.
        /// </summary>
        public AttributeTableBuilder ModulePackages(Action<PackageConstantTableEncoder> packages)
        {
            Encoder.ModulePackages(_constants.Get(AttributeName.ModulePackages), packages);
            return this;
        }

        /// <summary>
        /// Adds a new ModuleMainClass attribute.
        /// </summary>
        /// <param name="mainClass"></param>
        public AttributeTableBuilder ModuleMainClass(ClassConstantHandle mainClass)
        {
            Encoder.ModuleMainClass(_constants.Get(AttributeName.ModuleMainClass), mainClass);
            return this;
        }

        /// <summary>
        /// Adds a new NestHost attribute.
        /// </summary>
        /// <param name="nestHost"></param>
        public AttributeTableBuilder NestHost(ClassConstantHandle nestHost)
        {
            Encoder.NestHost(_constants.Get(AttributeName.NestHost), nestHost);
            return this;
        }

        /// <summary>
        /// Adds a new NestMembers attribute.
        /// </summary>
        /// <param name="classes"></param>
        public AttributeTableBuilder NestMembers(Action<ClassConstantTableEncoder> classes)
        {
            Encoder.NestMembers(_constants.Get(AttributeName.NestMembers), classes);
            return this;
        }

        /// <summary>
        /// Adds a new Record attribute.
        /// </summary>
        public AttributeTableBuilder Record(Action<RecordComponentTableEncoder> components)
        {
            Encoder.Record(_constants.Get(AttributeName.Record), components);
            return this;
        }

        /// <summary>
        /// Adds a new PermittedSubclasses attribute.
        /// </summary>
        /// <param name="classes"></param>
        public AttributeTableBuilder PermittedSubclasses(Action<ClassConstantTableEncoder> classes)
        {
            Encoder.PermittedSubclasses(_constants.Get(AttributeName.PermittedSubclasses), classes);
            return this;
        }

        /// <summary>
        /// Serializes the attributes to the specified builder.
        /// </summary>
        /// <param name="builder"></param>
        public void Serialize(BlobBuilder builder)
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            if (_builder != null)
                builder.LinkSuffix(_builder);
            else
                new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U2).GetBytes()).TryWriteU2(0);
        }

    }

}
