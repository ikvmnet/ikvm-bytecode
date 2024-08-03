namespace IKVM.ByteCode.Writing
{

    public delegate void EncoderAction<T>(in T encoder) where T : struct;

}
