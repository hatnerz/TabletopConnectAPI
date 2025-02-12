using TabletopConnect.Domain.Exceptions;
using TabletopConnect.Common.Extensions;

namespace TabletopConnect.Domain.Validators;

public static class NumberValidators
{
    public static void ValidateRangeInclusive<TNumber>(TNumber? value, TNumber? min, TNumber? max = null, string? fieldName = null)
        where TNumber : struct, IComparable<TNumber>
    {
        if (value is null)
            return;

        string fieldLabel = fieldName?.MakeFirstLetterUppercase() ?? "Value";

        if (min.HasValue && max.HasValue && (value.Value.CompareTo(min.Value) < 0 || value.Value.CompareTo(max.Value) > 0))
            throw new DomainValidationException(
                $"{fieldLabel} must be between {min} and {max} inclusive.",
                fieldName);

        if (min.HasValue && value.Value.CompareTo(min.Value) < 0)
            throw new DomainValidationException(
                $"{fieldLabel} must be greater than or equal to {min}",
                fieldName);

        if (max.HasValue && value.Value.CompareTo(max.Value) > 0)
            throw new DomainValidationException(
                $"{fieldLabel} must be less than or equal to {max}",
                fieldName);
    }
}
