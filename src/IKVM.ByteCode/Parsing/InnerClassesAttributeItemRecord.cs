namespace IKVM.ByteCode.Parsing
{

    public readonly record struct InnerClassesAttributeItemRecord(ClassConstantHandle InnerClass, ClassConstantHandle OuterClass, Utf8ConstantHandle InnerName, AccessFlag InnerClassAccessFlags);

}
