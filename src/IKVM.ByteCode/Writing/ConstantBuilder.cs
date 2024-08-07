using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Reading;
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
        readonly Dictionary<Utf8ConstantHandle, MethodTypeConstantHandle> _methodTypeCache = new();

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
        public Utf8ConstantHandle GetOrAddUtf8Constant(ReadOnlyMemory<byte> value)
        {
            return _blobUtf8Cache.TryGetValue(value, out var w) ? w : AddUtf8Constant(value);
        }

        /// <summary>
        /// Adds a new UTF8 constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Utf8ConstantHandle AddUtf8Constant(string value)
        {
            return _stringUtf8cache[value] = AddUtf8Constant(_mutf8.GetBytes(value));
        }

        /// <summary>
        /// Gets or adds a UTF8 constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Utf8ConstantHandle GetOrAddUtf8Constant(string value)
        {
            return _stringUtf8cache.TryGetValue(value, out var w) ? w : _stringUtf8cache[value] = GetOrAddUtf8Constant(_mutf8.GetBytes(value));
        }

        /// <summary>
        /// Adds a new Integer constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IntegerConstantHandle AddIntegerConstant(int value)
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
        public IntegerConstantHandle GetOrAddIntegerConstant(int value)
        {
            return _integerCache.TryGetValue(value, out var w) ? w : AddIntegerConstant(value);
        }

        /// <summary>
        /// Adds a new Float constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FloatConstantHandle AddFloatConstant(float value)
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
        public FloatConstantHandle GetOrAddFloatConstant(float value)
        {
            return _floatCache.TryGetValue(value, out var w) ? w : AddFloatConstant(value);
        }

        /// <summary>
        /// Adds a new Long constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LongConstantHandle AddLongConstant(long value)
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
        public LongConstantHandle GetOrAddLongConstant(long value)
        {
            return _longCache.TryGetValue(value, out var w) ? w : AddLongConstant(value);
        }

        /// <summary>
        /// Adds a new Double constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DoubleConstantHandle AddDoubleConstant(double value)
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
        public DoubleConstantHandle GetOrAddDoubleConstant(double value)
        {
            return _doubleCache.TryGetValue(value, out var w) ? w : AddDoubleConstant(value);
        }

        /// <summary>
        /// Adds a new Class constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ClassConstantHandle AddClassConstant(Utf8ConstantHandle name)
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
        public ClassConstantHandle AddClassConstant(string name)
        {
            return AddClassConstant(GetOrAddUtf8Constant(name));
        }

        /// <summary>
        /// Gets or adds a Class constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ClassConstantHandle GetOrAddClassConstant(Utf8ConstantHandle name)
        {
            return _classCache.TryGetValue(name, out var w) ? w : AddClassConstant(name);
        }

        /// <summary>
        /// Gets or adds a Class constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ClassConstantHandle GetOrAddClassConstant(string name)
        {
            return GetOrAddClassConstant(GetOrAddUtf8Constant(name));
        }

        /// <summary>
        /// Adds a new String constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public StringConstantHandle AddStringConstant(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.String);
            w.TryWriteU2(name.Index);
            return new(_next++);
        }

        /// <summary>
        /// Adds a new String constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public StringConstantHandle AddStringConstant(string name)
        {
            return AddStringConstant(GetOrAddUtf8Constant(name));
        }

        /// <summary>
        /// Gets or adds a String constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public StringConstantHandle GetOrAddStringConstant(Utf8ConstantHandle name)
        {
            return _stringCache.TryGetValue(name, out var w) ? w : AddStringConstant(name);
        }

        /// <summary>
        /// Gets or adds a String constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public StringConstantHandle GetOrAddStringConstant(string name)
        {
            return GetOrAddStringConstant(GetOrAddUtf8Constant(name));
        }

        /// <summary>
        /// Adds a new Fieldref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public FieldrefConstantHandle AddFieldrefConstant(ClassConstantHandle clazz, NameAndTypeConstantHandle nameAndType)
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
        public FieldrefConstantHandle GetOrAddFieldrefConstant(ClassConstantHandle clazz, NameAndTypeConstantHandle nameAndType)
        {
            return _fieldrefCache.TryGetValue((clazz, nameAndType), out var w) ? w : AddFieldrefConstant(clazz, nameAndType);
        }

        /// <summary>
        /// Gets or adds a Fieldref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public FieldrefConstantHandle GetOrAddFieldrefConstant(string clazz, string name, string descriptor)
        {
            return GetOrAddFieldrefConstant(GetOrAddClassConstant(clazz), GetOrAddNameAndTypeConstant(name, descriptor));
        }

        /// <summary>
        /// Adds a new Methodref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public MethodrefConstantHandle AddMethodrefConstant(ClassConstantHandle clazz, NameAndTypeConstantHandle nameAndType)
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
        public MethodrefConstantHandle GetOrAddMethodrefConstant(ClassConstantHandle clazz, NameAndTypeConstantHandle nameAndType)
        {
            return _methodrefCache.TryGetValue((clazz, nameAndType), out var w) ? w : AddMethodrefConstant(clazz, nameAndType);
        }

        /// <summary>
        /// Gets or adds a Methodref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public MethodrefConstantHandle GetOrAddMethodrefConstant(string clazz, string name, string descriptor)
        {
            return GetOrAddMethodrefConstant(GetOrAddClassConstant(clazz), GetOrAddNameAndTypeConstant(name, descriptor));
        }

        /// <summary>
        /// Adds a new InterfaceMethodref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public InterfaceMethodrefConstantHandle AddInterfaceMethodrefConstant(ClassConstantHandle clazz, NameAndTypeConstantHandle nameAndType)
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
        public InterfaceMethodrefConstantHandle GetOrAddInterfacerefConstant(ClassConstantHandle clazz, NameAndTypeConstantHandle nameAndType)
        {
            return _interfaceMethodrefCache.TryGetValue((clazz, nameAndType), out var w) ? w : AddInterfaceMethodrefConstant(clazz, nameAndType);
        }

        /// <summary>
        /// Gets or adds a InterfaceMethodref constant value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public InterfaceMethodrefConstantHandle GetOrAddInterfacerefConstant(string clazz, string name, string descriptor)
        {
            return GetOrAddInterfacerefConstant(GetOrAddClassConstant(clazz), GetOrAddNameAndTypeConstant(name, descriptor));
        }

        /// <summary>
        /// Adds a new NameAndType constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public NameAndTypeConstantHandle AddNameAndTypeConstant(Utf8ConstantHandle name, Utf8ConstantHandle type)
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
        public NameAndTypeConstantHandle GetOrAddNameAndTypeConstant(Utf8ConstantHandle name, Utf8ConstantHandle type)
        {
            return _nameAndTypeCache.TryGetValue((name, type), out var w) ? w : AddNameAndTypeConstant(name, type);
        }

        /// <summary>
        /// Gets or adds a NameAndType constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public NameAndTypeConstantHandle GetOrAddNameAndTypeConstant(string name, string type)
        {
            return GetOrAddNameAndTypeConstant(GetOrAddUtf8Constant(name), GetOrAddUtf8Constant(type));
        }

        /// <summary>
        /// Adds a new MethodHandle constant value.
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public MethodHandleConstantHandle AddMethodHandleConstant(ReferenceKind kind, RefConstantHandle reference)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.MethodHandle);
            w.TryWriteU1((byte)kind);
            w.TryWriteU2(reference.Index);
            return new(_next++);
        }

        /// <summary>
        /// Adds a new MethodType constant value.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public MethodTypeConstantHandle AddMethodTypeConstant(Utf8ConstantHandle type)
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
        public MethodTypeConstantHandle GetOrAddMethodTypeConstant(Utf8ConstantHandle type)
        {
            return _methodTypeCache.TryGetValue(type, out var w) ? w : AddMethodTypeConstant(type);
        }

        /// <summary>
        /// Adds a new Dynamic constant value.
        /// </summary>
        /// <param name="bootstrapMethodAttrIndex"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public DynamicConstantHandle AddDynamicConstant(ushort bootstrapMethodAttrIndex, NameAndTypeConstantHandle nameAndType)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.Dynamic);
            w.TryWriteU2(bootstrapMethodAttrIndex);
            w.TryWriteU2(nameAndType.Index);
            return new(_next++);
        }

        /// <summary>
        /// Adds a new InvokeDynamic constant value.
        /// </summary>
        /// <param name="bootstrapMethodAttrIndex"></param>
        /// <param name="nameAndType"></param>
        /// <returns></returns>
        public InvokeDynamicConstantHandle AddInvokeDynamicConstant(ushort bootstrapMethodAttrIndex, NameAndTypeConstantHandle nameAndType)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.InvokeDynamic);
            w.TryWriteU2(bootstrapMethodAttrIndex);
            w.TryWriteU2(nameAndType.Index);
            return new(_next++);
        }

        /// <summary>
        /// Adds a new Module constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ModuleConstantHandle AddModuleConstant(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.Module);
            w.TryWriteU2(name.Index);
            return new(_next++);
        }

        /// <summary>
        /// Adds a new Module constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ModuleConstantHandle AddModuleConstant(string name)
        {
            return AddModuleConstant(GetOrAddUtf8Constant(name));
        }

        /// <summary>
        /// Adds a new Package constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PackageConstantHandle AddPackageConstant(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantKind.Package);
            w.TryWriteU2(name.Index);
            return new(_next++);
        }

        /// <summary>
        /// Adds a new Package constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PackageConstantHandle AddPackageConstant(string name)
        {
            return AddPackageConstant(GetOrAddUtf8Constant(name));
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
