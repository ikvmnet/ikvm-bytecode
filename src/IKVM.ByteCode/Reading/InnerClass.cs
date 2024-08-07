namespace IKVM.ByteCode.Reading
{

    public readonly record struct InnerClass(ClassConstantHandle Inner, ClassConstantHandle Outer, Utf8ConstantHandle InnerName, AccessFlag InnerAccessFlags);

}
