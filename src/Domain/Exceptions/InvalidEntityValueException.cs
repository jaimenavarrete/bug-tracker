using Domain.Common;

namespace Domain.Exceptions
{
    public class InvalidEntityValueException : BaseCustomException
    {
        public InvalidEntityValueException(string entityName, string entityId)
            : base($"The {entityName} with ID \"{entityId}\" exists but cannot be used in this entity.") 
        { }
    }
}
