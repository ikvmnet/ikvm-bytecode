using System;
using System.Buffers;

using IKVM.ByteCode.Buffers;

namespace IKVM.ByteCode.Encoding
{

    /// <summary>
    /// Provides an API for assembling a JVM attribute table.
    /// </summary>
    public struct AttributeTableEncoder
    {

        readonly BlobBuilder _builder;
        Blob _countBlob;
        int _count = 0;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AttributeTableEncoder(BlobBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _countBlob = _builder.ReserveBytes(ClassFormatWriter.U2);
            _count = 0;
        }

        /// <summary>
        /// Writes the count value.
        /// </summary>
        /// <param name="value"></param>
        readonly void WriteCount(int value)
        {
            new ClassFormatWriter(_countBlob.GetBytes()).WriteU2((ushort)value);
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
        /// <param name="attributeName"></param>
        /// <param name="data"></param>
        public AttributeTableEncoder Attribute(Utf8ConstantHandle attributeName, BlobBuilder data)
        {
            if (data != null && data.Count > 0)
            {
                var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U4).GetBytes());
                w.WriteU2(attributeName.Slot);
                w.WriteU4((uint)data.Count);
                _builder.LinkSuffix(data);
                IncrementCount();
                return this;
            }
            else
            {
                return Attribute(attributeName);
            }
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="attributeName"></param>
        /// <param name="data"></param>
        public AttributeTableEncoder Attribute(Utf8ConstantHandle attributeName, ReadOnlySpan<byte> data)
        {
            if (data.Length > 0)
            {
                var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U4).GetBytes());
                w.WriteU2(attributeName.Slot);
                w.WriteU4((uint)data.Length);
                _builder.WriteBytes(data);
                IncrementCount();
                return this;
            }
            else
            {
                return Attribute(attributeName);
            }
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="attributeName"></param>
        /// <param name="data"></param>
        public AttributeTableEncoder Attribute(Utf8ConstantHandle attributeName, ReadOnlySequence<byte> data)
        {
            if (data.Length > 0)
            {
                var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U4).GetBytes());
                w.WriteU2(attributeName.Slot);
                w.WriteU4((uint)data.Length);
                _builder.WriteBytes(data);
                IncrementCount();
                return this;
            }
            else
            {
                return Attribute(attributeName);
            }
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="attributeName"></param>
        public AttributeTableEncoder Attribute(Utf8ConstantHandle attributeName)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U4).GetBytes());
            w.WriteU2(attributeName.Slot);
            w.WriteU4(0);
            IncrementCount();
            return this;
        }

        /// <summary>
        /// Adds a new ConstantValue attribute.
        /// </summary>
        /// <param name="constantName"></param>
        /// <param name="value"></param>
        public AttributeTableEncoder ConstantValue(Utf8ConstantHandle attributeName, ConstantHandle value)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.WriteU2(value.Slot);
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new Code attribute.
        /// </summary>
        /// <param name="maxStack"></param>
        /// <param name="maxLocals"></param>
        /// <param name="code"></param>
        /// <param name="exceptions"></param>
        /// <param name="attributes"></param>
        public AttributeTableEncoder Code(Utf8ConstantHandle attributeName, ushort maxStack, ushort maxLocals, BlobBuilder code, Action<ExceptionTableEncoder> exceptions, AttributeTableBuilder attributes)
        {
            if (code is null)
                throw new ArgumentNullException(nameof(code));
            if (exceptions is null)
                throw new ArgumentNullException(nameof(exceptions));
            if (attributes is null)
                throw new ArgumentNullException(nameof(attributes));

            var b = new BlobBuilder();
            var w = new ClassFormatWriter(b.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U4).GetBytes());
            w.WriteU2(maxStack);
            w.WriteU2(maxLocals);
            w.WriteU4((uint)code.Count);
            b.LinkSuffix(code);
            exceptions(new ExceptionTableEncoder(b));
            attributes.Serialize(b);
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new StackMapTable attribute.
        /// </summary>
        public AttributeTableEncoder StackMapTable(Utf8ConstantHandle attributeName, Action<StackMapTableEncoder> stackMapTable)
        {
            if (stackMapTable is null)
                throw new ArgumentNullException(nameof(stackMapTable));

            var b = new BlobBuilder();
            stackMapTable(new StackMapTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new Exceptions attribute.
        /// </summary>
        public AttributeTableEncoder Exceptions(Utf8ConstantHandle attributeName, Action<ClassConstantTableEncoder> exceptions)
        {
            if (exceptions is null)
                throw new ArgumentNullException(nameof(exceptions));

            var b = new BlobBuilder();
            exceptions(new ClassConstantTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new InnerClasses attribute.
        /// </summary>
        /// <param name="classes"></param>
        public AttributeTableEncoder InnerClasses(Utf8ConstantHandle attributeName, Action<InnerClassTableEncoder> classes)
        {
            if (classes is null)
                throw new ArgumentNullException(nameof(classes));

            var b = new BlobBuilder();
            classes(new InnerClassTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new EnclosingMethod attribute.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        public AttributeTableEncoder EnclosingMethod(Utf8ConstantHandle attributeName, ClassConstantHandle clazz, NameAndTypeConstantHandle method)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2 + ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.WriteU2(clazz.Slot);
            w.WriteU2(method.Slot);
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new Synthetic attribute.
        /// </summary>
        public AttributeTableEncoder Synthetic(Utf8ConstantHandle attributeName)
        {
            return Attribute(attributeName);
        }

        /// <summary>
        /// Adds a new Signature attribute.
        /// </summary>
        /// <param name="signature"></param>
        public AttributeTableEncoder Signature(Utf8ConstantHandle attributeName, Utf8ConstantHandle signature)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.WriteU2(signature.Slot);
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new SourceFile attribute.
        /// </summary>
        /// <param name="sourceFile"></param>
        public AttributeTableEncoder SourceFile(Utf8ConstantHandle attributeName, Utf8ConstantHandle sourceFile)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.WriteU2(sourceFile.Slot);
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new SourceDebugExtension attribute.
        /// </summary>
        /// <param name="debugExtension"></param>
        public AttributeTableEncoder SourceDebugExtension(Utf8ConstantHandle attributeName, BlobBuilder debugExtension)
        {
            return Attribute(attributeName, debugExtension);
        }

        /// <summary>
        /// Adds a new LineNumberTable attribute.
        /// </summary>
        public AttributeTableEncoder LineNumberTable(Utf8ConstantHandle attributeName, Action<LineNumberTableEncoder> lineNumbers)
        {
            if (lineNumbers is null)
                throw new ArgumentNullException(nameof(lineNumbers));

            var b = new BlobBuilder();
            lineNumbers(new LineNumberTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new LocalVariableTable attribute.
        /// </summary>
        public AttributeTableEncoder LocalVariableTable(Utf8ConstantHandle attributeName, Action<LocalVariableTableEncoder> localVars)
        {
            if (localVars is null)
                throw new ArgumentNullException(nameof(localVars));

            var b = new BlobBuilder();
            localVars(new LocalVariableTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new LocalVariableTypeTable attribute.
        /// </summary>
        public AttributeTableEncoder LocalVariableTypeTable(Utf8ConstantHandle attributeName, Action<LocalVariableTypeTableEncoder> localVarTypes)
        {
            if (localVarTypes is null)
                throw new ArgumentNullException(nameof(localVarTypes));

            var b = new BlobBuilder();
            localVarTypes(new LocalVariableTypeTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new Deprecated attribute.
        /// </summary>
        public AttributeTableEncoder Deprecated(Utf8ConstantHandle attributeName)
        {
            return Attribute(attributeName);
        }

        /// <summary>
        /// Adds a new RuntimeVisibleAnnotations attribute.
        /// </summary>
        /// <param name="annotations"></param>
        public AttributeTableEncoder RuntimeVisibleAnnotations(Utf8ConstantHandle attributeName, Action<AnnotationTableEncoder> annotations)
        {
            if (annotations is null)
                throw new ArgumentNullException(nameof(annotations));

            var b = new BlobBuilder();
            annotations(new AnnotationTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new RuntimeInvisibleAnnotations attribute.
        /// </summary>
        public AttributeTableEncoder RuntimeInvisibleAnnotations(Utf8ConstantHandle attributeName, Action<AnnotationTableEncoder> annotations)
        {
            if (annotations is null)
                throw new ArgumentNullException(nameof(annotations));

            var b = new BlobBuilder();
            annotations(new AnnotationTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new RuntimeVisibleParameterAnnotations attribute.
        /// </summary>
        public AttributeTableEncoder RuntimeVisibleParameterAnnotations(Utf8ConstantHandle attributeName, Action<ParameterAnnotationTableEncoder> parameterAnnotations)
        {
            if (parameterAnnotations is null)
                throw new ArgumentNullException(nameof(parameterAnnotations));

            var b = new BlobBuilder();
            parameterAnnotations(new ParameterAnnotationTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new RuntimeInvisibleParameterAnnotations attribute.
        /// </summary>
        public AttributeTableEncoder RuntimeInvisibleParameterAnnotations(Utf8ConstantHandle attributeName, Action<ParameterAnnotationTableEncoder> parameterAnnotations)
        {
            if (parameterAnnotations is null)
                throw new ArgumentNullException(nameof(parameterAnnotations));

            var b = new BlobBuilder();
            parameterAnnotations(new ParameterAnnotationTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new RuntimeVisibleTypeAnnotations attribute.
        /// </summary>
        /// <param name="typeAnnotations"></param>
        public AttributeTableEncoder RuntimeVisibleTypeAnnotations(Utf8ConstantHandle attributeName, Action<TypeAnnotationTableEncoder> typeAnnotations)
        {
            if (typeAnnotations is null)
                throw new ArgumentNullException(nameof(typeAnnotations));

            var b = new BlobBuilder();
            typeAnnotations(new TypeAnnotationTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new RuntimeInvisibleTypeAnnotations attribute.
        /// </summary>
        /// <param name="typeAnnotations"></param>
        public AttributeTableEncoder RuntimeInvisibleTypeAnnotations(Utf8ConstantHandle attributeName, Action<TypeAnnotationTableEncoder> typeAnnotations)
        {
            if (typeAnnotations is null)
                throw new ArgumentNullException(nameof(typeAnnotations));

            var b = new BlobBuilder();
            typeAnnotations(new TypeAnnotationTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new AnnotationDefault attribute.
        /// </summary>
        /// <param name="defaultValue"></param>
        public AttributeTableEncoder AnnotationDefault(Utf8ConstantHandle attributeName, Action<ElementValueEncoder> defaultValue)
        {
            if (defaultValue is null)
                throw new ArgumentNullException(nameof(defaultValue));

            var b = new BlobBuilder();
            defaultValue(new ElementValueEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new BootstrapMethods attribute.
        /// </summary>
        /// <param name="bootstrapMethods"></param>
        public AttributeTableEncoder BootstrapMethods(Utf8ConstantHandle attributeName, Action<BootstrapMethodTableEncoder> bootstrapMethods)
        {
            if (bootstrapMethods is null)
                throw new ArgumentNullException(nameof(bootstrapMethods));

            var b = new BlobBuilder();
            bootstrapMethods(new BootstrapMethodTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new MethodParameters attribute.
        /// </summary>
        public AttributeTableEncoder MethodParameters(Utf8ConstantHandle attributeName, Action<MethodParameterTableEncoder> parameters)
        {
            if (parameters is null)
                throw new ArgumentNullException(nameof(parameters));

            var b = new BlobBuilder();
            parameters(new MethodParameterTableEncoder(b));
            return Attribute(attributeName, b);
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
        public AttributeTableEncoder Module(Utf8ConstantHandle attributeName, ModuleConstantHandle name, ModuleFlag flags, Utf8ConstantHandle version, Action<ModuleRequiresTableEncoder> requires, Action<ModuleExportsTableEncoder> exports, Action<ModuleOpensTableEncoder> opens, Action<ClassConstantTableEncoder> uses, Action<ModuleProvidesTableEncoder> provides)
        {
            if (requires is null)
                throw new ArgumentNullException(nameof(requires));
            if (exports is null)
                throw new ArgumentNullException(nameof(exports));
            if (opens is null)
                throw new ArgumentNullException(nameof(opens));
            if (uses is null)
                throw new ArgumentNullException(nameof(uses));
            if (provides is null)
                throw new ArgumentNullException(nameof(provides));

            var b = new BlobBuilder();
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.WriteU2(name.Slot);
            w.WriteU2((ushort)flags);
            w.WriteU2(version.Slot);
            requires(new ModuleRequiresTableEncoder(b));
            exports(new ModuleExportsTableEncoder(b));
            opens(new ModuleOpensTableEncoder(b));
            uses(new ClassConstantTableEncoder(b));
            provides(new ModuleProvidesTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new ModulePackages attribute.
        /// </summary>
        public AttributeTableEncoder ModulePackages(Utf8ConstantHandle attributeName, Action<PackageConstantTableEncoder> packages)
        {
            var b = new BlobBuilder();
            packages(new PackageConstantTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new ModuleMainClass attribute.
        /// </summary>
        /// <param name="mainClass"></param>
        public AttributeTableEncoder ModuleMainClass(Utf8ConstantHandle attributeName, ClassConstantHandle mainClass)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.WriteU2(mainClass.Slot);
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new NestHost attribute.
        /// </summary>
        /// <param name="nestHost"></param>
        public AttributeTableEncoder NestHost(Utf8ConstantHandle attributeName, ClassConstantHandle nestHost)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.WriteU2(nestHost.Slot);
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new NestMembers attribute.
        /// </summary>
        /// <param name="classes"></param>
        public AttributeTableEncoder NestMembers(Utf8ConstantHandle attributeName, Action<ClassConstantTableEncoder> classes)
        {
            var b = new BlobBuilder();
            classes(new ClassConstantTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new Record attribute.
        /// </summary>
        public AttributeTableEncoder Record(Utf8ConstantHandle attributeName, Action<RecordComponentTableEncoder> components)
        {
            var b = new BlobBuilder();
            components(new RecordComponentTableEncoder(b));
            return Attribute(attributeName, b);
        }

        /// <summary>
        /// Adds a new PermittedSubclasses attribute.
        /// </summary>
        /// <param name="classes"></param>
        public AttributeTableEncoder PermittedSubclasses(Utf8ConstantHandle attributeName, Action<ClassConstantTableEncoder> classes)
        {
            var b = new BlobBuilder();
            classes(new ClassConstantTableEncoder(b));
            return Attribute(attributeName, b);
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
                new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U2).GetBytes()).WriteU2(0);
        }

    }

}
