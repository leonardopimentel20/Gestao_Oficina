namespace Oficina.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficina.Domain.Entities;

public class ServicoConfiguration : IEntityTypeConfiguration<Servico>
{
    public void Configure(EntityTypeBuilder<Servico> builder)
    {
        builder.ToTable("servicos");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Codigo).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Nome).IsRequired().HasMaxLength(150);
        builder.Property(s => s.Descricao).HasMaxLength(1000);
        builder.Property(s => s.PrecoPadrao).HasPrecision(18, 2);
        builder.Property(s => s.CustoPadrao).HasPrecision(18, 2);

        builder.HasIndex(s => s.Codigo).IsUnique();

        builder.HasOne(s => s.CategoriaServico)
            .WithMany()
            .HasForeignKey(s => s.CategoriaServicoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
