namespace IKVM.ByteCode.Parsing
{

    public record struct ExceptionHandlerRecord(ushort StartOffset, ushort EndOffset, ushort HandlerOffset, ClassConstantHandle CatchType);

}
