using Oficina.Application.DTOs;
using Oficina.Application.Interfaces;
using Oficina.Domain.Entities;

namespace Oficina.Application.services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> ListarProdutosAsync()
        {
            return await _produtoRepository.ObterTodosAsync();
        }

        public async Task<Produto?> ObterPorIdAsync(Guid id)
        {
            return await _produtoRepository.ObterPorIdAsync(id);
        }

        public async Task<Produto> CriarAsync(CriarProdutoDto dto)
        {
            // Regra de negócio: O preço de venda não pode ser inferior ao custo médio
            if (dto.PrecoVenda < dto.CustoMedio)
            {
                throw new InvalidOperationException("O preço de venda não pode ser inferior ao custo médio.");
            }

            var produto = new Produto
            {
                Codigo = dto.Codigo,
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                UnidadeMedida = dto.UnidadeMedida,
                PrecoVenda = dto.PrecoVenda,
                CustoMedio = dto.CustoMedio,
                Quantidade = dto.Quantidade,
                EstoqueMinimo = dto.EstoqueMinimo,
                CategoriaProdutoId = dto.CategoriaProdutoId
            };

            await _produtoRepository.AdicionarAsync(produto);
            return produto;
        }
    }
}