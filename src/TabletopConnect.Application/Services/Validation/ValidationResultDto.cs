using TabletopConnect.Common.Constants;

namespace TabletopConnect.Application.Services.Validation;

public class ValidationResultDto
{
    private readonly List<ValidationErrorDto> _errors = new();
    public bool Success => Errors.Count == 0;
    public IReadOnlyCollection<ValidationErrorDto> Errors => _errors.AsReadOnly();

    private ValidationResultDto()
    {
    }
     
    private ValidationResultDto(IEnumerable<ValidationErrorDto> errors)
    {
        _errors.AddRange(errors);
    }

    public static ValidationResultDto CreateSuccess() => new();
    public static ValidationResultDto CreateFailure(IEnumerable<ValidationErrorDto> errors) => new(errors);
    public static ValidationResultDto CreateFailure() => new([new ValidationErrorDto(ValidationMessages.Common.UnknownError)]);
}

public record ValidationErrorDto(
    string Message,
    string? PropertyName = null);