using TabletopConnect.Domain.Entities.Common;
using TabletopConnect.Domain.Validators;

namespace TabletopConnect.Domain.Entities.IAM;

public class User : Entity<int>
{
    public string Email { get; private set; } = null!;
    public string? PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    public string? GoogleId { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public Role Role { get; set; }

    private User()
    {
    }

    private User(string email, string? passwordHash, string? phoneNumber, string? googleId, bool isEmailConfirmed, Role role)
    {
        Email = email;
        PasswordHash = passwordHash;
        PhoneNumber = phoneNumber;
        GoogleId = googleId;
        IsEmailConfirmed = isEmailConfirmed;
        Role = role;
    }

    public static User RegisterRegular(string email, string passwordHash)
    {
        CredentialsValidators.ValidateEmail(email);

        return new User(
            email,
            passwordHash,
            null,
            null,
            false,
            Role.RegularUser);
    }

    public static User RegisterGoogle(string email, bool isEmailConfirmed, string googleId)
    {
        CredentialsValidators.ValidateEmail(email);

        return new User(
            email,
            null,
            null,
            googleId,
            isEmailConfirmed,
            Role.RegularUser);
    }

    public void ChangeRole(Role role)
    {
        Role = role;
    }

    public void UpdatePhone(string phoneNumber)
    {
        CredentialsValidators.ValidatePhoneNumber(phoneNumber);

        PhoneNumber = phoneNumber;
    }

    public void LinkGoogle(string googleId)
    {
        GoogleId = googleId;
    }

    public void ConfirmEmail()
    {
        IsEmailConfirmed = true;
    }
}