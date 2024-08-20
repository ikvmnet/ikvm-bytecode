namespace IKVM.ByteCode
{

    public readonly struct Constant
    {

        public static Utf8Constant Utf8(string value)
        {
            return new Utf8Constant(value);
        }

        public static IntegerConstant Integer(bool value)
        {
            return new IntegerConstant(value ? 1 : 0);
        }

        public static IntegerConstant Integer(byte value)
        {
            return new IntegerConstant(unchecked((sbyte)value));
        }

        public static IntegerConstant Integer(short value)
        {
            return new IntegerConstant(value);
        }

        public static IntegerConstant Integer(int value)
        {
            return new IntegerConstant(value);
        }

        public static FloatConstant Float(float value)
        {
            return new FloatConstant(value);
        }

        public static LongConstant Long(long value)
        {
            return new LongConstant(value);
        }

        public static DoubleConstant Double(double value)
        {
            return new DoubleConstant(value);
        }

        public static ClassConstant Class(string value)
        {
            return new ClassConstant(value);
        }

        public static StringConstant String(string value)
        {
            return new StringConstant(value);
        }

        public static FieldrefConstant Fieldref(string className, string name, string descriptor)
        {
            return new FieldrefConstant(className, name, descriptor);
        }

        public static MethodrefConstant Methodref(string className, string name, string descriptor)
        {
            return new MethodrefConstant(className, name, descriptor);
        }

        public static InterfaceMethodrefConstant InterfaceMethodref(string className, string name, string descriptor)
        {
            return new InterfaceMethodrefConstant(className, name, descriptor);
        }

        public static NameAndTypeConstant NameAndType(string name, string descriptor)
        {
            return new NameAndTypeConstant(name, descriptor);
        }

        public static MethodHandleConstant MethodHandle(MethodHandleKind kind, RefConstant reference)
        {
            return new MethodHandleConstant(kind, reference.Kind, reference.ClassName, reference.Name, reference.Descriptor);
        }

        public static MethodHandleConstant MethodHandle(MethodHandleKind kind, FieldrefConstant reference)
        {
            return new MethodHandleConstant(kind, ConstantKind.Fieldref, reference.ClassName, reference.Name, reference.Descriptor);
        }

        public static MethodHandleConstant MethodHandle(MethodHandleKind kind, MethodrefConstant reference)
        {
            return new MethodHandleConstant(kind, ConstantKind.Methodref, reference.ClassName, reference.Name, reference.Descriptor);
        }

        public static MethodHandleConstant MethodHandle(MethodHandleKind kind, InterfaceMethodrefConstant reference)
        {
            return new MethodHandleConstant(kind, ConstantKind.InterfaceMethodref, reference.ClassName, reference.Name, reference.Descriptor);
        }

        public static MethodTypeConstant MethodType(string descriptor)
        {
            return new MethodTypeConstant(descriptor);
        }

        public static DynamicConstant Dynamic(ushort bootstrapMethodAttributeIndex, string name, string descriptor)
        {
            return new DynamicConstant(bootstrapMethodAttributeIndex, name, descriptor);
        }

        public static InvokeDynamicConstant InvokeDynamic(ushort bootstrapMethodAttributeIndex, string name, string descriptor)
        {
            return new InvokeDynamicConstant(bootstrapMethodAttributeIndex, name, descriptor);
        }

        public static ModuleConstant Module(string name)
        {
            return new ModuleConstant(name);
        }

        public static PackageConstant Package(string name)
        {
            return new PackageConstant(name);
        }

        internal readonly ConstantKind _kind;
        internal readonly object? _object1;
        internal readonly object? _object2;
        internal readonly object? _object3;
        internal readonly ulong _ulong1;
        internal readonly bool _isNotNil = true;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="object1"></param>
        /// <param name="object2"></param>
        /// <param name="object3"></param>
        /// <param name="ulong1"></param>
        internal Constant(ConstantKind kind, object? object1, object? object2, object? object3, ulong ulong1)
        {
            _kind = kind;
            _object1 = object1;
            _object2 = object2;
            _object3 = object3;
            _ulong1 = ulong1;
        }

        /// <summary>
        /// Gets the kind of the stored constant.
        /// </summary>
        public readonly ConstantKind Kind => _kind;

        public readonly bool IsNil => !IsNotNil;

        public readonly bool IsNotNil => _isNotNil;

    }

}
