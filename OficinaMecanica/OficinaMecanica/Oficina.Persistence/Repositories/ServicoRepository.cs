using Microsoft.EntityFrameworkCore;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;
using Oficina.Persistence.Context;

namespace Oficina.Persistence.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly AppDbContext _context;

        public ServicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Servico?> ObterPorIdAsync(Guid id)
        {
            return await _context.Servicos
                .Include(s => s.CategoriaServico)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Servico>> ObterTodosAsync()
        {
            return await _context.Servicos
                .Include(s => s.CategoriaServico)
                .ToListAsync();
        }

        public async Task AdicionarAsync(Servico servico)
        {
            await _context.Servicos.AddAsync(servico);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Servico servico)
        {
            _context.Servicos.Update(servico);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var servico = await ObterPorIdAsync(id);
            if (servico != null)
            {
                _context.Servicos.Remove(servico);
                await _context.SaveChangesAsync();
            }
        }
    }
}