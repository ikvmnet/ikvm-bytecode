using IKVM.ByteCode.Decoding;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Implements a <see cref="IConstantMap"/> that imports constants from one view to a pool.
    /// </summary>
    public struct ImportingConstantMap<TConstantView, TConstantPool> : IConstantMap
        where TConstantView : IConstantView
        where TConstantPool : IConstantPool
    {

        readonly TConstantView _view;
        readonly TConstantPool _pool;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        public ImportingConstantMap(TConstantView view, TConstantPool pool)
        {
            _view = view;
            _pool = pool;
        }

        public Constant Get(ConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public RefConstant Get(RefConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public Utf8Constant Get(Utf8ConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public IntegerConstant Get(IntegerConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public FloatConstant Get(FloatConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public LongConstant Get(LongConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public DoubleConstant Get(DoubleConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public ClassConstant Get(ClassConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public StringConstant Get(StringConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public FieldrefConstant Get(FieldrefConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public MethodrefConstant Get(MethodrefConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public InterfaceMethodrefConstant Get(InterfaceMethodrefConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public NameAndTypeConstant Get(NameAndTypeConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public MethodHandleConstant Get(MethodHandleConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public MethodTypeConstant Get(MethodTypeConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public DynamicConstant Get(DynamicConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public InvokeDynamicConstant Get(InvokeDynamicConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public ModuleConstant Get(ModuleConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public PackageConstant Get(PackageConstantHandle handle)
        {
            return _view.Get(handle);
        }

        public ConstantHandle Map(ConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public Utf8ConstantHandle Map(Utf8ConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public IntegerConstantHandle Map(IntegerConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public FloatConstantHandle Map(FloatConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public LongConstantHandle Map(LongConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public DoubleConstantHandle Map(DoubleConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public ClassConstantHandle Map(ClassConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public StringConstantHandle Map(StringConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public FieldrefConstantHandle Map(FieldrefConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public MethodrefConstantHandle Map(MethodrefConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public InterfaceMethodrefConstantHandle Map(InterfaceMethodrefConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public NameAndTypeConstantHandle Map(NameAndTypeConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public MethodHandleConstantHandle Map(MethodHandleConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public MethodTypeConstantHandle Map(MethodTypeConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public DynamicConstantHandle Map(DynamicConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public InvokeDynamicConstantHandle Map(InvokeDynamicConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public ModuleConstantHandle Map(ModuleConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

        public PackageConstantHandle Map(PackageConstantHandle handle)
        {
            return _pool.Get(_view.Get(handle));
        }

    }

}
