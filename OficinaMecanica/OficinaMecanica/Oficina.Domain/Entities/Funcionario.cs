namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class Funcionario : BaseEntity
{
    public Guid UnidadeId { get; set; }
    public Unidade Unidade { get; set; } = null!;
    public string Nome { get; set; } = string.Empty;
    public string? Documento { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public decimal PercentualComissaoPadrao { get; set; }
    public bool Ativo { get; set; } = true;
}
