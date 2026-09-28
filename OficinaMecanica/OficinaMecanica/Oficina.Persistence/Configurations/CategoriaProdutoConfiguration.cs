namespace Oficina.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficina.Domain.Entities;

public class CategoriaProdutoConfiguration : IEntityTypeConfiguration<CategoriaProduto>
{
    public void Configure(EntityTypeBuilder<CategoriaProduto> builder)
    {
        builder.ToTable("categoria_produtos");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Descricao).HasMaxLength(500);
    }
}
