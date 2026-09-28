namespace Oficina.Application.Interfaces;

using Oficina.Domain.Entities;

public interface ITokenService
{
    string GerarToken(Usuario usuario);
}
