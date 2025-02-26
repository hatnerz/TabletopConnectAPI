using System.Security.Cryptography;
using System.Text;
using TabletopConnect.Domain.Entities.IAM;

namespace TabletopConnect.Application.Infrastucture.Interfaces;

public interface IPasswordHasher
{
    string HashPassword(string password);

    bool VerifyPassword(string password, string storedHash);
}
