namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class OrdemServicoItem : BaseEntity
{
    public Guid OrdemServicoId { get; set; }
    public OrdemServico? OrdemServico { get; set; }

    public Guid? ProdutoId { get; set; }
    public Produto? Produto { get; set; }

    public Guid? ServicoId { get; set; }
    public Servico? Servico { get; set; }

    public int Quantidade { get; set; } = 1;
    public decimal ValorUnitario { get; set; }
    public decimal ValorTotal => Quantidade * ValorUnitario;
    public string Tipo { get; set; } = "Produto"; // "Produto" ou "Servico"
}