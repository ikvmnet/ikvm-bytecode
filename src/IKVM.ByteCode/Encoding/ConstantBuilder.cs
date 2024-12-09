using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Decoding;
using IKVM.ByteCode.Text;

namespace IKVM.ByteCode.Encoding
{

    public class ConstantBuilder : IConstantPool
    {

        readonly ClassFormatVersion _version;
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
        readonly Dictionary<(MethodHandleKind kind, RefConstantHandle reference), MethodHandleConstantHandle> _methodHandleCache = new();
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
            _version = version;
            _mutf8 = MUTF8Encoding.GetMUTF8(version.Major);
        }

        /// <summary>
        /// Gets the number of constants currently added.
        /// </summary>
        public int Count => _next - 1;

        /// <summary>
        /// Gets or adds a constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ConstantHandle Add(in Constant value)
        {
            return value.Kind switch
            {
                ConstantKind.Utf8 => Add((Utf8Constant)value),
                ConstantKind.Integer => Add((IntegerConstant)value),
                ConstantKind.Float => Add((FloatConstant)value),
                ConstantKind.Long => Add((LongConstant)value),
                ConstantKind.Double => Add((DoubleConstant)value),
                ConstantKind.Class => Add((ClassConstant)value),
                ConstantKind.String => Add((StringConstant)value),
                ConstantKind.Fieldref => Add((FieldrefConstant)value),
                ConstantKind.Methodref => Add((MethodrefConstant)value),
                ConstantKind.InterfaceMethodref => Add((InterfaceMethodrefConstant)value),
                ConstantKind.NameAndType => Add((NameAndTypeConstant)value),
                ConstantKind.MethodHandle => Add((MethodHandleConstant)value),
                ConstantKind.MethodType => Add((MethodTypeConstant)value),
                ConstantKind.Dynamic => Add((DynamicConstant)value),
                ConstantKind.InvokeDynamic => Add((InvokeDynamicConstant)value),
                ConstantKind.Module => Add((ModuleConstant)value),
                ConstantKind.Package => Add((PackageConstant)value),
                _ => throw new ArgumentException("Unknown ConstantValue kind."),
            };
        }

        /// <summary>
        /// Gets or adds a constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ConstantHandle GetOrAdd(in Constant value)
        {
            return value.Kind switch
            {
                ConstantKind.Utf8 => GetOrAdd((Utf8Constant)value),
                ConstantKind.Integer => GetOrAdd((IntegerConstant)value),
                ConstantKind.Float => GetOrAdd((FloatConstant)value),
                ConstantKind.Long => GetOrAdd((LongConstant)value),
                ConstantKind.Double => GetOrAdd((DoubleConstant)value),
                ConstantKind.Class => GetOrAdd((ClassConstant)value),
                ConstantKind.String => GetOrAdd((StringConstant)value),
                ConstantKind.Fieldref => GetOrAdd((FieldrefConstant)value),
                ConstantKind.Methodref => GetOrAdd((MethodrefConstant)value),
                ConstantKind.InterfaceMethodref => GetOrAdd((InterfaceMethodrefConstant)value),
                ConstantKind.NameAndType => GetOrAdd((NameAndTypeConstant)value),
                ConstantKind.MethodHandle => GetOrAdd((MethodHandleConstant)value),
                ConstantKind.MethodType => GetOrAdd((MethodTypeConstant)value),
                ConstantKind.Dynamic => GetOrAdd((DynamicConstant)value),
                ConstantKind.InvokeDynamic => GetOrAdd((InvokeDynamicConstant)value),
                ConstantKind.Module => GetOrAdd((ModuleConstant)value),
                ConstantKind.Package => GetOrAdd((PackageConstant)value),
                _ => throw new ArgumentException("Unknown ConstantValue kind."),
            };
        }

        /// <summary>
        /// Adds a new UTF8 constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Utf8ConstantHandle AddUtf8(ReadOnlyMemory<byte> value)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ConstantKind.Utf8);
            w.WriteU2((ushort)value.Length);
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
            return _blobUtf8Cache.TryGetValue(value, out var w) ? w : AddUtf8(value);
        }

        /// <summary>
        /// Adds a new UTF8 constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Utf8ConstantHandle AddUtf8(string value)
        {
            return _stringUtf8cache[value] = AddUtf8(_mutf8.GetBytes(value));
        }

        /// <summary>
        /// Gets or adds a UTF8 constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Utf8ConstantHandle GetOrAddUtf8(string value)
        {
            return _stringUtf8cache.TryGetValue(value, out var w) ? w : _stringUtf8cache[value] = GetOrAddUtf8(_mutf8.GetBytes(value));
        }

        /// <summary>
        /// Adds a new UTF8 constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Utf8ConstantHandle Add(in Utf8Constant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddUtf8(value.Value);
        }

        /// <summary>
        /// Gets or adds a UTF8 constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Utf8ConstantHandle GetOrAdd(in Utf8Constant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddUtf8(value.Value);
        }

        /// <summary>
        /// Adds a new Integer constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IntegerConstantHandle AddInteger(int value)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U4).GetBytes());
            w.WriteU1((byte)ConstantKind.Integer);
            w.WriteU4((uint)value);
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
        /// Adds a new Integer constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IntegerConstantHandle Add(in IntegerConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddInteger(value.Value);
        }

        /// <summary>
        /// Gets or adds an Integer constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IntegerConstantHandle GetOrAdd(in IntegerConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddInteger(value.Value);
        }

        /// <summary>
        /// Adds a new Float constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FloatConstantHandle AddFloat(float value)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U4).GetBytes());
            w.WriteU1((byte)ConstantKind.Float);
            w.WriteU4(RawBitConverter.SingleToUInt32Bits(value));
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
        /// Adds a new Float constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FloatConstantHandle Add(in FloatConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddFloat(value.Value);
        }

        /// <summary>
        /// Gets or adds an Integer constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FloatConstantHandle GetOrAdd(in FloatConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddFloat(value.Value);
        }

        /// <summary>
        /// Adds a new Long constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LongConstantHandle AddLong(long value)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U4 + ClassFormatWriter.U4).GetBytes());
            w.WriteU1((byte)ConstantKind.Long);
            w.WriteU4((uint)(value >> 32));
            w.WriteU4(unchecked((uint)value));

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
        /// Adds a new Long constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LongConstantHandle Add(in LongConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddLong(value.Value);
        }

        /// <summary>
        /// Gets or adds an Long constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LongConstantHandle GetOrAdd(in LongConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddLong(value.Value);
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
            w.WriteU1((byte)ConstantKind.Double);
            w.WriteU4((uint)(v >> 32));
            w.WriteU4(unchecked((uint)v));

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
        /// Adds a new Double constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DoubleConstantHandle Add(in DoubleConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddDouble(value.Value);
        }

        /// <summary>
        /// Gets or adds an Double constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DoubleConstantHandle GetOrAdd(in DoubleConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddDouble(value.Value);
        }

        /// <summary>
        /// Adds a new Class constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ClassConstantHandle AddClass(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ConstantKind.Class);
            w.WriteU2(name.Slot);
            return _classCache[name] = new(_next++);
        }

        /// <summary>
        /// Adds a new Class constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ClassConstantHandle AddClass(string? name)
        {
            return AddClass(name != null ? GetOrAddUtf8(name) : default);
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
            return GetOrAddClass(name != null ? GetOrAddUtf8(name) : default);
        }

        /// <summary>
        /// Adds a new Class constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ClassConstantHandle Add(in ClassConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddClass(value.Name);
        }

        /// <summary>
        /// Gets or adds an Class constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ClassConstantHandle GetOrAdd(in ClassConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddClass(value.Name);
        }

        /// <summary>
        /// Adds a new String constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public StringConstantHandle AddString(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ConstantKind.String);
            w.WriteU2(name.Slot);
            return _stringCache[name] = new(_next++);
        }

        /// <summary>
        /// Adds a new String constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public StringConstantHandle AddString(string? value)
        {
            return AddString(value != null ? GetOrAddUtf8(value) : default);
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
            return GetOrAddString(value != null ? GetOrAddUtf8(value) : default);
        }

        /// <summary>
        /// Adds a new String constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public StringConstantHandle Add(in StringConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddString(value.Value);
        }

        /// <summary>
        /// Gets or adds an String constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public StringConstantHandle GetOrAdd(in StringConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddString(value.Value);
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
            w.WriteU1((byte)ConstantKind.Fieldref);
            w.WriteU2(clazz.Slot);
            w.WriteU2(nameAndType.Slot);
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
        public FieldrefConstantHandle GetOrAddFieldref(string? clazz, string? name, string? descriptor)
        {
            return GetOrAddFieldref(GetOrAddClass(clazz), GetOrAddNameAndType(name, descriptor));
        }

        /// <summary>
        /// Adds a new Fieldref constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FieldrefConstantHandle Add(in FieldrefConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddFieldref(GetOrAddClass(value.ClassName), GetOrAddNameAndType(value.Name, value.Descriptor));
        }

        /// <summary>
        /// Gets or adds an Fieldref constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FieldrefConstantHandle GetOrAdd(in FieldrefConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddFieldref(value.ClassName, value.Name, value.Descriptor);
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
            w.WriteU1((byte)ConstantKind.Methodref);
            w.WriteU2(clazz.Slot);
            w.WriteU2(nameAndType.Slot);
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
        public MethodrefConstantHandle GetOrAddMethodref(string? clazz, string? name, string? descriptor)
        {
            return GetOrAddMethodref(GetOrAddClass(clazz), GetOrAddNameAndType(name, descriptor));
        }

        /// <summary>
        /// Adds a new Methodref constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MethodrefConstantHandle Add(in MethodrefConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddMethodref(GetOrAddClass(value.ClassName), GetOrAddNameAndType(value.Name, value.Descriptor));
        }

        /// <summary>
        /// Gets or adds an Methodref constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MethodrefConstantHandle GetOrAdd(in MethodrefConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddMethodref(value.ClassName, value.Name, value.Descriptor);
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
            w.WriteU1((byte)ConstantKind.InterfaceMethodref);
            w.WriteU2(clazz.Slot);
            w.WriteU2(nameAndType.Slot);
            return _interfaceMethodrefCache[(clazz, nameAndType)] = new(_next++);
        }

        /// <summary>
        /// Gets or adds a InterfaceMethodref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public InterfaceMethodrefConstantHandle GetOrAddInterfaceMethodref(ClassConstantHandle clazz, NameAndTypeConstantHandle nameAndType)
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
        public InterfaceMethodrefConstantHandle GetOrAddInterfaceMethodref(string? clazz, string? name, string? descriptor)
        {
            return GetOrAddInterfaceMethodref(GetOrAddClass(clazz), GetOrAddNameAndType(name, descriptor));
        }

        /// <summary>
        /// Adds a new InterfaceMethodref constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public InterfaceMethodrefConstantHandle Add(in InterfaceMethodrefConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddInterfaceMethodref(GetOrAddClass(value.ClassName), GetOrAddNameAndType(value.Name, value.Descriptor));
        }

        /// <summary>
        /// Gets or adds an InterfaceMethodref constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public InterfaceMethodrefConstantHandle GetOrAdd(in InterfaceMethodrefConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddInterfaceMethodref(value.ClassName, value.Name, value.Descriptor);
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
            w.WriteU1((byte)ConstantKind.NameAndType);
            w.WriteU2(name.Slot);
            w.WriteU2(type.Slot);
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
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public NameAndTypeConstantHandle GetOrAddNameAndType(string? name, string? descriptor)
        {
            return GetOrAddNameAndType(name != null ? GetOrAddUtf8(name) : default, descriptor != null ? GetOrAddUtf8(descriptor) : default);
        }

        /// <summary>
        /// Adds a new NameAndType constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public NameAndTypeConstantHandle Add(in NameAndTypeConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddNameAndType(value.Name != null ? GetOrAddUtf8(value.Name) : default, value.Descriptor != null ? GetOrAddUtf8(value.Descriptor) : default);
        }

        /// <summary>
        /// Gets or adds an NameAndType constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public NameAndTypeConstantHandle GetOrAdd(in NameAndTypeConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddNameAndType(value.Name != null ? GetOrAddUtf8(value.Name) : default, value.Descriptor != null ? GetOrAddUtf8(value.Descriptor) : default);
        }

        /// <summary>
        /// Adds a new MethodHandle constant value.
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public MethodHandleConstantHandle AddMethodHandle(MethodHandleKind kind, RefConstantHandle reference)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ConstantKind.MethodHandle);
            w.WriteU1((byte)kind);
            w.WriteU2(reference.Index);
            return _methodHandleCache[(kind, reference)] = new(_next++);
        }

        /// <summary>
        /// Adds a new MethodHandle constant value.
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        public MethodHandleConstantHandle AddMethodHandle(MethodHandleKind kind, ConstantKind referenceKind, string? clazz, string? name, string? descriptor)
        {
            if (referenceKind is ConstantKind.Fieldref)
            {
                if (kind is not MethodHandleKind.GetField and not MethodHandleKind.GetStatic and not MethodHandleKind.PutField and not MethodHandleKind.PutStatic)
                    throw new ByteCodeException($"MethodHandle of kind {kind} cannot reference field.");

                return AddMethodHandle(kind, GetOrAddFieldref(clazz, name, descriptor));
            }

            if (referenceKind is ConstantKind.Methodref)
            {
                if (_version.Major >= 52)
                {
                    if (kind is not MethodHandleKind.InvokeVirtual and not MethodHandleKind.NewInvokeSpecial and not MethodHandleKind.InvokeStatic and not MethodHandleKind.InvokeSpecial)
                        throw new ByteCodeException($"MethodHandle of kind {kind} cannot reference method.");
                }
                else
                {
                    if (kind is not MethodHandleKind.InvokeVirtual and not MethodHandleKind.NewInvokeSpecial)
                        throw new ByteCodeException($"MethodHandle of kind {kind} cannot reference method.");
                }

                return AddMethodHandle(kind, GetOrAddMethodref(clazz, name, descriptor));
            }

            if (referenceKind is ConstantKind.InterfaceMethodref)
            {
                if (kind is not MethodHandleKind.InvokeVirtual and not MethodHandleKind.NewInvokeSpecial and not MethodHandleKind.InvokeStatic and not MethodHandleKind.InvokeSpecial and not MethodHandleKind.InvokeInterface)
                    throw new ByteCodeException($"MethodHandle of kind {kind} cannot reference method.");

                return AddMethodHandle(kind, GetOrAddInterfaceMethodref(clazz, name, descriptor));
            }

            throw new ArgumentException("Invalid ConstantKind for MethodHandle.");
        }

        /// <summary>
        /// Adds a new MethodHandle constant value.
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public MethodHandleConstantHandle GetOrAddMethodHandle(MethodHandleKind kind, RefConstantHandle reference)
        {
            return _methodHandleCache.TryGetValue((kind, reference), out var w) ? w : AddMethodHandle(kind, reference);
        }

        /// <summary>
        /// Adds a new MethodHandle constant value for the specified reference.
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        /// <exception cref="ByteCodeException"></exception>
        public MethodHandleConstantHandle GetOrAddMethodHandle(MethodHandleKind kind, ConstantKind referenceKind, string? clazz, string? name, string? descriptor)
        {
            if (referenceKind is ConstantKind.Fieldref)
            {
                if (kind is not MethodHandleKind.GetField and not MethodHandleKind.GetStatic and not MethodHandleKind.PutField and not MethodHandleKind.PutStatic)
                    throw new ByteCodeException($"MethodHandle of kind {kind} cannot reference field.");

                return GetOrAddMethodHandle(kind, GetOrAddFieldref(clazz, name, descriptor));
            }

            if (referenceKind is ConstantKind.Methodref)
            {
                if (_version.Major >= 52)
                {
                    if (kind is not MethodHandleKind.InvokeVirtual and not MethodHandleKind.NewInvokeSpecial and not MethodHandleKind.InvokeStatic and not MethodHandleKind.InvokeSpecial)
                        throw new ByteCodeException($"MethodHandle of kind {kind} cannot reference method.");
                }
                else
                {
                    if (kind is not MethodHandleKind.InvokeVirtual and not MethodHandleKind.NewInvokeSpecial)
                        throw new ByteCodeException($"MethodHandle of kind {kind} cannot reference method.");
                }

                return GetOrAddMethodHandle(kind, GetOrAddMethodref(clazz, name, descriptor));
            }

            if (referenceKind is ConstantKind.InterfaceMethodref)
            {
                if (kind is not MethodHandleKind.InvokeVirtual and not MethodHandleKind.NewInvokeSpecial and not MethodHandleKind.InvokeStatic and not MethodHandleKind.InvokeSpecial and not MethodHandleKind.InvokeInterface)
                    throw new ByteCodeException($"MethodHandle of kind {kind} cannot reference method.");

                return GetOrAddMethodHandle(kind, GetOrAddInterfaceMethodref(clazz, name, descriptor));
            }

            throw new ArgumentException("Invalid ConstantKind for MethodHandle.");
        }

        /// <summary>
        /// Adds a new MethodHandle constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MethodHandleConstantHandle Add(in MethodHandleConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddMethodHandle(value.Kind, value.ReferenceKind, value.ClassName, value.Name, value.Descriptor);
        }

        /// <summary>
        /// Gets or adds an MethodHandle constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MethodHandleConstantHandle GetOrAdd(in MethodHandleConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddMethodHandle(value.Kind, value.ReferenceKind, value.ClassName, value.Name, value.Descriptor);
        }

        /// <summary>
        /// Adds a new MethodType constant value.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public MethodTypeConstantHandle AddMethodType(Utf8ConstantHandle descriptor)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ConstantKind.MethodType);
            w.WriteU2(descriptor.Slot);
            return _methodTypeCache[descriptor] = new(_next++);
        }

        /// <summary>
        /// Adds a new MethodType constant value.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public MethodTypeConstantHandle AddMethodType(string? descriptor)
        {
            return AddMethodType(descriptor != null ? GetOrAddUtf8(descriptor) : default);
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
        /// Gets or adds a MethodType constant value.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public MethodTypeConstantHandle GetOrAddMethodType(string? descriptor)
        {
            return GetOrAddMethodType(descriptor != null ? GetOrAddUtf8(descriptor) : default);
        }

        /// <summary>
        /// Adds a new MethodType constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MethodTypeConstantHandle Add(in MethodTypeConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddMethodType(value.Descriptor);
        }

        /// <summary>
        /// Gets or adds an MethodType constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MethodTypeConstantHandle GetOrAdd(in MethodTypeConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddMethodType(value.Descriptor);
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
            w.WriteU1((byte)ConstantKind.Dynamic);
            w.WriteU2(bootstrapMethodAttrIndex);
            w.WriteU2(nameAndType.Slot);
            return _dynamicCache[(bootstrapMethodAttrIndex, nameAndType)] = new(_next++);
        }

        /// <summary>
        /// Gets or adds a Dynamic constant value.
        /// </summary>
        /// <param name="bootstrapMethodAttrIndex"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public DynamicConstantHandle AddDynamic(ushort bootstrapMethodAttrIndex, string? name, string? descriptor)
        {
            return AddDynamic(bootstrapMethodAttrIndex, GetOrAddNameAndType(name, descriptor));
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
        /// Gets or adds a Dynamic constant value.
        /// </summary>
        /// <param name="bootstrapMethodAttrIndex"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public DynamicConstantHandle GetOrAddDynamic(ushort bootstrapMethodAttrIndex, string? name, string? descriptor)
        {
            return GetOrAddDynamic(bootstrapMethodAttrIndex, GetOrAddNameAndType(name, descriptor));
        }

        /// <summary>
        /// Adds a new Dynamic constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DynamicConstantHandle Add(in DynamicConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddDynamic(value.BootstrapMethodAttributeIndex, GetOrAddNameAndType(value.Name, value.Descriptor));
        }

        /// <summary>
        /// Gets or adds an Dynamic constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DynamicConstantHandle GetOrAdd(in DynamicConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddDynamic(value.BootstrapMethodAttributeIndex, GetOrAddNameAndType(value.Name, value.Descriptor));
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
            w.WriteU1((byte)ConstantKind.InvokeDynamic);
            w.WriteU2(bootstrapMethodAttrIndex);
            w.WriteU2(nameAndType.Slot);
            return _invokeDynamicCache[(bootstrapMethodAttrIndex, nameAndType)] = new(_next++);
        }

        /// <summary>
        /// Gets or adds a InvokeDynamic constant value.
        /// </summary>
        /// <param name="bootstrapMethodAttrIndex"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public InvokeDynamicConstantHandle AddInvokeDynamic(ushort bootstrapMethodAttrIndex, string? name, string? descriptor)
        {
            return AddInvokeDynamic(bootstrapMethodAttrIndex, GetOrAddNameAndType(name, descriptor));
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
        /// Gets or adds a InvokeDynamic constant value.
        /// </summary>
        /// <param name="bootstrapMethodAttrIndex"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public InvokeDynamicConstantHandle GetOrAddInvokeDynamic(ushort bootstrapMethodAttrIndex, string name, string descriptor)
        {
            return GetOrAddInvokeDynamic(bootstrapMethodAttrIndex, GetOrAddNameAndType(name, descriptor));
        }

        /// <summary>
        /// Adds a new InvokeDynamic constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public InvokeDynamicConstantHandle Add(in InvokeDynamicConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddInvokeDynamic(value.BootstrapMethodAttributeIndex, GetOrAddNameAndType(value.Name, value.Descriptor));
        }

        /// <summary>
        /// Gets or adds an InvokeDynamic constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public InvokeDynamicConstantHandle GetOrAdd(in InvokeDynamicConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddInvokeDynamic(value.BootstrapMethodAttributeIndex, GetOrAddNameAndType(value.Name, value.Descriptor));
        }

        /// <summary>
        /// Adds a new Module constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ModuleConstantHandle AddModule(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ConstantKind.Module);
            w.WriteU2(name.Slot);
            return _moduleCache[name] = new(_next++);
        }

        /// <summary>
        /// Adds a new Module constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ModuleConstantHandle AddModule(string? name)
        {
            return AddModule(name != null ? GetOrAddUtf8(name) : default);
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
        public ModuleConstantHandle GetOrAddModule(string? name)
        {
            return GetOrAddModule(name != null ? GetOrAddUtf8(name) : default);
        }

        /// <summary>
        /// Adds a new Module constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ModuleConstantHandle Add(in ModuleConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddModule(value.Name);
        }

        /// <summary>
        /// Gets or adds an Module constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ModuleConstantHandle GetOrAdd(in ModuleConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddModule(value.Name);
        }

        /// <summary>
        /// Adds a new Package constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PackageConstantHandle AddPackage(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.WriteU1((byte)ConstantKind.Package);
            w.WriteU2(name.Slot);
            return _packageCache[name] = new(_next++);
        }

        /// <summary>
        /// Adds a new Package constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PackageConstantHandle AddPackage(string? name)
        {
            return AddPackage(name != null ? GetOrAddUtf8(name) : default);
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
        public PackageConstantHandle GetOrAddPackage(string? name)
        {
            if (name == null)
                return default;

            return GetOrAddPackage(name != null ? GetOrAddUtf8(name) : default);
        }

        /// <summary>
        /// Adds a new Package constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public PackageConstantHandle Add(in PackageConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return AddPackage(value.Name);
        }

        /// <summary>
        /// Gets or adds an Module constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public PackageConstantHandle GetOrAdd(in PackageConstant value)
        {
            if (value.IsNil)
                throw new ArgumentNullException(nameof(value));

            return GetOrAddPackage(value.Name);
        }

        /// <summary>
        /// Serialize the constants to the specified builder.
        /// </summary>
        /// <param name="builder"></param>
        public void Serialize(BlobBuilder builder)
        {
            var w = new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.WriteU2((ushort)(Count + 1));
            builder.LinkSuffix(_builder);
        }

        #region IConstantPool

        ConstantHandle IConstantPool.Get(in Constant value)
        {
            return GetOrAdd(value);
        }

        Utf8ConstantHandle IConstantPool.Get(in Utf8Constant value)
        {
            return GetOrAddUtf8(value.Value);
        }

        IntegerConstantHandle IConstantPool.Get(in IntegerConstant value)
        {
            return GetOrAddInteger(value.Value);
        }

        FloatConstantHandle IConstantPool.Get(in FloatConstant value)
        {
            return GetOrAddFloat(value.Value);
        }

        LongConstantHandle IConstantPool.Get(in LongConstant value)
        {
            return GetOrAddLong(value.Value);
        }

        DoubleConstantHandle IConstantPool.Get(in DoubleConstant value)
        {
            return GetOrAddDouble(value.Value);
        }

        ClassConstantHandle IConstantPool.Get(in ClassConstant value)
        {
            return GetOrAddClass(value.Name);
        }

        StringConstantHandle IConstantPool.Get(in StringConstant value)
        {
            return GetOrAddString(value.Value);
        }

        FieldrefConstantHandle IConstantPool.Get(in FieldrefConstant value)
        {
            return GetOrAddFieldref(value.ClassName, value.Name, value.Descriptor);
        }

        MethodrefConstantHandle IConstantPool.Get(in MethodrefConstant value)
        {
            return GetOrAddMethodref(value.ClassName, value.Name, value.Descriptor);
        }

        InterfaceMethodrefConstantHandle IConstantPool.Get(in InterfaceMethodrefConstant value)
        {
            return GetOrAddInterfaceMethodref(value.ClassName, value.Name, value.Descriptor);
        }

        NameAndTypeConstantHandle IConstantPool.Get(in NameAndTypeConstant value)
        {
            return GetOrAddNameAndType(value.Name, value.Descriptor);
        }

        MethodHandleConstantHandle IConstantPool.Get(in MethodHandleConstant value)
        {
            return GetOrAddMethodHandle(value.Kind, value.ReferenceKind, value.ClassName, value.Name, value.Descriptor);
        }

        MethodTypeConstantHandle IConstantPool.Get(in MethodTypeConstant value)
        {
            return GetOrAddMethodType(value.Descriptor);
        }

        DynamicConstantHandle IConstantPool.Get(in DynamicConstant value)
        {
            return GetOrAddDynamic(value.BootstrapMethodAttributeIndex, GetOrAddNameAndType(value.Name, value.Descriptor));
        }

        InvokeDynamicConstantHandle IConstantPool.Get(in InvokeDynamicConstant value)
        {
            return GetOrAddInvokeDynamic(value.BootstrapMethodAttributeIndex, GetOrAddNameAndType(value.Name, value.Descriptor));
        }

        ModuleConstantHandle IConstantPool.Get(in ModuleConstant value)
        {
            return GetOrAddModule(value.Name);
        }

        PackageConstantHandle IConstantPool.Get(in PackageConstant value)
        {
            return GetOrAddPackage(value.Name);
        }

        #endregion

    }

}
