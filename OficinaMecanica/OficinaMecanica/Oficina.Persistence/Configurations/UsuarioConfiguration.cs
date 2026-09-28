namespace Oficina.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficina.Domain.Entities;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuarios");
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Nome).IsRequired().HasMaxLength(150);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(150);
        builder.Property(u => u.SenhaHash).IsRequired().HasMaxLength(255);
        
        builder.HasIndex(u => u.Email).IsUnique();

        builder.HasOne(u => u.Unidade)
            .WithMany()
            .HasForeignKey(u => u.UnidadeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(u => u.Funcionario)
            .WithMany()
            .HasForeignKey(u => u.FuncionarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
