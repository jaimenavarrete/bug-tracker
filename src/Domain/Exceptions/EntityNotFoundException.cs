namespace Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base("The element you are working with does not exist.")
        { }

        public EntityNotFoundException(string message) : base(message)
        { }
    }
}
