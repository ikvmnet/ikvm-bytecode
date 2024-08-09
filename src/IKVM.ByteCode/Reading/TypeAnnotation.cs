using System;
using System.Collections;
using System.Collections.Generic;

using IKVM.ByteCode.Writing;

namespace IKVM.ByteCode.Reading
{

    public readonly struct TypeAnnotation : IReadOnlyList<ElementValuePair>
    {

        public struct Enumerator : IEnumerator<ElementValuePair>
        {

            readonly ElementValuePair[] _items;
            int _index;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="items"></param>
            internal Enumerator(ElementValuePair[] items)
            {
                _items = items;
                _index = -1;
            }

            /// <inheritdoc />
            public readonly ElementValuePair Current => _items[_index];

            /// <inheritdoc />
            public bool MoveNext()
            {
                return ++_index < _items.Length;
            }

            /// <inheritdoc />
            public void Reset()
            {
                _index = -1;
            }

            /// <inheritdoc />
            public readonly void Dispose()
            {

            }

            /// <inheritdoc />
            readonly object IEnumerator.Current => Current;

        }

        public static bool TryRead(ref ClassFormatReader reader, out TypeAnnotation annotation)
        {
            annotation = default;

            if (TypeAnnotationTarget.TryReadData(ref reader, out var target) == false)
                return false;
            if (TypePath.TryRead(ref reader, out var targetPath) == false)
                return false;
            if (reader.TryReadU2(out ushort typeIndex) == false)
                return false;
            if (reader.TryReadU2(out ushort pairCount) == false)
                return false;

            var elements = pairCount == 0 ? [] : new ElementValuePair[pairCount];
            for (int i = 0; i < pairCount; i++)
                if (ElementValuePair.TryRead(ref reader, out elements[i]) == false)
                    return false;

            annotation = new TypeAnnotation(target, targetPath, new(typeIndex), elements);
            return true;
        }

        readonly TypeAnnotationTarget _target;
        readonly TypePath _targetPath;
        readonly Utf8ConstantHandle _type;
        readonly ElementValuePair[] _items;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="targetPath"></param>
        /// <param name="type"></param>
        /// <param name="items"></param>
        /// <exception cref="ArgumentNullException"></exception>
        internal TypeAnnotation(TypeAnnotationTarget target, TypePath targetPath, Utf8ConstantHandle type, ElementValuePair[] items)
        {
            _target = target;
            _targetPath = targetPath;
            _type = type;
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public TypeAnnotationTarget Target => _target;

        public TypePath TargetPath => _targetPath;

        public Utf8ConstantHandle Type => _type;

        /// <summary>
        /// Gets a reference to the element value pair at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ElementValuePair this[int index] => GetAttribute(index);

        /// <summary>
        /// Gets the element value pair at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        ElementValuePair GetAttribute(int index) => _items[index];

        /// <summary>
        /// Gets the number of element values.
        /// </summary>
        public int Count => _items.Length;

        /// <summary>
        /// Gets an enumerator over the element values.
        /// </summary>
        public Enumerator GetEnumerator() => new Enumerator(_items);

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref TypeAnnotationTableEncoder encoder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            var self = this;
            encoder.TypeAnnotation(e => self.EncodeTo(view, pool, ref e));
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref TypeAnnotationEncoder encoder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            var self = this;

            switch (Target.Type)
            {
                case TypeAnnotationTargetType.ClassTypeParameter:
                    var _classTypeParameter = Target.AsTypeParameterTarget();
                    encoder.ClassTypeParameter(_classTypeParameter.ParameterIndex, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodTypeParameter:
                    var _methodTypeParameter = Target.AsTypeParameterTarget();
                    encoder.MethodTypeParameter(_methodTypeParameter.ParameterIndex, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.ClassExtends:
                    var _superTypeTarget = Target.AsSuperTypeTarget();
                    encoder.ClassExtends(_superTypeTarget.SuperTypeIndex, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.ClassTypeParameterBound:
                    var _classTypeParameterBound = Target.AsTypeParameterBoundTarget();
                    encoder.ClassTypeParameterBound(_classTypeParameterBound.ParameterIndex, _classTypeParameterBound.BoundIndex, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodTypeParameterBound:
                    var _methodTypeParameterBound = Target.AsTypeParameterBoundTarget();
                    encoder.MethodTypeParameterBound(_methodTypeParameterBound.ParameterIndex, _methodTypeParameterBound.BoundIndex, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.Field:
                    var _field = Target.AsEmptyTarget();
                    encoder.Field(e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReturn:
                    var _methodReturn = Target.AsEmptyTarget();
                    encoder.MethodReturn(e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReceiver:
                    var _methodReceiver = Target.AsEmptyTarget();
                    encoder.MethodReceiver(e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodFormalParameter:
                    var _methodFormalParameter = Target.AsFormalParameterTarget();
                    encoder.MethodFormalParameter(_methodFormalParameter.ParameterIndex, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.Throws:
                    var _throws = Target.AsThrowsTarget();
                    encoder.Throws(_throws.ThrowsTypeIndex, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.LocalVar:
                    var _localVar = Target.AsLocalVarTarget();
                    encoder.LocalVariable(e => _localVar.EncodeTo(view, pool, ref e), e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.ResourceVariable:
                    var _resourceVariable = Target.AsLocalVarTarget();
                    encoder.ResourceVariable(e => _resourceVariable.EncodeTo(view, pool, ref e), e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.ExceptionParameter:
                    var _catchTarget = Target.AsCatchTarget();
                    encoder.ExceptionParameter(_catchTarget.ExceptionTableIndex, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.InstanceOf:
                    var _instanceOf = Target.AsOffsetTarget();
                    encoder.InstanceOf(_instanceOf.Offset, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.New:
                    var _new = Target.AsOffsetTarget();
                    encoder.New(_new.Offset, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorReference:
                    var _constructorReference = Target.AsOffsetTarget();
                    encoder.ConstructorReference(_constructorReference.Offset, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReference:
                    var _methodReference = Target.AsOffsetTarget();
                    encoder.MethodReference(_methodReference.Offset, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.Cast:
                    var _cast = Target.AsTypeArgumentTarget();
                    encoder.Cast(_cast.Offset, _cast.TypeArgumentIndex, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorInvocationTypeArgument:
                    var _constructorInvocationTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorInvocationTypeArgument(_constructorInvocationTypeArgument.Offset, _constructorInvocationTypeArgument.TypeArgumentIndex, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodInvocationTypeArgument:
                    var _methodInvocationTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.MethodInvocationTypeArgument(_methodInvocationTypeArgument.Offset, _methodInvocationTypeArgument.TypeArgumentIndex, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.ConstructorReferenceTypeArgument:
                    var _constructorReferenceTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorReferenceTypeArgument(_constructorReferenceTypeArgument.Offset, _constructorReferenceTypeArgument.TypeArgumentIndex, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                case TypeAnnotationTargetType.MethodReferenceTypeArgument:
                    var _methodReferenceTypeArgument = Target.AsTypeArgumentTarget();
                    encoder.ConstructorReferenceTypeArgument(_methodReferenceTypeArgument.Offset, _methodReferenceTypeArgument.TypeArgumentIndex, e => self.TargetPath.EncodeTo(view, pool, ref e), pool.Import(view, self.Type), e => self.EncodeTo(view, pool, ref e));
                    break;
                default:
                    throw new ByteCodeException("Invalid type annotation target type.");
            }
        }

        /// <summary>
        /// Encodes this data class to the encoder.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="pool"></param>
        /// <param name="encoder"></param>
        public void EncodeTo<TConstantView, TConstantPool>(TConstantView view, TConstantPool pool, ref ElementValuePairTableEncoder encoder)
            where TConstantView : class, IConstantView
            where TConstantPool : class, IConstantPool
        {
            if (view is null)
                throw new ArgumentNullException(nameof(view));
            if (pool is null)
                throw new ArgumentNullException(nameof(pool));

            foreach (var i in this)
                i.EncodeTo(view, pool, ref encoder);
        }

        /// <inheritdoc />
        IEnumerator<ElementValuePair> IEnumerable<ElementValuePair>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
