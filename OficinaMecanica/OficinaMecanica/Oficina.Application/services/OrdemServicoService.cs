using Oficina.Application.DTOs;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;

namespace Oficina.Application.services
{
    public class OrdemServicoService
    {
        private readonly IOrdemServicoRepository _repository;

        public OrdemServicoService(IOrdemServicoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrdemServico>> ListarAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        public async Task<OrdemServico?> ObterPorIdAsync(Guid id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task<OrdemServico> CriarAsync(CriarOrdemServicoDto dto)
        {
            var ordemServico = new OrdemServico
            {
                ClienteId = dto.ClienteId,
                VeiculoId = dto.VeiculoId,
                FuncionarioId = dto.FuncionarioId,
                DefeitoRelatado = dto.DefeitoRelatado,
                Status = "Aberta",
                DataAbertura = DateTime.UtcNow
            };

            await _repository.AdicionarAsync(ordemServico);
            return ordemServico;
        }

        public async Task<OrdemServicoItem> AdicionarItemAsync(Guid ordemServicoId, AdicionarItemOsDto dto)
{
    var ordemServico = await _repository.ObterPorIdAsync(ordemServicoId);
    if (ordemServico == null)
    {
        throw new InvalidOperationException("Ordem de Serviço não encontrada.");
    }

    var item = new OrdemServicoItem
    {
        OrdemServicoId = ordemServicoId,
        ProdutoId = dto.ProdutoId,
        ServicoId = dto.ServicoId,
        Quantidade = dto.Quantidade,
        ValorUnitario = dto.ValorUnitario,
        Tipo = dto.Tipo
    };

    // Atualiza o valor total da OS
    ordemServico.ValorTotal += item.ValorTotal;

    // Se tiver um repositório dedicado a itens ou se atualizar diretamente pela OS:
    // Certifique-se de guardar as alterações no contexto
    await _repository.AtualizarAsync(ordemServico);
    return item;
}

        
    }
}