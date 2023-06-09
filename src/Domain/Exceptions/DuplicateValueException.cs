using Domain.Common;

namespace Domain.Exceptions
{
    public class DuplicateValueException : BaseCustomException
    {
        public DuplicateValueException(string valueName, string value, string groupId)
            : base($"The {valueName} \"{value}\" already exists in the group with id \"{groupId}\"")
        { }
    }
}