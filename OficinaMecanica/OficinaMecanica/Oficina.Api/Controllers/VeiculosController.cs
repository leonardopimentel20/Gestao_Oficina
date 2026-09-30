namespace Oficina.Api.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oficina.Application.Services;
using System.Security.Claims;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class VeiculosController : ControllerBase
{
    private readonly VeiculoService _veiculoService;

    public VeiculosController(VeiculoService veiculoService)
    {
        _veiculoService = veiculoService;
    }

   private Guid ObterUnidadeIdLogada()
    {
        var claim = User.FindFirst("UnidadeId")?.Value;
        if (Guid.TryParse(claim, out Guid unidadeId))
        {
            return unidadeId;
        }

        // Fallback seguro para ambiente de desenvolvimento se não houver claim no token
        // Retorna Guid.Empty ou um GUID fixo padrão que exista no seu banco de dados de testes
        return Guid.Empty; 
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarVeiculoDto dto)
    {
        try
        {
            var unidadeId = ObterUnidadeIdLogada();
            
            // Fallback temporário para testes se a unidade vier vazia
            if (unidadeId == Guid.Empty)
            {
                unidadeId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            }

            var id = await _veiculoService.RegistarVeiculoAsync(dto, unidadeId);
            return CreatedAtAction(nameof(ObterPorId), new { id = id }, new { id = id });
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
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
        var veiculo = await _veiculoService.ObterVeiculoSeguroAsync(id, unidadeId);
        if (veiculo == null)
            return NotFound();
            
        return Ok(veiculo);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var unidadeId = ObterUnidadeIdLogada();
        var veiculos = await _veiculoService.ObterTodosSeguroAsync(unidadeId);
        return Ok(veiculos);
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ObterPorCliente(Guid clienteId)
    {
        var unidadeId = ObterUnidadeIdLogada();
        var veiculos = await _veiculoService.ObterPorClienteSeguroAsync(clienteId, unidadeId);
        return Ok(veiculos);
    }
}
