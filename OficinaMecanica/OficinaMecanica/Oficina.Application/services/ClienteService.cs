namespace Oficina.Application.Services;

using Oficina.Application.DTOs;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;

public class ClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Guid> RegistarClienteAsync(CriarClienteDto dto, Guid unidadeIdLogada)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome))
        {
            throw new ArgumentException("O nome do cliente é obrigatório.");
        }

        var cliente = new Cliente
        {
            UnidadeId = unidadeIdLogada, // Forçado pelo token de segurança, ignorando a prop do DTO se houver
            TipoPessoa = dto.TipoPessoa,
            Nome = dto.Nome,
            Documento = dto.Documento,
            Email = dto.Email,
            Observacoes = dto.Observacoes,
            Ativo = true
        };

        await _clienteRepository.AdicionarAsync(cliente);
        return cliente.Id;
    }
    
    public async Task<Cliente?> ObterClienteSeguroAsync(Guid id, Guid unidadeIdLogada)
    {
        // Garante a recuperação apenas se pertencer à unidade logada
        return await _clienteRepository.ObterPorIdAsync(id, unidadeIdLogada);
    }

    public async Task<IEnumerable<Cliente>> ObterTodosSeguroAsync(Guid unidadeIdLogada)
    {
        return await _clienteRepository.ObterTodosPorUnidadeAsync(unidadeIdLogada);
    }
}
