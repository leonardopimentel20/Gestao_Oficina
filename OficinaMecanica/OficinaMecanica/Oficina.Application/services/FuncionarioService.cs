using Oficina.Application.DTOs;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;

namespace Oficina.Application.services
{
    public class FuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<IEnumerable<Funcionario>> ListarAsync()
        {
            return await _funcionarioRepository.ObterTodosAsync();
        }

        public async Task<Funcionario?> ObterPorIdAsync(Guid id)
        {
            return await _funcionarioRepository.ObterPorIdAsync(id);
        }

        public async Task<Funcionario> CriarAsync(CriarFuncionarioDto dto)
        {
            var funcionario = new Funcionario
            {
                UnidadeId = dto.UnidadeId,
                Nome = dto.Nome,
                Documento = dto.Documento,
                Email = dto.Email,
                Telefone = dto.Telefone,
                PercentualComissaoPadrao = dto.PercentualComissaoPadrao,
                Ativo = true
            };

            await _funcionarioRepository.AdicionarAsync(funcionario);
            return funcionario;
        }
    }
}