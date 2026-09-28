using Microsoft.EntityFrameworkCore;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;
using Oficina.Persistence.Context;

namespace Oficina.Persistence.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly AppDbContext _context;

        public RelatorioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrdemServico>> ObterOrdensServicoCompletasPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            return await _context.OrdensServico
                .AsNoTracking()
                .Include(os => os.Cliente)
                .Include(os => os.Veiculo)
                .Include(os => os.Funcionario)
                .Include(os => os.Itens)
                    .ThenInclude(item => item.Produto)
                .Include(os => os.Itens)
                    .ThenInclude(item => item.Servico)
                .Where(os => os.DataAbertura >= dataInicio && os.DataAbertura <= dataFim)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosEstoqueCompletoAsync()
        {
            return await _context.Produtos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Funcionario>> ObterFuncionariosAtivosAsync()
        {
            return await _context.Funcionarios
                .AsNoTracking()
                .Where(f => f.Ativo)
                .ToListAsync();
        }
    }
}