namespace Oficina.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficina.Domain.Entities;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("produtos");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Codigo).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Nome).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Descricao).HasMaxLength(1000);
        builder.Property(p => p.UnidadeMedida).IsRequired().HasMaxLength(20);
        builder.Property(p => p.PrecoVenda).HasPrecision(18, 2);
        builder.Property(p => p.CustoMedio).HasPrecision(18, 2);
        builder.Property(p => p.EstoqueMinimo).HasPrecision(18, 2);

        builder.HasIndex(p => p.Codigo).IsUnique();

        builder.HasOne(p => p.CategoriaProduto)
            .WithMany()
            .HasForeignKey(p => p.CategoriaProdutoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
