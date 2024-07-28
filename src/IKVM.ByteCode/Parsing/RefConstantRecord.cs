namespace IKVM.ByteCode.Parsing
{

    internal abstract record RefConstantRecord(ClassConstantHandle Class, NameAndTypeConstantHandle NameAndType) :
        ConstantRecord
    {



    }

}
