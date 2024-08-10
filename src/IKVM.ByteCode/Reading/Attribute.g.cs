using System;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly partial struct Attribute
    {


        public static explicit operator ConstantValueAttribute(Attribute attribute) => attribute.AsConstantValue();

        public ConstantValueAttribute AsConstantValue()
        {
            var reader = new ClassFormatReader(Data);
            if (ConstantValueAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.ConstantValue)}.");

            return value;
        }

        public static explicit operator CodeAttribute(Attribute attribute) => attribute.AsCode();

        public CodeAttribute AsCode()
        {
            var reader = new ClassFormatReader(Data);
            if (CodeAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.Code)}.");

            return value;
        }

        public static explicit operator StackMapTableAttribute(Attribute attribute) => attribute.AsStackMapTable();

        public StackMapTableAttribute AsStackMapTable()
        {
            var reader = new ClassFormatReader(Data);
            if (StackMapTableAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.StackMapTable)}.");

            return value;
        }

        public static explicit operator ExceptionsAttribute(Attribute attribute) => attribute.AsExceptions();

        public ExceptionsAttribute AsExceptions()
        {
            var reader = new ClassFormatReader(Data);
            if (ExceptionsAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.Exceptions)}.");

            return value;
        }

        public static explicit operator InnerClassesAttribute(Attribute attribute) => attribute.AsInnerClasses();

        public InnerClassesAttribute AsInnerClasses()
        {
            var reader = new ClassFormatReader(Data);
            if (InnerClassesAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.InnerClasses)}.");

            return value;
        }

        public static explicit operator EnclosingMethodAttribute(Attribute attribute) => attribute.AsEnclosingMethod();

        public EnclosingMethodAttribute AsEnclosingMethod()
        {
            var reader = new ClassFormatReader(Data);
            if (EnclosingMethodAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.EnclosingMethod)}.");

            return value;
        }

        public static explicit operator SyntheticAttribute(Attribute attribute) => attribute.AsSynthetic();

        public SyntheticAttribute AsSynthetic()
        {
            var reader = new ClassFormatReader(Data);
            if (SyntheticAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.Synthetic)}.");

            return value;
        }

        public static explicit operator SignatureAttribute(Attribute attribute) => attribute.AsSignature();

        public SignatureAttribute AsSignature()
        {
            var reader = new ClassFormatReader(Data);
            if (SignatureAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.Signature)}.");

            return value;
        }

        public static explicit operator SourceFileAttribute(Attribute attribute) => attribute.AsSourceFile();

        public SourceFileAttribute AsSourceFile()
        {
            var reader = new ClassFormatReader(Data);
            if (SourceFileAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.SourceFile)}.");

            return value;
        }

        public static explicit operator SourceDebugExtensionAttribute(Attribute attribute) => attribute.AsSourceDebugExtension();

        public SourceDebugExtensionAttribute AsSourceDebugExtension()
        {
            var reader = new ClassFormatReader(Data);
            if (SourceDebugExtensionAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.SourceDebugExtension)}.");

            return value;
        }

        public static explicit operator LineNumberTableAttribute(Attribute attribute) => attribute.AsLineNumberTable();

        public LineNumberTableAttribute AsLineNumberTable()
        {
            var reader = new ClassFormatReader(Data);
            if (LineNumberTableAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.LineNumberTable)}.");

            return value;
        }

        public static explicit operator LocalVariableTableAttribute(Attribute attribute) => attribute.AsLocalVariableTable();

        public LocalVariableTableAttribute AsLocalVariableTable()
        {
            var reader = new ClassFormatReader(Data);
            if (LocalVariableTableAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.LocalVariableTable)}.");

            return value;
        }

        public static explicit operator LocalVariableTypeTableAttribute(Attribute attribute) => attribute.AsLocalVariableTypeTable();

        public LocalVariableTypeTableAttribute AsLocalVariableTypeTable()
        {
            var reader = new ClassFormatReader(Data);
            if (LocalVariableTypeTableAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.LocalVariableTypeTable)}.");

            return value;
        }

        public static explicit operator DeprecatedAttribute(Attribute attribute) => attribute.AsDeprecated();

        public DeprecatedAttribute AsDeprecated()
        {
            var reader = new ClassFormatReader(Data);
            if (DeprecatedAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.Deprecated)}.");

            return value;
        }

        public static explicit operator RuntimeVisibleAnnotationsAttribute(Attribute attribute) => attribute.AsRuntimeVisibleAnnotations();

        public RuntimeVisibleAnnotationsAttribute AsRuntimeVisibleAnnotations()
        {
            var reader = new ClassFormatReader(Data);
            if (RuntimeVisibleAnnotationsAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.RuntimeVisibleAnnotations)}.");

            return value;
        }

        public static explicit operator RuntimeInvisibleAnnotationsAttribute(Attribute attribute) => attribute.AsRuntimeInvisibleAnnotations();

        public RuntimeInvisibleAnnotationsAttribute AsRuntimeInvisibleAnnotations()
        {
            var reader = new ClassFormatReader(Data);
            if (RuntimeInvisibleAnnotationsAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.RuntimeInvisibleAnnotations)}.");

            return value;
        }

        public static explicit operator RuntimeVisibleParameterAnnotationsAttribute(Attribute attribute) => attribute.AsRuntimeVisibleParameterAnnotations();

        public RuntimeVisibleParameterAnnotationsAttribute AsRuntimeVisibleParameterAnnotations()
        {
            var reader = new ClassFormatReader(Data);
            if (RuntimeVisibleParameterAnnotationsAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.RuntimeVisibleParameterAnnotations)}.");

            return value;
        }

        public static explicit operator RuntimeInvisibleParameterAnnotationsAttribute(Attribute attribute) => attribute.AsRuntimeInvisibleParameterAnnotations();

        public RuntimeInvisibleParameterAnnotationsAttribute AsRuntimeInvisibleParameterAnnotations()
        {
            var reader = new ClassFormatReader(Data);
            if (RuntimeInvisibleParameterAnnotationsAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.RuntimeInvisibleParameterAnnotations)}.");

            return value;
        }

        public static explicit operator RuntimeVisibleTypeAnnotationsAttribute(Attribute attribute) => attribute.AsRuntimeVisibleTypeAnnotations();

        public RuntimeVisibleTypeAnnotationsAttribute AsRuntimeVisibleTypeAnnotations()
        {
            var reader = new ClassFormatReader(Data);
            if (RuntimeVisibleTypeAnnotationsAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.RuntimeVisibleTypeAnnotations)}.");

            return value;
        }

        public static explicit operator RuntimeInvisibleTypeAnnotationsAttribute(Attribute attribute) => attribute.AsRuntimeInvisibleTypeAnnotations();

        public RuntimeInvisibleTypeAnnotationsAttribute AsRuntimeInvisibleTypeAnnotations()
        {
            var reader = new ClassFormatReader(Data);
            if (RuntimeInvisibleTypeAnnotationsAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.RuntimeInvisibleTypeAnnotations)}.");

            return value;
        }

        public static explicit operator AnnotationDefaultAttribute(Attribute attribute) => attribute.AsAnnotationDefault();

        public AnnotationDefaultAttribute AsAnnotationDefault()
        {
            var reader = new ClassFormatReader(Data);
            if (AnnotationDefaultAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.AnnotationDefault)}.");

            return value;
        }

        public static explicit operator BootstrapMethodsAttribute(Attribute attribute) => attribute.AsBootstrapMethods();

        public BootstrapMethodsAttribute AsBootstrapMethods()
        {
            var reader = new ClassFormatReader(Data);
            if (BootstrapMethodsAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.BootstrapMethods)}.");

            return value;
        }

        public static explicit operator MethodParametersAttribute(Attribute attribute) => attribute.AsMethodParameters();

        public MethodParametersAttribute AsMethodParameters()
        {
            var reader = new ClassFormatReader(Data);
            if (MethodParametersAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.MethodParameters)}.");

            return value;
        }

        public static explicit operator ModuleAttribute(Attribute attribute) => attribute.AsModule();

        public ModuleAttribute AsModule()
        {
            var reader = new ClassFormatReader(Data);
            if (ModuleAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.Module)}.");

            return value;
        }

        public static explicit operator ModulePackagesAttribute(Attribute attribute) => attribute.AsModulePackages();

        public ModulePackagesAttribute AsModulePackages()
        {
            var reader = new ClassFormatReader(Data);
            if (ModulePackagesAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.ModulePackages)}.");

            return value;
        }

        public static explicit operator ModuleMainClassAttribute(Attribute attribute) => attribute.AsModuleMainClass();

        public ModuleMainClassAttribute AsModuleMainClass()
        {
            var reader = new ClassFormatReader(Data);
            if (ModuleMainClassAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.ModuleMainClass)}.");

            return value;
        }

        public static explicit operator NestHostAttribute(Attribute attribute) => attribute.AsNestHost();

        public NestHostAttribute AsNestHost()
        {
            var reader = new ClassFormatReader(Data);
            if (NestHostAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.NestHost)}.");

            return value;
        }

        public static explicit operator NestMembersAttribute(Attribute attribute) => attribute.AsNestMembers();

        public NestMembersAttribute AsNestMembers()
        {
            var reader = new ClassFormatReader(Data);
            if (NestMembersAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.NestMembers)}.");

            return value;
        }

        public static explicit operator RecordAttribute(Attribute attribute) => attribute.AsRecord();

        public RecordAttribute AsRecord()
        {
            var reader = new ClassFormatReader(Data);
            if (RecordAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.Record)}.");

            return value;
        }

        public static explicit operator PermittedSubclassesAttribute(Attribute attribute) => attribute.AsPermittedSubclasses();

        public PermittedSubclassesAttribute AsPermittedSubclasses()
        {
            var reader = new ClassFormatReader(Data);
            if (PermittedSubclassesAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.PermittedSubclasses)}.");

            return value;
        }

        readonly void EncodeSelfTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, AttributeTableBuilder builder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            switch (view.Get(Name).Value)
            {
                case AttributeName.ConstantValue:
                    ((ConstantValueAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.Code:
                    ((CodeAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.StackMapTable:
                    ((StackMapTableAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.Exceptions:
                    ((ExceptionsAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.InnerClasses:
                    ((InnerClassesAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.EnclosingMethod:
                    ((EnclosingMethodAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.Synthetic:
                    ((SyntheticAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.Signature:
                    ((SignatureAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.SourceFile:
                    ((SourceFileAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.SourceDebugExtension:
                    ((SourceDebugExtensionAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.LineNumberTable:
                    ((LineNumberTableAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.LocalVariableTable:
                    ((LocalVariableTableAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.LocalVariableTypeTable:
                    ((LocalVariableTypeTableAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.Deprecated:
                    ((DeprecatedAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.RuntimeVisibleAnnotations:
                    ((RuntimeVisibleAnnotationsAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.RuntimeInvisibleAnnotations:
                    ((RuntimeInvisibleAnnotationsAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.RuntimeVisibleParameterAnnotations:
                    ((RuntimeVisibleParameterAnnotationsAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.RuntimeInvisibleParameterAnnotations:
                    ((RuntimeInvisibleParameterAnnotationsAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.RuntimeVisibleTypeAnnotations:
                    ((RuntimeVisibleTypeAnnotationsAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.RuntimeInvisibleTypeAnnotations:
                    ((RuntimeInvisibleTypeAnnotationsAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.AnnotationDefault:
                    ((AnnotationDefaultAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.BootstrapMethods:
                    ((BootstrapMethodsAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.MethodParameters:
                    ((MethodParametersAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.Module:
                    ((ModuleAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.ModulePackages:
                    ((ModulePackagesAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.ModuleMainClass:
                    ((ModuleMainClassAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.NestHost:
                    ((NestHostAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.NestMembers:
                    ((NestMembersAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.Record:
                    ((RecordAttribute)this).EncodeTo(view, pool, builder);
                    break;
                case AttributeName.PermittedSubclasses:
                    ((PermittedSubclassesAttribute)this).EncodeTo(view, pool, builder);
                    break;
                default:
                    throw new ByteCodeException("Cannot encode unknown attribute. Attribute layout is unknown.");
            }
        }

    }

}
