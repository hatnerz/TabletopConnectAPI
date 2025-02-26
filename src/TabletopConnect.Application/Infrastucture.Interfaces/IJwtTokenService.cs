using TabletopConnect.Domain.Entities.IAM;

namespace TabletopConnect.Application.Infrastucture.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}
