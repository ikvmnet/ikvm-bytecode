using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Provides an API for assembling a JVM attribute table.
    /// </summary>
    public class AttributeTableBuilder
    {

        readonly ConstantBuilder _constants;
        BlobBuilder _builder;
        Blob _countBlob;
        int _count = 0;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="constants"></param>
        public AttributeTableBuilder(ConstantBuilder constants)
        {
            _constants = constants ?? throw new ArgumentNullException(nameof(constants));
        }

        /// <summary>
        /// Gets the builder.
        /// </summary>
        BlobBuilder Builder => GetBuilder();

        /// <summary>
        /// Gets the builder.
        /// </summary>
        /// <returns></returns>
        BlobBuilder GetBuilder()
        {
            if (_builder == null)
            {
                _builder = new BlobBuilder();
                _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
                WriteCount(_count);
            }

            return _builder;
        }

        /// <summary>
        /// Writes the count value.
        /// </summary>
        /// <param name="value"></param>
        void WriteCount(int value)
        {
            GetBuilder();
            new ClassFormatWriter(_countBlob.GetBytes()).TryWriteU2((ushort)value);
        }

        /// <summary>
        /// Increments the counter.
        /// </summary>
        void IncrementCount()
        {
            WriteCount(++_count);
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public AttributeTableBuilder Attribute(Utf8ConstantHandle name, BlobBuilder data)
        {
            if (data != null && data.Count > 0)
            {
                var w = new ClassFormatWriter(Builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
                w.TryWriteU2(name.Index);
                w.TryWriteU2((ushort)data.Count);
                Builder.LinkSuffix(data);
                IncrementCount();
                return this;
            }
            else
            {
                return Attribute(name);
            }
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public AttributeTableBuilder Attribute(string name, BlobBuilder data)
        {
            return Attribute(_constants.GetOrAddUtf8Constant(name), data);
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public AttributeTableBuilder Attribute(Utf8ConstantHandle name, ReadOnlySpan<byte> data)
        {
            if (data.Length > 0)
            {
                var w = new ClassFormatWriter(Builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
                w.TryWriteU2(name.Index);
                w.TryWriteU2((ushort)data.Length);
                Builder.WriteBytes(data);
                IncrementCount();
                return this;
            }
            else
            {
                return Attribute(name);
            }
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public AttributeTableBuilder Attribute(string name, ReadOnlySpan<byte> data)
        {
            return Attribute(_constants.GetOrAddUtf8Constant(name), data);
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        public AttributeTableBuilder Attribute(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(Builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(name.Index);
            w.TryWriteU2(0);
            IncrementCount();
            return this;
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        public AttributeTableBuilder Attribute(string name)
        {
            return Attribute(_constants.GetOrAddUtf8Constant(name));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(ConstantHandle value)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.TryWriteU2(value.Index);
            return Attribute("ConstantValue", b);
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(int value)
        {
            return ConstantValue(_constants.GetOrAddIntegerConstant(value));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(short value)
        {
            return ConstantValue(_constants.GetOrAddIntegerConstant(value));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(char value)
        {
            return ConstantValue(_constants.GetOrAddIntegerConstant(value));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(byte value)
        {
            return ConstantValue(_constants.GetOrAddIntegerConstant(value));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(bool value)
        {
            return ConstantValue(_constants.GetOrAddIntegerConstant(value ? 1 : 0));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(float value)
        {
            return ConstantValue(_constants.GetOrAddFloatConstant(value));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(long value)
        {
            return ConstantValue(_constants.GetOrAddLongConstant(value));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(double value)
        {
            return ConstantValue(_constants.GetOrAddDoubleConstant(value));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public AttributeTableBuilder ConstantValue(string value)
        {
            return ConstantValue(_constants.GetOrAddStringConstant(value));
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
            var b = new BlobBuilder();
            var w = new ClassFormatWriter(b.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U4).GetBytes());
            w.TryWriteU2(maxStack);
            w.TryWriteU2(maxLocals);
            w.TryWriteU4((uint)code.Count);
            b.LinkSuffix(code);
            exceptions(new ExceptionTableEncoder(b));
            attributes.Serialize(b);
            return Attribute("Code", b);
        }

        /// <summary>
        /// Adds a new StackMapTable attribute.
        /// </summary>
        public AttributeTableBuilder StackMapTable(Action<StackMapTableEncoder> stackMapTable)
        {
            var b = new BlobBuilder();
            stackMapTable(new StackMapTableEncoder(b));
            return Attribute("StackMapTable", b);
        }

        /// <summary>
        /// Adds a new Exceptions attribute.
        /// </summary>
        public AttributeTableBuilder Exceptions(Action<ClassConstantTableEncoder> exceptions)
        {
            var b = new BlobBuilder();
            exceptions(new ClassConstantTableEncoder(b));
            return Attribute("Exceptions", b);
        }

        /// <summary>
        /// Adds a new InnerClasses attribute.
        /// </summary>
        /// <param name="classes"></param>
        public AttributeTableBuilder InnerClasses(BlobBuilder classes)
        {
            return Attribute("InnerClasses", classes);
        }

        /// <summary>
        /// Adds a new EnclosingMethod attribute.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        public AttributeTableBuilder EnclosingMethod(ClassConstantHandle clazz, NameAndTypeConstantHandle method)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2 + ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.TryWriteU2(clazz.Index);
            w.TryWriteU2(method.Index);
            return Attribute("EnclosingMethod", b);
        }

        /// <summary>
        /// Adds a new Synthetic attribute.
        /// </summary>
        public AttributeTableBuilder Synthetic()
        {
            return Attribute("Synthetic");
        }

        /// <summary>
        /// Adds a new Signature attribute.
        /// </summary>
        /// <param name="signature"></param>
        public AttributeTableBuilder Signature(Utf8ConstantHandle signature)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.TryWriteU2(signature.Index);
            return Attribute("Signature", b);
        }

        /// <summary>
        /// Adds a new Signature attribute.
        /// </summary>
        /// <param name="signature"></param>
        public AttributeTableBuilder Signature(string signature)
        {
            return Signature(_constants.GetOrAddUtf8Constant(signature));
        }

        /// <summary>
        /// Adds a new SourceFile attribute.
        /// </summary>
        /// <param name="sourceFile"></param>
        public AttributeTableBuilder SourceFile(Utf8ConstantHandle sourceFile)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.TryWriteU2(sourceFile.Index);
            return Attribute("SourceFile", b);
        }

        /// <summary>
        /// Adds a new SourceFile attribute.
        /// </summary>
        /// <param name="sourceFile"></param>
        public AttributeTableBuilder SourceFile(string sourceFile)
        {
            return SourceFile(_constants.GetOrAddUtf8Constant(sourceFile));
        }

        /// <summary>
        /// Adds a new SourceDebugExtension attribute.
        /// </summary>
        /// <param name="debugExtension"></param>
        public AttributeTableBuilder SourceDebugExtension(BlobBuilder debugExtension)
        {
            return Attribute("SourceDebugExtension", debugExtension);
        }

        /// <summary>
        /// Adds a new LineNumberTable attribute.
        /// </summary>
        public AttributeTableBuilder LineNumberTable(Action<LineNumberTableEncoder> lineNumbers)
        {
            var b = new BlobBuilder();
            lineNumbers(new LineNumberTableEncoder(b));
            return Attribute("LineNumberTable", b);
        }

        /// <summary>
        /// Adds a new LocalVariableTable attribute.
        /// </summary>
        public AttributeTableBuilder LocalVariableTable(Action<LocalVariableTableEncoder> localVars)
        {
            var b = new BlobBuilder();
            localVars(new LocalVariableTableEncoder(b));
            return Attribute("LocalVariableTable", b);
        }

        /// <summary>
        /// Adds a new LocalVariableTypeTable attribute.
        /// </summary>
        public AttributeTableBuilder LocalVariableTypeTable(Action<LocalVariableTypeTableEncoder> localVarTypes)
        {
            var b = new BlobBuilder();
            localVarTypes(new LocalVariableTypeTableEncoder(b));
            return Attribute("LocalVariableTypeTable", b);
        }

        /// <summary>
        /// Adds a new Deprecated attribute.
        /// </summary>
        public AttributeTableBuilder Deprecated()
        {
            return Attribute("Deprecated");
        }

        /// <summary>
        /// Adds a new RuntimeVisibleAnnotations attribute.
        /// </summary>
        /// <param name="annotations"></param>
        public AttributeTableBuilder RuntimeVisibleAnnotations(Action<AnnotationTableEncoder> annotations)
        {
            var b = new BlobBuilder();
            annotations(new AnnotationTableEncoder(b));
            return Attribute("RuntimeVisibleAnnotations", b);
        }

        /// <summary>
        /// Adds a new RuntimeInvisibleAnnotations attribute.
        /// </summary>
        public AttributeTableBuilder RuntimeInvisibleAnnotations(Action<AnnotationTableEncoder> annotations)
        {
            var b = new BlobBuilder();
            annotations(new AnnotationTableEncoder(b));
            return Attribute("RuntimeInvisibleAnnotations", b);
        }

        /// <summary>
        /// Adds a new RuntimeVisibleParameterAnnotations attribute.
        /// </summary>
        public AttributeTableBuilder RuntimeVisibleParameterAnnotations(Action<ParameterAnnotationTableEncoder> parameterAnnotations)
        {
            var b = new BlobBuilder();
            parameterAnnotations(new ParameterAnnotationTableEncoder(b));
            return Attribute("RuntimeVisibleParameterAnnotations", b);
        }

        /// <summary>
        /// Adds a new RuntimeInvisibleParameterAnnotations attribute.
        /// </summary>
        public AttributeTableBuilder RuntimeInvisibleParametersAnnotations(Action<ParameterAnnotationTableEncoder> parameterAnnotations)
        {
            var b = new BlobBuilder();
            parameterAnnotations(new ParameterAnnotationTableEncoder(b));
            return Attribute("RuntimeInvisibleParameterAnnotations", b);
        }

        /// <summary>
        /// Adds a new RuntimeVisibleTypeAnnotations attribute.
        /// </summary>
        /// <param name="typeAnnotations"></param>
        public AttributeTableBuilder RuntimeVisibleTypeAnnotations(Action<TypeAnnotationTableEncoder> typeAnnotations)
        {
            var b = new BlobBuilder();
            typeAnnotations(new TypeAnnotationTableEncoder(b));
            return Attribute("RuntimeVisibleTypeAnnotations", b);
        }

        /// <summary>
        /// Adds a new RuntimeInvisibleTypeAnnotations attribute.
        /// </summary>
        /// <param name="typeAnnotations"></param>
        public AttributeTableBuilder RuntimeInvisibleTypeAnnotations(Action<TypeAnnotationTableEncoder> typeAnnotations)
        {
            var b = new BlobBuilder();
            typeAnnotations(new TypeAnnotationTableEncoder(b));
            return Attribute("RuntimeInvisibleTypeAnnotations", b);
        }

        /// <summary>
        /// Adds a new AnnotationDefault attribute.
        /// </summary>
        /// <param name="defaultValue"></param>
        public AttributeTableBuilder AnnotationDefault(Action<ElementValueEncoder> defaultValue)
        {
            var b = new BlobBuilder();
            defaultValue(new ElementValueEncoder(b));
            return Attribute("AnnotationDefault", b);
        }

        /// <summary>
        /// Adds a new BootstrapMethods attribute.
        /// </summary>
        /// <param name="bootstrapMethods"></param>
        public AttributeTableBuilder BootstrapMethods(Action<BootstrapMethodsTableEncoder> bootstrapMethods)
        {
            var b = new BlobBuilder();
            bootstrapMethods(new BootstrapMethodsTableEncoder(b));
            return Attribute("BootstrapMethods", b);
        }

        /// <summary>
        /// Adds a new MethodParameters attribute.
        /// </summary>
        public AttributeTableBuilder MethodParameters(Action<MethodParametersTableEncoder> parameters)
        {
            var b = new BlobBuilder();
            parameters(new MethodParametersTableEncoder(b));
            return Attribute("MethodParameters", b);
        }

        /// <summary>
        /// Adds a new Module attribute.
        /// </summary>
        /// <param name="module"></param>
        public AttributeTableBuilder Module(ModuleConstantHandle name, ModuleFlag flags, Utf8ConstantHandle version, Action<ModuleRequiresTableEncoder> requires, Action<ModuleExportsTableEncoder> exports, Action<ModuleOpensTableEncoder> opens, Action<ClassConstantTableEncoder> uses, Action<ModuleProvidesTableEncoder> provides)
        {
            var b = new BlobBuilder();
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(name.Index);
            w.TryWriteU2((ushort)flags);
            w.TryWriteU2(version.Index);
            requires(new ModuleRequiresTableEncoder(b));
            exports(new ModuleExportsTableEncoder(b));
            opens(new ModuleOpensTableEncoder(b));
            uses(new ClassConstantTableEncoder(b));
            provides(new ModuleProvidesTableEncoder(b));
            return Attribute("Module", b);
        }

        /// <summary>
        /// Adds a new ModulePackages attribute.
        /// </summary>
        public AttributeTableBuilder ModulePackages(Action<PackageConstantTableEncoder> packages)
        {
            var b = new BlobBuilder();
            packages(new PackageConstantTableEncoder(b));
            return Attribute("ModulePackages", b);
        }

        /// <summary>
        /// Adds a new ModuleMainClass attribute.
        /// </summary>
        /// <param name="mainClass"></param>
        public AttributeTableBuilder ModuleMainClass(ClassConstantHandle mainClass)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.TryWriteU2(mainClass.Index);
            return Attribute("ModuleMainClass", b);
        }

        /// <summary>
        /// Adds a new NestHost attribute.
        /// </summary>
        /// <param name="hostClass"></param>
        public AttributeTableBuilder NestHost(ClassConstantHandle hostClass)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.TryWriteU2(hostClass.Index);
            return Attribute("NestHost", b);
        }

        /// <summary>
        /// Adds a new NestMembers attribute.
        /// </summary>
        /// <param name="classes"></param>
        public AttributeTableBuilder NestMembers(Action<ClassConstantTableEncoder> classes)
        {
            var b = new BlobBuilder();
            classes(new ClassConstantTableEncoder(b));
            return Attribute("NestMembers", b);
        }

        /// <summary>
        /// Adds a new Record attribute.
        /// </summary>
        public AttributeTableBuilder Record(Action<RecordComponentTableEncoder> components)
        {
            var b = new BlobBuilder();
            components(new RecordComponentTableEncoder(b));
            return Attribute("Record", b);
        }

        /// <summary>
        /// Adds a new PermittedSubclasses attribute.
        /// </summary>
        /// <param name="classes"></param>
        public AttributeTableBuilder PermittedSubclasses(Action<ClassConstantTableEncoder> classes)
        {
            var b = new BlobBuilder();
            classes(new ClassConstantTableEncoder(b));
            return Attribute("PermittedSubclasses", b);
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
