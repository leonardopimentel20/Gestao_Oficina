namespace Oficina.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficina.Domain.Entities;

public class UsuarioPerfilConfiguration : IEntityTypeConfiguration<UsuarioPerfil>
{
    public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
    {
        builder.ToTable("usuario_perfis");
        builder.HasKey(up => up.Id);

        builder.HasOne(up => up.Usuario)
            .WithMany()
            .HasForeignKey(up => up.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade); // Se o usuario for excluido (exclusao fisica não recomendada, mas se ocorrer), o vinculo some

        builder.HasOne(up => up.Perfil)
            .WithMany()
            .HasForeignKey(up => up.PerfilId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
