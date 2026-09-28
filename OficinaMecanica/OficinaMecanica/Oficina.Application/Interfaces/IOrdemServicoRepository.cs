using Oficina.Domain.Entities;

namespace Oficina.Application.Interfaces
{
    public interface IOrdemServicoRepository
    {
        Task<OrdemServico?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<OrdemServico>> ObterTodosAsync();
        Task AdicionarAsync(OrdemServico ordemServico);
        Task AtualizarAsync(OrdemServico ordemServico);
        Task RemoverAsync(Guid id);
    }
}