namespace Oficina.Application.DTOs;

public class UsuarioResponseDto
{
    public Guid Id { get; set; }
    public Guid UnidadeId { get; set; }
    public Guid? FuncionarioId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool Ativo { get; set; }
}
