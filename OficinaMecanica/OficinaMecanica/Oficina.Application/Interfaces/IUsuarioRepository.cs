namespace Oficina.Application.Interfaces;

using Oficina.Domain.Entities;

public interface IUsuarioRepository
{
    Task<Usuario?> ObterPorIdAsync(Guid id);
    Task<Usuario?> ObterPorEmailAsync(string email);
    Task AdicionarAsync(Usuario usuario);
    Task AtualizarAsync(Usuario usuario);
}
