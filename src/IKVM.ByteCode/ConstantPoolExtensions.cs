using IKVM.ByteCode.Decoding;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Extension methods for <see cref="IConstantPool"/> that import constant handles from a <see cref="IConstantView"/>.
    /// </summary>
    public static class ConstantPoolExtensions
    {

        /// <summary>Imports a <see cref="ConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static ConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in ConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports a <see cref="Utf8ConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static Utf8ConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in Utf8ConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports an <see cref="IntegerConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static IntegerConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in IntegerConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports a <see cref="FloatConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static FloatConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in FloatConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports a <see cref="LongConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static LongConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in LongConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports a <see cref="DoubleConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static DoubleConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in DoubleConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports a <see cref="ClassConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static ClassConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in ClassConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports a <see cref="StringConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static StringConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in StringConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports a <see cref="FieldrefConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static FieldrefConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in FieldrefConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports a <see cref="MethodrefConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static MethodrefConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in MethodrefConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports an <see cref="InterfaceMethodrefConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static InterfaceMethodrefConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in InterfaceMethodrefConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports a <see cref="NameAndTypeConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static NameAndTypeConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in NameAndTypeConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports a <see cref="MethodHandleConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static MethodHandleConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in MethodHandleConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports a <see cref="MethodTypeConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static MethodTypeConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in MethodTypeConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports a <see cref="DynamicConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static DynamicConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in DynamicConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports an <see cref="InvokeDynamicConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static InvokeDynamicConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in InvokeDynamicConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports a <see cref="ModuleConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static ModuleConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in ModuleConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

        /// <summary>Imports a <see cref="PackageConstantHandle"/> from <paramref name="view"/> into <paramref name="pool"/>.</summary>
        public static PackageConstantHandle Import<TConstantView, TConstantPool>(this TConstantPool pool, TConstantView view, in PackageConstantHandle handle)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            return pool.Get(view.Get(handle));
        }

    }

}
