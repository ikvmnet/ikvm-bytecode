using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Decoding;
using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Console
{

    public static class Program
    {

        readonly static BlobBuilder methodBody;
        readonly static CodeBuilder methodCode;

        /// <summary>
        /// Initializes the static instance.
        /// </summary>
        static Program()
        {
            methodBody = new BlobBuilder();
            methodCode = new CodeBuilder(methodBody);
            methodCode.AconstNull();
            methodCode.Athrow();
        }

        public static void Main(string[] args)
        {
            ProcessAsync(".", @"D:\ikvm\src\IKVM.Java\obj\Debug\net8.0\classes\com\sun\beans\finder\ConstructorFinder.class", CancellationToken.None).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Processes each individual class file.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        static async Task<bool> ProcessAsync(string outputDir, string clazz, CancellationToken cancellationToken)
        {
            if (ClassFile.TryRead(clazz, out var cf) == false)
                return false;

            if (cf is null)
                return false;

            try
            {
                if (cf.Constants.Get(cf.This).Name is not string name)
                    throw new InvalidOperationException();

                string? super = null;
                if (cf.Super.IsNotNil)
                    super = cf.Constants.Get(cf.Super).Name;

                var cb = new ClassFileBuilder(cf.Version, cf.AccessFlags, name, super);

                foreach (var iface in cf.Interfaces)
                    Translate(cf, cb, iface);

                foreach (var field in cf.Fields)
                    Translate(cf, cb, field);

                foreach (var method in cf.Methods)
                    Translate(cf, cb, method);

                var ab = new AttributeTableBuilder(cb.Constants);
                foreach (var attribute in cf.Attributes)
                    Translate(cf, cb, ab, attribute);

                // serialize class to blob
                var b = new BlobBuilder();
                cb.Serialize(b);

                // get output directory
                var d = Path.Combine([outputDir, .. name.Split('/')[..^1]]);
                Directory.CreateDirectory(d);

                // calculate file path
                var n = Path.ChangeExtension(name.Split('/')[^1], ".class");
                var p = Path.Combine(d, n);

                // open the output file and write the contents
                using (var cs = File.Open(p, FileMode.Create, FileAccess.Write, FileShare.None))
                    b.WriteContentTo(cs);

                return true;
            }
            finally
            {
                cf?.Dispose();
            }
        }

        static void Translate(ClassFile cf, ClassFileBuilder cb, Interface iface)
        {
            var clazz = cf.Constants.Get(iface.Class);
            if (clazz.Name is string name)
                cb.AddInterface(name);
        }

        static void Translate(ClassFile cf, ClassFileBuilder cb, Field field)
        {
            var ab = new AttributeTableBuilder(cb.Constants);
            foreach (var attribute in field.Attributes)
                Translate(cf, cb, ab, attribute);

            cb.AddField(field.AccessFlags, cf.Constants.Get(field.Name).Value, cf.Constants.Get(field.Descriptor).Value, ab);
        }

        static void Translate(ClassFile cf, ClassFileBuilder cb, Method method)
        {
            var ab = new AttributeTableBuilder(cb.Constants);
            foreach (var attribute in method.Attributes)
                Translate(cf, cb, ab, attribute);

            cb.AddMethod(method.AccessFlags, cf.Constants.Get(method.Name).Value, cf.Constants.Get(method.Descriptor).Value, ab);
        }

        static void Translate(ClassFile cf, ClassFileBuilder cb, AttributeTableBuilder ab, IKVM.ByteCode.Decoding.Attribute attribute)
        {
            switch (cf.Constants.Get(attribute.Name).Value)
            {
                //case AttributeName.Code:
                //    Translate(cf, cb, ab, attribute.AsCode());
                //    break;
                //case AttributeName.LineNumberTable:
                //case AttributeName.StackMapTable:
                //case AttributeName.LocalVariableTable:
                //case AttributeName.LocalVariableTypeTable:
                //break;
                default:
                    attribute.CopyTo(cf.Constants, cb.Constants, ref ab.Encoder);
                    break;
            }
        }

        static void Translate(ClassFile cf, ClassFileBuilder cb, AttributeTableBuilder ab, CodeAttribute attribute)
        {
            var ab2 = new AttributeTableBuilder(cb.Constants);
            foreach (var attribute2 in attribute.Attributes)
                Translate(cf, cb, ab2, attribute2);

            var b = new BlobBuilder();
            methodBody.WriteContentTo(b);
            ab.Code(4, 255, b, e => methodCode.WriteExceptionsTo(ref e), ab2);
        }

    }

}
