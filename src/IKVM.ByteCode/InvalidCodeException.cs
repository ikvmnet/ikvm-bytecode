namespace IKVM.ByteCode
{

    /// <summary>
    /// Describes an attempt to parse an unsupported code data.
    /// </summary>
    internal class InvalidCodeException :
        ByteCodeException
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        internal InvalidCodeException(string message) :
            base(message)
        {

        }

    }

}
