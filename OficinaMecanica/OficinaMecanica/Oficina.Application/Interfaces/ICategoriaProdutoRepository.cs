using Oficina.Domain.Entities;

namespace Oficina.Application.Interfaces
{
    public interface ICategoriaProdutoRepository
    {
        Task<CategoriaProduto?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<CategoriaProduto>> ObterTodosAsync();
        Task AdicionarAsync(CategoriaProduto categoria);
        Task AtualizarAsync(CategoriaProduto categoria);
        Task RemoverAsync(Guid id);
    }
}