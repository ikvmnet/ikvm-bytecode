using System;

using IKVM.ByteCode.Decoding;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Implements a <see cref="IConstantHandleMap"/> that emits constants unchanged from an existing <see cref="IConstantPool"/>.
    /// </summary>
    public class IdentityConstantMap<TConstantView> : IConstantHandleMap
        where TConstantView : IConstantView
    {

        readonly TConstantView _view;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="view"></param>
        public IdentityConstantMap(TConstantView view)
        {
            _view = view;
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
            return handle;
        }

        public Utf8ConstantHandle Map(Utf8ConstantHandle handle)
        {
            return handle;
        }

        public IntegerConstantHandle Map(IntegerConstantHandle handle)
        {
            return handle;
        }

        public FloatConstantHandle Map(FloatConstantHandle handle)
        {
            return handle;
        }

        public LongConstantHandle Map(LongConstantHandle handle)
        {
            return handle;
        }

        public DoubleConstantHandle Map(DoubleConstantHandle handle)
        {
            return handle;
        }

        public ClassConstantHandle Map(ClassConstantHandle handle)
        {
            return handle;
        }

        public StringConstantHandle Map(StringConstantHandle handle)
        {
            return handle;
        }

        public FieldrefConstantHandle Map(FieldrefConstantHandle handle)
        {
            return handle;
        }

        public MethodrefConstantHandle Map(MethodrefConstantHandle handle)
        {
            return handle;
        }

        public InterfaceMethodrefConstantHandle Map(InterfaceMethodrefConstantHandle handle)
        {
            return handle;
        }

        public NameAndTypeConstantHandle Map(NameAndTypeConstantHandle handle)
        {
            return handle;
        }

        public MethodHandleConstantHandle Map(MethodHandleConstantHandle handle)
        {
            return handle;
        }

        public MethodTypeConstantHandle Map(MethodTypeConstantHandle handle)
        {
            return handle;
        }

        public DynamicConstantHandle Map(DynamicConstantHandle handle)
        {
            return handle;
        }

        public InvokeDynamicConstantHandle Map(InvokeDynamicConstantHandle handle)
        {
            return handle;
        }

        public ModuleConstantHandle Map(ModuleConstantHandle handle)
        {
            return handle;
        }

        public PackageConstantHandle Map(PackageConstantHandle handle)
        {
            return handle;
        }
    }

}
