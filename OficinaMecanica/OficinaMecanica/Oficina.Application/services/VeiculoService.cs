namespace Oficina.Application.Services;

using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;

public class CriarVeiculoDto
{
    public Guid ClienteId { get; set; }
    public string Placa { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
}

public class VeiculoService
{
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IClienteRepository _clienteRepository;

    public VeiculoService(IVeiculoRepository veiculoRepository, IClienteRepository clienteRepository)
    {
        _veiculoRepository = veiculoRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task<Guid> RegistarVeiculoAsync(CriarVeiculoDto dto, Guid unidadeIdLogada)
    {
        var cliente = await _clienteRepository.ObterPorIdAsync(dto.ClienteId, unidadeIdLogada);
        if (cliente == null)
        {
            throw new UnauthorizedAccessException("Cliente não encontrado ou não pertence a esta unidade.");
        }

        var veiculo = new Veiculo
        {
            ClienteId = dto.ClienteId,
            Placa = dto.Placa,
            Marca = dto.Marca,
            Modelo = dto.Modelo
        };

        await _veiculoRepository.AdicionarAsync(veiculo);
        return veiculo.Id;
    }

    public async Task<Veiculo?> ObterVeiculoSeguroAsync(Guid id, Guid unidadeIdLogada)
    {
        return await _veiculoRepository.ObterPorIdAsync(id, unidadeIdLogada);
    }

    public async Task<IEnumerable<Veiculo>> ObterTodosSeguroAsync(Guid unidadeIdLogada)
    {
        return await _veiculoRepository.ObterTodosPorUnidadeAsync(unidadeIdLogada);
    }
}
