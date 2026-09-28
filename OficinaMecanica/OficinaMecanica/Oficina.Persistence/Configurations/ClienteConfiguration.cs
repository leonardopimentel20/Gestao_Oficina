namespace Oficina.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficina.Domain.Entities;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("clientes");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(c => c.Documento)
            .HasMaxLength(20);

        builder.Property(c => c.Email)
            .HasMaxLength(150);

        builder.HasOne(c => c.Unidade)
            .WithMany()
            .HasForeignKey(c => c.UnidadeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}