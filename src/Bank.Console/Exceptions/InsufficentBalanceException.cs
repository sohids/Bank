using System.Runtime.Serialization;

namespace Bank.Console.Exceptions
{
    [Serializable]
    public class InsufficentBalanceException : Exception
    {
        public InsufficentBalanceException()
        {
        }

        public InsufficentBalanceException(string? message) : base(message)
        {
        }

        public InsufficentBalanceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InsufficentBalanceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}