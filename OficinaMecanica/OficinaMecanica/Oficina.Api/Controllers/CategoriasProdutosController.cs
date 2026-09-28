using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oficina.Application.DTOs;
using Oficina.Application.services;

namespace Oficina.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasProdutosController : ControllerBase
    {
        private readonly CategoriaProdutoService _service;

        public CategoriasProdutosController(CategoriaProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var categorias = await _service.ListarAsync();
            return Ok(categorias);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var categoria = await _service.ObterPorIdAsync(id);
            if (categoria == null)
            {
                return NotFound(new { mensagem = "Categoria não encontrada." });
            }
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarCategoriaProdutoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var novaCategoria = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = novaCategoria.Id }, novaCategoria);
        }
    }
}