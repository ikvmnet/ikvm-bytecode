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
        public void AddAttribute(Utf8ConstantHandle name, BlobBuilder data)
        {
            if (data != null && data.Count > 0)
            {
                var w = new ClassFormatWriter(Builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
                w.TryWriteU2(name.Value);
                w.TryWriteU2((ushort)data.Count);
                Builder.LinkSuffix(data);
                IncrementCount();
            }
            else
            {
                AddAttribute(name);
            }
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void AddAttribute(string name, BlobBuilder data)
        {
            AddAttribute(_constants.GetOrAddUtf8Constant(name), data);
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void AddAttribute(Utf8ConstantHandle name, ReadOnlySpan<byte> data)
        {
            if (data.Length > 0)
            {
                var w = new ClassFormatWriter(Builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
                w.TryWriteU2(name.Value);
                w.TryWriteU2((ushort)data.Length);
                Builder.WriteBytes(data);
                IncrementCount();
            }
            else
            {
                AddAttribute(name);
            }
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void AddAttribute(string name, ReadOnlySpan<byte> data)
        {
            AddAttribute(_constants.GetOrAddUtf8Constant(name), data);
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        public void AddAttribute(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(Builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(name.Value);
            w.TryWriteU2(0);
            IncrementCount();
        }

        /// <summary>
        /// Adds a new attribute to the attribute set.
        /// </summary>
        /// <param name="name"></param>
        public void AddAttribute(string name)
        {
            AddAttribute(_constants.GetOrAddUtf8Constant(name));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute.
        /// </summary>
        /// <param name="value"></param>
        public void AddConstantValueAttribute(ConstantHandle value)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.TryWriteU2(value.Value);
            AddAttribute("ConstantValue", b);
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public void AddConstantValueAttribute(int value)
        {
            AddConstantValueAttribute(_constants.GetOrAddIntegerConstant(value));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public void AddConstantValueAttribute(short value)
        {
            AddConstantValueAttribute(_constants.GetOrAddIntegerConstant(value));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public void AddConstantValueAttribute(char value)
        {
            AddConstantValueAttribute(_constants.GetOrAddIntegerConstant(value));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public void AddConstantValueAttribute(byte value)
        {
            AddConstantValueAttribute(_constants.GetOrAddIntegerConstant(value));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public void AddConstantValueAttribute(bool value)
        {
            AddConstantValueAttribute(_constants.GetOrAddIntegerConstant(value ? 1 : 0));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public void AddConstantValueAttribute(float value)
        {
            AddConstantValueAttribute(_constants.GetOrAddFloatConstant(value));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public void AddConstantValueAttribute(long value)
        {
            AddConstantValueAttribute(_constants.GetOrAddLongConstant(value));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public void AddConstantValueAttribute(double value)
        {
            AddConstantValueAttribute(_constants.GetOrAddDoubleConstant(value));
        }

        /// <summary>
        /// Adds a new ConstantValue attribute with the specified integer.
        /// </summary>
        /// <param name="value"></param>
        public void AddConstantValueAttribute(string value)
        {
            AddConstantValueAttribute(_constants.GetOrAddStringConstant(value));
        }

        /// <summary>
        /// Adds a new Code attribute.
        /// </summary>
        /// <param name="maxStack"></param>
        /// <param name="maxLocals"></param>
        /// <param name="code"></param>
        /// <param name="exceptions"></param>
        /// <param name="attributes"></param>
        public void AddCodeAttribute(ushort maxStack, ushort maxLocals, BlobBuilder code, in ExceptionTableBuilder exceptions, in AttributeTableBuilder attributes)
        {
            var b = new BlobBuilder();
            var w = new ClassFormatWriter(b.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U4).GetBytes());
            w.TryWriteU2(maxStack);
            w.TryWriteU2(maxLocals);
            w.TryWriteU4((uint)code.Count);
            b.LinkSuffix(code);
            exceptions.Serialize(b);
            attributes.Serialize(b);
            AddAttribute("Code", b);
        }

        /// <summary>
        /// Adds a new StackMapTable attribute.
        /// </summary>
        public void AddStackMapTableAttribute(in StackMapTableBuilder stackMapTable)
        {
            var b = new BlobBuilder();
            stackMapTable.Serialize(b);
            AddAttribute("StackMapTable", b);
        }

        /// <summary>
        /// Adds a new Exceptions attribute.
        /// </summary>
        public void AddExceptionsAttribute(in ClassConstantTableBuilder exceptions)
        {
            var b = new BlobBuilder();
            exceptions.Serialize(b);
            AddAttribute("Exceptions", b);
        }

        /// <summary>
        /// Adds a new InnerClasses attribute.
        /// </summary>
        /// <param name="classes"></param>
        public void AddInnerClassesAttribute(BlobBuilder classes)
        {
            AddAttribute("InnerClasses", classes);
        }

        /// <summary>
        /// Adds a new EnclosingMethod attribute.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        public void AddEnclosingMethodAttribute(ClassConstantHandle clazz, NameAndTypeConstantHandle method)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2 + ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.TryWriteU2(clazz.Value);
            w.TryWriteU2(method.Value);
            AddAttribute("EnclosingMethod", b);
        }

        /// <summary>
        /// Adds a new Synthetic attribute.
        /// </summary>
        public void AddSyntheticAttribute()
        {
            AddAttribute("Synthetic");
        }

        /// <summary>
        /// Adds a new Signature attribute.
        /// </summary>
        /// <param name="signature"></param>
        public void AddSignatureAttribute(Utf8ConstantHandle signature)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.TryWriteU2(signature.Value);
            AddAttribute("Signature", b);
        }

        /// <summary>
        /// Adds a new Signature attribute.
        /// </summary>
        /// <param name="signature"></param>
        public void AddSignatureAttribute(string signature)
        {
            AddSignatureAttribute(_constants.GetOrAddUtf8Constant(signature));
        }

        /// <summary>
        /// Adds a new SourceFile attribute.
        /// </summary>
        /// <param name="sourceFile"></param>
        public void AddSourceFileAttribute(Utf8ConstantHandle sourceFile)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.TryWriteU2(sourceFile.Value);
            AddAttribute("SourceFile", b);
        }

        /// <summary>
        /// Adds a new SourceFile attribute.
        /// </summary>
        /// <param name="sourceFile"></param>
        public void AddSourceFileAttribute(string sourceFile)
        {
            AddSourceFileAttribute(_constants.GetOrAddUtf8Constant(sourceFile));
        }

        /// <summary>
        /// Adds a new SourceDebugExtension attribute.
        /// </summary>
        /// <param name="debugExtension"></param>
        public void AddSourceDebugExtensionAttribute(BlobBuilder debugExtension)
        {
            AddAttribute("SourceDebugExtension", debugExtension);
        }

        /// <summary>
        /// Adds a new LineNumberTable attribute.
        /// </summary>
        public void AddLineNumberTableAttribute(in LineNumberTableBuilder lineNumbers)
        {
            var b = new BlobBuilder();
            lineNumbers.Serialize(b);
            AddAttribute("LineNumberTable", b);
        }

        /// <summary>
        /// Adds a new LocalVariableTable attribute.
        /// </summary>
        public void AddLocalVariableTableAttribute(BlobBuilder localVariableTable)
        {
            AddAttribute("LocalVariableTable", localVariableTable);
        }

        /// <summary>
        /// Adds a new LocalVariableTypeTable attribute.
        /// </summary>
        public void AddLocalVariableTypeTableAttribute(BlobBuilder localVariableTypeTable)
        {
            AddAttribute("LocalVariableTypeTable", localVariableTypeTable);
        }

        /// <summary>
        /// Adds a new Deprecated attribute.
        /// </summary>
        public void AddDeprecatedAttribute()
        {
            AddAttribute("Deprecated");
        }

        /// <summary>
        /// Adds a new RuntimeVisibleAnnotations attribute.
        /// </summary>
        /// <param name="annotations"></param>
        public void AddRuntimeVisibleAnnotationsAttribute(in AnnotationTableBuilder annotations)
        {
            var b = new BlobBuilder();
            annotations.Serialize(b);
            AddAttribute("RuntimeVisibleAnnotations", b);
        }

        /// <summary>
        /// Adds a new RuntimeInvisibleAnnotations attribute.
        /// </summary>
        public void AddRuntimeInvisibleAnnotationsAttribute(in AnnotationTableBuilder annotations)
        {
            var b = new BlobBuilder();
            annotations.Serialize(b);
            AddAttribute("RuntimeInvisibleAnnotations", b);
        }

        /// <summary>
        /// Adds a new RuntimeVisibleParameterAnnotations attribute.
        /// </summary>
        public void AddRuntimeVisibleParameterAnnotationsAttribute(BlobBuilder parameterAnnotations)
        {
            AddAttribute("RuntimeVisibleParameterAnnotations", parameterAnnotations);
        }

        /// <summary>
        /// Adds a new RuntimeInvisibleParameterAnnotations attribute.
        /// </summary>
        public void AddRuntimeInvisibleParametersAnnotationsAttribute(BlobBuilder parameterAnnotations)
        {
            AddAttribute("RuntimeInvisibleParameterAnnotations", parameterAnnotations);
        }

        /// <summary>
        /// Adds a new RuntimeVisibleTypeAnnotations attribute.
        /// </summary>
        /// <param name="typeAnnotations"></param>
        public void AddRuntimeVisibleTypeAnnotationsAttribute(BlobBuilder typeAnnotations)
        {
            AddAttribute("RuntimeVisibleTypeAnnotations", typeAnnotations);
        }

        /// <summary>
        /// Adds a new RuntimeInvisibleTypeAnnotations attribute.
        /// </summary>
        /// <param name="typeAnnotations"></param>
        public void AddRuntimeInvisibleTypeAnnotationsAttribute(BlobBuilder typeAnnotations)
        {
            AddAttribute("RuntimeInvisibleTypeAnnotations", typeAnnotations);
        }

        /// <summary>
        /// Adds a new AnnotationDefault attribute.
        /// </summary>
        /// <param name="defaultValue"></param>
        public void AddAnnotationDefaultAttribute(BlobBuilder defaultValue)
        {
            AddAttribute("AnnotationDefault", defaultValue);
        }

        /// <summary>
        /// Adds a new BootstrapMethods attribute.
        /// </summary>
        /// <param name="bootstrapMethods"></param>
        public void AddBootstrapMethodsAttribute(BlobBuilder bootstrapMethods)
        {
            AddAttribute("BootstrapMethods", bootstrapMethods);
        }

        /// <summary>
        /// Adds a new MethodParameters attribute.
        /// </summary>
        public void AddMethodParametersAttribute(BlobBuilder methodParameters)
        {
            AddAttribute("MethodParameters", methodParameters);
        }

        /// <summary>
        /// Adds a new Module attribute.
        /// </summary>
        /// <param name="module"></param>
        public void AddModuleAttribute(BlobBuilder module)
        {
            AddAttribute("Module", module);
        }

        /// <summary>
        /// Adds a new ModulePackages attribute.
        /// </summary>
        public void AddModulePackagesAttribute(BlobBuilder modulePackages)
        {
            AddAttribute("ModulePackages", modulePackages);
        }

        /// <summary>
        /// Adds a new ModuleMainClass attribute.
        /// </summary>
        /// <param name="mainClass"></param>
        public void AddModuleMainClassAttribute(ClassConstantHandle mainClass)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.TryWriteU2(mainClass.Value);
            AddAttribute("ModuleMainClass", b);
        }

        /// <summary>
        /// Adds a new NestHost attribute.
        /// </summary>
        /// <param name="hostClass"></param>
        public void AddNestHostAttribute(ClassConstantHandle hostClass)
        {
            var b = (Span<byte>)stackalloc byte[ClassFormatWriter.U2];
            var w = new ClassFormatWriter(b);
            w.TryWriteU2(hostClass.Value);
            AddAttribute("NestHost", b);
        }

        /// <summary>
        /// Adds a new NestMembers attribute.
        /// </summary>
        /// <param name="classes"></param>
        public void AddNestMembersAttribute(BlobBuilder classes)
        {
            AddAttribute("NestMembers", classes);
        }

        /// <summary>
        /// Adds a new Record attribute.
        /// </summary>
        public void AddRecordAttribute(BlobBuilder components)
        {
            AddAttribute("Record", components);
        }

        /// <summary>
        /// Adds a new PermittedSubclasses attribute.
        /// </summary>
        /// <param name="classes"></param>
        public void AddPermittedSubclassesAttribute(ClassConstantTableBuilder classes)
        {
            var b = new BlobBuilder();
            classes.Serialize(b);
            AddAttribute("PermittedSubclasses", b);
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
