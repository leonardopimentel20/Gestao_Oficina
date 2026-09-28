using Oficina.Domain.Entities;

namespace Oficina.Application.Interfaces
{
    public interface IServicoRepository
    {
        Task<Servico?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Servico>> ObterTodosAsync();
        Task AdicionarAsync(Servico servico);
        Task AtualizarAsync(Servico servico);
        Task RemoverAsync(Guid id);
    }
}