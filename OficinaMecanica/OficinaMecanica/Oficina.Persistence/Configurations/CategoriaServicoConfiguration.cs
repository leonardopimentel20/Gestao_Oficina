namespace Oficina.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficina.Domain.Entities;

public class CategoriaServicoConfiguration : IEntityTypeConfiguration<CategoriaServico>
{
    public void Configure(EntityTypeBuilder<CategoriaServico> builder)
    {
        builder.ToTable("categoria_servicos");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Descricao).HasMaxLength(500);
    }
}
