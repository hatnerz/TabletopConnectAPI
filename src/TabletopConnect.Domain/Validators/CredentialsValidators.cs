using System.Text.RegularExpressions;
using TabletopConnect.Common.Extensions;
using TabletopConnect.Domain.Exceptions;

namespace TabletopConnect.Domain.Validators;

public static class CredentialsValidators
{

    private const string phonePattern = @"^\+?\d{7,15}$";

    public static void ValidateEmail(string email, string fieldName = "Email")
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainValidationException($"{fieldName.MakeFirstLetterUppercase()} cannot be empty.", fieldName);

        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(email, emailPattern))
            throw new DomainValidationException($"{email} is not a valid email address.", fieldName);
    }

    public static void ValidatePhoneNumber(string phoneNumber, string fieldName = "Phone Number")
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new DomainValidationException($"{fieldName.MakeFirstLetterUppercase()} cannot be empty.", fieldName);

        if (!Regex.IsMatch(phoneNumber, phonePattern))
            throw new DomainValidationException($"{phoneNumber} is not a valid phone number.", fieldName);
    }
}
