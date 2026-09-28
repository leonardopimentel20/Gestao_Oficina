using Microsoft.EntityFrameworkCore;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;
using Oficina.Persistence.Context;

namespace Oficina.Persistence.Repositories
{
    public class OrdemServicoRepository : IOrdemServicoRepository
    {
        private readonly AppDbContext _context;

        public OrdemServicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrdemServico?> ObterPorIdAsync(Guid id)
        {
            return await _context.OrdensServico
                .Include(os => os.Cliente)
                .Include(os => os.Veiculo)
                .Include(os => os.Funcionario)
                .FirstOrDefaultAsync(os => os.Id == id);
        }

        public async Task<IEnumerable<OrdemServico>> ObterTodosAsync()
        {
            return await _context.OrdensServico
                .Include(os => os.Cliente)
                .Include(os => os.Veiculo)
                .Include(os => os.Funcionario)
                .ToListAsync();
        }

        public async Task AdicionarAsync(OrdemServico ordemServico)
        {
            await _context.OrdensServico.AddAsync(ordemServico);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(OrdemServico ordemServico)
        {
            _context.OrdensServico.Update(ordemServico);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var os = await ObterPorIdAsync(id);
            if (os != null)
            {
                _context.OrdensServico.Remove(os);
                await _context.SaveChangesAsync();
            }
        }
    }
}