namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class Servico : BaseEntity
{
    public Guid? CategoriaServicoId { get; set; }
    public CategoriaServico? CategoriaServico { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public decimal PrecoPadrao { get; set; }
    public decimal? CustoPadrao { get; set; }
    public bool Ativo { get; set; } = true;
}
