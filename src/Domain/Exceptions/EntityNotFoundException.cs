namespace Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message) 
        { }

        public EntityNotFoundException(string entityName, string entityId) 
            : base($"The {entityName} with ID \"{entityId}\" was not found.")
        { }
    }
}
