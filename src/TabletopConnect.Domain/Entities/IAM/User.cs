namespace TabletopConnect.Domain.Entities.IAM;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    public string? GoogleId { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public Role Role { get; set; }
}