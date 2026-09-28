namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class CategoriaServico : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public bool Ativa { get; set; } = true;
}
