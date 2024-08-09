using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public class ConstantTable : IConstantView, IConstantPool, IReadOnlyCollection<ConstantHandle>
    {

        public struct Enumerator : IEnumerator<ConstantHandle>
        {

            readonly ConstantData[] _constants;
            int _index = 0;
            int _skip = 1;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="constants"></param>
            internal Enumerator(ConstantData[] constants)
            {
                _constants = constants ?? throw new ArgumentNullException(nameof(constants));
            }

            /// <inheritdoc />
            public readonly ConstantHandle Current => new(_constants[checked((ushort)_index)].Kind, checked((ushort)_index));

            /// <inheritdoc />
            public bool MoveNext()
            {
                // advance to next constant
                _index += _skip;
                if (_index >= _constants.Length)
                    return false;

                // current constant governs how many we should skip to reach the next constant
                _skip = _constants[_index].Kind is ConstantKind.Long or ConstantKind.Double ? 2 : 1;
                return true;
            }

            /// <inheritdoc />
            public void Reset()
            {
                _index = -1;
            }

            /// <inheritdoc />
            public readonly void Dispose()
            {

            }

            /// <inheritdoc />
            readonly object IEnumerator.Current => Current;

        }

        readonly ClassFormatVersion _version;
        readonly ConstantData[] _items;
        readonly int _count = 0;
        Utf8ConstantData[]? _utf8Cache;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="constants"></param>
        public ConstantTable(ClassFormatVersion version, ConstantData[] constants)
        {
            _version = version;
            _items = constants;

            // since longs and doubles take two slots, count
            foreach (var constant in constants)
                _count += constant.Kind is ConstantKind.Long or ConstantKind.Double ? 2 : 1;
        }

        /// <summary>
        /// Gets the untyped constant for the given handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public ref readonly ConstantData this[ConstantHandle handle] => ref ReadData(handle);

        /// <summary>
        /// Gets the untyped constant for the given handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        ref readonly ConstantData ReadData(ConstantHandle handle) => ref _items[handle.Index];

        /// <summary>
        /// Gets the number of constants.
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Gets an enumerator over the interfaces.
        /// </summary>
        public Enumerator GetEnumerator() => new(_items);

        /// <summary>
        /// Gets the <see cref="ConstantData"/> value refered to by the <see cref="ConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ByteCodeException"></exception>
        public ConstantData Read(ConstantHandle handle)
        {
            return ReadData(handle);
        }

        /// <summary>
        /// Gets the <see cref="Utf8Constant"/> value refered to by the <see cref="Utf8ConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ByteCodeException"></exception>
        public Constant Get(ConstantHandle handle)
        {
            var kind = Read(handle).Kind;
            if (handle.Kind != ConstantKind.Unknown && handle.Kind != kind)
                throw new ArgumentException("Incompatible constant handle kind.");

            return kind switch
            {
                ConstantKind.Utf8 => Get((Utf8ConstantHandle)handle),
                ConstantKind.Integer => Get((IntegerConstantHandle)handle),
                ConstantKind.Float => Get((FloatConstantHandle)handle),
                ConstantKind.Long => Get((LongConstantHandle)handle),
                ConstantKind.Double => Get((DoubleConstantHandle)handle),
                ConstantKind.Class => Get((ClassConstantHandle)handle),
                ConstantKind.String => Get((StringConstantHandle)handle),
                ConstantKind.Fieldref => Get((FieldrefConstantHandle)handle),
                ConstantKind.Methodref => Get((MethodrefConstantHandle)handle),
                ConstantKind.InterfaceMethodref => Get((InterfaceMethodrefConstantHandle)handle),
                ConstantKind.NameAndType => Get((NameAndTypeConstantHandle)handle),
                ConstantKind.MethodHandle => Get((MethodHandleConstantHandle)handle),
                ConstantKind.MethodType => Get((MethodTypeConstantHandle)handle),
                ConstantKind.Dynamic => Get((DynamicConstantHandle)handle),
                ConstantKind.InvokeDynamic => Get((InvokeDynamicConstantHandle)handle),
                ConstantKind.Module => Get((ModuleConstantHandle)handle),
                ConstantKind.Package => Get((PackageConstantHandle)handle),
                _ => throw new ArgumentException("Unknown ConstantHandle kind."),
            };
        }

        /// <summary>
        /// Gets the <see cref="Utf8ConstantData"/> value refered to by the <see cref="Utf8ConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ByteCodeException"></exception>
        public Utf8ConstantData Read(Utf8ConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            // we cache UTF8 values
            _utf8Cache ??= new Utf8ConstantData[_items.Length];
            var cached = _utf8Cache[handle.Index];
            if (cached.Value != null)
                return cached;

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Utf8)
                throw new InvalidClassException($"Constant at index {handle.Index} is not a Utf8 constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (Utf8ConstantData.TryRead(ref reader, out var value, _version.Major) == false)
                throw new InvalidClassException($"Failed to read Utf8 constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="Utf8Constant"/> value refered to by the <see cref="Utf8ConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ByteCodeException"></exception>
        public Utf8Constant Get(Utf8ConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            return new Utf8Constant(value.Value);
        }

        /// <summary>
        /// Gets the <see cref="IntegerConstantData"/> value refered to by the <see cref="IntegerConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public IntegerConstantData Read(IntegerConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Integer)
                throw new InvalidClassException($"Constant at index {handle.Index} is not an Integer constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (IntegerConstantData.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"Failed to read Integer constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="IntegerConstant"/> value refered to by the <see cref="IntegerConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public IntegerConstant Get(IntegerConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            return new IntegerConstant(value.Value);
        }

        /// <summary>
        /// Gets the <see cref="FloatConstantData"/> value refered to by the <see cref="FloatConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public FloatConstantData Read(FloatConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Float)
                throw new InvalidClassException($"Constant at index {handle.Index} is not a Float constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (FloatConstantData.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"Failed to read Float constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="FloatConstant"/> value refered to by the <see cref="FloatConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public FloatConstant Get(FloatConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            return new FloatConstant(value.Value);
        }

        /// <summary>
        /// Gets the <see cref="LongConstantData"/> value refered to by the <see cref="LongConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public LongConstantData Read(LongConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Long)
                throw new InvalidClassException($"Constant at index {handle.Index} is not a Long constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (LongConstantData.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"Failed to read Long constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="LongConstant"/> value refered to by the <see cref="LongConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public LongConstant Get(LongConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            return new LongConstant(value.Value);
        }

        /// <summary>
        /// Gets the <see cref="DoubleConstantData"/> value refered to by the <see cref="DoubleConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public DoubleConstantData Read(DoubleConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Double)
                throw new InvalidClassException($"Constant at index {handle.Index} is not a Double constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (DoubleConstantData.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"Failed to read Double constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="DoubleConstantData"/> value refered to by the <see cref="DoubleConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public DoubleConstant Get(DoubleConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            return new DoubleConstant(value.Value);
        }

        /// <summary>
        /// Gets the <see cref="ClassConstantData"/> value refered to by the <see cref="ClassConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public ClassConstantData Read(ClassConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Class)
                throw new InvalidClassException($"Constant at index {handle.Index} is not a Class constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (ClassConstantData.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"Failed to read Class constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="ClassConstantData"/> value refered to by the <see cref="ClassConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public ClassConstant Get(ClassConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            if (value.Name.IsNil)
                throw new InvalidClassException("Nil name on ClassConstant.");

            var nameValue = Read(value.Name);
            return new ClassConstant(nameValue.Value);
        }

        /// <summary>
        /// Gets the <see cref="StringConstantData"/> value refered to by the <see cref="StringConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public StringConstantData Read(StringConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.String)
                throw new InvalidClassException($"Constant at index {handle.Index} is not a String constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (StringConstantData.TryReadStringConstant(ref reader, out var value) == false)
                throw new InvalidClassException($"Failed to read String constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="StringConstant"/> value refered to by the <see cref="StringConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public StringConstant Get(StringConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            if (value.Value.IsNil)
                throw new InvalidClassException("Nil Value on StringConstant.");

            var nameValue = Read(value.Value);
            return new StringConstant(nameValue.Value);
        }

        /// <summary>
        /// Gets the <see cref="RefConstant"/> value refered to by the <see cref="RefConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public RefConstant Get(RefConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var kind = ReadData(handle).Kind;
            if (kind == ConstantKind.Fieldref)
                return Get((FieldrefConstantHandle)handle);
            if (kind == ConstantKind.Methodref)
                return Get((MethodrefConstantHandle)handle);
            if (kind == ConstantKind.InterfaceMethodref)
                return Get((InterfaceMethodrefConstantHandle)handle);

            throw new InvalidClassException("Unexpected Kind on RefConstant.");
        }

        /// <summary>
        /// Gets the <see cref="FieldrefConstantData"/> value refered to by the <see cref="FieldrefConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public FieldrefConstantData Read(FieldrefConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Fieldref)
                throw new InvalidClassException($"Constant at index {handle.Index} is not a Fieldref constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (FieldrefConstantData.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"Failed to read Fieldref constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="FieldrefConstant"/> value refered to by the <see cref="FieldrefConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public FieldrefConstant Get(FieldrefConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            if (value.Class.IsNil)
                throw new InvalidClassException("Nil Class on Fieldref.");
            if (value.NameAndType.IsNil)
                throw new InvalidClassException("Nil NameAndType on Fieldref.");

            var clazz = Get(value.Class);
            var nameAndType = Get(value.NameAndType);
            return new FieldrefConstant(clazz.Name, nameAndType.Name, nameAndType.Descriptor);
        }

        /// <summary>
        /// Gets the <see cref="MethodrefConstantData"/> value refered to by the <see cref="MethodrefConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public MethodrefConstantData Read(MethodrefConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Methodref)
                throw new InvalidClassException($"Constant at index {handle.Index} is not a Methodref constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (MethodrefConstantData.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"Failed to read Methodref constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="MethodrefConstant"/> value refered to by the <see cref="MethodrefConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public MethodrefConstant Get(MethodrefConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            if (value.Class.IsNil)
                throw new InvalidClassException("Nil Class on Methodref.");
            if (value.NameAndType.IsNil)
                throw new InvalidClassException("Nil NameAndType on Methodref.");

            var clazz = Get(value.Class);
            var nameAndType = Get(value.NameAndType);
            return new MethodrefConstant(clazz.Name, nameAndType.Name, nameAndType.Descriptor);
        }

        /// <summary>
        /// Gets the <see cref="InterfaceMethodrefConstantData"/> value refered to by the <see cref="InterfaceMethodrefConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public InterfaceMethodrefConstantData Read(InterfaceMethodrefConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.InterfaceMethodref)
                throw new InvalidClassException($"Constant at index {handle.Index} is not a InterfaceMethodref constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (InterfaceMethodrefConstantData.TryRead(ref reader, out var value) == false)
                throw new InvalidClassException($"Failed to read InterfaceMethodref constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="InterfaceMethodrefConstant"/> value refered to by the <see cref="InterfaceMethodrefConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public InterfaceMethodrefConstant Get(InterfaceMethodrefConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            if (value.Class.IsNil)
                throw new InvalidClassException("Nil Class on Methodref.");
            if (value.NameAndType.IsNil)
                throw new InvalidClassException("Nil NameAndType on Methodref.");

            var clazz = Get(value.Class);
            var nameAndType = Get(value.NameAndType);
            return new InterfaceMethodrefConstant(clazz.Name, nameAndType.Name, nameAndType.Descriptor);
        }

        /// <summary>
        /// Gets the <see cref="NameAndTypeConstantData"/> value refered to by the <see cref="NameAndTypeConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public NameAndTypeConstantData Read(NameAndTypeConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.NameAndType)
                throw new InvalidClassException($"Constant at index {handle.Index} is not a NameAndType constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (NameAndTypeConstantData.TryReadNameAndTypeConstant(ref reader, out var value) == false)
                throw new InvalidClassException($"Failed to read NameAndType constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="NameAndTypeConstant"/> value refered to by the <see cref="NameAndTypeConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public NameAndTypeConstant Get(NameAndTypeConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            if (value.Name.IsNil)
                throw new InvalidClassException("Nil Name on NameAndType.");
            if (value.Descriptor.IsNil)
                throw new InvalidClassException("Nil Descriptor on NameAndType.");

            var name = Get(value.Name);
            var descriptor = Get(value.Descriptor);
            return new NameAndTypeConstant(name.Value, descriptor.Value);
        }

        /// <summary>
        /// Gets the <see cref="MethodHandleConstantData"/> value refered to by the <see cref="MethodHandleConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public MethodHandleConstantData Read(MethodHandleConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.MethodHandle)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a MethodHandle constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (MethodHandleConstantData.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read MethodHandle constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="MethodHandleConstant"/> value refered to by the <see cref="MethodHandleConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public MethodHandleConstant Get(MethodHandleConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            if (value.Reference.IsNil)
                throw new InvalidClassException("Nil Reference on MethodHandle.");

            var constant = Get(value.Reference);

            if (value.Kind is MethodHandleKind.GetField or MethodHandleKind.GetStatic or MethodHandleKind.PutField or MethodHandleKind.PutStatic)
            {
                if (constant.Kind is ConstantKind.Fieldref)
                {
                    var fieldref = (FieldrefConstant)constant;
                    return new MethodHandleConstant(value.Kind, constant.Kind, fieldref.ClassName, fieldref.Name, fieldref.Descriptor);
                }
            }

            if (value.Kind is MethodHandleKind.InvokeVirtual or MethodHandleKind.NewInvokeSpecial)
            {
                if (constant.Kind is ConstantKind.Methodref)
                {
                    var methodref = (MethodrefConstant)constant;
                    return new MethodHandleConstant(value.Kind, constant.Kind, methodref.ClassName, methodref.Name, methodref.Descriptor);
                }
            }

            if (value.Kind is MethodHandleKind.InvokeStatic or MethodHandleKind.InvokeSpecial)
            {
                if (constant.Kind is ConstantKind.Methodref)
                {
                    var methodref = (MethodrefConstant)constant;
                    return new MethodHandleConstant(value.Kind, constant.Kind, methodref.ClassName, methodref.Name, methodref.Descriptor);
                }

                if (constant.Kind is ConstantKind.InterfaceMethodref)
                {
                    var methodref = (InterfaceMethodrefConstant)constant;
                    return new MethodHandleConstant(value.Kind, constant.Kind, methodref.ClassName, methodref.Name, methodref.Descriptor);
                }
            }

            if (value.Kind is MethodHandleKind.InvokeInterface)
            {
                if (constant.Kind is ConstantKind.InterfaceMethodref)
                {
                    var methodref = (InterfaceMethodrefConstant)constant;
                    return new MethodHandleConstant(value.Kind, constant.Kind, methodref.ClassName, methodref.Name, methodref.Descriptor);
                }
            }

            throw new InvalidClassException($"MethodHandle {handle} of kind {value.Kind} cannot reference constant of kind {constant.Kind}.");
        }

        /// <summary>
        /// Gets the <see cref="MethodTypeConstantData"/> value refered to by the <see cref="MethodTypeConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public MethodTypeConstantData Read(MethodTypeConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.MethodType)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a MethodType constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (MethodTypeConstantData.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read MethodType constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="MethodTypeConstant"/> value refered to by the <see cref="MethodTypeConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public MethodTypeConstant Get(MethodTypeConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            if (value.Descriptor.IsNil)
                throw new InvalidClassException("Nil Descriptor on MethodType.");

            var descriptor = Get(value.Descriptor);
            return new MethodTypeConstant(descriptor.Value);
        }

        /// <summary>
        /// Gets the <see cref="DynamicConstantData"/> value refered to by the <see cref="DynamicConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public DynamicConstantData Read(DynamicConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Dynamic)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a Dynamic constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (DynamicConstantData.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read Dynamic constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="DynamicConstant"/> value refered to by the <see cref="DynamicConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public DynamicConstant Get(DynamicConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            if (value.NameAndType.IsNil)
                throw new InvalidClassException("Nil NameAndType on Dynamic.");

            var nameAndType = Get(value.NameAndType);
            return new DynamicConstant(value.BootstrapMethodAttributeIndex, nameAndType.Name, nameAndType.Descriptor);
        }

        /// <summary>
        /// Gets the <see cref="InvokeDynamicConstantData"/> value refered to by the <see cref="InvokeDynamicConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public InvokeDynamicConstantData Read(InvokeDynamicConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.InvokeDynamic)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a InvokeDynamic constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (InvokeDynamicConstantData.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read InvokeDynamic constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="InvokeDynamicConstant"/> value refered to by the <see cref="InvokeDynamicConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public InvokeDynamicConstant Get(InvokeDynamicConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            if (value.NameAndType.IsNil)
                throw new InvalidClassException("Nil NameAndType on InvokeDynamic.");

            var nameAndType = Get(value.NameAndType);
            return new InvokeDynamicConstant(value.BootstrapMethodAttributeIndex, nameAndType.Name, nameAndType.Descriptor);
        }

        /// <summary>
        /// Gets the <see cref="ModuleConstantData"/> value refered to by the <see cref="ModuleConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public ModuleConstantData Read(ModuleConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Module)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a Module constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (ModuleConstantData.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read Module constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="ModuleConstant"/> value refered to by the <see cref="ModuleConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public ModuleConstant Get(ModuleConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            if (value.Name.IsNil)
                throw new InvalidClassException("Nil Name on Module.");

            var name = Get(value.Name);
            return new ModuleConstant(name.Value);
        }

        /// <summary>
        /// Gets the <see cref="PackageConstantData"/> value refered to by the <see cref="PackageConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public PackageConstantData Read(PackageConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Package)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a Package constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (PackageConstantData.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read Package constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="PackageConstant"/> value refered to by the <see cref="PackageConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public PackageConstant Get(PackageConstantHandle handle)
        {
            if (handle.IsNil)
                return default;

            var value = Read(handle);
            if (value.Name.IsNil)
                throw new InvalidClassException("Nil Name on Package.");

            var name = Get(value.Name);
            return new PackageConstant(name.Value);
        }

        /// <inheritdoc />
        IEnumerator<ConstantHandle> IEnumerable<ConstantHandle>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        ConstantHandle IConstantPool.Get(in Constant value)
        {
            return value.Kind switch
            {
                ConstantKind.Utf8 => ((IConstantPool)this).Get((Utf8Constant)value),
                ConstantKind.Integer => ((IConstantPool)this).Get((IntegerConstant)value),
                ConstantKind.Float => ((IConstantPool)this).Get((FloatConstant)value),
                ConstantKind.Long => ((IConstantPool)this).Get((LongConstant)value),
                ConstantKind.Double => ((IConstantPool)this).Get((DoubleConstant)value),
                ConstantKind.Class => ((IConstantPool)this).Get((ClassConstant)value),
                ConstantKind.String => ((IConstantPool)this).Get((StringConstant)value),
                ConstantKind.Fieldref => ((IConstantPool)this).Get((FieldrefConstant)value),
                ConstantKind.Methodref => ((IConstantPool)this).Get((MethodrefConstant)value),
                ConstantKind.InterfaceMethodref => ((IConstantPool)this).Get((InterfaceMethodrefConstant)value),
                ConstantKind.NameAndType => ((IConstantPool)this).Get((NameAndTypeConstant)value),
                ConstantKind.MethodHandle => ((IConstantPool)this).Get((MethodHandleConstant)value),
                ConstantKind.MethodType => ((IConstantPool)this).Get((MethodTypeConstant)value),
                ConstantKind.Dynamic => ((IConstantPool)this).Get((DynamicConstant)value),
                ConstantKind.InvokeDynamic => ((IConstantPool)this).Get((InvokeDynamicConstant)value),
                ConstantKind.Module => ((IConstantPool)this).Get((ModuleConstant)value),
                ConstantKind.Package => ((IConstantPool)this).Get((PackageConstant)value),
                _ => throw new ArgumentException("Unknown ConstantValue kind."),
            };
        }

        Utf8ConstantHandle IConstantPool.Get(in Utf8Constant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.Utf8)
                {
                    var h = (Utf8ConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        IntegerConstantHandle IConstantPool.Get(in IntegerConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.Integer)
                {
                    var h = (IntegerConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        FloatConstantHandle IConstantPool.Get(in FloatConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.Float)
                {
                    var h = (FloatConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        LongConstantHandle IConstantPool.Get(in LongConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.Long)
                {
                    var h = (LongConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        DoubleConstantHandle IConstantPool.Get(in DoubleConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.Double)
                {
                    var h = (DoubleConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        ClassConstantHandle IConstantPool.Get(in ClassConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.Class)
                {
                    var h = (ClassConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        StringConstantHandle IConstantPool.Get(in StringConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.String)
                {
                    var h = (StringConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        FieldrefConstantHandle IConstantPool.Get(in FieldrefConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.Fieldref)
                {
                    var h = (FieldrefConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        MethodrefConstantHandle IConstantPool.Get(in MethodrefConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.Methodref)
                {
                    var h = (MethodrefConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        InterfaceMethodrefConstantHandle IConstantPool.Get(in InterfaceMethodrefConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.InterfaceMethodref)
                {
                    var h = (InterfaceMethodrefConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        NameAndTypeConstantHandle IConstantPool.Get(in NameAndTypeConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.NameAndType)
                {
                    var h = (NameAndTypeConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        MethodHandleConstantHandle IConstantPool.Get(in MethodHandleConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.MethodHandle)
                {
                    var h = (MethodHandleConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        MethodTypeConstantHandle IConstantPool.Get(in MethodTypeConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.MethodType)
                {
                    var h = (MethodTypeConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        DynamicConstantHandle IConstantPool.Get(in DynamicConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.Dynamic)
                {
                    var h = (DynamicConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        InvokeDynamicConstantHandle IConstantPool.Get(in InvokeDynamicConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.InvokeDynamic)
                {
                    var h = (InvokeDynamicConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        ModuleConstantHandle IConstantPool.Get(in ModuleConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.Module)
                {
                    var h = (ModuleConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

        PackageConstantHandle IConstantPool.Get(in PackageConstant value)
        {
            foreach (var i in this)
            {
                if (ReadData(i).Kind == ConstantKind.Package)
                {
                    var h = (PackageConstantHandle)i;
                    var v = Get(h);
                    if (v == value)
                        return h;
                }
            }

            throw new ByteCodeException("Unknown constant for value.");
        }

    }

}
