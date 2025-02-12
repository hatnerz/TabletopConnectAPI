using TabletopConnect.Domain.Exceptions;
using TabletopConnect.Common.Extensions;
using System.Xml.Linq;

namespace TabletopConnect.Domain.Validators;

public static class TextValidators
{
    public static void ValidateTextProperty(string? value, int maxLength, string? fieldName = null)
    {
        if (value?.Length > maxLength)
            throw new DomainValidationException(
                $"{fieldName?.MakeFirstLetterUppercase() ?? "Value"} is too long. It must be less than {maxLength} characters.",
                fieldName);
    }

    public static void ValidateRequiredTextProperty(string value, int maxLength, string? fieldName)
    {
        if (value.Length > maxLength)
            throw new DomainValidationException(
                $"{fieldName?.MakeFirstLetterUppercase() ?? "Value"} is too long. It must be less than {maxLength} characters.",
                fieldName);

        if (string.IsNullOrWhiteSpace(value))
            throw new DomainValidationException("Value cannot be empty", fieldName);
    }

}
