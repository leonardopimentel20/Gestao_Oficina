namespace Oficina.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficina.Domain.Entities;

public class ProdutoFornecedorConfiguration : IEntityTypeConfiguration<ProdutoFornecedor>
{
    public void Configure(EntityTypeBuilder<ProdutoFornecedor> builder)
    {
        builder.ToTable("produto_fornecedores");
        builder.HasKey(pf => pf.Id);

        builder.Property(pf => pf.CodigoFornecedor).HasMaxLength(50);
        builder.Property(pf => pf.PrecoUltimaCompra).HasPrecision(18, 2);

        builder.HasOne(pf => pf.Produto)
            .WithMany()
            .HasForeignKey(pf => pf.ProdutoId)
            .OnDelete(DeleteBehavior.Cascade); // Se o produto sumir, vinculo some

        builder.HasOne(pf => pf.Fornecedor)
            .WithMany()
            .HasForeignKey(pf => pf.FornecedorId)
            .OnDelete(DeleteBehavior.Cascade); // Se o fornecedor sumir, vinculo some
    }
}
