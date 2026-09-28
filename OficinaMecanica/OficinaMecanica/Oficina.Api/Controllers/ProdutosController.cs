using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oficina.Application.DTOs;
using Oficina.Application.services;

namespace Oficina.Api.Controllers
{
    [Authorize] // Garante que apenas usuários autenticados acessem a API de produtos
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var produtos = await _produtoService.ListarProdutosAsync();
            return Ok(produtos);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var produto = await _produtoService.ObterPorIdAsync(id);
            if (produto == null)
            {
                return NotFound(new { mensagem = "Produto não encontrado." });
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarProdutoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var produtoCriado = await _produtoService.CriarAsync(dto);
                return CreatedAtAction(nameof(ObterPorId), new { id = produtoCriado.Id }, produtoCriado);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}