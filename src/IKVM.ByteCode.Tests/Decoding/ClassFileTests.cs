using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Decoding.Tests
{

    [TestClass]
    public class ClassFileTests
    {

        [TestMethod]
        [ExpectedException(typeof(InvalidClassException))]
        public async Task ShouldThrowOnEmptyStream()
        {
            var stream = new MemoryStream();
            using var clazz = await ClassFile.ReadAsync(stream);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidClassMagicException))]
        public async Task ShouldThrowOnSmallStream()
        {
            var stream = new MemoryStream(new byte[10]);
            using var clazz = await ClassFile.ReadAsync(stream);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidClassMagicException))]
        public async Task ShouldThrowOnBadStream()
        {
            var stream = new MemoryStream(new byte[35]);
            using var clazz = await ClassFile.ReadAsync(stream);
        }

        [TestMethod]
        public void CanReadFromFile()
        {
            using var clazz = ClassFile.Read(Path.Combine(Path.GetDirectoryName(typeof(ClassFileTests).Assembly.Location), "0.class"));
            clazz.Should().NotBeNull();

            foreach (var m in clazz.Methods)
                Console.WriteLine(m.Name);

            clazz.Constants.Read(clazz.Constants.Read(clazz.This).Name).Value.Should().Be("0");
            foreach (var i in clazz.Constants)
                i.Kind.Should().NotBe(ConstantKind.Unknown);
            clazz.Interfaces.ToList();
            clazz.Fields.Should().HaveCount(0);
            clazz.Fields.ToList();
            clazz.Methods.Should().HaveCount(2);
            clazz.Methods.ToList();

            clazz.Methods[0].Attributes.Where(i => clazz.Constants.Get(i.Name).Value == AttributeName.Code).Select(i => (CodeAttribute)i).First().Code.Length.Should().BeGreaterThan(0);
            clazz.Methods[1].Attributes.Where(i => clazz.Constants.Get(i.Name).Value == AttributeName.Code).Select(i => (CodeAttribute)i).First().Code.Length.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void CanReadFromFileStream()
        {
            using var clazz = ClassFile.Read(File.OpenRead(Path.Combine(Path.GetDirectoryName(typeof(ClassFileTests).Assembly.Location), "0.class")));
            clazz.Should().NotBeNull();

            foreach (var m in clazz.Methods)
                Console.WriteLine(m.Name);

            clazz.Constants.Read(clazz.Constants.Read(clazz.This).Name).Value.Should().Be("0");
            foreach (var i in clazz.Constants)
                i.Kind.Should().NotBe(ConstantKind.Unknown);
            clazz.Interfaces.ToList();
            clazz.Fields.Should().HaveCount(0);
            clazz.Fields.ToList();
            clazz.Methods.Should().HaveCount(2);
            clazz.Methods.ToList();

            clazz.Methods[0].Attributes.Where(i => clazz.Constants.Get(i.Name).Value == AttributeName.Code).Select(i => (CodeAttribute)i).First().Code.Length.Should().BeGreaterThan(0);
            clazz.Methods[1].Attributes.Where(i => clazz.Constants.Get(i.Name).Value == AttributeName.Code).Select(i => (CodeAttribute)i).First().Code.Length.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void CanReadFromStream()
        {
            using var stream = new MemoryStream();
            var buffer = File.ReadAllBytes(Path.Combine(Path.GetDirectoryName(typeof(ClassFileTests).Assembly.Location), "0.class"));
            stream.Write(buffer, 0, buffer.Length);
            stream.Position = 0;

            using var clazz = ClassFile.Read(stream);
            clazz.Should().NotBeNull();

            foreach (var m in clazz.Methods)
                Console.WriteLine(m.Name);

            clazz.Constants.Read(clazz.Constants.Read(clazz.This).Name).Value.Should().Be("0");
            foreach (var i in clazz.Constants)
                i.Kind.Should().NotBe(ConstantKind.Unknown);
            clazz.Interfaces.ToList();
            clazz.Fields.Should().HaveCount(0);
            clazz.Fields.ToList();
            clazz.Methods.Should().HaveCount(2);
            clazz.Methods.ToList();

            clazz.Methods[0].Attributes.Where(i => clazz.Constants.Get(i.Name).Value == AttributeName.Code).Select(i => (CodeAttribute)i).First().Code.Length.Should().BeGreaterThan(0);
            clazz.Methods[1].Attributes.Where(i => clazz.Constants.Get(i.Name).Value == AttributeName.Code).Select(i => (CodeAttribute)i).First().Code.Length.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void CanLoadTestClassFiles()
        {
            var d = Path.Combine(Path.GetDirectoryName(typeof(ClassFileTests).Assembly.Location), "resources");
            var l = Directory.GetFiles(d, "*.class", SearchOption.AllDirectories);

            foreach (var i in l)
            {
                using var c = ClassFile.Read(i);
                c.This.Should().NotBeNull();
                c.Constants.ToList();

                foreach (var constant in c.Constants)
                    TestConstant(c, constant);

                c.Interfaces.ToList();
                c.Interfaces.Should().OnlyHaveUniqueItems();
                c.Fields.ToList();
                c.Fields.Should().OnlyHaveUniqueItems();
                c.Methods.ToList();
                c.Methods.Should().OnlyHaveUniqueItems();

                foreach (var iface in c.Interfaces)
                    c.Constants.Get(iface.Class).Should().NotBeNull();

                foreach (var field in c.Fields)
                {
                    field.Should().NotBeNull();
                    c.Constants.Get(field.Name).Should().NotBeNull();
                    c.Constants.Get(field.Descriptor).Should().NotBeNull();
                    field.Attributes.ToList();

                    foreach (var attribute in field.Attributes)
                        TestAttribute(c, attribute);
                }

                foreach (var method in c.Methods)
                {
                    method.Name.Should().NotBeNull();
                    method.Descriptor.Should().NotBeNull();
                    method.Attributes.ToList();

                    foreach (var attribute in method.Attributes)
                        TestAttribute(c, attribute);
                }

                c.Attributes.ToList();
                foreach (var attribute in c.Attributes)
                    TestAttribute(c, attribute);
            }
        }

        void TestConstant(ClassFile clazz, ConstantHandle constant)
        {
            if (constant.Kind is ConstantKind.Utf8)
                TestConstant(clazz, clazz.Constants.Read((Utf8ConstantHandle)constant));
            if (constant.Kind is ConstantKind.Integer)
                TestConstant(clazz, clazz.Constants.Read((IntegerConstantHandle)constant));
            if (constant.Kind is ConstantKind.MethodHandle)
                TestConstant(clazz, clazz.Constants.Read((MethodHandleConstantHandle)constant));
        }

        void TestConstant(ClassFile clazz, Utf8ConstantData utf8)
        {
            utf8.Value.Should().NotBeNull();
        }

        void TestConstant(ClassFile clazz, IntegerConstantData integer)
        {
            integer.Value.Should().NotBe(-1);
        }

        void TestConstant(ClassFile clazz, MethodHandleConstantData methodHandle)
        {
            if (methodHandle.Kind is MethodHandleKind.GetField or MethodHandleKind.GetStatic or MethodHandleKind.PutField or MethodHandleKind.PutStatic)
                clazz.Constants.Get(methodHandle.Reference).Kind.Should().Be(ConstantKind.Fieldref);
            if (methodHandle.Kind is MethodHandleKind.InvokeVirtual or MethodHandleKind.NewInvokeSpecial)
                clazz.Constants.Get(methodHandle.Reference).Kind.Should().Be(ConstantKind.Methodref);
            if (methodHandle.Kind is MethodHandleKind.InvokeStatic or MethodHandleKind.InvokeSpecial && clazz.Version < new ClassFormatVersion(52, 0))
                clazz.Constants.Get(methodHandle.Reference).Kind.Should().Be(ConstantKind.Methodref);
            if (methodHandle.Kind is MethodHandleKind.InvokeStatic or MethodHandleKind.InvokeSpecial && clazz.Version >= new ClassFormatVersion(52, 0))
                clazz.Constants.Get(methodHandle.Reference).Kind.Should().Match<ConstantKind>(i => i == ConstantKind.Methodref || i == ConstantKind.InterfaceMethodref);
            if (methodHandle.Kind is MethodHandleKind.InvokeInterface)
                clazz.Constants.Get(methodHandle.Reference).Kind.Should().Be(ConstantKind.InterfaceMethodref);
            if (methodHandle.Kind is MethodHandleKind.InvokeVirtual or MethodHandleKind.InvokeStatic or MethodHandleKind.InvokeSpecial or MethodHandleKind.InvokeInterface && clazz.Constants.Get(methodHandle.Reference).Kind is ConstantKind.Methodref)
                clazz.Constants.Get(clazz.Constants.Read(clazz.Constants.Read((MethodrefConstantHandle)methodHandle.Reference).NameAndType).Name).Should().NotBe("<init>").And.NotBe("<clinit>");
            if (methodHandle.Kind is MethodHandleKind.InvokeVirtual or MethodHandleKind.InvokeStatic or MethodHandleKind.InvokeSpecial or MethodHandleKind.InvokeInterface && clazz.Constants.Get(methodHandle.Reference).Kind is ConstantKind.InterfaceMethodref)
                clazz.Constants.Get(clazz.Constants.Read((InterfaceMethodrefConstantHandle)methodHandle.Reference).Class).Should().NotBe("<init>").And.NotBe("<clinit>");
        }

        void TestAttribute(ClassFile clazz, Attribute attribute)
        {
            if (clazz.Constants.Get(attribute.Name).Value is "RuntimeVisibleAnnotations")
                TestAttribute(clazz, (RuntimeVisibleAnnotationsAttribute)attribute);
            if (clazz.Constants.Get(attribute.Name).Value is "RuntimeInvisibleAnnotations")
                TestAttribute(clazz, (RuntimeInvisibleAnnotationsAttribute)attribute);
            if (clazz.Constants.Get(attribute.Name).Value is "RuntimeVisibleTypeAnnotations")
                TestAttribute(clazz, (RuntimeVisibleTypeAnnotationsAttribute)attribute);
            if (clazz.Constants.Get(attribute.Name).Value is "RuntimeInvisibleTypeAnnotations")
                TestAttribute(clazz, (RuntimeInvisibleTypeAnnotationsAttribute)attribute);
        }

        void TestAttribute(ClassFile clazz, RuntimeVisibleAnnotationsAttribute attribute)
        {
            TestAnnotations(clazz, attribute.Annotations);
        }

        void TestAttribute(ClassFile clazz, RuntimeInvisibleAnnotationsAttribute attribute)
        {
            TestAnnotations(clazz, attribute.Annotations);
        }

        void TestAttribute(ClassFile clazz, RuntimeVisibleTypeAnnotationsAttribute attribute)
        {
            TestAnnotations(clazz, attribute.TypeAnnotations);
        }

        void TestAttribute(ClassFile clazz, RuntimeInvisibleTypeAnnotationsAttribute attribute)
        {
            TestAnnotations(clazz, attribute.TypeAnnotations);
        }

        void TestAnnotations(ClassFile clazz, AnnotationTable annotations)
        {
            foreach (var annotation in annotations)
                TestAnnotation(clazz, annotation);
        }

        void TestAnnotations(ClassFile clazz, TypeAnnotationTable annotations)
        {
            foreach (var annotation in annotations)
                TestAnnotation(clazz, annotation);
        }

        void TestAnnotation(ClassFile clazz, Annotation annotation)
        {
            clazz.Constants.Get(annotation.Type).Value.Should().NotBeEmpty();
            TestElementValuePair(clazz, annotation.Elements);
        }

        void TestAnnotation(ClassFile clazz, TypeAnnotation annotation)
        {
            clazz.Constants.Get(annotation.Type).Value.Should().NotBeEmpty();
            TestElementValuePair(clazz, annotation.Elements);
        }

        void TestElementValuePair(ClassFile clazz, IReadOnlyCollection<ElementValuePair> elements)
        {
            elements.Count.Should().BeLessThan(256);

            foreach (var element in elements)
                TestElement(clazz, clazz.Constants.Get(element.Name), element.Value);
        }

        void TestElement(ClassFile clazz, string name, ElementValue value)
        {
            name.Should().NotBeEmpty();
            value.Should().NotBeNull();

            TestElementValue(clazz, value);
        }

        void TestElementValue(ClassFile clazz, ElementValue value)
        {
            if (value.Kind is ElementValueKind.Byte or ElementValueKind.Char or ElementValueKind.Double or ElementValueKind.Float or ElementValueKind.Integer or ElementValueKind.Long or ElementValueKind.Short or ElementValueKind.Boolean or ElementValueKind.String)
                TestElementValue(clazz, (ConstantElementValue)value);
            if (value.Kind is ElementValueKind.Annotation)
                TestElementValue(clazz, (AnnotationElementValue)value);
            if (value.Kind is ElementValueKind.Array)
                TestElementValue(clazz, (ArrayElementValue)value);
            if (value.Kind is ElementValueKind.Class)
                TestElementValue(clazz, (ClassElementValue)value);
        }

        void TestElementValue(ClassFile clazz, ConstantElementValue value)
        {
            value.Handle.IsNil.Should().BeFalse();
            TestConstant(clazz, value.Handle);
        }

        void TestElementValue(ClassFile clazz, ClassElementValue value)
        {
            clazz.Constants.Get(value.Class).Value.Should().NotBeEmpty();
        }

        void TestElementValue(ClassFile clazz, AnnotationElementValue value)
        {
            TestAnnotation(clazz, value.Annotation);
        }

        void TestElementValue(ClassFile clazz, ArrayElementValue value)
        {
            foreach (var elementValue in value)
                TestElementValue(clazz, elementValue);
        }

    }

}
