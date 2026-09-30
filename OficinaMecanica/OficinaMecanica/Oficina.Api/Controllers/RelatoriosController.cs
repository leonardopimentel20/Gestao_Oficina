using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oficina.Application.services;

namespace Oficina.Api.Controllers
{
    [AllowAnonymous] // Permite acesso anônimo a este controlador
    [ApiController]
    [Route("api/[controller]")]
    public class RelatoriosController : ControllerBase
    {
        private readonly RelatorioService _relatorioService;

        public RelatoriosController(RelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet("faturamento-detalhado")]
public async Task<IActionResult> GetFaturamentoDetalhado(
    [FromQuery] DateTime dataInicio, 
    [FromQuery] DateTime dataFim,
    [FromQuery] decimal percentualMarkupPecas = 0)
{
    if (dataInicio.Kind == DateTimeKind.Unspecified)
{
    dataInicio = DateTime.SpecifyKind(dataInicio, DateTimeKind.Utc);
}

if (dataFim.Kind == DateTimeKind.Unspecified)
{
    dataFim = DateTime.SpecifyKind(dataFim, DateTimeKind.Utc);
}

    var resultado = await _relatorioService.ObterFaturamentoDetalhadoAsync(dataInicio, dataFim, percentualMarkupPecas);
    return Ok(resultado);
}
        [HttpGet("comissoes")]
        public async Task<IActionResult> GetComissoes([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
        {
           if (dataInicio.Kind == DateTimeKind.Unspecified)
{
    dataInicio = DateTime.SpecifyKind(dataInicio, DateTimeKind.Utc);
}

if (dataFim.Kind == DateTimeKind.Unspecified)
{
    dataFim = DateTime.SpecifyKind(dataFim, DateTimeKind.Utc);
}
            var resultado = await _relatorioService.ObterComissoesFuncionariosAsync(dataInicio, dataFim);
            return Ok(resultado);
        }

        [HttpGet("estoque")]
        public async Task<IActionResult> GetEstoque()
        {
            var resultado = await _relatorioService.ObterRelatorioEstoqueAsync();
            return Ok(resultado);
        }

       [HttpGet("ordens-servico-analitico")]
public async Task<IActionResult> GetOrdensServicoAnalitico([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim, [FromQuery] string? status)
{
    if (dataInicio == default || dataFim == default)
    {
        return BadRequest(new { mensagem = "As datas de início e fim são obrigatórias e devem ser válidas." });
    }

    if (dataInicio.Kind == DateTimeKind.Unspecified)
    {
        dataInicio = DateTime.SpecifyKind(dataInicio, DateTimeKind.Utc);
    }

    if (dataFim.Kind == DateTimeKind.Unspecified)
    {
        dataFim = DateTime.SpecifyKind(dataFim, DateTimeKind.Utc);
    }

    var resultado = await _relatorioService.ObterOrdensServicoAnaliticoAsync(dataInicio, dataFim, status);
    return Ok(resultado);
}

    }
}