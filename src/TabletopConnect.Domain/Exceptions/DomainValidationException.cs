namespace TabletopConnect.Domain.Exceptions;

public class DomainValidationException(string message, string? fieldName = null) : Exception(message)
{
    public string? FieldName { get; } = fieldName;
}
