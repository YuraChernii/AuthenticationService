namespace Domain.Exceptions.Base
{
    public class ValidationException : UnauthorizedAccessException
    {
        public ValidationException(string message) : base(message) { }
    }
}