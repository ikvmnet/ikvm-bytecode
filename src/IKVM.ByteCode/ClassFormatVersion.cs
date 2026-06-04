using System;

namespace IKVM.ByteCode
{

    /// <summary>
    /// Describes a Java Class file format version number, consisting of a major and minor pair.
    /// </summary>
    /// <param name="Major">The major version number.</param>
    /// <param name="Minor">The minor version number. For most class file versions this is <c>0</c>; a value of <c>65535</c> signals a preview feature class.</param>
    public record struct ClassFormatVersion(ushort Major, ushort Minor) : IComparable<ClassFormatVersion>
    {

        /// <summary>Java 1.1 (class file 45.0)</summary>
        public static readonly ClassFormatVersion Java1_1 = new(45, 0);

        /// <summary>Java 1.2 (class file 46.0)</summary>
        public static readonly ClassFormatVersion Java1_2 = new(46, 0);

        /// <summary>Java 1.3 (class file 47.0)</summary>
        public static readonly ClassFormatVersion Java1_3 = new(47, 0);

        /// <summary>Java 1.4 (class file 48.0)</summary>
        public static readonly ClassFormatVersion Java1_4 = new(48, 0);

        /// <summary>Java 5 (class file 49.0)</summary>
        public static readonly ClassFormatVersion Java5 = new(49, 0);

        /// <summary>Java 6 (class file 50.0)</summary>
        public static readonly ClassFormatVersion Java6 = new(50, 0);

        /// <summary>Java 7 (class file 51.0)</summary>
        public static readonly ClassFormatVersion Java7 = new(51, 0);

        /// <summary>Java 8 (class file 52.0)</summary>
        public static readonly ClassFormatVersion Java8 = new(52, 0);

        /// <summary>Java 9 (class file 53.0)</summary>
        public static readonly ClassFormatVersion Java9 = new(53, 0);

        /// <summary>Java 10 (class file 54.0)</summary>
        public static readonly ClassFormatVersion Java10 = new(54, 0);

        /// <summary>Java 11 (class file 55.0)</summary>
        public static readonly ClassFormatVersion Java11 = new(55, 0);

        /// <summary>Java 12 (class file 56.0)</summary>
        public static readonly ClassFormatVersion Java12 = new(56, 0);

        /// <summary>Java 13 (class file 57.0)</summary>
        public static readonly ClassFormatVersion Java13 = new(57, 0);

        /// <summary>Java 14 (class file 58.0)</summary>
        public static readonly ClassFormatVersion Java14 = new(58, 0);

        /// <summary>Java 15 (class file 59.0)</summary>
        public static readonly ClassFormatVersion Java15 = new(59, 0);

        /// <summary>Java 16 (class file 60.0)</summary>
        public static readonly ClassFormatVersion Java16 = new(60, 0);

        /// <summary>Java 17 (class file 61.0)</summary>
        public static readonly ClassFormatVersion Java17 = new(61, 0);

        /// <summary>Java 18 (class file 62.0)</summary>
        public static readonly ClassFormatVersion Java18 = new(62, 0);

        /// <summary>Java 19 (class file 63.0)</summary>
        public static readonly ClassFormatVersion Java19 = new(63, 0);

        /// <summary>Java 20 (class file 64.0)</summary>
        public static readonly ClassFormatVersion Java20 = new(64, 0);

        /// <summary>Java 21 (class file 65.0)</summary>
        public static readonly ClassFormatVersion Java21 = new(65, 0);

        /// <summary>Java 22 (class file 66.0)</summary>
        public static readonly ClassFormatVersion Java22 = new(66, 0);

        /// <summary>Java 23 (class file 67.0)</summary>
        public static readonly ClassFormatVersion Java23 = new(67, 0);

        /// <summary>Java 24 (class file 68.0)</summary>
        public static readonly ClassFormatVersion Java24 = new(68, 0);

        /// <summary>Java 25 (class file 69.0)</summary>
        public static readonly ClassFormatVersion Java25 = new(69, 0);

        /// <summary>
        /// Implicitly converts a major version number to a <see cref="ClassFormatVersion"/> with a minor version of <c>0</c>.
        /// </summary>
        /// <param name="major">The major version number.</param>
        public static implicit operator ClassFormatVersion(ushort major)
        {
            return new ClassFormatVersion(major, 0);
        }

        /// <summary>
        /// Implicitly converts a <see cref="ClassFormatVersion"/> to its string representation.
        /// </summary>
        /// <param name="version">The version to convert.</param>
        public static implicit operator string(ClassFormatVersion version)
        {
            return version.ToString();
        }

        /// <summary>
        /// Returns <c>true</c> if <paramref name="a"/> is greater than <paramref name="b"/>.
        /// </summary>
        public static bool operator >(ClassFormatVersion a, ClassFormatVersion b)
        {
            return a.CompareTo(b) is 1;
        }

        /// <summary>
        /// Returns <c>true</c> if <paramref name="a"/> is less than <paramref name="b"/>.
        /// </summary>
        public static bool operator <(ClassFormatVersion a, ClassFormatVersion b)
        {
            return a.CompareTo(b) is -1;
        }

        /// <summary>
        /// Returns <c>true</c> if <paramref name="a"/> is greater than or equal to <paramref name="b"/>.
        /// </summary>
        public static bool operator >=(ClassFormatVersion a, ClassFormatVersion b)
        {
            return a.CompareTo(b) is 0 or 1;
        }

        /// <summary>
        /// Returns <c>true</c> if <paramref name="a"/> is less than or equal to <paramref name="b"/>.
        /// </summary>
        public static bool operator <=(ClassFormatVersion a, ClassFormatVersion b)
        {
            return a.CompareTo(b) is 0 or -1;
        }

        /// <summary>
        /// Compares this instance with another <see cref="ClassFormatVersion"/> value.
        /// </summary>
        /// <param name="other">The value to compare to.</param>
        /// <returns>A negative integer, zero, or a positive integer if this instance is less than, equal to, or greater than <paramref name="other"/>.</returns>
        public int CompareTo(ClassFormatVersion other)
        {
            if (Major < other.Major)
                return -1;
            else if (Major > other.Major)
                return 1;

            if (Minor < other.Minor)
                return -1;
            else if (Minor > other.Minor)
                return 1;

            return 0;
        }

        /// <summary>
        /// Returns the version number as a string in <c>major.minor</c> format.
        /// </summary>
        public override string ToString()
        {
            return $"{Major}.{Minor}";
        }

    }

}
