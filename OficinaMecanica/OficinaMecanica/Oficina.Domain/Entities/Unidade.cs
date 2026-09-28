namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class Unidade : BaseEntity
{
    public Guid EmpresaId { get; set; }
    public Empresa Empresa { get; set; } = null!;

    public string Nome { get; set; } = string.Empty;
    public string Codigo { get; set; } = string.Empty;
    public string? Cnpj { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public bool Ativa { get; set; } = true;
}