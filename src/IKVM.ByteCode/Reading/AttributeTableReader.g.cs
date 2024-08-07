#pragma warning disable 8073, 0282

namespace IKVM.ByteCode.Reading
{

    public partial class AttributeTableReader
    {

        ConstantValueAttribute constantValue;

        public ConstantValueAttribute ConstantValue
        {
            get
            {
                if (constantValue.IsNil)
                {
                    var attribute = FindByName(AttributeName.ConstantValue);
                    if (attribute.IsNotNil)
                        constantValue = attribute.AsConstantValue();
                }

                return constantValue;
            }
        }

        CodeAttribute code;

        public CodeAttribute Code
        {
            get
            {
                if (code.IsNil)
                {
                    var attribute = FindByName(AttributeName.Code);
                    if (attribute.IsNotNil)
                        code = attribute.AsCode();
                }

                return code;
            }
        }

        StackMapTableAttribute stackMapTable;

        public StackMapTableAttribute StackMapTable
        {
            get
            {
                if (stackMapTable.IsNil)
                {
                    var attribute = FindByName(AttributeName.StackMapTable);
                    if (attribute.IsNotNil)
                        stackMapTable = attribute.AsStackMapTable();
                }

                return stackMapTable;
            }
        }

        ExceptionsAttribute exceptions;

        public ExceptionsAttribute Exceptions
        {
            get
            {
                if (exceptions.IsNil)
                {
                    var attribute = FindByName(AttributeName.Exceptions);
                    if (attribute.IsNotNil)
                        exceptions = attribute.AsExceptions();
                }

                return exceptions;
            }
        }

        InnerClassesAttribute innerClasses;

        public InnerClassesAttribute InnerClasses
        {
            get
            {
                if (innerClasses.IsNil)
                {
                    var attribute = FindByName(AttributeName.InnerClasses);
                    if (attribute.IsNotNil)
                        innerClasses = attribute.AsInnerClasses();
                }

                return innerClasses;
            }
        }

        EnclosingMethodAttribute enclosingMethod;

        public EnclosingMethodAttribute EnclosingMethod
        {
            get
            {
                if (enclosingMethod.IsNil)
                {
                    var attribute = FindByName(AttributeName.EnclosingMethod);
                    if (attribute.IsNotNil)
                        enclosingMethod = attribute.AsEnclosingMethod();
                }

                return enclosingMethod;
            }
        }

        SyntheticAttribute synthetic;

        public SyntheticAttribute Synthetic
        {
            get
            {
                if (synthetic.IsNil)
                {
                    var attribute = FindByName(AttributeName.Synthetic);
                    if (attribute.IsNotNil)
                        synthetic = attribute.AsSynthetic();
                }

                return synthetic;
            }
        }

        SignatureAttribute signature;

        public SignatureAttribute Signature
        {
            get
            {
                if (signature.IsNil)
                {
                    var attribute = FindByName(AttributeName.Signature);
                    if (attribute.IsNotNil)
                        signature = attribute.AsSignature();
                }

                return signature;
            }
        }

        SourceFileAttribute sourceFile;

        public SourceFileAttribute SourceFile
        {
            get
            {
                if (sourceFile.IsNil)
                {
                    var attribute = FindByName(AttributeName.SourceFile);
                    if (attribute.IsNotNil)
                        sourceFile = attribute.AsSourceFile();
                }

                return sourceFile;
            }
        }

        SourceDebugExtensionAttribute sourceDebugExtension;

        public SourceDebugExtensionAttribute SourceDebugExtension
        {
            get
            {
                if (sourceDebugExtension.IsNil)
                {
                    var attribute = FindByName(AttributeName.SourceDebugExtension);
                    if (attribute.IsNotNil)
                        sourceDebugExtension = attribute.AsSourceDebugExtension();
                }

                return sourceDebugExtension;
            }
        }

        LineNumberTableAttribute lineNumberTable;

        public LineNumberTableAttribute LineNumberTable
        {
            get
            {
                if (lineNumberTable.IsNil)
                {
                    var attribute = FindByName(AttributeName.LineNumberTable);
                    if (attribute.IsNotNil)
                        lineNumberTable = attribute.AsLineNumberTable();
                }

                return lineNumberTable;
            }
        }

        LocalVariableTableAttribute localVariableTable;

        public LocalVariableTableAttribute LocalVariableTable
        {
            get
            {
                if (localVariableTable.IsNil)
                {
                    var attribute = FindByName(AttributeName.LocalVariableTable);
                    if (attribute.IsNotNil)
                        localVariableTable = attribute.AsLocalVariableTable();
                }

                return localVariableTable;
            }
        }

        LocalVariableTypeTableAttribute localVariableTypeTable;

        public LocalVariableTypeTableAttribute LocalVariableTypeTable
        {
            get
            {
                if (localVariableTypeTable.IsNil)
                {
                    var attribute = FindByName(AttributeName.LocalVariableTypeTable);
                    if (attribute.IsNotNil)
                        localVariableTypeTable = attribute.AsLocalVariableTypeTable();
                }

                return localVariableTypeTable;
            }
        }

        DeprecatedAttribute deprecated;

        public DeprecatedAttribute Deprecated
        {
            get
            {
                if (deprecated.IsNil)
                {
                    var attribute = FindByName(AttributeName.Deprecated);
                    if (attribute.IsNotNil)
                        deprecated = attribute.AsDeprecated();
                }

                return deprecated;
            }
        }

        RuntimeVisibleAnnotationsAttribute runtimeVisibleAnnotations;

        public RuntimeVisibleAnnotationsAttribute RuntimeVisibleAnnotations
        {
            get
            {
                if (runtimeVisibleAnnotations.IsNil)
                {
                    var attribute = FindByName(AttributeName.RuntimeVisibleAnnotations);
                    if (attribute.IsNotNil)
                        runtimeVisibleAnnotations = attribute.AsRuntimeVisibleAnnotations();
                }

                return runtimeVisibleAnnotations;
            }
        }

        RuntimeInvisibleAnnotationsAttribute runtimeInvisibleAnnotations;

        public RuntimeInvisibleAnnotationsAttribute RuntimeInvisibleAnnotations
        {
            get
            {
                if (runtimeInvisibleAnnotations.IsNil)
                {
                    var attribute = FindByName(AttributeName.RuntimeInvisibleAnnotations);
                    if (attribute.IsNotNil)
                        runtimeInvisibleAnnotations = attribute.AsRuntimeInvisibleAnnotations();
                }

                return runtimeInvisibleAnnotations;
            }
        }

        RuntimeVisibleParameterAnnotationsAttribute runtimeVisibleParameterAnnotations;

        public RuntimeVisibleParameterAnnotationsAttribute RuntimeVisibleParameterAnnotations
        {
            get
            {
                if (runtimeVisibleParameterAnnotations.IsNil)
                {
                    var attribute = FindByName(AttributeName.RuntimeVisibleParameterAnnotations);
                    if (attribute.IsNotNil)
                        runtimeVisibleParameterAnnotations = attribute.AsRuntimeVisibleParameterAnnotations();
                }

                return runtimeVisibleParameterAnnotations;
            }
        }

        RuntimeInvisibleParameterAnnotationsAttribute runtimeInvisibleParameterAnnotations;

        public RuntimeInvisibleParameterAnnotationsAttribute RuntimeInvisibleParameterAnnotations
        {
            get
            {
                if (runtimeInvisibleParameterAnnotations.IsNil)
                {
                    var attribute = FindByName(AttributeName.RuntimeInvisibleParameterAnnotations);
                    if (attribute.IsNotNil)
                        runtimeInvisibleParameterAnnotations = attribute.AsRuntimeInvisibleParameterAnnotations();
                }

                return runtimeInvisibleParameterAnnotations;
            }
        }

        RuntimeVisibleTypeAnnotationsAttribute runtimeVisibleTypeAnnotations;

        public RuntimeVisibleTypeAnnotationsAttribute RuntimeVisibleTypeAnnotations
        {
            get
            {
                if (runtimeVisibleTypeAnnotations.IsNil)
                {
                    var attribute = FindByName(AttributeName.RuntimeVisibleTypeAnnotations);
                    if (attribute.IsNotNil)
                        runtimeVisibleTypeAnnotations = attribute.AsRuntimeVisibleTypeAnnotations();
                }

                return runtimeVisibleTypeAnnotations;
            }
        }

        RuntimeInvisibleTypeAnnotationsAttribute runtimeInvisibleTypeAnnotations;

        public RuntimeInvisibleTypeAnnotationsAttribute RuntimeInvisibleTypeAnnotations
        {
            get
            {
                if (runtimeInvisibleTypeAnnotations.IsNil)
                {
                    var attribute = FindByName(AttributeName.RuntimeInvisibleTypeAnnotations);
                    if (attribute.IsNotNil)
                        runtimeInvisibleTypeAnnotations = attribute.AsRuntimeInvisibleTypeAnnotations();
                }

                return runtimeInvisibleTypeAnnotations;
            }
        }

        AnnotationDefaultAttribute annotationDefault;

        public AnnotationDefaultAttribute AnnotationDefault
        {
            get
            {
                if (annotationDefault.IsNil)
                {
                    var attribute = FindByName(AttributeName.AnnotationDefault);
                    if (attribute.IsNotNil)
                        annotationDefault = attribute.AsAnnotationDefault();
                }

                return annotationDefault;
            }
        }

        BootstrapMethodsAttribute bootstrapMethods;

        public BootstrapMethodsAttribute BootstrapMethods
        {
            get
            {
                if (bootstrapMethods.IsNil)
                {
                    var attribute = FindByName(AttributeName.BootstrapMethods);
                    if (attribute.IsNotNil)
                        bootstrapMethods = attribute.AsBootstrapMethods();
                }

                return bootstrapMethods;
            }
        }

        MethodParametersAttribute methodParameters;

        public MethodParametersAttribute MethodParameters
        {
            get
            {
                if (methodParameters.IsNil)
                {
                    var attribute = FindByName(AttributeName.MethodParameters);
                    if (attribute.IsNotNil)
                        methodParameters = attribute.AsMethodParameters();
                }

                return methodParameters;
            }
        }

        ModuleAttribute module;

        public ModuleAttribute Module
        {
            get
            {
                if (module.IsNil)
                {
                    var attribute = FindByName(AttributeName.Module);
                    if (attribute.IsNotNil)
                        module = attribute.AsModule();
                }

                return module;
            }
        }

        ModulePackagesAttribute modulePackages;

        public ModulePackagesAttribute ModulePackages
        {
            get
            {
                if (modulePackages.IsNil)
                {
                    var attribute = FindByName(AttributeName.ModulePackages);
                    if (attribute.IsNotNil)
                        modulePackages = attribute.AsModulePackages();
                }

                return modulePackages;
            }
        }

        ModuleMainClassAttribute moduleMainClass;

        public ModuleMainClassAttribute ModuleMainClass
        {
            get
            {
                if (moduleMainClass.IsNil)
                {
                    var attribute = FindByName(AttributeName.ModuleMainClass);
                    if (attribute.IsNotNil)
                        moduleMainClass = attribute.AsModuleMainClass();
                }

                return moduleMainClass;
            }
        }

        NestHostAttribute nestHost;

        public NestHostAttribute NestHost
        {
            get
            {
                if (nestHost.IsNil)
                {
                    var attribute = FindByName(AttributeName.NestHost);
                    if (attribute.IsNotNil)
                        nestHost = attribute.AsNestHost();
                }

                return nestHost;
            }
        }

        NestMembersAttribute nestMembers;

        public NestMembersAttribute NestMembers
        {
            get
            {
                if (nestMembers.IsNil)
                {
                    var attribute = FindByName(AttributeName.NestMembers);
                    if (attribute.IsNotNil)
                        nestMembers = attribute.AsNestMembers();
                }

                return nestMembers;
            }
        }

        RecordAttribute record;

        public RecordAttribute Record
        {
            get
            {
                if (record.IsNil)
                {
                    var attribute = FindByName(AttributeName.Record);
                    if (attribute.IsNotNil)
                        record = attribute.AsRecord();
                }

                return record;
            }
        }

        PermittedSubclassesAttribute permittedSubclasses;

        public PermittedSubclassesAttribute PermittedSubclasses
        {
            get
            {
                if (permittedSubclasses.IsNil)
                {
                    var attribute = FindByName(AttributeName.PermittedSubclasses);
                    if (attribute.IsNotNil)
                        permittedSubclasses = attribute.AsPermittedSubclasses();
                }

                return permittedSubclasses;
            }
        }

    }

}
