namespace Oficina.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficina.Domain.Entities;

public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.ToTable("veiculos");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Placa)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(v => v.Marca)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(v => v.Modelo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(v => v.KmAtual)
            .HasPrecision(10, 2);

        // Índice único para a placa do veículo
        builder.HasIndex(v => v.Placa)
            .IsUnique();

        builder.HasOne(v => v.Cliente)
            .WithMany(c => c.Veiculos)
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}