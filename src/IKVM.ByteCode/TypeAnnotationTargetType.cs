namespace IKVM.ByteCode
{

    /// <summary>
    /// A reference to a type appearing in a class, field or method declaration, or on an instruction.
    /// such a reference designates the part of the class where the referenced type is appearing(e.g.an
    /// 'extends', 'implements' or 'throws' clause, a 'new' instruction, a 'catch' clause, a type cast, a
    /// local variable declaration, etc).
    /// </summary>
    public enum TypeAnnotationTargetType : byte
    {

        /// <summary>
        /// The sort of type references that target a type parameter of a generic class.
        /// </summary>
        ClassTypeParameter = 0x00,

        /// <summary>
        /// The sort of type references that target a type parameter of a generic method.
        /// </summary>
        MethodTypeParameter = 0x01,

        /// <summary>
        /// The sort of type references that target the super class of a class or one of the interfaces it
        /// implements.
        /// </summary>
        ClassExtends = 0x10,

        /// <summary>
        /// The sort of type references that target a bound of a type parameter of a generic class.
        /// </summary>
        ClassTypeParameterBound = 0x11,

        /// <summary>
        /// The sort of type references that target a bound of a type parameter of a generic method.
        /// </summary>
        MethodTypeParameterBound = 0x12,

        /// <summary>
        /// The sort of type references that target the type of a field.
        /// </summary>
        Field = 0x13,

        /// <summary>
        /// The sort of type references that target the return type of a method.
        /// </summary>
        MethodReturn = 0x14,

        /// <summary>
        /// The sort of type references that target the receiver type of a method.
        /// </summary>
        MethodReceiver = 0x15,

        /// <summary>
        /// The sort of type references that target the type of a formal parameter of a method.
        /// </summary>
        MethodFormalParameter = 0x16,

        /// <summary>
        /// The sort of type references that target the type of an exception declared in the throws clause
        /// of a method.
        /// </summary>
        Throws = 0x17,

        /// <summary>
        /// The sort of type references that target the type of a local variable in a method.
        /// </summary>
        LocalVar = 0x40,

        /// <summary>
        /// The sort of type references that target the type of a resource variable in a method.
        /// </summary>
        ResourceVariable = 0x41,

        /// <summary>
        /// The sort of type references that target the type of the exception of a 'catch' clause in a
        /// method.
        /// </summary>
        ExceptionParameter = 0x42,

        /// <summary>
        /// The sort of type references that target the type declared in an 'instanceof' instruction.
        /// </summary>
        InstanceOf = 0x43,

        /// <summary>
        /// The sort of type references that target the type of the object created by a 'new' instruction.
        /// </summary>
        New = 0x44,

        /// <summary>
        /// The sort of type references that target the receiver type of a constructor reference.
        /// </summary>
        ConstructorReference = 0x45,

        /// <summary>
        /// The sort of type references that target the receiver type of a method reference.
        /// </summary>
        MethodReference = 0x46,

        /// <summary>
        /// The sort of type references that target the type declared in an explicit or implicit cast
        /// instruction.
        /// </summary>
        Cast = 0x47,

        /// <summary>
        /// The sort of type references that target a type parameter of a generic constructor in a
        /// constructor call.
        /// </summary>
        ConstructorInvocationTypeArgument = 0x48,

        /// <summary>
        /// The sort of type references that target a type parameter of a generic method in a method call.
        /// </summary>
        MethodInvocationTypeArgument = 0x49,

        /// <summary>
        /// The sort of type references that target a type parameter of a generic constructor in a
        /// constructor reference.
        /// </summary>
        ConstructorReferenceTypeArgument = 0x4A,

        /// <summary>
        /// The sort of type references that target a type parameter of a generic method in a method
        /// reference.
        /// </summary>
        MethodReferenceTypeArgument = 0x4B,

    }

}