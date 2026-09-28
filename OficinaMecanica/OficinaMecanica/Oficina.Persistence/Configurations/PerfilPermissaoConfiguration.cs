namespace Oficina.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficina.Domain.Entities;

public class PerfilPermissaoConfiguration : IEntityTypeConfiguration<PerfilPermissao>
{
    public void Configure(EntityTypeBuilder<PerfilPermissao> builder)
    {
        builder.ToTable("perfil_permissoes");
        builder.HasKey(pp => pp.Id);

        builder.HasOne(pp => pp.Perfil)
            .WithMany()
            .HasForeignKey(pp => pp.PerfilId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pp => pp.Permissao)
            .WithMany()
            .HasForeignKey(pp => pp.PermissaoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
