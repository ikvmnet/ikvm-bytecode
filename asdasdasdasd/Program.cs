using IKVM.ByteCode.Reading;

namespace asdasdasdasd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClassFile.Read(Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "ConstantReaderTests.class"));
        }
    }
}
