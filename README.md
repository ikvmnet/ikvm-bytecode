# IKVM.ByteCode

Provides a Java class file parser, reader and writer implementation used by the IKVM project.

The core of the project contains the various abstractions that are used throughout. These abstractions are loosely modeled on the System.Reflection.Metadata namespace. The design is low allocation.

### Decoding

The `IKVM.ByteCode.Decoding` namespace contains specialized structures for reading data from the class file specification. The main entry point of this namespace will be `ClassFile` which can be used to read a Java class file from a variety of sources. `ClassFile` itself holds a reference to the underlying original memory that was read from and parses the minimal amount possible depending on the operation. `ClassFile` implements `IDisposable` for releasing this memory.

`ClassFile`'s companion structures are field-only record types. This allows directly taking a `ref` to a item in a collection or a field.

Constant values are left unresolved in this structure just like `System.Reflection.Metadata` token handles. It is the users responsibilty to obtain a `ConstantHandle` from one of the data structures and refer to the `ClassFile.Constants` `ConstantTable` to lookup the `ConstantKind`, `ConstantData` or `Constant` itself.

Each of the field-only record structures can be individually used to parse or encode data. To parse each provides it's own `TryMeasure` and `TryRead` methods. `TryMeasure` does a minimal amount of parsing to determine the size of the data from the initial position. This is helpful due to a Java class file's forward-only nature: you can't know the size of the class without reading each part of the class. `TryMeasure` thus allows you to measure the given structure without committing to parsing or allocating objects.

`TryRead` actually reads the data. In both of these cases, `false` is returned if the end of the memory has been reached. Exceptions are thrown for parsing errors involving valid data.

Each of the field-only record structures also contains `CopyTo` and `WriteTo`. `CopyTo` processes the structure, along with a `IConstantHandleMap`, and reemits it to an Encoder. This allows you to copy structures read from one class file into another, either creating the necessary constants in the new class, or reencode it to an output stream using `IdentityConstantMap`. `CopyTo` requires acccess to a `IConstantHandleMap` to read constant data in order to navigate into dynamic components that require constant data to reason about (for instance `Attribute`s). `WriteTo` is much lighter weight: it simply emits the structure as is without consideration as to the constants. They must already be present in whatever constant table is used with the resulting class file.

### Constants

Constants are represented in three sets of data structures: `*ConstantData`, `*ConstantHandle` and `*Constant`

`*Constant` structures represent a full local constant value in native .NET types. For instance, `Utf8Constant` directly contains the string value. These are used to pass around desired constant values for lookup or insertion. These types are arrainged in a hierarchy implemented through custom operators. For instance one can cast between `Constant` and `Utf8Constant`. Casting to `Constant` encodes the original `ConstantKind` on the structure, so that casting back to `Utf8Constant` would fail.

`*ConstantHandle` structures represent a handle to a location (slot) in a constant table. These are single-field structures, merely used for type safety. Like `Constant`, casting is allowed between compatible types. These abstract the locality of a constant in a constant table.

`*ConstantData` structures store the actual constant data that would be present in a constant table. Most constants are simply collections of handles to other constants. However, constants like `Utf8ConstantData` contain a pointer to the original parsed memory, and is decoded to a .NET string on demand. The base `ConstantData` structure maps over the original segmented constant data from a class file and parses it only on demand when cast.

### Encoding

Encoding class files or parts of class files in `IKVM.ByteCode` is similar to `System.Reflection.Metadata.Ecma335`. A common linkable buffer, `BlobBuilder`, is provided which is the target of the various builders and encoders. `BlobBuilder` allows for fast append, and fast enumeration from the beginning, by linked list of segments of memory. `BlobBuilder`s can be linked to the end of existing `BlobBuilder`s. Assembling Java class files then is allocating a `BlobBuilder` and using one of the various Encoder classes to emit output into it. That output can then be appened together with other segments before being serialized to output.

`ClassFormatWriter` represents the main operations for emitting class file output data: U1, U2 and U4, as defined by the specification. Each of the encoder structures target a `ClassFormatWriter`, which can be backed by a `Span<byte>` which can be allocated in segments from a `BlobBuilder`. Each Encoder provides a number of methods that have to be invoked in order to write the appropriate components. Encoders can be passed by `ref` between methods. They maintain minimal state such as a count of emitted elements. The nested structure of a Java class file is encapsulated by passing delegates with the nested encoders.

`ClassBuilder` makes it easy to encode an entire Java class file to a temporary series of blobs that are then assembled into a final format.
