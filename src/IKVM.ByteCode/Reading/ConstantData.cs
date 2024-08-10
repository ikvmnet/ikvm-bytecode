using System.Buffers;

namespace IKVM.ByteCode.Reading
{

    public record struct ConstantData(ConstantKind Kind, ReadOnlySequence<byte> Data)
    {

        /// <summary>
        /// Attempts to read the constant at the current position. Returns the the number of index positions to skip.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="constant"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        public static bool TryRead(ref ClassFormatReader reader, out ConstantData constant, out int skip)
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

        static bool TryReadConstantUtf8(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (Utf8ConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.Utf8, _data);
            return true;
        }

        static bool TryReadConstantInteger(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (IntegerConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.Integer, _data);
            return true;
        }

        static bool TryReadConstantFloat(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (FloatConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.Float, _data);
            return true;
        }

        static bool TryReadConstantLong(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (LongConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.Long, _data);
            return true;
        }

        static bool TryReadConstantDouble(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (DoubleConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.Double, _data);
            return true;
        }

        static bool TryReadConstantClass(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (ClassConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.Class, _data);
            return true;
        }

        static bool TryReadConstantString(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (StringConstantData.TryReadStringConstantData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.String, _data);
            return true;
        }

        static bool TryReadConstantFieldref(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (FieldrefConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.Fieldref, _data);
            return true;
        }

        static bool TryReadConstantMethodref(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (MethodrefConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.Methodref, _data);
            return true;
        }

        static bool TryReadConstantInterfaceMethodref(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (InterfaceMethodrefConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.InterfaceMethodref, _data);
            return true;
        }

        static bool TryReadConstantNameAndType(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (NameAndTypeConstantData.TryReadNameAndTypeConstantData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.NameAndType, _data);
            return true;
        }

        static bool TryReadConstantMethodHandle(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (MethodHandleConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.MethodHandle, _data);
            return true;
        }

        static bool TryReadConstantMethodType(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (MethodTypeConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.MethodType, _data);
            return true;
        }

        static bool TryReadConstantDynamic(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (DynamicConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.Dynamic, _data);
            return true;
        }

        static bool TryReadConstantInvokeDynamic(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (InvokeDynamicConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.InvokeDynamic, _data);
            return true;
        }

        static bool TryReadConstantModule(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (ModuleConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.Module, _data);
            return true;
        }

        static bool TryReadConstantPackage(ref ClassFormatReader reader, out ConstantData data, out int skip)
        {
            data = default;

            if (PackageConstantData.TryReadData(ref reader, out var _data, out skip) == false)
                return false;

            data = new ConstantData(ConstantKind.Package, _data);
            return true;
        }

        public readonly ConstantKind Kind = Kind;
        public readonly ReadOnlySequence<byte> Data = Data;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

    }

}
