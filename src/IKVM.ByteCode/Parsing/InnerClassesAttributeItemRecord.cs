namespace IKVM.ByteCode.Parsing
{

    internal record struct InnerClassesAttributeItemRecord(ClassConstantHandle InnerClass, ClassConstantHandle OuterClass, Utf8ConstantHandle InnerName, AccessFlag InnerClassAccessFlags);

}
