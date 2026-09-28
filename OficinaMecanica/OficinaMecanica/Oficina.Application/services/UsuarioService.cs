namespace Oficina.Application.Services;

using Oficina.Application.DTOs;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ITokenService _tokenService;

    public UsuarioService(IUsuarioRepository usuarioRepository, ITokenService tokenService)
    {
        _usuarioRepository = usuarioRepository;
        _tokenService = tokenService;
    }

    public async Task<Guid> CriarUsuarioAsync(CriarUsuarioDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome) || string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Senha))
        {
            throw new ArgumentException("Nome, Email e Senha são obrigatórios.");
        }

        var existente = await _usuarioRepository.ObterPorEmailAsync(dto.Email);
        if (existente != null)
        {
            throw new InvalidOperationException("E-mail já está em uso.");
        }

        var usuario = new Usuario
        {
            UnidadeId = dto.UnidadeId,
            FuncionarioId = dto.FuncionarioId,
            Nome = dto.Nome,
            Email = dto.Email,
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
            Ativo = true
        };

        await _usuarioRepository.AdicionarAsync(usuario);
        return usuario.Id;
    }

    public async Task<LoginResponseDto> AutenticarAsync(LoginDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Senha))
        {
            throw new ArgumentException("E-mail e Senha são obrigatórios.");
        }

        var usuario = await _usuarioRepository.ObterPorEmailAsync(dto.Email);
        if (usuario == null || !usuario.Ativo)
        {
            throw new UnauthorizedAccessException("Credenciais inválidas.");
        }

        bool senhaValida = BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash);
        if (!senhaValida)
        {
            throw new UnauthorizedAccessException("Credenciais inválidas.");
        }

        usuario.UltimoLoginEm = DateTimeOffset.UtcNow;
        await _usuarioRepository.AtualizarAsync(usuario);

        var token = _tokenService.GerarToken(usuario);

        return new LoginResponseDto
        {
            Token = token,
            Usuario = new UsuarioResponseDto
            {
                Id = usuario.Id,
                UnidadeId = usuario.UnidadeId,
                FuncionarioId = usuario.FuncionarioId,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Ativo = usuario.Ativo
            }
        };
    }
}
