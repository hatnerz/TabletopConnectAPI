using System.Text.RegularExpressions;
using TabletopConnect.Domain.Exceptions;

namespace TabletopConnect.Domain.Validators;

public static class CredentialsValidators
{
    public static void ValidateEmail(string email, string? fieldName = "Email")
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainValidationException($"{fieldName} cannot be empty.", fieldName);

        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(email, emailPattern))
            throw new DomainValidationException($"{fieldName} is not a valid email address.", fieldName);
    }

    public static void ValidatePhoneNumber(string phoneNumber, string? fieldName = "Phone Number")
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new DomainValidationException($"{fieldName} cannot be empty.", fieldName);

        string phonePattern = @"^\+?\d{7,15}$";
        if (!Regex.IsMatch(phoneNumber, phonePattern))
            throw new DomainValidationException($"{fieldName} is not a valid phone number.", fieldName);
    }
}
