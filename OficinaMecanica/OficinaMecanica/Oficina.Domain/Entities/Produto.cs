namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class Produto : BaseEntity
{
    public Guid? CategoriaProdutoId { get; set; }
    public CategoriaProduto? CategoriaProduto { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public string UnidadeMedida { get; set; } = string.Empty;
    public decimal PrecoVenda { get; set; }
    public decimal CustoMedio { get; set; }

    public int Quantidade { get; set; } 
    public decimal EstoqueMinimo { get; set; }
    public bool Ativo { get; set; } = true;
}
