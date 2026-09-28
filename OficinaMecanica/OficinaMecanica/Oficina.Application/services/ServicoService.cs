using Oficina.Application.DTOs;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;

namespace Oficina.Application.services
{
    public class ServicoService
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoService(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<IEnumerable<Servico>> ListarAsync()
        {
            return await _servicoRepository.ObterTodosAsync();
        }

        public async Task<Servico?> ObterPorIdAsync(Guid id)
        {
            return await _servicoRepository.ObterPorIdAsync(id);
        }

        public async Task<Servico> CriarAsync(CriarServicoDto dto)
        {
            var servico = new Servico
            {
                Codigo = dto.Codigo,
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                PrecoPadrao = dto.PrecoPadrao, // Mapeia o preço do DTO para a propriedade correta da entidade
                Ativo = true,
                CategoriaServicoId = dto.CategoriaServicoId
            };

            await _servicoRepository.AdicionarAsync(servico);
            return servico;
        }
    }
}