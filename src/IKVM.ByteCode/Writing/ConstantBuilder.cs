using System;
using System.Collections.Generic;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;
using IKVM.ByteCode.Text;

namespace IKVM.ByteCode.Writing
{

    public class ConstantBuilder
    {

        readonly MUTF8Encoding _mutf8;
        readonly BlobBuilder _builder = new();
        ushort _count = 0;

        readonly Dictionary<string, Utf8ConstantHandle> _utf8cache = new();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="version"></param>
        public ConstantBuilder(ClassFormatVersion version)
        {
            _mutf8 = MUTF8Encoding.GetMUTF8(version.Major);
        }

        /// <summary>
        /// Adds a new UTF8 constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Utf8ConstantHandle AddUtf8Constant(ReadOnlySpan<byte> value)
        {
            // write length prefix
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantTag.Utf8);
            w.TryWriteU2((ushort)value.Length);
            _builder.WriteBytes(value);
            return new(_count++);
        }

        /// <summary>
        /// Adds a new UTF8 constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Utf8ConstantHandle AddUtf8Constant(string value)
        {
            return AddUtf8Constant(_mutf8.GetBytes(value));
        }

        /// <summary>
        /// Gets or adds a UTF8 constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Utf8ConstantHandle GetOrAddUtf8Constant(string value)
        {
            return _utf8cache.TryGetValue(value, out var w) ? w : (_utf8cache[value] = AddUtf8Constant(value));
        }

        /// <summary>
        /// Adds a new Integer constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IntegerConstantHandle AddIntegerConstant(int value)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U4).GetBytes());
            w.TryWriteU1((byte)ConstantTag.Integer);
            w.TryWriteU4((uint)value);
            return new(_count++);
        }

        /// <summary>
        /// Adds a new Float constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FloatConstantHandle AddFloatConstant(float value)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U4).GetBytes());
            w.TryWriteU1((byte)ConstantTag.Float);
#if NETFRAMEWORK || NETCOREAPP3_1
            w.TryWriteU4(RawBitConverter.SingleToUInt32Bits(value));
#else
            w.TryWriteU4(BitConverter.SingleToUInt32Bits(value));
#endif
            return new(_count++);
        }

        /// <summary>
        /// Adds a new Long constant value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LongConstantHandle AddLongConstant(long value)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U4 + ClassFormatWriter.U4).GetBytes());
            w.TryWriteU1((byte)ConstantTag.Long);
            w.TryWriteU4((uint)(value >> 32));
            w.TryWriteU4(unchecked((uint)value));

            var n = _count;
            _count += 2;
            return new(n);
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
            w.TryWriteU1((byte)ConstantTag.Double);
            w.TryWriteU4((uint)(v >> 32));
            w.TryWriteU4(unchecked((uint)v));

            var n = _count;
            _count += 2;
            return new(n);
        }

        /// <summary>
        /// Adds a new Class constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ClassConstantHandle AddClassConstant(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantTag.Class);
            w.TryWriteU2(name.Value);
            return new(_count++);
        }

        /// <summary>
        /// Adds a new String constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public StringConstantHandle AddStringConstant(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantTag.String);
            w.TryWriteU2(name.Value);
            return new(_count++);
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
            w.TryWriteU1((byte)ConstantTag.Fieldref);
            w.TryWriteU2(clazz.Value);
            w.TryWriteU2(nameAndType.Value);
            return new(_count++);
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
            w.TryWriteU1((byte)ConstantTag.Methodref);
            w.TryWriteU2(clazz.Value);
            w.TryWriteU2(nameAndType.Value);
            return new(_count++);
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
            w.TryWriteU1((byte)ConstantTag.InterfaceMethodref);
            w.TryWriteU2(clazz.Value);
            w.TryWriteU2(nameAndType.Value);
            return new(_count++);
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
            w.TryWriteU1((byte)ConstantTag.NameAndType);
            w.TryWriteU2(name.Value);
            w.TryWriteU2(type.Value);
            return new(_count++);
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
            w.TryWriteU1((byte)ConstantTag.MethodHandle);
            w.TryWriteU1((byte)kind);
            w.TryWriteU2(reference.Value);
            return new(_count++);
        }

        /// <summary>
        /// Adds a new MethodType constant value.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public MethodTypeConstantHandle AddMethodTypeConstant(Utf8ConstantHandle type)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantTag.MethodType);
            w.TryWriteU2(type.Value);
            return new(_count++);
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
            w.TryWriteU1((byte)ConstantTag.Dynamic);
            w.TryWriteU2(bootstrapMethodAttrIndex);
            w.TryWriteU2(nameAndType.Value);
            return new(_count++);
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
            w.TryWriteU1((byte)ConstantTag.InvokeDynamic);
            w.TryWriteU2(bootstrapMethodAttrIndex);
            w.TryWriteU2(nameAndType.Value);
            return new(_count++);
        }

        /// <summary>
        /// Adds a new Module constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ModuleConstantHandle AddModuleConstant(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantTag.Module);
            w.TryWriteU2(name.Value);
            return new(_count++);
        }

        /// <summary>
        /// Adds a new Package constant value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ModuleConstantHandle AddPackageConstant(Utf8ConstantHandle name)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U1 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU1((byte)ConstantTag.Package);
            w.TryWriteU2(name.Value);
            return new(_count++);
        }

        /// <summary>
        /// Serialize the constants to the specified builder.
        /// </summary>
        /// <param name="builder"></param>
        public void Serialize(BlobBuilder builder)
        {
            var w = new ClassFormatWriter(_builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(_count);
            builder.LinkSuffix(_builder);
        }

    }

}
