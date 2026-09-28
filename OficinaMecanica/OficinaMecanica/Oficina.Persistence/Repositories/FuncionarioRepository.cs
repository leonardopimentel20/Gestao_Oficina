using Microsoft.EntityFrameworkCore;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;
using Oficina.Persistence.Context;

namespace Oficina.Persistence.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _context;

        public FuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Funcionario?> ObterPorIdAsync(Guid id)
        {
            return await _context.Funcionarios.FindAsync(id);
        }

        public async Task<IEnumerable<Funcionario>> ObterTodosAsync()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task AdicionarAsync(Funcionario funcionario)
        {
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var funcionario = await ObterPorIdAsync(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
            }
        }
    }
}