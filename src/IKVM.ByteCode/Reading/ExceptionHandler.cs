namespace IKVM.ByteCode.Reading
{

    public readonly record struct ExceptionHandler(ushort StartOffset, ushort EndOffset, ushort HandlerOffset, ClassConstantHandle CatchType);

}
