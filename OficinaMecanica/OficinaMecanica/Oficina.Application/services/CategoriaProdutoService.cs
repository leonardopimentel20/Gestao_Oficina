using Oficina.Application.DTOs;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;

namespace Oficina.Application.services
{
    public class CategoriaProdutoService
    {
        private readonly ICategoriaProdutoRepository _categoriaRepository;

        public CategoriaProdutoService(ICategoriaProdutoRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<CategoriaProduto>> ListarAsync()
        {
            return await _categoriaRepository.ObterTodosAsync();
        }

        public async Task<CategoriaProduto?> ObterPorIdAsync(Guid id)
        {
            return await _categoriaRepository.ObterPorIdAsync(id);
        }

        public async Task<CategoriaProduto> CriarAsync(CriarCategoriaProdutoDto dto)
        {
            var categoria = new CategoriaProduto
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao
            };

            await _categoriaRepository.AdicionarAsync(categoria);
            return categoria;
        }
    }
}