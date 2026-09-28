namespace Oficina.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;
using Oficina.Persistence.Context;

public class VeiculoRepository : IVeiculoRepository
{
    private readonly AppDbContext _context;

    public VeiculoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Veiculo veiculo)
    {
        await _context.Veiculos.AddAsync(veiculo);
        await _context.SaveChangesAsync();
    }

    public async Task<Veiculo?> ObterPorIdAsync(Guid id, Guid unidadeId)
    {
        // Garante que o veiculo pertence a um cliente da mesma unidade
        return await _context.Veiculos
            .Include(v => v.Cliente)
            .FirstOrDefaultAsync(v => v.Id == id && v.Cliente.UnidadeId == unidadeId);
    }
    
    public async Task<IEnumerable<Veiculo>> ObterTodosPorUnidadeAsync(Guid unidadeId)
    {
        return await _context.Veiculos
            .Include(v => v.Cliente)
            .Where(v => v.Cliente.UnidadeId == unidadeId)
            .ToListAsync();
    }
}
