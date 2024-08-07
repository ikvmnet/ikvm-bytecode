using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.ByteCode.Reading.Tests
{

    [TestClass]
    public class ClassReaderTests
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
        public void CanLoadClass()
        {
            using var clazz = ClassFile.Read(Path.Combine(Path.GetDirectoryName(typeof(ClassReaderTests).Assembly.Location), "0.class"));
            clazz.Should().NotBeNull();

            foreach (var m in clazz.Methods)
                Console.WriteLine(m.Name);

            clazz.GetUtf8(clazz.GetClass(clazz.This).Name).Value.Should().Be("0");
            foreach (var i in clazz.Constants)
                clazz.GetKind(i).Should().NotBe(ConstantKind.Unknown);
            clazz.Interfaces.ToList();
            clazz.Fields.Should().HaveCount(0);
            clazz.Fields.ToList();
            clazz.Methods.Should().HaveCount(2);
            clazz.Methods.ToList();

            new AttributeTableReader(clazz, clazz.Methods[0].Attributes).Code.Code.Should().NotBeNull();
            new AttributeTableReader(clazz, clazz.Methods[1].Attributes).Code.Code.Should().NotBeNull();
        }

        [TestMethod]
        public void CanLoadTestClassFiles()
        {
            var d = Path.Combine(Path.GetDirectoryName(typeof(ClassReaderTests).Assembly.Location), "resources");
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
                    c.GetClassName(iface.Class).Should().NotBeNull();

                foreach (var field in c.Fields)
                {
                    field.Should().NotBeNull();
                    c.GetUtf8Value(field.Name).Should().NotBeNull();
                    c.GetUtf8Value(field.Descriptor).Should().NotBeNull();
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
                TestConstant(clazz, clazz.Constants.GetUtf8((Utf8ConstantHandle)constant));
            if (constant.Kind is ConstantKind.Integer)
                TestConstant(clazz, clazz.Constants.GetInteger((IntegerConstantHandle)constant));
            if (constant.Kind is ConstantKind.MethodHandle)
                TestConstant(clazz, clazz.Constants.GetMethodHandle((MethodHandleConstantHandle)constant));
        }

        void TestConstant(ClassFile clazz, Utf8Constant utf8)
        {
            utf8.Value.Should().NotBeNull();
        }

        void TestConstant(ClassFile clazz, IntegerConstant integer)
        {
            integer.Value.Should().NotBe(-1);
        }

        void TestConstant(ClassFile clazz, MethodHandleConstant methodHandle)
        {
            if (methodHandle.ReferenceKind is ReferenceKind.GetField or ReferenceKind.GetStatic or ReferenceKind.PutField or ReferenceKind.PutStatic)
                clazz.GetKind(methodHandle.Reference).Should().Be(ConstantKind.Fieldref);
            if (methodHandle.ReferenceKind is ReferenceKind.InvokeVirtual or ReferenceKind.NewInvokeSpecial)
                clazz.GetKind(methodHandle.Reference).Should().Be(ConstantKind.Methodref);
            if (methodHandle.ReferenceKind is ReferenceKind.InvokeStatic or ReferenceKind.InvokeSpecial && clazz.Version < new ClassFormatVersion(52, 0))
                clazz.GetKind(methodHandle.Reference).Should().Be(ConstantKind.Methodref);
            if (methodHandle.ReferenceKind is ReferenceKind.InvokeStatic or ReferenceKind.InvokeSpecial && clazz.Version >= new ClassFormatVersion(52, 0))
                clazz.GetKind(methodHandle.Reference).Should().Match<ConstantKind>(i => i == ConstantKind.Methodref || i == ConstantKind.InterfaceMethodref);
            if (methodHandle.ReferenceKind is ReferenceKind.InvokeInterface)
                clazz.GetKind(methodHandle.Reference).Should().Be(ConstantKind.InterfaceMethodref);
            if (methodHandle.ReferenceKind is ReferenceKind.InvokeVirtual or ReferenceKind.InvokeStatic or ReferenceKind.InvokeSpecial or ReferenceKind.InvokeInterface && clazz.GetKind(methodHandle.Reference) is ConstantKind.Methodref)
                clazz.GetUtf8Value(clazz.GetNameAndType(clazz.GetMethodref((MethodrefConstantHandle)methodHandle.Reference).NameAndType).Name).Should().NotBe("<init>").And.NotBe("<clinit>");
            if (methodHandle.ReferenceKind is ReferenceKind.InvokeVirtual or ReferenceKind.InvokeStatic or ReferenceKind.InvokeSpecial or ReferenceKind.InvokeInterface && clazz.GetKind(methodHandle.Reference) is ConstantKind.InterfaceMethodref)
                clazz.GetClassName(clazz.GetInterfaceMethodref((InterfaceMethodrefConstantHandle)methodHandle.Reference).Class).Should().NotBe("<init>").And.NotBe("<clinit>");
        }

        void TestAttribute(ClassFile clazz, Attribute attribute)
        {
            if (clazz.GetUtf8Value(attribute.Name) is "RuntimeVisibleAnnotations")
                TestAttribute(clazz, (RuntimeVisibleAnnotationsAttribute)attribute);
            if (clazz.GetUtf8Value(attribute.Name) is "RuntimeInvisibleAnnotations")
                TestAttribute(clazz, (RuntimeInvisibleAnnotationsAttribute)attribute);
            if (clazz.GetUtf8Value(attribute.Name) is "RuntimeVisibleTypeAnnotations")
                TestAttribute(clazz, (RuntimeVisibleTypeAnnotationsAttribute)attribute);
            if (clazz.GetUtf8Value(attribute.Name) is "RuntimeInvisibleTypeAnnotations")
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
            TestAnnotations(clazz, attribute.Annotations);
        }

        void TestAttribute(ClassFile clazz, RuntimeInvisibleTypeAnnotationsAttribute attribute)
        {
            TestAnnotations(clazz, attribute.Annotations);
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
            clazz.GetUtf8Value(annotation.Type).Should().NotBeEmpty();
            TestElementValuePair(clazz, annotation);
        }

        void TestAnnotation(ClassFile clazz, TypeAnnotation annotation)
        {
            clazz.GetUtf8Value(annotation.Type).Should().NotBeEmpty();
            TestElementValuePair(clazz, annotation);
        }

        void TestElementValuePair(ClassFile clazz, IReadOnlyCollection<ElementValuePair> elements)
        {
            elements.Count.Should().BeLessThan(256);

            foreach (var element in elements)
                TestElement(clazz, clazz.GetUtf8Value(element.Name), element.Value);
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
            clazz.GetUtf8Value(value.Class).Should().NotBeEmpty();
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
