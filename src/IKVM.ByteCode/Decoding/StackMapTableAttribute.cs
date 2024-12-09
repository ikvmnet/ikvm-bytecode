using System;
using System.Buffers;

using IKVM.ByteCode.Encoding;

namespace IKVM.ByteCode.Decoding
{

    public readonly record struct StackMapTableAttribute(StackMapFrameTable Frames)
    {

        public static StackMapTableAttribute Nil => default;

        public static bool TryRead(ref ClassFormatReader reader, out StackMapTableAttribute attribute)
        {
            attribute = default;

            if (reader.TryReadU2(out ushort count) == false)
                return false;

            var frames = count == 0 ? [] : new StackMapFrame[count];
            for (int i = 0; i < count; i++)
                if (StackMapFrame.TryRead(ref reader, out frames[i]) == false)
                    return false;

            attribute = new StackMapTableAttribute(new(frames));
            return true;
        }

        public readonly StackMapFrameTable Frames = Frames;
        readonly bool _isNotNil = true;

        /// <summary>
        /// Gets whether the instance is nil.
        /// </summary>
        public readonly bool IsNil => !IsNotNil;

        /// <summary>
        /// Gets whether the instance is not nil.
        /// </summary>
        public readonly bool IsNotNil => _isNotNil;

        /// <summary>
        /// Copies this attribute to the builder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref AttributeTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            encoder.StackMapTable(constantPool.Get(AttributeName.StackMapTable), e => self.CopyTo(constantView, constantPool, ref e));
        }

        /// <summary>
        /// Copes this attribute to the encoder.
        /// </summary>
        /// <typeparam name="TConstantView"></typeparam>
        /// <typeparam name="TConstantPool"></typeparam>
        /// <param name="constantView"></param>
        /// <param name="constantPool"></param>
        /// <param name="encoder"></param>
        public readonly void CopyTo<TConstantView, TConstantPool>(TConstantView constantView, TConstantPool constantPool, ref StackMapTableEncoder encoder)
            where TConstantView : IConstantView
            where TConstantPool : IConstantPool
        {
            var self = this;
            foreach (var i in self.Frames)
                i.CopyTo(constantView, constantPool, ref encoder);
        }

    }

}
