namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class Empresa : BaseEntity
{
    public string RazaoSocial { get; set; } = string.Empty;
    public string? NomeFantasia { get; set; }
    public string? Cnpj { get; set; }
    public string? InscricaoEstadual { get; set; }
    public bool Ativa { get; set; } = true;

    // Relacionamento
    public ICollection<Unidade> Unidades { get; set; } = new List<Unidade>();
}