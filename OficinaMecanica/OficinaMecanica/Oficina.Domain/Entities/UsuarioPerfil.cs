namespace Oficina.Domain.Entities;

using Oficina.Domain.Common;

public class UsuarioPerfil : BaseEntity
{
    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;
    public Guid PerfilId { get; set; }
    public Perfil Perfil { get; set; } = null!;
}
