using Domain.Common;

namespace Domain.Exceptions
{
    public class EntityValueNotFoundException : BaseCustomException
    {
        public EntityValueNotFoundException(string entityName, string entityId)
            : base($"The {entityName} with ID \"{entityId}\" does not exist.")
        { }
    }
}
