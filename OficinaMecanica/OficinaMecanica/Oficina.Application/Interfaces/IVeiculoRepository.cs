namespace Oficina.Application.Interfaces;

using Oficina.Domain.Entities;

public interface IVeiculoRepository
{
    Task AdicionarAsync(Veiculo veiculo);
    Task<Veiculo?> ObterPorIdAsync(Guid id, Guid unidadeId);
    Task<IEnumerable<Veiculo>> ObterTodosPorUnidadeAsync(Guid unidadeId);
}
