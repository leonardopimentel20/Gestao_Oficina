namespace Oficina.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oficina.Domain.Entities;

public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.ToTable("funcionarios");
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Nome).IsRequired().HasMaxLength(150);
        builder.Property(f => f.Documento).HasMaxLength(20);
        builder.Property(f => f.Email).HasMaxLength(150);
        builder.Property(f => f.Telefone).HasMaxLength(20);
        builder.Property(f => f.PercentualComissaoPadrao).HasPrecision(5, 2);

        builder.HasOne(f => f.Unidade)
            .WithMany()
            .HasForeignKey(f => f.UnidadeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
