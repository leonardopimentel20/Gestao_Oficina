using Oficina.Domain.Entities;

namespace Oficina.Application.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<Fornecedor?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Fornecedor>> ObterTodosAsync();
        Task AdicionarAsync(Fornecedor fornecedor);
        Task AtualizarAsync(Fornecedor fornecedor);
        Task RemoverAsync(Guid id);
    }
}