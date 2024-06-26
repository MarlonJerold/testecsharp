using backend.Dtos;
using backend.models;

namespace backend.Infraestrutura.Security;

public interface ITokenService
{
    string GenerateToken(LoginDto usuario);
}
