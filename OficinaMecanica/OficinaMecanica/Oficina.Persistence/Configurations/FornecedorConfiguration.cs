namespace Oficina.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficina.Domain.Entities;

public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        builder.ToTable("fornecedores");
        builder.HasKey(f => f.Id);

        builder.Property(f => f.RazaoSocial).IsRequired().HasMaxLength(150);
        builder.Property(f => f.NomeFantasia).HasMaxLength(150);
        builder.Property(f => f.Cnpj).HasMaxLength(20);
        builder.Property(f => f.Email).HasMaxLength(150);
        builder.Property(f => f.Telefone).HasMaxLength(20);

        builder.HasOne(f => f.Unidade)
            .WithMany()
            .HasForeignKey(f => f.UnidadeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
