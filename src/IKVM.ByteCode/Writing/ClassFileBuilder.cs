using System;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Reading;

namespace IKVM.ByteCode.Writing
{

    /// <summary>
    /// Provides an API for writing a class file.
    /// </summary>
    public class ClassFileBuilder
    {

        readonly ClassFormatVersion _version;
        readonly ConstantBuilder _constants;
        readonly AccessFlag _accessFlags;
        readonly ClassConstantHandle _thisClass;
        readonly ClassConstantHandle _superClass;

        readonly BlobBuilder _interfaces;
        ushort _interfaceCount = 0;

        readonly BlobBuilder _fields;
        ushort _fieldCount = 0;

        readonly BlobBuilder _methods;
        ushort _methodCount = 0;

        readonly AttributeTableBuilder _attributes;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="accessFlags"></param>
        /// <param name="thisClass"></param>
        /// <param name="superClass"></param>
        /// <attributes></attributes>
        public ClassFileBuilder(ClassFormatVersion version, AccessFlag accessFlags, string thisClass, string? superClass)
        {
            if (version.Major < 0)
                throw new ArgumentOutOfRangeException(nameof(version));
            if (version.Minor < 0)
                throw new ArgumentOutOfRangeException(nameof(version));
            if (thisClass == null)
                throw new ArgumentException("Invalid class.", nameof(thisClass));

            _version = version;
            _accessFlags = accessFlags;

            // create new builders
            _constants = new ConstantBuilder(version);
            _interfaces = new BlobBuilder();
            _fields = new BlobBuilder();
            _methods = new BlobBuilder();
            _attributes = new AttributeTableBuilder(_constants);

            // allocate constants
            _thisClass = _constants.AddClass(thisClass);
            _superClass = superClass != null ? _constants.AddClass(superClass) : default;
        }

        /// <summary>
        /// Gets the constants of the class.
        /// </summary>
        public ConstantBuilder Constants => _constants;

        /// <summary>
        /// Adds a new interface to the class.
        /// </summary>
        /// <param name="clazz"></param>
        /// <returns></returns>
        public InterfaceHandle AddInterface(ClassConstantHandle clazz)
        {
            var w = new ClassFormatWriter(_interfaces.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.WriteU2(clazz.Slot);
            return new(_interfaceCount++);
        }

        /// <summary>
        /// Adds a new interface to the class.
        /// </summary>
        /// <param name="clazz"></param>
        /// <returns></returns>
        public InterfaceHandle AddInterface(string clazz)
        {
            return AddInterface(Constants.GetOrAddClass(Constants.GetOrAddUtf8(clazz)));
        }

        /// <summary>
        /// Adds a new field to the class.
        /// </summary>
        /// <param name="accessFlags"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public FieldHandle AddField(AccessFlag accessFlags, Utf8ConstantHandle name, Utf8ConstantHandle descriptor, AttributeTableBuilder? attributes = null)
        {
            attributes ??= new AttributeTableBuilder(Constants);
            var w = new ClassFormatWriter(_fields.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.WriteU2((ushort)accessFlags);
            w.WriteU2(name.Slot);
            w.WriteU2(descriptor.Slot);
            attributes.Serialize(_fields);
            return new(_fieldCount++);
        }

        /// <summary>
        /// Adds a new field to the class.
        /// </summary>
        /// <param name="accessFlags"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public FieldHandle AddField(AccessFlag accessFlags, string name, string descriptor, AttributeTableBuilder? attributes = null)
        {
            return AddField(accessFlags, Constants.GetOrAddUtf8(name), Constants.GetOrAddUtf8(descriptor), attributes);
        }

        /// <summary>
        /// Adds a new method to the class.
        /// </summary>
        /// <param name="accessFlags"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public MethodHandle AddMethod(AccessFlag accessFlags, Utf8ConstantHandle name, Utf8ConstantHandle descriptor, AttributeTableBuilder? attributes = null)
        {
            attributes ??= new AttributeTableBuilder(Constants);
            var w = new ClassFormatWriter(_methods.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.WriteU2((ushort)accessFlags);
            w.WriteU2(name.Slot);
            w.WriteU2(descriptor.Slot);
            attributes.Serialize(_methods);
            return new(_methodCount++);
        }

        /// <summary>
        /// Adds a new method to the class.
        /// </summary>
        /// <param name="accessFlags"></param>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public MethodHandle AddMethod(AccessFlag accessFlags, string name, string descriptor, AttributeTableBuilder? attributes = null)
        {
            return AddMethod(accessFlags, Constants.GetOrAddUtf8(name), Constants.GetOrAddUtf8(descriptor), attributes);
        }

        /// <summary>
        /// Gets the attribute builder used to add attributes to the class.
        /// </summary>
        public AttributeTableBuilder Attributes => _attributes;

        /// <summary>
        /// Serializes the class to the specified blob builder.
        /// </summary>
        /// <param name="builder"></param>
        public void Serialize(BlobBuilder builder)
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            SerializeHeader(builder);
            SerializeConstants(builder);
            SerializeBody(builder);
            SerializeInterfaces(builder);
            SerializeFields(builder);
            SerializeMethods(builder);
            SerializeAttributes(builder);
        }

        /// <summary>
        /// Serializes the header.
        /// </summary>
        /// <param name="builder"></param>
        void SerializeHeader(BlobBuilder builder)
        {
            var w = new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U4 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.WriteU4(ClassFile.MAGIC);
            w.WriteU2(_version.Minor);
            w.WriteU2(_version.Major);
        }

        /// <summary>
        /// Serializes the constants.
        /// </summary>
        /// <param name="builder"></param>
        void SerializeConstants(BlobBuilder builder)
        {
            _constants.Serialize(builder);
        }

        /// <summary>
        /// Serializes the body of the class.
        /// </summary>
        /// <param name="builder"></param>
        void SerializeBody(BlobBuilder builder)
        {
            var w = new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U2 + ClassFormatWriter.U2 + ClassFormatWriter.U2).GetBytes());
            w.WriteU2((ushort)_accessFlags);
            w.WriteU2(_thisClass.Slot);
            w.WriteU2(_superClass.Slot);
        }

        /// <summary>
        /// Serializes the interfaces.
        /// </summary>
        /// <param name="builder"></param>
        void SerializeInterfaces(BlobBuilder builder)
        {
            var w = new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.WriteU2(_interfaceCount);
            builder.LinkSuffix(_interfaces);
        }

        /// <summary>
        /// Serializes the fields.
        /// </summary>
        /// <param name="builder"></param>
        void SerializeFields(BlobBuilder builder)
        {
            var w = new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.WriteU2(_fieldCount);
            builder.LinkSuffix(_fields);
        }

        /// <summary>
        /// Serializes the methods.
        /// </summary>
        /// <param name="builder"></param>
        void SerializeMethods(BlobBuilder builder)
        {
            var w = new ClassFormatWriter(builder.ReserveBytes(ClassFormatWriter.U2).GetBytes());
            w.WriteU2(_methodCount);
            builder.LinkSuffix(_methods);
        }

        /// <summary>
        /// Serializes the attributes.
        /// </summary>
        /// <param name="builder"></param>
        void SerializeAttributes(BlobBuilder builder)
        {
            _attributes.Serialize(builder);
        }

    }

}
