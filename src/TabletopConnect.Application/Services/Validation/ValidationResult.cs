namespace TabletopConnect.Application.Services.Validation;

public class ValidationResult
{
    private readonly List<ValidationError> _errors = new();
    public bool IsValid => Errors.Count == 0;
    public IReadOnlyCollection<ValidationError> Errors => _errors.AsReadOnly();

    private ValidationResult()
    {
    }
     
    private ValidationResult(IEnumerable<ValidationError> errors)
    {
        _errors.AddRange(errors);
    }

    public static ValidationResult CreateSuccess() => new();
    public static ValidationResult CreateFailure(IEnumerable<ValidationError> errors) => new(errors);
}

public record ValidationError(
    string Message,
    string? PropertyName = null);