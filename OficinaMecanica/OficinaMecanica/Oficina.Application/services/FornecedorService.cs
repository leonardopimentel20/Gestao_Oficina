using Oficina.Application.DTOs;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;

namespace Oficina.Application.services
{
    public class FornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<IEnumerable<Fornecedor>> ListarAsync()
        {
            return await _fornecedorRepository.ObterTodosAsync();
        }

        public async Task<Fornecedor?> ObterPorIdAsync(Guid id)
        {
            return await _fornecedorRepository.ObterPorIdAsync(id);
        }

        public async Task<Fornecedor> CriarAsync(CriarFornecedorDto dto)
        {
            var fornecedor = new Fornecedor
            {
                UnidadeId = dto.UnidadeId,
                RazaoSocial = dto.RazaoSocial,
                NomeFantasia = dto.NomeFantasia,
                Cnpj = dto.Cnpj,
                Email = dto.Email,
                Telefone = dto.Telefone,
                Ativo = true
            };

            await _fornecedorRepository.AdicionarAsync(fornecedor);
            return fornecedor;
        }
    }
}