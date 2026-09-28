namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class Fornecedor : BaseEntity
{
    public Guid UnidadeId { get; set; }
    public Unidade Unidade { get; set; } = null!;
    public string RazaoSocial { get; set; } = string.Empty;
    public string? NomeFantasia { get; set; }
    public string? Cnpj { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public bool Ativo { get; set; } = true;
}
