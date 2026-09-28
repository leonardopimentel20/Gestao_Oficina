namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;
using Oficina.Domain.Enums;

public class Cliente : BaseEntity
{
    public Guid UnidadeId { get; set; }
    public Unidade Unidade { get; set; } = null!;

    public TipoPessoa TipoPessoa { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Documento { get; set; }
    public string? Email { get; set; }
    public string? Observacoes { get; set; }
    public bool Ativo { get; set; } = true;

    public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}