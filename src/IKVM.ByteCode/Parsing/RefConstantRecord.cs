namespace IKVM.ByteCode.Parsing
{

    public abstract record RefConstantRecord(ClassConstantHandle Class, NameAndTypeConstantHandle NameAndType) :
        ConstantRecord
    {



    }

}
