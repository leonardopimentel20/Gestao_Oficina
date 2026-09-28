using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oficina.Application.services;

namespace Oficina.Api.Controllers
{
    [Authorize]
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
    if (dataInicio == default || dataFim == default)
    {
        return BadRequest(new { mensagem = "As datas de início e fim são obrigatórias e devem ser válidas." });
    }

    var resultado = await _relatorioService.ObterFaturamentoDetalhadoAsync(dataInicio, dataFim, percentualMarkupPecas);
    return Ok(resultado);
}
        [HttpGet("comissoes")]
        public async Task<IActionResult> GetComissoes([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
        {
            if (dataInicio == default || dataFim == default)
            {
                return BadRequest(new { mensagem = "As datas de início e fim são obrigatórias e devem ser válidas." });
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

            var resultado = await _relatorioService.ObterOrdensServicoAnaliticoAsync(dataInicio, dataFim, status);
            return Ok(resultado);
        }
    }
}