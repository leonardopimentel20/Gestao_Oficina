namespace Oficina.Api.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oficina.Application.DTOs;
using Oficina.Application.Services;
using System.Security.Claims;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ClienteService _clienteService;

    public ClientesController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    private Guid ObterUnidadeIdLogada()
    {
        var claim = User.FindFirst("UnidadeId")?.Value;
        if (Guid.TryParse(claim, out Guid unidadeId))
        {
            return unidadeId;
        }
        
        // Retorna um Guid padrão para testes locais quando o token não possui a claim
        return Guid.Empty;
    }

   [HttpPost]
public async Task<IActionResult> Criar([FromBody] CriarClienteDto dto)
{
    try
    {
        var unidadeId = ObterUnidadeIdLogada();
        
        // Se a unidade vier vazia (Guid.Empty), assume temporariamente a unidade padrão de teste
        if (unidadeId == Guid.Empty)
        {
            unidadeId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        }

        var id = await _clienteService.RegistarClienteAsync(dto, unidadeId);
        return CreatedAtAction(nameof(ObterPorId), new { id = id }, new { id = id });
    }
    catch (ArgumentException ex)
    {
        return BadRequest(new { message = ex.Message });
    }
}
    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var unidadeId = ObterUnidadeIdLogada();
        var cliente = await _clienteService.ObterClienteSeguroAsync(id, unidadeId);
        if (cliente == null)
            return NotFound();
            
        return Ok(cliente);
    }

   [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        try
        {
            Guid unidadeId = Guid.Empty;
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                var unidadeClaim = User.FindFirst("UnidadeId")?.Value;
                if (!string.IsNullOrEmpty(unidadeClaim))
                {
                    Guid.TryParse(unidadeClaim, out unidadeId);
                }
            }

            // Se a unidade vier vazia, assume a unidade padrão de teste (igual ao método Criar)
            if (unidadeId == Guid.Empty)
            {
                unidadeId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            }

            var clientes = await _clienteService.ObterTodosSeguroAsync(unidadeId);
            return Ok(clientes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro ao listar clientes", detalhes = ex.Message });
        }
    }
}