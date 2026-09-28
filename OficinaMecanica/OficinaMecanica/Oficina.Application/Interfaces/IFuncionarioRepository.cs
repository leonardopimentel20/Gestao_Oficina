using Oficina.Domain.Entities;

namespace Oficina.Application.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<Funcionario?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Funcionario>> ObterTodosAsync();
        Task AdicionarAsync(Funcionario funcionario);
        Task AtualizarAsync(Funcionario funcionario);
        Task RemoverAsync(Guid id);
    }
}