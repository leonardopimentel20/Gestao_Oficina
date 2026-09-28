namespace Oficina.Infrastructure.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;

public class TokenService : ITokenService
{
    private readonly string _secretKey = "MinhaChaveSuperSecretaParaOJWTdaOficinaMecanica2026!"; // Deve vir da configuração em prod
    private readonly string _issuer = "OficinaMecanicaAPI";
    private readonly string _audience = "OficinaMecanicaAPP";

    public string GerarToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim("UnidadeId", usuario.UnidadeId.ToString())
        };

        if (usuario.FuncionarioId.HasValue)
        {
            claims.Add(new Claim("FuncionarioId", usuario.FuncionarioId.Value.ToString()));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(8),
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
