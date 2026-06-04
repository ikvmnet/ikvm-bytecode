# IKVM.ByteCode

A low-allocation Java class file parser, reader, and writer for .NET. Designed for use by the [IKVM](https://github.com/ikvmnet/ikvm) project, but usable as a general-purpose library for reading and writing Java `.class` files.

The API is modeled after `System.Reflection.Metadata` — constant pool entries are referenced by typed handles rather than resolved eagerly, keeping allocations minimal.

## Decoding

The `IKVM.ByteCode.Decoding` namespace provides structures for reading Java class files. The main entry point is `ClassFile`, which can read from a file path, byte array, stream, or `ReadOnlyMemory<byte>`. `ClassFile` holds a reference to the underlying memory and parses lazily. It implements `IDisposable`.

```csharp
using IKVM.ByteCode.Decoding;

using var clazz = ClassFile.Read("MyClass.class");

// Read the class name from the constant pool
string className = clazz.Constants.Get(clazz.This).Name;
Console.WriteLine($"Class: {className}");

// Enumerate methods
foreach (var method in clazz.Methods)
{
    string name = clazz.Constants.Get(method.Name).Value;
    string descriptor = clazz.Constants.Get(method.Descriptor).Value;
    Console.WriteLine($"  Method: {name}{descriptor}");
}
```

Constant pool entries are not resolved automatically. Obtain a `*ConstantHandle` from any data structure, then look it up via `ClassFile.Constants`.

Each decoding structure supports `CopyTo` (re-emits to an encoder with constant remapping via `IConstantHandleMap`) and `WriteTo` (raw emit, assuming constants are already present in the target).

## Constants

Constants are represented by three families of types:

| Type | Description |
|---|---|
| `*Constant` | A fully resolved .NET value (e.g. `Utf8Constant` holds the `string`). Used for lookup or insertion. |
| `*ConstantHandle` | A typed handle to a slot in a constant table. Analogous to `System.Reflection.Metadata` tokens. |
| `*ConstantData` | The raw constant data as stored in the class file. Decoded lazily on demand. |

Casts between compatible handle and constant types are supported via custom operators.

## Encoding

The `IKVM.ByteCode.Encoding` namespace provides builders and encoders for writing class files.

`BlobBuilder` is a linked-list buffer supporting fast append and serialization. Encoders write into a `ClassFormatWriter` backed by segments of a `BlobBuilder`.

`ClassFileBuilder` is the high-level entry point for constructing a complete class file:

```csharp
using IKVM.ByteCode.Buffers;
using IKVM.ByteCode.Decoding;
using IKVM.ByteCode.Encoding;

// Build a simple public class
var builder = new ClassFileBuilder(
    new ClassFormatVersion(53, 0),  // Java 9
    AccessFlag.Public,
    "com/example/MyClass",
    "java/lang/Object");

builder.AddField(AccessFlag.Private, "_value", "I");
builder.AddMethod(AccessFlag.Public, "getValue", "()I");

var blob = new BlobBuilder();
builder.Serialize(blob);

// Write to file
File.WriteAllBytes("MyClass.class", blob.ToArray());
```

For lower-level encoding, individual encoder structures (e.g. `MethodEncoder`, `AttributeTableEncoder`) can be used directly, passed by `ref` between methods.
