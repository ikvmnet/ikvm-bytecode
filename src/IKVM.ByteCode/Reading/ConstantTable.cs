using System;
using System.Collections;
using System.Collections.Generic;

namespace IKVM.ByteCode.Reading
{

    public struct ConstantTable : IReadOnlyCollection<ConstantHandle>
    {

        public struct Enumerator : IEnumerator<ConstantHandle>
        {

            readonly Constant[] _constants;
            int _index = 0;
            int _skip = 1;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="constants"></param>
            internal Enumerator(Constant[] constants)
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
        readonly Constant[] _items;
        readonly int _count = 0;
        Utf8Constant[] _utf8Cache;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="constants"></param>
        public ConstantTable(ClassFormatVersion version, Constant[] constants)
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
        public ref readonly Constant this[ConstantHandle handle] => ref Get(handle);

        /// <summary>
        /// Gets the untyped constant for the given handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        readonly ref readonly Constant Get(ConstantHandle handle) => ref _items[handle.Index];

        /// <summary>
        /// Gets the number of constants.
        /// </summary>
        public readonly int Count => _count;

        /// <summary>
        /// Gets an enumerator over the interfaces.
        /// </summary>
        public readonly Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Discovers the kind of the specified constant handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly ConstantKind GetKind(ConstantHandle handle) => Get(handle).Kind;

        /// <summary>
        /// Gets the <see cref="Utf8Constant"/> value refered to by the <see cref="Utf8ConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ByteCodeException"></exception>
        public Utf8Constant GetUtf8(Utf8ConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            // we cache UTF8 values
            _utf8Cache ??= new Utf8Constant[_items.Length];
            var cached = _utf8Cache[handle.Index];
            if (cached.Value != null)
                return cached;

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Utf8)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a Utf8 constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (Utf8Constant.TryReadUtf8Constant(ref reader, out var value, _version.Major) == false)
                throw new ByteCodeException($"Failed to read Utf8 constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="IntegerConstant"/> value refered to by the <see cref="IntegerConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly IntegerConstant GetInteger(IntegerConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Integer)
                throw new ByteCodeException($"Constant at index {handle.Index} is not an Integer constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (IntegerConstant.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read Integer constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="FloatConstant"/> value refered to by the <see cref="FloatConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly FloatConstant GetFloat(FloatConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Float)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a Float constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (FloatConstant.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read Float constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="LongConstant"/> value refered to by the <see cref="LongConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly LongConstant GetLong(LongConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Long)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a Long constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (LongConstant.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read Long constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="DoubleConstant"/> value refered to by the <see cref="DoubleConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly DoubleConstant GetDouble(DoubleConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Double)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a Double constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (DoubleConstant.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read Double constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="ClassConstant"/> value refered to by the <see cref="ClassConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly ClassConstant GetClass(ClassConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Class)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a Class constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (ClassConstant.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read Class constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="StringConstant"/> value refered to by the <see cref="StringConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly StringConstant GetString(StringConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.String)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a String constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (StringConstant.TryReadStringConstant(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read String constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="FieldrefConstant"/> value refered to by the <see cref="FieldrefConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly FieldrefConstant GetFieldref(FieldrefConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Fieldref)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a Fieldref constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (FieldrefConstant.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read Fieldref constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="MethodrefConstant"/> value refered to by the <see cref="MethodrefConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly MethodrefConstant GetMethodref(MethodrefConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Methodref)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a Methodref constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (MethodrefConstant.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read Methodref constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="InterfaceMethodrefConstant"/> value refered to by the <see cref="InterfaceMethodrefConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly InterfaceMethodrefConstant GetInterfaceMethodref(InterfaceMethodrefConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.InterfaceMethodref)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a InterfaceMethodref constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (InterfaceMethodrefConstant.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read InterfaceMethodref constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="NameAndTypeConstant"/> value refered to by the <see cref="NameAndTypeConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly NameAndTypeConstant GetNameAndType(NameAndTypeConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.NameAndType)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a NameAndType constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (NameAndTypeConstant.TryReadNameAndTypeConstant(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read NameAndType constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="MethodHandleConstant"/> value refered to by the <see cref="MethodHandleConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly MethodHandleConstant GetMethodHandle(MethodHandleConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.MethodHandle)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a MethodHandle constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (MethodHandleConstant.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read MethodHandle constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="MethodTypeConstant"/> value refered to by the <see cref="MethodTypeConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly MethodTypeConstant GetMethodType(MethodTypeConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.MethodType)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a MethodType constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (MethodTypeConstant.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read MethodType constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="DynamicConstant"/> value refered to by the <see cref="DynamicConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly DynamicConstant GetDynamic(DynamicConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Dynamic)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a Dynamic constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (DynamicConstant.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read Dynamic constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="InvokeDynamicConstant"/> value refered to by the <see cref="InvokeDynamicConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly InvokeDynamicConstant GetInvokeDynamic(InvokeDynamicConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.InvokeDynamic)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a InvokeDynamic constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (InvokeDynamicConstant.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read InvokeDynamic constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="ModuleConstant"/> value refered to by the <see cref="ModuleConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly ModuleConstant GetModule(ModuleConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Module)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a Module constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (ModuleConstant.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read Module constant at index {handle.Index}.");

            return value;
        }

        /// <summary>
        /// Gets the <see cref="PackageConstant"/> value refered to by the <see cref="PackageConstantHandle"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public readonly PackageConstant GetPackage(PackageConstantHandle handle)
        {
            if (handle.IsNil)
                throw new ArgumentNullException(nameof(handle));

            var constant = _items[handle.Index];
            if (constant.Kind != ConstantKind.Package)
                throw new ByteCodeException($"Constant at index {handle.Index} is not a Package constant.");

            var reader = new ClassFormatReader(constant.Data);
            if (PackageConstant.TryRead(ref reader, out var value) == false)
                throw new ByteCodeException($"Failed to read Package constant at index {handle.Index}.");

            return value;
        }

        /// <inheritdoc />
        readonly IEnumerator<ConstantHandle> IEnumerable<ConstantHandle>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
