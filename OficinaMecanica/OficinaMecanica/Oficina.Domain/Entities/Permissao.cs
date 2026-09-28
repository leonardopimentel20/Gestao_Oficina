namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class Permissao : BaseEntity
{
    public string Codigo { get; set; } = string.Empty;
    public string? Descricao { get; set; }
}
