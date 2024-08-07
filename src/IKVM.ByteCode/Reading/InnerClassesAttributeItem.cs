namespace IKVM.ByteCode.Reading
{

    public readonly record struct InnerClassesAttributeItem(ClassConstantHandle InnerClass, ClassConstantHandle OuterClass, Utf8ConstantHandle InnerName, AccessFlag InnerClassAccessFlags);

}
