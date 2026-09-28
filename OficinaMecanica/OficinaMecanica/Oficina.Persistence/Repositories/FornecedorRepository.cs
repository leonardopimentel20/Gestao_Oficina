using Microsoft.EntityFrameworkCore;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;
using Oficina.Persistence.Context;

namespace Oficina.Persistence.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppDbContext _context;

        public FornecedorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Fornecedor?> ObterPorIdAsync(Guid id)
        {
            return await _context.Fornecedores.FindAsync(id);
        }

        public async Task<IEnumerable<Fornecedor>> ObterTodosAsync()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        public async Task AdicionarAsync(Fornecedor fornecedor)
        {
            await _context.Fornecedores.AddAsync(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var fornecedor = await ObterPorIdAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}