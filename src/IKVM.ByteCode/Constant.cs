namespace IKVM.ByteCode
{

    /// <summary>
    /// A factory for creating typed constant values to be added to a constant pool.
    /// </summary>
    public readonly struct Constant
    {

        /// <summary>
        /// Creates a new <see cref="Utf8Constant"/> with the given string value.
        /// </summary>
        /// <param name="value">The UTF-8 string value.</param>
        public static Utf8Constant Utf8(string value)
        {
            return new Utf8Constant(value);
        }

        /// <summary>
        /// Creates a new <see cref="IntegerConstant"/> from a boolean value (<c>true</c> becomes 1, <c>false</c> becomes 0).
        /// </summary>
        /// <param name="value">The boolean value.</param>
        public static IntegerConstant Integer(bool value)
        {
            return new IntegerConstant(value ? 1 : 0);
        }

        /// <summary>
        /// Creates a new <see cref="IntegerConstant"/> from a byte value.
        /// </summary>
        /// <param name="value">The byte value.</param>
        public static IntegerConstant Integer(byte value)
        {
            return new IntegerConstant((sbyte)value);
        }

        /// <summary>
        /// Creates a new <see cref="IntegerConstant"/> from a short value.
        /// </summary>
        /// <param name="value">The short value.</param>
        public static IntegerConstant Integer(short value)
        {
            return new IntegerConstant(value);
        }

        /// <summary>
        /// Creates a new <see cref="IntegerConstant"/> from an int value.
        /// </summary>
        /// <param name="value">The integer value.</param>
        public static IntegerConstant Integer(int value)
        {
            return new IntegerConstant(value);
        }

        /// <summary>
        /// Creates a new <see cref="FloatConstant"/> from a float value.
        /// </summary>
        /// <param name="value">The float value.</param>
        public static FloatConstant Float(float value)
        {
            return new FloatConstant(value);
        }

        /// <summary>
        /// Creates a new <see cref="LongConstant"/> from a long value.
        /// </summary>
        /// <param name="value">The long value.</param>
        public static LongConstant Long(long value)
        {
            return new LongConstant(value);
        }

        /// <summary>
        /// Creates a new <see cref="DoubleConstant"/> from a double value.
        /// </summary>
        /// <param name="value">The double value.</param>
        public static DoubleConstant Double(double value)
        {
            return new DoubleConstant(value);
        }

        /// <summary>
        /// Creates a new <see cref="ClassConstant"/> with the given internal class name.
        /// </summary>
        /// <param name="value">The internal class name (e.g. <c>java/lang/Object</c>).</param>
        public static ClassConstant Class(string? value)
        {
            return new ClassConstant(value);
        }

        /// <summary>
        /// Creates a new <see cref="StringConstant"/> with the given string value.
        /// </summary>
        /// <param name="value">The string value.</param>
        public static StringConstant String(string? value)
        {
            return new StringConstant(value);
        }

        /// <summary>
        /// Creates a new <see cref="FieldrefConstant"/> identifying a field.
        /// </summary>
        /// <param name="className">The internal name of the class that declares the field.</param>
        /// <param name="name">The name of the field.</param>
        /// <param name="descriptor">The field descriptor.</param>
        public static FieldrefConstant Fieldref(string? className, string? name, string? descriptor)
        {
            return new FieldrefConstant(className, name, descriptor);
        }

        /// <summary>
        /// Creates a new <see cref="MethodrefConstant"/> identifying a class method.
        /// </summary>
        /// <param name="className">The internal name of the class that declares the method.</param>
        /// <param name="name">The name of the method.</param>
        /// <param name="descriptor">The method descriptor.</param>
        public static MethodrefConstant Methodref(string? className, string? name, string? descriptor)
        {
            return new MethodrefConstant(className, name, descriptor);
        }

        /// <summary>
        /// Creates a new <see cref="InterfaceMethodrefConstant"/> identifying an interface method.
        /// </summary>
        /// <param name="className">The internal name of the interface that declares the method.</param>
        /// <param name="name">The name of the method.</param>
        /// <param name="descriptor">The method descriptor.</param>
        public static InterfaceMethodrefConstant InterfaceMethodref(string? className, string? name, string? descriptor)
        {
            return new InterfaceMethodrefConstant(className, name, descriptor);
        }

        /// <summary>
        /// Creates a new <see cref="NameAndTypeConstant"/> describing a field or method name and descriptor pair.
        /// </summary>
        /// <param name="name">The unqualified name of the field or method.</param>
        /// <param name="descriptor">The field or method descriptor.</param>
        public static NameAndTypeConstant NameAndType(string? name, string? descriptor)
        {
            return new NameAndTypeConstant(name, descriptor);
        }

        /// <summary>
        /// Creates a new <see cref="MethodHandleConstant"/> from a generic reference constant.
        /// </summary>
        /// <param name="kind">The method handle reference kind.</param>
        /// <param name="reference">The reference constant.</param>
        public static MethodHandleConstant MethodHandle(MethodHandleKind kind, RefConstant reference)
        {
            return new MethodHandleConstant(kind, reference.Kind, reference.ClassName, reference.Name, reference.Descriptor);
        }

        /// <summary>
        /// Creates a new <see cref="MethodHandleConstant"/> pointing to a field.
        /// </summary>
        /// <param name="kind">The method handle reference kind.</param>
        /// <param name="reference">The field reference constant.</param>
        public static MethodHandleConstant MethodHandle(MethodHandleKind kind, FieldrefConstant reference)
        {
            return new MethodHandleConstant(kind, ConstantKind.Fieldref, reference.ClassName, reference.Name, reference.Descriptor);
        }

        /// <summary>
        /// Creates a new <see cref="MethodHandleConstant"/> pointing to a class method.
        /// </summary>
        /// <param name="kind">The method handle reference kind.</param>
        /// <param name="reference">The method reference constant.</param>
        public static MethodHandleConstant MethodHandle(MethodHandleKind kind, MethodrefConstant reference)
        {
            return new MethodHandleConstant(kind, ConstantKind.Methodref, reference.ClassName, reference.Name, reference.Descriptor);
        }

        /// <summary>
        /// Creates a new <see cref="MethodHandleConstant"/> pointing to an interface method.
        /// </summary>
        /// <param name="kind">The method handle reference kind.</param>
        /// <param name="reference">The interface method reference constant.</param>
        public static MethodHandleConstant MethodHandle(MethodHandleKind kind, InterfaceMethodrefConstant reference)
        {
            return new MethodHandleConstant(kind, ConstantKind.InterfaceMethodref, reference.ClassName, reference.Name, reference.Descriptor);
        }

        /// <summary>
        /// Creates a new <see cref="MethodTypeConstant"/> with the given method descriptor.
        /// </summary>
        /// <param name="descriptor">The method descriptor.</param>
        public static MethodTypeConstant MethodType(string? descriptor)
        {
            return new MethodTypeConstant(descriptor);
        }

        /// <summary>
        /// Creates a new <see cref="DynamicConstant"/> representing a dynamically-computed constant.
        /// </summary>
        /// <param name="bootstrapMethodAttributeIndex">The index into the <c>BootstrapMethods</c> attribute.</param>
        /// <param name="name">The unqualified name of the constant.</param>
        /// <param name="descriptor">The field descriptor indicating the type of the constant.</param>
        public static DynamicConstant Dynamic(ushort bootstrapMethodAttributeIndex, string? name, string? descriptor)
        {
            return new DynamicConstant(bootstrapMethodAttributeIndex, name, descriptor);
        }

        /// <summary>
        /// Creates a new <see cref="InvokeDynamicConstant"/> representing a dynamically-computed call site.
        /// </summary>
        /// <param name="bootstrapMethodAttributeIndex">The index into the <c>BootstrapMethods</c> attribute.</param>
        /// <param name="name">The unqualified name of the method.</param>
        /// <param name="descriptor">The method descriptor.</param>
        public static InvokeDynamicConstant InvokeDynamic(ushort bootstrapMethodAttributeIndex, string? name, string? descriptor)
        {
            return new InvokeDynamicConstant(bootstrapMethodAttributeIndex, name, descriptor);
        }

        /// <summary>
        /// Creates a new <see cref="ModuleConstant"/> with the given module name.
        /// </summary>
        /// <param name="name">The module name.</param>
        public static ModuleConstant Module(string? name)
        {
            return new ModuleConstant(name);
        }

        /// <summary>
        /// Creates a new <see cref="PackageConstant"/> with the given package name.
        /// </summary>
        /// <param name="name">The internal form of the package name.</param>
        public static PackageConstant Package(string? name)
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
