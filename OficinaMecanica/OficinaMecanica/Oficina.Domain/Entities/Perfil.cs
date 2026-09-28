namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class Perfil : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public bool Ativo { get; set; } = true;
}
