namespace Oficina.Application.Interfaces;

using Oficina.Domain.Entities;

public interface IClienteRepository
{
    Task AdicionarAsync(Cliente cliente);
    Task<Cliente?> ObterPorIdAsync(Guid id, Guid unidadeId);
    Task<IEnumerable<Cliente>> ObterTodosPorUnidadeAsync(Guid unidadeId);
}
