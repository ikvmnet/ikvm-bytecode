namespace IKVM.ByteCode.Parsing
{

    public sealed record EmptyTargetRecord : TypeAnnotationTargetRecord
    {

        public static bool TryRead(ref ClassFormatReader reader, out TypeAnnotationTargetRecord targetInfo)
        {
            targetInfo = new EmptyTargetRecord();
            return true;
        }

    }

}