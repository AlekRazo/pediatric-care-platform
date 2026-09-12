namespace Pediatria.Domain.Exceptions;

public class ValidationException : Exception
{
    public IEnumerable<string>? Errors { get; }

    public ValidationException(string message, IEnumerable<string>? errors = null) : base(message) { }
}