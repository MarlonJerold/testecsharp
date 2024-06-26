using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.Dtos;
using backend.models;
using backend.Repositorio;
using Microsoft.IdentityModel.Tokens;

namespace backend.Infraestrutura.Security;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IUsuarioRepository _usuarioRepository;

    public TokenService(IConfiguration configuration, IUsuarioRepository usuarioRepository)
    {
        _configuration = configuration;
        _usuarioRepository = usuarioRepository;
    }

    public string GenerateToken(LoginDto usuario)
    {
        var usuarioDb = _usuarioRepository.GetUsuarioPorUserName(usuario.Email);

        if (usuario.Email != usuarioDb.Email || usuario.Senha != usuarioDb.Senha)
            return String.Empty;
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));

        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];

        var signinCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: new []
            {
                new Claim(type: ClaimTypes.Name, usuarioDb.Email),
                new Claim(type: ClaimTypes.Role, usuarioDb.Senha)
            },
            expires:DateTime.Now.AddHours(1),
            signingCredentials: signinCredential
        );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return token;
    }
}
