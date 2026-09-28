namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class PerfilPermissao : BaseEntity
{
    public Guid PerfilId { get; set; }
    public Perfil Perfil { get; set; } = null!;
    public Guid PermissaoId { get; set; }
    public Permissao Permissao { get; set; } = null!;
}
