using IKVM.ByteCode.Reading;

namespace IKVM.ByteCode.Writing
{

    public partial class ClassFileImporter<TConstantView, TConstantPool>
        where TConstantView : class, IConstantView
        where TConstantPool : class, IConstantPool
    {

        public void Import(IKVM.ByteCode.Reading.Attribute source, AttributeTableBuilder builder)
        {
            switch (_view.Get(source.Name).Value)
            {
                case AttributeName.ConstantValue:
                    Import((ConstantValueAttribute)source, builder);
                    break;
                case AttributeName.Code:
                    Import((CodeAttribute)source, builder);
                    break;
                case AttributeName.StackMapTable:
                    Import((StackMapTableAttribute)source, builder);
                    break;
                case AttributeName.Exceptions:
                    Import((ExceptionsAttribute)source, builder);
                    break;
                case AttributeName.InnerClasses:
                    Import((InnerClassesAttribute)source, builder);
                    break;
                case AttributeName.EnclosingMethod:
                    Import((EnclosingMethodAttribute)source, builder);
                    break;
                case AttributeName.Synthetic:
                    Import((SyntheticAttribute)source, builder);
                    break;
                case AttributeName.Signature:
                    Import((SignatureAttribute)source, builder);
                    break;
                case AttributeName.SourceFile:
                    Import((SourceFileAttribute)source, builder);
                    break;
                case AttributeName.SourceDebugExtension:
                    Import((SourceDebugExtensionAttribute)source, builder);
                    break;
                case AttributeName.LineNumberTable:
                    Import((LineNumberTableAttribute)source, builder);
                    break;
                case AttributeName.LocalVariableTable:
                    Import((LocalVariableTableAttribute)source, builder);
                    break;
                case AttributeName.LocalVariableTypeTable:
                    Import((LocalVariableTypeTableAttribute)source, builder);
                    break;
                case AttributeName.Deprecated:
                    Import((DeprecatedAttribute)source, builder);
                    break;
                case AttributeName.RuntimeVisibleAnnotations:
                    Import((RuntimeVisibleAnnotationsAttribute)source, builder);
                    break;
                case AttributeName.RuntimeInvisibleAnnotations:
                    Import((RuntimeInvisibleAnnotationsAttribute)source, builder);
                    break;
                case AttributeName.RuntimeVisibleParameterAnnotations:
                    Import((RuntimeVisibleParameterAnnotationsAttribute)source, builder);
                    break;
                case AttributeName.RuntimeInvisibleParameterAnnotations:
                    Import((RuntimeInvisibleParameterAnnotationsAttribute)source, builder);
                    break;
                case AttributeName.RuntimeVisibleTypeAnnotations:
                    Import((RuntimeVisibleTypeAnnotationsAttribute)source, builder);
                    break;
                case AttributeName.RuntimeInvisibleTypeAnnotations:
                    Import((RuntimeInvisibleTypeAnnotationsAttribute)source, builder);
                    break;
                case AttributeName.AnnotationDefault:
                    Import((AnnotationDefaultAttribute)source, builder);
                    break;
                case AttributeName.BootstrapMethods:
                    Import((BootstrapMethodsAttribute)source, builder);
                    break;
                case AttributeName.MethodParameters:
                    Import((MethodParametersAttribute)source, builder);
                    break;
                case AttributeName.Module:
                    Import((ModuleAttribute)source, builder);
                    break;
                case AttributeName.ModulePackages:
                    Import((ModulePackagesAttribute)source, builder);
                    break;
                case AttributeName.ModuleMainClass:
                    Import((ModuleMainClassAttribute)source, builder);
                    break;
                case AttributeName.NestHost:
                    Import((NestHostAttribute)source, builder);
                    break;
                case AttributeName.NestMembers:
                    Import((NestMembersAttribute)source, builder);
                    break;
                case AttributeName.Record:
                    Import((RecordAttribute)source, builder);
                    break;
                case AttributeName.PermittedSubclasses:
                    Import((PermittedSubclassesAttribute)source, builder);
                    break;
                default:
                    throw new ByteCodeException("Cannot import unknown attribute since its layout would be unknown.");
            }
        }

    }

}
