using System;
using System.Buffers;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Reading;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Provides methods to encode entities from an existing <see cref="ClassFile"/>.
    /// </summary>
    public partial class ClassFileImporter
    {

        readonly ClassFile _source;
        readonly ConstantBuilder _constants;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public ClassFileImporter(in ConstantTable _source, ConstantBuilder destination)
        {
            this._source = source ?? throw new System.ArgumentNullException(nameof(source));
            this._constants = destination ?? throw new System.ArgumentNullException(nameof(destination));
        }

        ConstantHandle Import(ConstantHandle handle)
        {
            return _source.GetKind(handle) switch
            {
                ConstantKind.Fieldref => Import((RefConstantHandle)handle),
                ConstantKind.Methodref => Import((RefConstantHandle)handle),
                ConstantKind.InterfaceMethodref => Import((RefConstantHandle)handle),
                ConstantKind.Utf8 => Import((Utf8ConstantHandle)handle),
                ConstantKind.Integer => Import((IntegerConstantHandle)handle),
                ConstantKind.Float => Import((FloatConstantHandle)handle),
                ConstantKind.Long => Import((LongConstantHandle)handle),
                ConstantKind.Double => Import((DoubleConstantHandle)handle),
                ConstantKind.Class => Import((ClassConstantHandle)handle),
                ConstantKind.String => Import((StringConstantHandle)handle),
                ConstantKind.NameAndType => Import((NameAndTypeConstantHandle)handle),
                ConstantKind.MethodHandle => Import((MethodHandleConstantHandle)handle),
                ConstantKind.MethodType => Import((MethodTypeConstantHandle)handle),
                ConstantKind.Dynamic => Import((DynamicConstantHandle)handle),
                ConstantKind.InvokeDynamic => Import((InvokeDynamicConstantHandle)handle),
                ConstantKind.Module => Import((ModuleConstantHandle)handle),
                ConstantKind.Package => Import((PackageConstantHandle)handle),
                _ => throw new ByteCodeException("Unknown ConstantHandle kind."),
            };
        }

        RefConstantHandle Import(RefConstantHandle handle)
        {
            return _source.GetKind(handle) switch
            {
                ConstantKind.Fieldref => (RefConstantHandle)Import((FieldrefConstantHandle)handle),
                ConstantKind.Methodref => (RefConstantHandle)Import((MethodrefConstantHandle)handle),
                ConstantKind.InterfaceMethodref => (RefConstantHandle)Import((InterfaceMethodrefConstantHandle)handle),
                _ => throw new ByteCodeException("Unknown RefConstantHandle kind."),
            };
        }

        Utf8ConstantHandle Import(Utf8ConstantHandle handle)
        {
            return _constants.GetOrAddUtf8(_source.GetUtf8Value(handle));
        }

        IntegerConstantHandle Import(IntegerConstantHandle handle)
        {
            return _constants.GetOrAddInteger(_source.GetIntegerValue(handle));
        }

        FloatConstantHandle Import(FloatConstantHandle handle)
        {
            return _constants.GetOrAddFloat(_source.GetFloatValue(handle));
        }

        LongConstantHandle Import(LongConstantHandle handle)
        {
            return _constants.GetOrAddLong(_source.GetLongValue(handle));
        }

        DoubleConstantHandle Import(DoubleConstantHandle handle)
        {
            return _constants.GetOrAddDouble(_source.GetDoubleValue(handle));
        }

        ClassConstantHandle Import(ClassConstantHandle handle)
        {
            return _constants.GetOrAddClass(_source.GetClassName(handle));
        }

        StringConstantHandle Import(StringConstantHandle handle)
        {
            return _constants.GetOrAddString(_source.GetStringValue(handle));
        }

        FieldrefConstantHandle Import(FieldrefConstantHandle handle)
        {
            var i = _source.GetFieldref(handle);
            return i.IsNotNil ? _constants.GetOrAddFieldref(Import(i.Class), Import(i.NameAndType)) : default;
        }

        MethodrefConstantHandle Import(MethodrefConstantHandle handle)
        {
            var i = _source.GetMethodref(handle);
            return i.IsNotNil ? _constants.GetOrAddMethodref(Import(i.Class), Import(i.NameAndType)) : default;
        }

        InterfaceMethodrefConstantHandle Import(InterfaceMethodrefConstantHandle handle)
        {
            var i = _source.GetInterfaceMethodref(handle);
            return i.IsNotNil ? _constants.GetOrAddInterfaceref(Import(i.Class), Import(i.NameAndType)) : default;
        }

        NameAndTypeConstantHandle Import(NameAndTypeConstantHandle handle)
        {
            var i = _source.GetNameAndType(handle);
            return i.IsNotNil ? _constants.GetOrAddNameAndType(Import(i.Name), Import(i.Descriptor)) : default;
        }

        MethodHandleConstantHandle Import(MethodHandleConstantHandle handle)
        {
            var i = _source.GetMethodHandle(handle);
            return i.IsNotNil ? _constants.AddMethodHandle(i.ReferenceKind, Import(i.Reference)) : default;
        }

        MethodTypeConstantHandle Import(MethodTypeConstantHandle handle)
        {
            var i = _source.GetMethodType(handle);
            return i.IsNotNil ? _constants.GetOrAddMethodType(Import(i.Descriptor)) : default;
        }

        DynamicConstantHandle Import(DynamicConstantHandle handle)
        {
            var i = _source.GetDynamic(handle);
            return i.IsNotNil ? _constants.GetOrAddDynamic(i.BootstrapMethodAttributeIndex, Import(i.NameAndType)) : default;
        }

        InvokeDynamicConstantHandle Import(InvokeDynamicConstantHandle handle)
        {
            var i = _source.GetInvokeDynamic(handle);
            return i.IsNotNil ? _constants.GetOrAddInvokeDynamic(i.BootstrapMethodAttributeIndex, Import(i.NameAndType)) : default;
        }

        ModuleConstantHandle Import(ModuleConstantHandle handle)
        {
            return _constants.GetOrAddModule(_source.GetModuleName(handle));
        }

        PackageConstantHandle Import(PackageConstantHandle handle)
        {
            return _constants.GetOrAddPackage(_source.GetPackageName(handle));
        }

        public void Import(Annotation source, ref AnnotationEncoder encoder)
        {
            encoder.Annotation(Import(source.Type), e =>
            {
                foreach (var i in source)
                    Import(i, ref e);
            });
        }

        public void Import(AnnotationTable source, ref AnnotationTableEncoder encoder)
        {
            foreach (var i in source)
                encoder.Annotation(e => Import(i, ref e));
        }

        public AttributeTableBuilder Import(AttributeTable source)
        {
            var b = new AttributeTableBuilder(_constants);
            Import(source, b);
            return b;
        }

        public void Import(AttributeTable source, AttributeTableBuilder builder)
        {
            foreach (var i in source)
                Import(i, builder);
        }

        public void Import(ConstantValueAttribute source, AttributeTableBuilder builder)
        {
            builder.ConstantValue(Import(source.Value));
        }

        public void Import(CodeAttribute source, AttributeTableBuilder builder)
        {
            throw new NotImplementedException("Cannot import the Code attribute since we are currently unable to parse byte code.");

            var b = new BlobBuilder();
            var s = b.ReserveBytes((int)source.Code.Length);
            source.Code.CopyTo(s.GetBytes());
            builder.Code(source.MaxStack, source.MaxLocals, b, e => Import(source.ExceptionTable, ref e), Import(source.Attributes));
        }

        public void Import(StackMapTableAttribute source, AttributeTableBuilder builder)
        {
            builder.StackMapTable(e => Import(source, ref e));
        }

        public void Import(StackMapTableAttribute source, ref StackMapTableEncoder encoder)
        {
            foreach (var i in source.Frames)
                Import(i, ref encoder);
        }

        public void Import(StackMapFrame source, ref StackMapTableEncoder encoder)
        {
            source.FrameType switch
            {
                <= 63 => SameStackMapFrame.TryMeasure(null),
                >= 64 and <= 127 => SameLocalsOneStackMapFrame.TryMeasure(null),
                247 => SameLocalsOneExtendedStackMapFrame.TryMeasure(null),
                >= 248 and <= 250 => ChopStackMapFrame.TryMeasure(null),
                251 => SameExtendedStackMapFrame.TryMeasure(null),
                >= 252 and <= 254 => AppendStackMapFrame.TryMeasure(null),
                255 => FullStackMapFrame.TryMeasure(null),
            };
        }
        }

        public void Import(ExceptionHandlerTable source, ref ExceptionTableEncoder encoder)
        {
            foreach (var i in source)
                Import(i, ref encoder);
        }

        public void Import(ExceptionHandler source, ref ExceptionTableEncoder encoder)
        {
            encoder.Exception(source.StartOffset, source.EndOffset, source.HandlerOffset, Import(source.CatchType));
        }

        public void Import(ElementValuePair source, ref ElementValuePairTableEncoder encoder)
        {
            encoder.Element(Import(source.Name), e => Import(source.Value, ref e));
        }

        public void Import(ElementValue source, ref ElementValueEncoder encoder)
        {
            switch (source.Kind)
            {
                case ElementValueKind.Byte:
                    var _byte = source.AsConstant();
                    encoder.Byte(Import((IntegerConstantHandle)_byte.Handle));
                    break;
                case ElementValueKind.Char:
                    var _char = source.AsConstant();
                    encoder.Char(Import((IntegerConstantHandle)_char.Handle));
                    break;
                case ElementValueKind.Double:
                    var _double = source.AsConstant();
                    encoder.Double(Import((DoubleConstantHandle)_double.Handle));
                    break;
                case ElementValueKind.Float:
                    var _float = source.AsConstant();
                    encoder.Float(Import((FloatConstantHandle)_float.Handle));
                    break;
                case ElementValueKind.Integer:
                    var _integer = source.AsConstant();
                    encoder.Integer(Import((IntegerConstantHandle)_integer.Handle));
                    break;
                case ElementValueKind.Long:
                    var _long = source.AsConstant();
                    encoder.Long(Import((LongConstantHandle)_long.Handle));
                    break;
                case ElementValueKind.Short:
                    var _short = source.AsConstant();
                    encoder.Short(Import((IntegerConstantHandle)_short.Handle));
                    break;
                case ElementValueKind.Boolean:
                    var _boolean = source.AsConstant();
                    encoder.Boolean(Import((IntegerConstantHandle)_boolean.Handle));
                    break;
                case ElementValueKind.String:
                    var _string = source.AsConstant();
                    encoder.String(Import((Utf8ConstantHandle)_string.Handle));
                    break;
                case ElementValueKind.Enum:
                    var _enum = source.AsEnum();
                    encoder.Enum(Import(_enum.TypeName), Import(_enum.ConstantName));
                    break;
                case ElementValueKind.Class:
                    var _class = source.AsClass();
                    encoder.Class(Import(_class.Class));
                    break;
                case ElementValueKind.Annotation:
                    var _annotation = source.AsAnnotation();
                    encoder.Annotation(e => Import(_annotation.Annotation, ref e));
                    break;
                case ElementValueKind.Array:
                    break;
            }

        }

    }

}
