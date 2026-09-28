namespace Oficina.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficina.Domain.Entities;

public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("empresas");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.RazaoSocial)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(e => e.Cnpj)
            .HasMaxLength(20);

        builder.HasIndex(e => e.Cnpj)
            .IsUnique();
    }
}