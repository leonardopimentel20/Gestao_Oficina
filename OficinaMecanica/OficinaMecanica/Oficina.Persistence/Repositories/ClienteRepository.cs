namespace Oficina.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;
using Oficina.Persistence.Context;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task<Cliente?> ObterPorIdAsync(Guid id, Guid unidadeId)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(c => c.Id == id && c.UnidadeId == unidadeId);
    }

    public async Task<IEnumerable<Cliente>> ObterTodosPorUnidadeAsync(Guid unidadeId)
    {
        return await _context.Clientes
            .Where(c => c.UnidadeId == unidadeId)
            .ToListAsync();
    }
}
