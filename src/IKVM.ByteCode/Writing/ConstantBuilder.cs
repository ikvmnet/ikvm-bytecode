using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Text;

namespace IKVM.ByteCode.Writing
{

    public class ConstantBuilder
    {

        readonly MUTF8Encoding _mutf8;
        readonly BlobBuilder _builder = new();
        ushort _next = 1;

        readonly Dictionary<ReadOnlyMemory<byte>, Utf8ConstantHandle> _blobUtf8Cache = new(new ReadOnlyByteMemoryEqualityComparer());
        readonly Dictionary<string, Utf8ConstantHandle> _stringUtf8cache = new();
        readonly Dictionary<int, IntegerConstantHandle> _integerCache = new();
        readonly Dictionary<long, LongConstantHandle> _longCache = new();
        readonly Dictionary<float, FloatConstantHandle> _floatCache = new();
        readonly Dictionary<double, DoubleConstantHandle> _doubleCache = new();
        readonly Dictionary<Utf8ConstantHandle, ClassConstantHandle> _classCache = new();
        readonly Dictionary<Utf8ConstantHandle, StringConstantHandle> _stringCache = new();
        readonly Dictionary<(Utf8ConstantHandle, Utf8ConstantHandle), NameAndTypeConstantHandle> _nameAndTypeCache = new();
        readonly Dictionary<(ClassConstantHandle, NameAndTypeConstantHandle), FieldrefConstantHandle> _fieldrefCache = new();
        readonly Dictionary<(ClassConstantHandle, NameAndTypeConstantHandle), MethodrefConstantHandle> _methodrefCache = new();
        readonly Dictionary<(ClassConstantHandle, NameAndTypeConstantHandle), InterfaceMethodrefConstantHandle> _interfaceMethodrefCache = new();
        readonly Dictionary<(ReferenceKind kind, RefConstantHandle reference), MethodHandleConstantHandle> _methodHandleCache = new();
        readonly Dictionary<Utf8ConstantHandle, MethodTypeConstantHandle> _methodTypeCache = new();
        readonly Dictionary<(ushort bootstrapMethodAttrIndex, NameAndTypeConstantHandle nameAndType), DynamicConstantHandle> _dynamicCache = new();
        readonly Dictionary<(ushort bootstrapMethodAttrIndex, NameAndTypeConstantHandle nameAndType), InvokeDynamicConstantHandle> _invokeDynamicCache = new();
        readonly Dictionary<Utf8ConstantHandle, ModuleConstantHandle> _moduleCache = new();
        readonly Dictionary<Utf8ConstantHandle, PackageConstantHandle> _packageCache = new();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="version"></param>
        public ConstantBuilder(ClassFormatVersion version)
        {
            _mutf8 = MUTF8Encoding.GetMUTF8(version.Major);
        }

        /// <summary>
        /// Gets the number of constants currently added.
        /// </summary>
        public int Count => _next - 1;

        /// <summary>
        /// Adds a new UTF8 constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Utf8ConstantHandle AddUtf8Constant(ReadOnlyMemory<byte> value)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.Utf8);
            w.TryWriteU2((ushort)value.Length);
            _builder.WriteBytes(value.Span);
            return _blobUtf8Cache[value] = new(_next++);
        }

        /// <summary>
        /// Gets or adds a UTF8 constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Utf8ConstantHandle GetOrAddUtf8(ReadOnlyMemory<byte> value)
        {
            return _blobUtf8Cache.TryGetValue(value, out var w) ? w : AddUtf8Constant(value);
        }

        /// <summary>
        /// Adds a new UTF8 constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Utf8ConstantHandle AddUtf8(string? value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            return _stringUtf8cache[value] = AddUtf8Constant(_mutf8.GetBytes(value));
        }

        /// <summary>
        /// Gets or adds a UTF8 constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Utf8ConstantHandle GetOrAddUtf8(string? value)
        {
            if (value == null)
                return default;
            else
                return _stringUtf8cache.TryGetValue(value, out var w) ? w : _stringUtf8cache[value] = GetOrAddUtf8(_mutf8.GetBytes(value));
        }

        /// <summary>
        /// Adds a new Integer constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IntegerConstantHandle AddInteger(int value)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U4).GetBytes());
            w.TryWriteU1((byte)ConstantKind.Integer);
            w.TryWriteU4((uint)value);
            return _integerCache[value] = new(_next++);
        }

        /// <summary>
        /// Gets or adds an Integer constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IntegerConstantHandle GetOrAddInteger(int value)
        {
            return _integerCache.TryGetValue(value, out var w) ? w : AddInteger(value);
        }

        /// <summary>
        /// Adds a new Float constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FloatConstantHandle AddFloat(float value)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U4).GetBytes());
            w.TryWriteU1((byte)ConstantKind.Float);
#if NETFRAMEWORK || NETCOREAPP3_1
            w.TryWriteU4(RawBitConverter.SingleToUInt32Bits(value));
#else
            w.TryWriteU4(BitConverter.SingleToUInt32Bits(value));
#endif
            return _floatCache[value] = new(_next++);
        }

        /// <summary>
        /// Gets or adds a Float constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FloatConstantHandle GetOrAddFloat(float value)
        {
            return _floatCache.TryGetValue(value, out var w) ? w : AddFloat(value);
        }

        /// <summary>
        /// Adds a new Long constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LongConstantHandle AddLong(long value)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U4 + ClassFormatWriter.U4).GetBytes());
            w.TryWriteU1((byte)ConstantKind.Long);
            w.TryWriteU4((uint)(value >> 32));
            w.TryWriteU4(unchecked((uint)value));

            var n = _next;
            _next += 2;
            return _longCache[value] = new(n);
        }

        /// <summary>
        /// Gets or adds a Long constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LongConstantHandle GetOrAddLong(long value)
        {
            return _longCache.TryGetValue(value, out var w) ? w : AddLong(value);
        }

        /// <summary>
        /// Adds a new Double constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DoubleConstantHandle AddDouble(double value)
        {
            var v = RawBitConverter.DoubleToUInt64Bits(value);
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U4 + ClassFormatWriter.U4).GetBytes());
            w.TryWriteU1((byte)ConstantKind.Double);
            w.TryWriteU4((uint)(v >> 32));
            w.TryWriteU4(unchecked((uint)v));

            var n = _next;
            _next += 2;
            return _doubleCache[value] = new(n);
        }

        /// <summary>
        /// Gets or adds a Double constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DoubleConstantHandle GetOrAddDouble(double value)
        {
            return _doubleCache.TryGetValue(value, out var w) ? w : AddDouble(value);
        }

        /// <summary>
        /// Adds a new Class constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ClassConstantHandle AddClass(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.Class);
            w.TryWriteU2(name.Index);
            return _classCache[name] = new(_next++);
        }

        /// <summary>
        /// Adds a new Class constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ClassConstantHandle AddClass(string? name)
        {
            return AddClass(GetOrAddUtf8(name));
        }

        /// <summary>
        /// Gets or adds a Class constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ClassConstantHandle GetOrAddClass(Utf8ConstantHandle name)
        {
            return _classCache.TryGetValue(name, out var w) ? w : AddClass(name);
        }

        /// <summary>
        /// Gets or adds a Class constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ClassConstantHandle GetOrAddClass(string? name)
        {
            return GetOrAddClass(GetOrAddUtf8(name));
        }

        /// <summary>
        /// Adds a new String constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public StringConstantHandle AddString(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.String);
            w.TryWriteU2(name.Index);
            return _stringCache[name] = new(_next++);
        }

        /// <summary>
        /// Adds a new String constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public StringConstantHandle AddString(string? value)
        {
            return AddString(GetOrAddUtf8(value));
        }

        /// <summary>
        /// Gets or adds a String constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public StringConstantHandle GetOrAddString(Utf8ConstantHandle value)
        {
            return _stringCache.TryGetValue(value, out var w) ? w : AddString(value);
        }

        /// <summary>
        /// Gets or adds a String constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public StringConstantHandle GetOrAddString(string? value)
        {
            return GetOrAddString(GetOrAddUtf8(value));
        }

        /// <summary>
        /// Adds a new Fieldref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public FieldrefConstantHandle AddFieldref(ClassConstantHandle clazz, NameAndTypeConstantHandle nameAndType)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.Fieldref);
            w.TryWriteU2(clazz.Index);
            w.TryWriteU2(nameAndType.Index);
            return _fieldrefCache[(clazz, nameAndType)] = new(_next++);
        }

        /// <summary>
        /// Gets or adds a Fieldref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public FieldrefConstantHandle GetOrAddFieldref(ClassConstantHandle clazz, NameAndTypeConstantHandle nameAndType)
        {
            return _fieldrefCache.TryGetValue((clazz, nameAndType), out var w) ? w : AddFieldref(clazz, nameAndType);
        }

        /// <summary>
        /// Gets or adds a Fieldref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public FieldrefConstantHandle GetOrAddFieldref(string clazz, string name, string descriptor)
        {
            return GetOrAddFieldref(GetOrAddClass(clazz), GetOrAddNameAndType(name, descriptor));
        }

        /// <summary>
        /// Adds a new Methodref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public MethodrefConstantHandle AddMethodref(ClassConstantHandle clazz, NameAndTypeConstantHandle nameAndType)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.Methodref);
            w.TryWriteU2(clazz.Index);
            w.TryWriteU2(nameAndType.Index);
            return _methodrefCache[(clazz, nameAndType)] = new(_next++);
        }

        /// <summary>
        /// Gets or adds a Methodref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public MethodrefConstantHandle GetOrAddMethodref(ClassConstantHandle clazz, NameAndTypeConstantHandle nameAndType)
        {
            return _methodrefCache.TryGetValue((clazz, nameAndType), out var w) ? w : AddMethodref(clazz, nameAndType);
        }

        /// <summary>
        /// Gets or adds a Methodref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public MethodrefConstantHandle GetOrAddMethodref(string clazz, string name, string descriptor)
        {
            return GetOrAddMethodref(GetOrAddClass(clazz), GetOrAddNameAndType(name, descriptor));
        }

        /// <summary>
        /// Adds a new InterfaceMethodref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public InterfaceMethodrefConstantHandle AddInterfaceMethodref(ClassConstantHandle clazz, NameAndTypeConstantHandle nameAndType)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.InterfaceMethodref);
            w.TryWriteU2(clazz.Index);
            w.TryWriteU2(nameAndType.Index);
            return _interfaceMethodrefCache[(clazz, nameAndType)] = new(_next++);
        }

        /// <summary>
        /// Gets or adds a InterfaceMethodref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public InterfaceMethodrefConstantHandle GetOrAddInterfaceref(ClassConstantHandle clazz, NameAndTypeConstantHandle nameAndType)
        {
            return _interfaceMethodrefCache.TryGetValue((clazz, nameAndType), out var w) ? w : AddInterfaceMethodref(clazz, nameAndType);
        }

        /// <summary>
        /// Gets or adds a InterfaceMethodref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public InterfaceMethodrefConstantHandle GetOrAddInterfaceref(string clazz, string name, string descriptor)
        {
            return GetOrAddInterfaceref(GetOrAddClass(clazz), GetOrAddNameAndType(name, descriptor));
        }

        /// <summary>
        /// Adds a new NameAndType constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public NameAndTypeConstantHandle AddNameAndType(Utf8ConstantHandle name, Utf8ConstantHandle type)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.NameAndType);
            w.TryWriteU2(name.Index);
            w.TryWriteU2(type.Index);
            return _nameAndTypeCache[(name, type)] = new NameAndTypeConstantHandle(_next++);
        }

        /// <summary>
        /// Gets or adds a NameAndType constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public NameAndTypeConstantHandle GetOrAddNameAndType(Utf8ConstantHandle name, Utf8ConstantHandle type)
        {
            return _nameAndTypeCache.TryGetValue((name, type), out var w) ? w : AddNameAndType(name, type);
        }

        /// <summary>
        /// Gets or adds a NameAndType constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public NameAndTypeConstantHandle GetOrAddNameAndType(string name, string type)
        {
            return GetOrAddNameAndType(GetOrAddUtf8(name), GetOrAddUtf8(type));
        }

        /// <summary>
        /// Adds a new MethodHandle constant value.
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public MethodHandleConstantHandle AddMethodHandle(ReferenceKind kind, RefConstantHandle reference)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.MethodHandle);
            w.TryWriteU1((byte)kind);
            w.TryWriteU2(reference.Index);
            return _methodHandleCache[(kind, reference)] = new(_next++);
        }

        /// <summary>
        /// Adds a new MethodHandle constant value.
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public MethodHandleConstantHandle GetOrAddMethodHandle(ReferenceKind kind, RefConstantHandle reference)
        {
            return _methodHandleCache.TryGetValue((kind, reference), out var w) ? w : AddMethodHandle(kind, reference);
        }

        /// <summary>
        /// Adds a new MethodType constant value.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public MethodTypeConstantHandle AddMethodType(Utf8ConstantHandle type)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.MethodType);
            w.TryWriteU2(type.Index);
            return _methodTypeCache[type] = new(_next++);
        }

        /// <summary>
        /// Gets or adds a MethodType constant value.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public MethodTypeConstantHandle GetOrAddMethodType(Utf8ConstantHandle type)
        {
            return _methodTypeCache.TryGetValue(type, out var w) ? w : AddMethodType(type);
        }

        /// <summary>
        /// Adds a new Dynamic constant value.
        /// </summary>
        /// <param name="bootstrapMethodAttrIndex"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public DynamicConstantHandle AddDynamic(ushort bootstrapMethodAttrIndex, NameAndTypeConstantHandle nameAndType)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.Dynamic);
            w.TryWriteU2(bootstrapMethodAttrIndex);
            w.TryWriteU2(nameAndType.Index);
            return _dynamicCache[(bootstrapMethodAttrIndex, nameAndType)] = new(_next++);
        }

        /// <summary>
        /// Gets or adds a Dynamic constant value.
        /// </summary>
        /// <param name="bootstrapMethodAttrIndex"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public DynamicConstantHandle GetOrAddDynamic(ushort bootstrapMethodAttrIndex, NameAndTypeConstantHandle nameAndType)
        {
            return _dynamicCache.TryGetValue((bootstrapMethodAttrIndex, nameAndType), out var w) ? w : AddDynamic(bootstrapMethodAttrIndex, nameAndType);
        }

        /// <summary>
        /// Adds a new InvokeDynamic constant value.
        /// </summary>
        /// <param name="bootstrapMethodAttrIndex"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public InvokeDynamicConstantHandle AddInvokeDynamic(ushort bootstrapMethodAttrIndex, NameAndTypeConstantHandle nameAndType)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.InvokeDynamic);
            w.TryWriteU2(bootstrapMethodAttrIndex);
            w.TryWriteU2(nameAndType.Index);
            return _invokeDynamicCache[(bootstrapMethodAttrIndex, nameAndType)] = new(_next++);
        }

        /// <summary>
        /// Gets or adds a InvokeDynamic constant value.
        /// </summary>
        /// <param name="bootstrapMethodAttrIndex"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public InvokeDynamicConstantHandle GetOrAddInvokeDynamic(ushort bootstrapMethodAttrIndex, NameAndTypeConstantHandle nameAndType)
        {
            return _invokeDynamicCache.TryGetValue((bootstrapMethodAttrIndex, nameAndType), out var w) ? w : AddInvokeDynamic(bootstrapMethodAttrIndex, nameAndType);
        }

        /// <summary>
        /// Adds a new Module constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ModuleConstantHandle AddModule(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.Module);
            w.TryWriteU2(name.Index);
            return _moduleCache[name] = new(_next++);
        }

        /// <summary>
        /// Adds a new Module constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ModuleConstantHandle AddModule(string name)
        {
            return AddModule(GetOrAddUtf8(name));
        }

        /// <summary>
        /// Gets or adds a Module constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ModuleConstantHandle GetOrAddModule(Utf8ConstantHandle name)
        {
            return _moduleCache.TryGetValue(name, out var w) ? w : AddModule(name);
        }

        /// <summary>
        /// Gets or adds a Module constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ModuleConstantHandle GetOrAddModule(string name)
        {
            return GetOrAddModule(GetOrAddUtf8(name));
        }

        /// <summary>
        /// Adds a new Package constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PackageConstantHandle AddPackage(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.Package);
            w.TryWriteU2(name.Index);
            return _packageCache[name] = new(_next++);
        }

        /// <summary>
        /// Adds a new Package constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PackageConstantHandle AddPackage(string name)
        {
            return AddPackage(GetOrAddUtf8(name));
        }

        /// <summary>
        /// Gets or adds a Package constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PackageConstantHandle GetOrAddPackage(Utf8ConstantHandle name)
        {
            return _packageCache.TryGetValue(name, out var w) ? w : AddPackage(name);
        }

        /// <summary>
        /// Gets or adds a Package constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PackageConstantHandle GetOrAddPackage(string name)
        {
            return GetOrAddPackage(GetOrAddUtf8(name));
        }

        /// <summary>
        /// Serialize the constants to the specified builder.
        /// </summary>
        /// <param name="builder"></param>
        public void Serialize(BlobBuilder builder)
        {
            var w = new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2((ushort)(Count + 1));
            builder.LinkSuffix(_builder);
        }

    }

}
