using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public record struct Constant(ConstantKind Kind, ReadOnlySequence<byte> Data)
    {

        /// <summary>
        /// Attempts to read the constant at the current position. Returns the the number of index positions to skip.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, out Constant constant, out int skip)
        {
            constant = default;
            skip = 0;

            if (reader.TryReadU1(out byte kind) == false)
                return false;

            return (ConstantKind)kind switch
            {
                ConstantKind.Utf8 => TryReadConstantUtf8(ref reader, out constant, out skip),
                ConstantKind.Integer => TryReadConstantInteger(ref reader, out constant, out skip),
                ConstantKind.Float => TryReadConstantFloat(ref reader, out constant, out skip),
                ConstantKind.Long => TryReadConstantLong(ref reader, out constant, out skip),
                ConstantKind.Double => TryReadConstantDouble(ref reader, out constant, out skip),
                ConstantKind.Class => TryReadConstantClass(ref reader, out constant, out skip),
                ConstantKind.String => TryReadConstantString(ref reader, out constant, out skip),
                ConstantKind.Fieldref => TryReadConstantFieldref(ref reader, out constant, out skip),
                ConstantKind.Methodref => TryReadConstantMethodref(ref reader, out constant, out skip),
                ConstantKind.InterfaceMethodref => TryReadConstantInterfaceMethodref(ref reader, out constant, out skip),
                ConstantKind.NameAndType => TryReadConstantNameAndType(ref reader, out constant, out skip),
                ConstantKind.MethodHandle => TryReadConstantMethodHandle(ref reader, out constant, out skip),
                ConstantKind.MethodType => TryReadConstantMethodType(ref reader, out constant, out skip),
                ConstantKind.Dynamic => TryReadConstantDynamic(ref reader, out constant, out skip),
                ConstantKind.InvokeDynamic => TryReadConstantInvokeDynamic(ref reader, out constant, out skip),
                ConstantKind.Module => TryReadConstantModule(ref reader, out constant, out skip),
                ConstantKind.Package => TryReadConstantPackage(ref reader, out constant, out skip),
                _ => throw new ByteCodeException($"Constant kind is nil."),
            };
        }

        static bool TryReadConstantUtf8(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (Utf8Constant.TryReadUtf8ConstantData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.Utf8, _data);
            return true;
        }

        static bool TryReadConstantInteger(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (IntegerConstant.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.Integer, _data);
            return true;
        }

        static bool TryReadConstantFloat(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (FloatConstant.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.Float, _data);
            return true;
        }

        static bool TryReadConstantLong(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (LongConstant.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.Long, _data);
            return true;
        }

        static bool TryReadConstantDouble(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (DoubleConstant.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.Double, _data);
            return true;
        }

        static bool TryReadConstantClass(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (ClassConstant.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.Class, _data);
            return true;
        }

        static bool TryReadConstantString(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (StringConstant.TryReadStringConstantData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.String, _data);
            return true;
        }

        static bool TryReadConstantFieldref(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (FieldrefConstant.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.Fieldref, _data);
            return true;
        }

        static bool TryReadConstantMethodref(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (MethodrefConstant.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.Methodref, _data);
            return true;
        }

        static bool TryReadConstantInterfaceMethodref(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (InterfaceMethodrefConstant.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.InterfaceMethodref, _data);
            return true;
        }

        static bool TryReadConstantNameAndType(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (NameAndTypeConstant.TryReadNameAndTypeConstantData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.NameAndType, _data);
            return true;
        }

        static bool TryReadConstantMethodHandle(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (MethodHandleConstant.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.MethodHandle, _data);
            return true;
        }

        static bool TryReadConstantMethodType(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (MethodTypeConstant.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.MethodType, _data);
            return true;
        }

        static bool TryReadConstantDynamic(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (DynamicConstant.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.Dynamic, _data);
            return true;
        }

        static bool TryReadConstantInvokeDynamic(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (InvokeDynamicConstant.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.InvokeDynamic, _data);
            return true;
        }

        static bool TryReadConstantModule(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (ModuleConstant.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.Module, _data);
            return true;
        }

        static bool TryReadConstantPackage(ref ClassFormatReader reader, out Constant data, out int skip)
        {
            data = default;

            if (PackageConstant.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new Constant(ConstantKind.Package, _data);
            return true;
        }

    }

}
