namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class ProdutoFornecedor : BaseEntity
{
    public Guid ProdutoId { get; set; }
    public Produto Produto { get; set; } = null!;
    public Guid FornecedorId { get; set; }
    public Fornecedor Fornecedor { get; set; } = null!;
    public string? CodigoFornecedor { get; set; }
    public decimal? PrecoUltimaCompra { get; set; }
    public int? PrazoGarantiaDias { get; set; }
}
