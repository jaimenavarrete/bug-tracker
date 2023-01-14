using Domain.Common;

namespace Domain.Exceptions
{
    public class InvalidEntityValueException : BaseCustomException
    {
        public InvalidEntityValueException(string entityValueName, 
                                            string entityValueId, 
                                            string entityName, 
                                            string parentEntityName)
            : base($"The {entityValueName} with ID \"{entityValueId}\" exists but cannot be used in this {entityName}, because they do not belong to the same {parentEntityName}.") 
        { }
    }
}
