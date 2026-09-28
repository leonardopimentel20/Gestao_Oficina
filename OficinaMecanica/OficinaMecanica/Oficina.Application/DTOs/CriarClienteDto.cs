namespace Oficina.Application.DTOs;

using Oficina.Domain.Enums;

public class CriarClienteDto
{
    public Guid UnidadeId { get; set; }
    public TipoPessoa TipoPessoa { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Documento { get; set; }
    public string? Email { get; set; }
    public string? Observacoes { get; set; }
}