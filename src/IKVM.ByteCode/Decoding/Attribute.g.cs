﻿using System;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
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

        public static explicit operator ModuleTargetAttribute(Attribute attribute) => attribute.AsModuleTarget();

        public ModuleTargetAttribute AsModuleTarget()
        {
            var reader = new ClassFormatReader(Data);
            if (ModuleTargetAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.ModuleTarget)}.");

            return value;
        }

        public static explicit operator ModuleHashesAttribute(Attribute attribute) => attribute.AsModuleHashes();

        public ModuleHashesAttribute AsModuleHashes()
        {
            var reader = new ClassFormatReader(Data);
            if (ModuleHashesAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.ModuleHashes)}.");

            return value;
        }

        public static explicit operator ModuleResolutionAttribute(Attribute attribute) => attribute.AsModuleResolution();

        public ModuleResolutionAttribute AsModuleResolution()
        {
            var reader = new ClassFormatReader(Data);
            if (ModuleResolutionAttribute.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"End of data reached casting Attribute to {nameof(AttributeName.ModuleResolution)}.");

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

        readonly void EncodeSelfTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            switch (constantView.Get(Name).Value)
            {
                case AttributeName.ConstantValue:
                    ((ConstantValueAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.Code:
                    ((CodeAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.StackMapTable:
                    ((StackMapTableAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.Exceptions:
                    ((ExceptionsAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.InnerClasses:
                    ((InnerClassesAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.EnclosingMethod:
                    ((EnclosingMethodAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.Synthetic:
                    ((SyntheticAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.Signature:
                    ((SignatureAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.SourceFile:
                    ((SourceFileAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.SourceDebugExtension:
                    ((SourceDebugExtensionAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.LineNumberTable:
                    ((LineNumberTableAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.LocalVariableTable:
                    ((LocalVariableTableAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.LocalVariableTypeTable:
                    ((LocalVariableTypeTableAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.Deprecated:
                    ((DeprecatedAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.RuntimeVisibleAnnotations:
                    ((RuntimeVisibleAnnotationsAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.RuntimeInvisibleAnnotations:
                    ((RuntimeInvisibleAnnotationsAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.RuntimeVisibleParameterAnnotations:
                    ((RuntimeVisibleParameterAnnotationsAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.RuntimeInvisibleParameterAnnotations:
                    ((RuntimeInvisibleParameterAnnotationsAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.RuntimeVisibleTypeAnnotations:
                    ((RuntimeVisibleTypeAnnotationsAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.RuntimeInvisibleTypeAnnotations:
                    ((RuntimeInvisibleTypeAnnotationsAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.AnnotationDefault:
                    ((AnnotationDefaultAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.BootstrapMethods:
                    ((BootstrapMethodsAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.MethodParameters:
                    ((MethodParametersAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.Module:
                    ((ModuleAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.ModulePackages:
                    ((ModulePackagesAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.ModuleMainClass:
                    ((ModuleMainClassAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.ModuleTarget:
                    ((ModuleTargetAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.ModuleHashes:
                    ((ModuleHashesAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.ModuleResolution:
                    ((ModuleResolutionAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.NestHost:
                    ((NestHostAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.NestMembers:
                    ((NestMembersAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.Record:
                    ((RecordAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                case AttributeName.PermittedSubclasses:
                    ((PermittedSubclassesAttribute)this).CopyTo(constantView, constantPool, ref encoder);
                    break;
                default:
                    throw new ByteCodeException("Cannot encode unknown attribute. Attribute layout is unknown.");
            }
        }

    }

}
