using Domain.Common;

namespace Domain.Exceptions
{
    public class BusinessRuleException : BaseCustomException
    {
        public BusinessRuleException() : base("The process you are performing is invalid.")
        { }

        public BusinessRuleException(string message) : base(message)
        { }
    }
}
