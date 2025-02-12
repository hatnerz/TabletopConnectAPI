using TabletopConnect.Domain.Exceptions;

namespace TabletopConnect.Domain.Validators;

internal static class DateValidators
{
    public static void ValidateDates(DateTime startDate, DateTime endDate, string? fieldName)
    {
        if (startDate > endDate)
            throw new DomainValidationException("Start date cannot be greater than end date", fieldName);
    }
}
