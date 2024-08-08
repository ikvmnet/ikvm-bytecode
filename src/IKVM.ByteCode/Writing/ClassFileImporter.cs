using System;
using System.Buffers;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Reading;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Provides methods to encode entities loaded from an existing <see cref="ClassFile"/>.
    /// </summary>
    public partial class ClassFileImporter
    {

        readonly ConstantTable _source;
        readonly ConstantBuilder _constants;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public ClassFileImporter(ConstantTable source, ConstantBuilder destination)
        {
            this._source = source ?? throw new ArgumentNullException(nameof(source));
            this._constants = destination ?? throw new ArgumentNullException(nameof(destination));
        }

        /// <summary>
        /// Imports a <see cref="ConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
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

        /// <summary>
        /// Imports a <see cref="RefConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
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

        /// <summary>
        /// Imports a <see cref="Annotation"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="encoder"></param>
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

        public void Import(ExceptionsAttribute source, AttributeTableBuilder builder)
        {
            builder.Exceptions(e => Import(source, ref e));
        }

        public void Import(InnerClassesAttribute source, AttributeTableBuilder builder)
        {
            builder.InnerClasses(e => Import(source, ref e));
        }

        public void Import(EnclosingMethodAttribute source, AttributeTableBuilder builder)
        {
            builder.EnclosingMethod(Import(source.Class), Import(source.Method));
        }

        public void Import(SyntheticAttribute source, AttributeTableBuilder builder)
        {
            builder.Synthetic();
        }

        public void Import(SignatureAttribute source, AttributeTableBuilder builder)
        {
            builder.Signature(Import(source.Signature));
        }

        public void Import(SourceFileAttribute source, AttributeTableBuilder builder)
        {
            builder.SourceFile(Import(source.SourceFile));
        }

        public void Import(SourceDebugExtensionAttribute source, AttributeTableBuilder builder)
        {
            var b = new BlobBuilder();
            source.Data.CopyTo(b.ReserveBytes((int)source.Data.Length).GetBytes().AsSpan());
            builder.SourceDebugExtension(b);
        }

        public void Import(LineNumberTableAttribute source, AttributeTableBuilder builder)
        {
            builder.LineNumberTable(e => Import(source.LineNumbers, ref e));
        }

        public void Import(LocalVariableTableAttribute source, AttributeTableBuilder builder)
        {
            builder.LocalVariableTable(e => Import(source.LocalVariables, ref e));
        }

        public void Import(LocalVariableTypeTableAttribute source, AttributeTableBuilder builder)
        {
            builder.LocalVariableTypeTable(e => Import(source.LocalVariableTypes, ref e));
        }

        public void Import(DeprecatedAttribute source, AttributeTableBuilder builder)
        {
            builder.Deprecated();
        }

        public void Import(RuntimeVisibleAnnotationsAttribute source, AttributeTableBuilder builder)
        {
            builder.RuntimeVisibleAnnotations(e => Import(source.Annotations, ref e));
        }

        public void Import(RuntimeInvisibleAnnotationsAttribute source, AttributeTableBuilder builder)
        {
            builder.RuntimeInvisibleAnnotations(e => Import(source.Annotations, ref e));
        }

        public void Import(RuntimeVisibleTypeAnnotationsAttribute source, AttributeTableBuilder builder)
        {
            builder.RuntimeVisibleTypeAnnotations(e => Import(source.Annotations, ref e));
        }

        public void Import(RuntimeInvisibleTypeAnnotationsAttribute source, AttributeTableBuilder builder)
        {
            builder.RuntimeInvisibleTypeAnnotations(e => Import(source.Annotations, ref e));
        }

        public void Import(RuntimeVisibleParameterAnnotationsAttribute source, AttributeTableBuilder builder)
        {
            builder.RuntimeVisibleParameterAnnotations(e => Import(source.Parameters, ref e));
        }

        public void Import(RuntimeInvisibleParameterAnnotationsAttribute source, AttributeTableBuilder builder)
        {
            builder.RuntimeInvisibleParametersAnnotations(e => Import(source.Parameters, ref e));
        }

        public void Import(AnnotationDefaultAttribute source, AttributeTableBuilder builder)
        {
            builder.AnnotationDefault(e => Import(source.DefaultValue, ref e));
        }

        public void Import(BootstrapMethodsAttribute source, AttributeTableBuilder builder)
        {
            builder.BootstrapMethods(e => Import(source.Methods, ref e));
        }

        public void Import(MethodParametersAttribute source, AttributeTableBuilder builder)
        {
            builder.MethodParameters(e => Import(source.Parameters, ref e));
        }

        public void Import(ModuleAttribute source, AttributeTableBuilder builder)
        {
            builder.Module(Import(source.Name), source.Flags, Import(source.Version), e => Import(source.Requires, ref e), e => Import(source.Exports, ref e), e => Import(source.Opens, ref e), e => Import(source.Uses, ref e), e => Import(source.Provides, ref e));
        }

        public void Import(ModulePackagesAttribute source, AttributeTableBuilder builder)
        {
            builder.ModulePackages(e => Import(source, ref e));
        }

        public void Import(ModuleMainClassAttribute source, AttributeTableBuilder builder)
        {
            builder.ModuleMainClass(Import(source.MainClass));
        }

        public void Import(NestHostAttribute source, AttributeTableBuilder builder)
        {
            builder.NestHost(Import(source.NestHost));
        }

        public void Import(NestMembersAttribute source, AttributeTableBuilder builder)
        {
            builder.NestMembers(e => Import(source, ref e));
        }

        public void Import(RecordAttribute source, AttributeTableBuilder builder)
        {
            builder.Record(e => Import(source.Components, ref e));
        }

        public void Import(PermittedSubclassesAttribute source, AttributeTableBuilder builder)
        {
            builder.PermittedSubclasses(e => Import(source, ref e));
        }

        public void Import(PermittedSubclassesAttribute source, ref ClassConstantTableEncoder encoder)
        {
            Import(source.PermittedSubclasses, ref encoder);
        }

        public void Import(RecordComponentTable source, ref RecordComponentTableEncoder encoder)
        {
            foreach (var i in source)
                Import(i, ref encoder);
        }

        public void Import(RecordComponent source, ref RecordComponentTableEncoder encoder)
        {
            encoder.RecordComponent(Import(source.Name), Import(source.Descriptor), Import(source.Attributes));
        }

        public void Import(NestMembersAttribute source, ref ClassConstantTableEncoder encoder)
        {
            Import(source.NestMembers, ref encoder);
        }

        public void Import(ModulePackagesAttribute source, ref PackageConstantTableEncoder encoder)
        {
            Import(source.Packages, ref encoder);
        }

        public void Import(PackageConstantHandleTable source, ref PackageConstantTableEncoder encoder)
        {
            foreach (var i in source)
                Import(i, ref encoder);
        }

        public void Import(PackageConstantHandle source, ref PackageConstantTableEncoder encoder)
        {
            encoder.PackageConstant(Import(source));
        }

        public void Import(ModuleRequiresTable source, ref ModuleRequiresTableEncoder encoder)
        {
            foreach (var i in source)
                Import(i, ref encoder);
        }

        public void Import(ModuleRequireInfo source, ref ModuleRequiresTableEncoder encoder)
        {
            encoder.Requires(Import(source.Module), source.Flag, Import(source.Version));
        }

        public void Import(ModuleExportsTable source, ref ModuleExportsTableEncoder encoder)
        {
            foreach (var i in source)
                Import(i, ref encoder);
        }

        public void Import(ModuleExportInfo source, ref ModuleExportsTableEncoder encoder)
        {
            encoder.Exports(Import(source.Package), source.Flags, e => Import(source.Modules, ref e));
        }

        public void Import(ModuleOpensTable source, ref ModuleOpensTableEncoder encoder)
        {
            foreach (var i in source)
                Import(i, ref encoder);
        }

        public void Import(ModuleOpenInfo source, ref ModuleOpensTableEncoder encoder)
        {
            encoder.Opens(Import(source.Package), source.Flags, e => Import(source.Modules, ref e));
        }

        private void Import(ModuleConstantHandleTable source, ref ModuleTableEncoder encoder)
        {
            foreach (var i in source)
                encoder.Module(Import(i));
        }

        public void Import(ModuleProvidesTable source, ref ModuleProvidesTableEncoder encoder)
        {
            foreach (var i in source)
                Import(i, ref encoder);
        }

        public void Import(ModuleProvideInfo source, ref ModuleProvidesTableEncoder encoder)
        {
            encoder.Provides(Import(source.Class), e => Import(source.With, ref e));
        }

        private void Import(ClassConstantHandleTable source, ref ClassConstantTableEncoder encoder)
        {
            foreach (var i in source)
                encoder.Class(Import(i));
        }

        public void Import(MethodParameterTable source, ref MethodParameterTableEncoder encoder)
        {
            foreach (var i in source)
                encoder.MethodParameter(Import(i.Name), i.AccessFlags);
        }

        public void Import(BootstrapMethodTable source, ref BootstrapMethodTableEncoder encoder)
        {
            foreach (var i in source)
                encoder.Method(Import(i.Method), e => Import(i.Arguments, ref e));
        }

        public void Import(ConstantHandleTable source, ref BootstrapArgumentTableEncoder encoder)
        {
            foreach (var i in source)
                encoder.Argument(Import(i));
        }

        public void Import(ParameterAnnotationTable source, ref ParameterAnnotationTableEncoder encoder)
        {
            foreach (var i in source)
                encoder.ParameterAnnotation(e => Import(i, ref e));
        }

        public void Import(ParameterAnnotation source, ref AnnotationTableEncoder encoder)
        {
            Import(source.Annotations, ref encoder);
        }

        public void Import(TypeAnnotationTable source, ref TypeAnnotationTableEncoder encoder)
        {
            foreach (var i in source)
                Import(i, ref encoder);
        }

        public void Import(TypeAnnotation source, ref TypeAnnotationTableEncoder encoder)
        {
            encoder.TypeAnnotation(e => Import(source, ref e));
        }

        public void Import(TypeAnnotation source, ref TypeAnnotationEncoder encoder)
        {
            switch (source.Target.Type)
            {
                case TypeAnnotationTargetType.ClassTypeParameter:
                    var _classTypeParameter = source.Target.AsTypeParameterTarget();
                    encoder.ClassTypeParameter(_classTypeParameter.ParameterIndex, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.MethodTypeParameter:
                    var _methodTypeParameter = source.Target.AsTypeParameterTarget();
                    encoder.MethodTypeParameter(_methodTypeParameter.ParameterIndex, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.ClassExtends:
                    var _superTypeTarget = source.Target.AsSuperTypeTarget();
                    encoder.ClassExtends(_superTypeTarget.SuperTypeIndex, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.ClassTypeParameterBound:
                    var _classTypeParameterBound = source.Target.AsTypeParameterBoundTarget();
                    encoder.ClassTypeParameterBound(_classTypeParameterBound.ParameterIndex, _classTypeParameterBound.BoundIndex, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.MethodTypeParameterBound:
                    var _methodTypeParameterBound = source.Target.AsTypeParameterBoundTarget();
                    encoder.MethodTypeParameterBound(_methodTypeParameterBound.ParameterIndex, _methodTypeParameterBound.BoundIndex, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.Field:
                    var _field = source.Target.AsEmptyTarget();
                    encoder.Field(e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReturn:
                    var _methodReturn = source.Target.AsEmptyTarget();
                    encoder.MethodReturn(e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReceiver:
                    var _methodReceiver = source.Target.AsEmptyTarget();
                    encoder.MethodReceiver(e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.MethodFormalParameter:
                    var _methodFormalParameter = source.Target.AsFormalParameterTarget();
                    encoder.MethodFormalParameter(_methodFormalParameter.ParameterIndex, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.Throws:
                    var _throws = source.Target.AsThrowsTarget();
                    encoder.Throws(_throws.ThrowsTypeIndex, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.LocalVar:
                    var _localVar = source.Target.AsLocalVarTarget();
                    encoder.LocalVariable(e => Import(_localVar, ref e), e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.ResourceVariable:
                    var _resourceVariable = source.Target.AsLocalVarTarget();
                    encoder.ResourceVariable(e => Import(_resourceVariable, ref e), e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.ExceptionParameter:
                    var _catchTarget = source.Target.AsCatchTarget();
                    encoder.ExceptionParameter(_catchTarget.ExceptionTableIndex, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.InstanceOf:
                    var _instanceOf = source.Target.AsOffsetTarget();
                    encoder.InstanceOf(_instanceOf.Offset, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.New:
                    var _new = source.Target.AsOffsetTarget();
                    encoder.New(_new.Offset, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorReference:
                    var _constructorReference = source.Target.AsOffsetTarget();
                    encoder.ConstructorReference(_constructorReference.Offset, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReference:
                    var _methodReference = source.Target.AsOffsetTarget();
                    encoder.MethodReference(_methodReference.Offset, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.Cast:
                    var _cast = source.Target.AsTypeArgumentTarget();
                    encoder.Cast(_cast.Offset, _cast.TypeArgumentIndex, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorInvocationTypeArgument:
                    var _constructorInvocationTypeArgument = source.Target.AsTypeArgumentTarget();
                    encoder.ConstructorInvocationTypeArgument(_constructorInvocationTypeArgument.Offset, _constructorInvocationTypeArgument.TypeArgumentIndex, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.MethodInvocationTypeArgument:
                    var _methodInvocationTypeArgument = source.Target.AsTypeArgumentTarget();
                    encoder.MethodInvocationTypeArgument(_methodInvocationTypeArgument.Offset, _methodInvocationTypeArgument.TypeArgumentIndex, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorReferenceTypeArgument:
                    var _constructorReferenceTypeArgument = source.Target.AsTypeArgumentTarget();
                    encoder.ConstructorReferenceTypeArgument(_constructorReferenceTypeArgument.Offset, _constructorReferenceTypeArgument.TypeArgumentIndex, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReferenceTypeArgument:
                    var _methodReferenceTypeArgument = source.Target.AsTypeArgumentTarget();
                    encoder.ConstructorReferenceTypeArgument(_methodReferenceTypeArgument.Offset, _methodReferenceTypeArgument.TypeArgumentIndex, e => Import(source.TargetPath, ref e), Import(source.Type), e => Import(source, ref e));
                    break;
                default:
                    throw new ByteCodeException("Invalid type annotation target type.");
            }
        }

        public void Import(LocalVarTarget source, ref LocalVarTargetTableEncoder encoder)
        {
            foreach (var i in source)
                Import(i, ref encoder);
        }

        public void Import(LocalVarTargetItem source, ref LocalVarTargetTableEncoder encoder)
        {
            encoder.LocalVar(source.Start, source.Length, source.Index);
        }

        public void Import(TypePath source, ref TypePathEncoder encoder)
        {
            foreach (var i in source)
                Import(i, ref encoder);
        }

        public void Import(TypePathComponent source, ref TypePathEncoder encoder)
        {
            switch (source.Kind)
            {
                case TypePathKind.TypeArgument:
                    encoder.TypeArgument(source.ArgumentIndex);
                    break;
                case TypePathKind.InnerType:
                    encoder.InnerType();
                    break;
                case TypePathKind.Array:
                    encoder.Array();
                    break;
                case TypePathKind.Wildcard:
                    encoder.Wildcard();
                    break;
            }
        }

        public void Import(TypeAnnotation source, ref ElementValuePairTableEncoder encoder)
        {
            foreach (var i in source)
                Import(i, ref encoder);
        }

        public void Import(LocalVariableTypeTable source, ref LocalVariableTypeTableEncoder encoder)
        {
            foreach (var i in source)
                Import(i, ref encoder);
        }

        public void Import(LocalVariableType source, ref LocalVariableTypeTableEncoder encoder)
        {
            encoder.LocalVariableType(source.StartPc, source.Length, Import(source.Name), Import(source.Signature), source.Slot);
        }

        public void Import(LocalVariableTable source, ref LocalVariableTableEncoder encoder)
        {
            foreach (var i in source)
                Import(i, ref encoder);
        }

        public void Import(LocalVariable source, ref LocalVariableTableEncoder encoder)
        {
            encoder.LocalVariable(source.StartPc, source.Length, Import(source.Name), Import(source.Type), source.Slot);
        }

        public void Import(LineNumberTable source, ref LineNumberTableEncoder encoder)
        {
            foreach (var i in source)
                encoder.LineNumber(i.StartPc, i.LineNumber);
        }

        public void Import(InnerClassesAttribute source, ref InnerClassTableEncoder encoder)
        {
            foreach (var i in source.Table)
                encoder.InnerClass(Import(i.Inner), Import(i.Outer), Import(i.InnerName), i.InnerAccessFlags);
        }

        public void Import(ExceptionsAttribute source, ref ClassConstantTableEncoder encoder)
        {
            foreach (var i in source.Exceptions)
                encoder.Class(Import(i));
        }

        public void Import(StackMapTableAttribute source, ref StackMapTableEncoder encoder)
        {
            foreach (var i in source.Frames)
                Import(i, ref encoder);
        }

        public void Import(StackMapFrame source, ref StackMapTableEncoder encoder)
        {
            if (source.FrameType is <= 65)
                Import((SameStackMapFrame)source, ref encoder);
            else if (source.FrameType is >= 64 and <= 127)
                Import((SameLocalsOneStackMapFrame)source, ref encoder);
            else if (source.FrameType is 247)
                Import((SameLocalsOneExtendedStackMapFrame)source, ref encoder);
            else if (source.FrameType is >= 248 and <= 250)
                Import((ChopStackMapFrame)source, ref encoder);
            else if (source.FrameType is 251)
                Import((SameExtendedStackMapFrame)source, ref encoder);
            else if (source.FrameType is >= 252 and <= 254)
                Import((AppendStackMapFrame)source, ref encoder);
            else if (source.FrameType is 255)
                Import((FullStackMapFrame)source, ref encoder);
            else
                throw new ByteCodeException("Invalid stack map frame type.");
        }

        public void Import(SameStackMapFrame source, ref StackMapTableEncoder encoder)
        {
            encoder.Same(source.FrameType);
        }

        public void Import(SameLocalsOneStackMapFrame source, ref StackMapTableEncoder encoder)
        {
            encoder.SameLocalsOneStackItem(source.FrameType, e => Import(source.Stack, ref e));
        }

        public void Import(SameLocalsOneExtendedStackMapFrame source, ref StackMapTableEncoder encoder)
        {
            encoder.SameLocalsOneStackItemExtended(source.OffsetDelta, e => Import(source.Stack, ref e));
        }

        public void Import(ChopStackMapFrame source, ref StackMapTableEncoder encoder)
        {
            encoder.Chop(source.FrameType, source.OffsetDelta);
        }

        public void Import(SameExtendedStackMapFrame source, ref StackMapTableEncoder encoder)
        {
            encoder.SameExtended(source.OffsetDelta);
        }

        public void Import(AppendStackMapFrame source, ref StackMapTableEncoder encoder)
        {
            encoder.Append(source.FrameType, source.OffsetDelta, e => Import(source.Locals, ref e));
        }

        public void Import(FullStackMapFrame source, ref StackMapTableEncoder encoder)
        {
            encoder.Full(source.OffsetDelta, e => Import(source.Locals, ref e), e => Import(source.Stack, ref e));
        }

        public void Import(VerificationTypeInfoTable source, ref VerificationTypeInfoEncoder encoder)
        {
            foreach (var i in source)
                Import(i, ref encoder);
        }

        public void Import(VerificationTypeInfo source, ref VerificationTypeInfoEncoder encoder)
        {
            switch (source.Kind)
            {
                case VerificationTypeInfoKind.Top:
                    encoder.Top();
                    break;
                case VerificationTypeInfoKind.Integer:
                    encoder.Integer();
                    break;
                case VerificationTypeInfoKind.Float:
                    encoder.Float();
                    break;
                case VerificationTypeInfoKind.Double:
                    encoder.Double();
                    break;
                case VerificationTypeInfoKind.Long:
                    encoder.Long();
                    break;
                case VerificationTypeInfoKind.Null:
                    encoder.Null();
                    break;
                case VerificationTypeInfoKind.UninitializedThis:
                    encoder.UninitializedThis();
                    break;
                case VerificationTypeInfoKind.Object:
                    encoder.Object(Import(source.AsObject().Class));
                    break;
                case VerificationTypeInfoKind.Uninitialized:
                    encoder.Uninitialized(source.AsUninitialized().Offset);
                    break;
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
