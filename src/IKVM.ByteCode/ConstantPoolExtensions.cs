using IKVM.ByteCode.Decoding;

namespace IKVM.ByteCode
{

    public static class ConstantPoolExtensions
    {

        public static ConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in ConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static Utf8ConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in Utf8ConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static IntegerConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in IntegerConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static FloatConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in FloatConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static LongConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in LongConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static DoubleConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in DoubleConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static ClassConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in ClassConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static StringConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in StringConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static FieldrefConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in FieldrefConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static MethodrefConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in MethodrefConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static InterfaceMethodrefConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in InterfaceMethodrefConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static NameAndTypeConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in NameAndTypeConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static MethodHandleConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in MethodHandleConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static MethodTypeConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in MethodTypeConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static DynamicConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in DynamicConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static InvokeDynamicConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in InvokeDynamicConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static ModuleConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in ModuleConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        public static PackageConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in PackageConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

    }

}
