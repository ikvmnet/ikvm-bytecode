namespace IKVM.ByteCode.Parsing
{

    public readonly record struct ExceptionHandlerRecord(ushort StartOffset, ushort EndOffset, ushort HandlerOffset, ClassConstantHandle CatchType);

}
