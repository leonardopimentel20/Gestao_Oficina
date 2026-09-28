namespace Oficina.Application.Interfaces;

using Oficina.Application.DTOs;

public interface IUsuarioService
{
    Task<Guid> CriarUsuarioAsync(CriarUsuarioDto dto);
    Task<LoginResponseDto> AutenticarAsync(LoginDto dto);
}
