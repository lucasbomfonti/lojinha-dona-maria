using System.Runtime.Serialization;

namespace Lojinha.DonaMaria.Exception
{
    public class TokenException : System.Exception
    {
        public TokenException()
        {
        }

        public TokenException(string message) : base(message)
        {
        }

        public TokenException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected TokenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
