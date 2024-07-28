using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Parsing;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Provides an API for writing a class file.
    /// </summary>
    public class ClassBuilder
    {

        readonly ClassFormatVersion _version;
        readonly ConstantBuilder _constants;
        readonly AccessFlag _accessFlags;
        readonly ClassConstantHandle _thisClass;
        readonly ClassConstantHandle _superClass;

        readonly BlobBuilder _interfaces = new();
        ushort _interfaceCount = 0;

        readonly BlobBuilder _fields = new();
        ushort _fieldCount = 0;

        readonly BlobBuilder _methods = new();
        ushort _methodCount = 0;

        readonly BlobBuilder _attributes = new();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="accessFlags"></param>
        /// <param name="thisClass"></param>
        /// <param name="superClass"></param>
        public ClassBuilder(ClassFormatVersion version, AccessFlag accessFlags, string thisClass, string superClass)
        {
            if (version.Major < 0)
                throw new ArgumentOutOfRangeException(nameof(version));
            if (version.Minor < 0)
                throw new ArgumentOutOfRangeException(nameof(version));
            if (thisClass == null)
                throw new ArgumentException("Invalid class.", nameof(thisClass));
            if (superClass == null)
                throw new ArgumentException("Invalid super class.", nameof(superClass));

            _version = version;
            _accessFlags = accessFlags;

            // create new constant builder and allocate constants
            _constants = new ConstantBuilder(version);
            _thisClass = _constants.AddClassConstant(_constants.AddUtf8Constant(thisClass));
            _superClass = _constants.AddClassConstant(_constants.AddUtf8Constant(superClass));
        }

        /// <summary>
        /// Adds a new interface to the class.
        /// </summary>
        /// <param name="clazz"></param>
        /// <returns></returns>
        public InterfaceHandle AddInterface(ClassConstantHandle clazz)
        {
            var w = new ClassFormatWriter(_interfaces.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2(clazz.Value);
            return new(_interfaceCount++);
        }

        /// <summary>
        /// Adds a new field to the class.
        /// </summary>
        /// <param name="accessFlags"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public FieldHandle AddField(AccessFlag accessFlags, Utf8ConstantHandle name, Utf8ConstantHandle descriptor, BlobBuilder attributes)
        {
            var w = new ClassFormatWriter(_fields.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2((ushort)accessFlags);
            w.TryWriteU2(name.Value);
            w.TryWriteU2(descriptor.Value);
            _fields.LinkSuffix(attributes);
            return new(_fieldCount++);
        }

        /// <summary>
        /// Adds a new method to the class.
        /// </summary>
        /// <param name="accessFlags"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public MethodHandle AddMethod(AccessFlag accessFlags, Utf8ConstantHandle name, Utf8ConstantHandle descriptor, BlobBuilder attributes)
        {
            var w = new ClassFormatWriter(_methods.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.TryWriteU2((ushort)accessFlags);
            w.TryWriteU2(name.Value);
            w.TryWriteU2(descriptor.Value);
            _methods.LinkSuffix(attributes);
            return new(_methodCount++);
        }

    }

}
