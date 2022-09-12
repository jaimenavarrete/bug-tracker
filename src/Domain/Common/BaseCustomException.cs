namespace Domain.Common
{
    public abstract class BaseCustomException : Exception
    {
        public BaseCustomException()
        { }

        public BaseCustomException(string message) : base(message)
        { }
    }
}
