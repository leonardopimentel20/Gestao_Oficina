using Microsoft.EntityFrameworkCore;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;
using Oficina.Persistence.Context;

namespace Oficina.Persistence.Repositories
{
    public class CategoriaProdutoRepository : ICategoriaProdutoRepository
    {
        private readonly AppDbContext _context;

        public CategoriaProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CategoriaProduto?> ObterPorIdAsync(Guid id)
        {
            return await _context.CategoriasProduto.FindAsync(id);
        }
        public async Task<IEnumerable<CategoriaProduto>> ObterTodosAsync()
        {
            return await _context.CategoriasProduto.ToListAsync();
        }

        public async Task AdicionarAsync(CategoriaProduto categoria)
        {
            await _context.CategoriasProduto.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(CategoriaProduto categoria)
        {
            _context.CategoriasProduto.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var categoria = await ObterPorIdAsync(id);
            if (categoria != null)
            {
                _context.CategoriasProduto.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}