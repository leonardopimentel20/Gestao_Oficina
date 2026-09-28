namespace Oficina.Persistence.Context;

using Microsoft.EntityFrameworkCore;
using Oficina.Domain.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<Unidade> Unidades => Set<Unidade>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Veiculo> Veiculos => Set<Veiculo>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Funcionario> Funcionarios => Set<Funcionario>();
    public DbSet<Perfil> Perfis => Set<Perfil>();
    public DbSet<Permissao> Permissoes => Set<Permissao>();
    public DbSet<UsuarioPerfil> UsuarioPerfis => Set<UsuarioPerfil>();
    public DbSet<PerfilPermissao> PerfilPermissoes => Set<PerfilPermissao>();
    public DbSet<Servico> Servicos => Set<Servico>();
    public DbSet<CategoriaServico> CategoriasServico => Set<CategoriaServico>();
    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<CategoriaProduto> CategoriasProduto => Set<CategoriaProduto>();
    public DbSet<Fornecedor> Fornecedores => Set<Fornecedor>();
    public DbSet<ProdutoFornecedor> ProdutoFornecedores => Set<ProdutoFornecedor>();
    public DbSet<OrdemServico> OrdensServico => Set<OrdemServico>();
    public DbSet<OrdemServicoItem> OrdemServicoItens { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("oficina");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
