namespace IKVM.ByteCode.Parsing
{

    public record struct InnerClassesAttributeItemRecord(ClassConstantHandle InnerClass, ClassConstantHandle OuterClass, Utf8ConstantHandle InnerName, AccessFlag InnerClassAccessFlags);

}
