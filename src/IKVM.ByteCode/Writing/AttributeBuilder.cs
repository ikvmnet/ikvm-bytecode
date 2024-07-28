using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Provides the capability to write a set of attributes.
    /// </summary>
    public class AttributeBuilder
    {

        readonly ConstantBuilder _constants;
        readonly BlobBuilder _builder = new();
        ushort _count = 0;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="constants"></param>
        public AttributeBuilder(ConstantBuilder constants)
        {
            _constants = constants ?? throw new ArgumentNullException(nameof(constants));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="clazz"></param>
        public AttributeBuilder(ClassBuilder clazz) :
            this(clazz.Constants)
        {

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
                var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
                w.TryWriteU2(name.Value);
                w.TryWriteU2((ushort)data.Count);
                _builder.LinkSuffix(data);
                _count++;
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
                var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
                w.TryWriteU2(name.Value);
                w.TryWriteU2((ushort)data.Length);
                _builder.WriteBytes(data);
                _count++;
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
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(name.Value);
            w.TryWriteU2(0);
            _count++;
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
        /// Adds a new Code attribute.
        /// </summary>
        /// <param name="maxStack"></param>
        /// <param name="maxLocals"></param>
        /// <param name="code"></param>
        /// <param name="exceptionsTable"></param>
        /// <param name="attributes"></param>
        public void AddCodeAttribute(ushort maxStack, ushort maxLocals, BlobBuilder code, BlobBuilder exceptionsTable, BlobBuilder attributes)
        {
            var b = new BlobBuilder();
            var w = new ClassFormatEncoder(b);
            w.WriteU2(maxStack);
            w.WriteU2(maxLocals);
            w.WriteU4((uint)code.Count);
            b.LinkSuffix(code);
            b.LinkSuffix(exceptionsTable);
            b.LinkSuffix(attributes);
            AddAttribute("Code", b);
        }

        /// <summary>
        /// Adds a new StackMapTable attribute.
        /// </summary>
        public void AddStackMapTableAttribute(BlobBuilder stackMapTable)
        {
            AddAttribute("StackMapTable", stackMapTable);
        }

        /// <summary>
        /// Adds a new Exceptions attribute.
        /// </summary>
        public void AddExceptionsAttribute(BlobBuilder exceptions)
        {
            AddAttribute("Exceptions", exceptions);
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
        public void AddLineNumberTableAttribute(BlobBuilder lineNumberTable)
        {
            AddAttribute("LineNumberTable", lineNumberTable);
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
        public void AddRuntimeVisibleAnnotationsAttribute(BlobBuilder annotations)
        {
            AddAttribute("RuntimeVisibleAnnotations", annotations);
        }

        /// <summary>
        /// Adds a new RuntimeInvisibleAnnotations attribute.
        /// </summary>
        public void AddRuntimeInvisibleAnnotationsAttribute(BlobBuilder annotations)
        {
            AddAttribute("RuntimeInvisibleAnnotations", annotations);
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
        public void AddPermittedSubclassesAttribute(BlobBuilder classes)
        {
            AddAttribute("PermittedSubclasses", classes);
        }

        /// <summary>
        /// Serializes the attributes to the specified builder.
        /// </summary>
        /// <param name="builder"></param>
        public void Serialize(BlobBuilder builder)
        {
            var w = new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(_count);
            builder.LinkSuffix(_builder);
        }

    }

}
