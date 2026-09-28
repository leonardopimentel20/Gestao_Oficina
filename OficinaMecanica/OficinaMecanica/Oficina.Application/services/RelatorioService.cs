using Oficina.Application.Interfaces;

namespace Oficina.Application.services
{
    public class RelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioService(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        public async Task<object> ObterFaturamentoDetalhadoAsync(DateTime dataInicio, DateTime dataFim, decimal percentualMarkupPecas = 0)
        {
            var ordens = await _relatorioRepository.ObterOrdensServicoCompletasPorPeriodoAsync(dataInicio, dataFim);

            decimal faturamentoPecasBruto = 0;
            decimal faturamentoPecasComMarkup = 0;
            decimal faturamentoServicos = 0;

            foreach (var os in ordens)
            {
                foreach (var item in os.Itens)
                {
                    var valorItem = item.Quantidade * item.ValorUnitario;
                    if (item.Tipo.Equals("Produto", StringComparison.OrdinalIgnoreCase))
                    {
                        faturamentoPecasBruto += valorItem;
                        var valorComAcrescimo = valorItem * (1 + (percentualMarkupPecas / 100));
                        faturamentoPecasComMarkup += valorComAcrescimo;
                    }
                    else if (item.Tipo.Equals("Servico", StringComparison.OrdinalIgnoreCase))
                    {
                        faturamentoServicos += valorItem;
                    }
                }
            }

            var valorTotalFaturado = faturamentoServicos + faturamentoPecasComMarkup;
            var quantidadeOs = ordens.Count();
            var ticketMedio = quantidadeOs > 0 ? valorTotalFaturado / quantidadeOs : 0;

            var ordensPorStatus = ordens
                .GroupBy(os => os.Status)
                .Select(g => new { Status = g.Key, Quantidade = g.Count(), ValorTotal = g.Sum(os => os.ValorTotal) })
                .ToList();

            return new
            {
                Periodo = new { dataInicio, dataFim },
                ConfiguracaoAplicada = new
                {
                    MarkupPecasPercentual = percentualMarkupPecas
                },
                ResumoFinanceiro = new
                {
                    ValorTotalFaturado = Math.Round(valorTotalFaturado, 2),
                    FaturamentoServicosMaoDeObra = Math.Round(faturamentoServicos, 2),
                    FaturamentoPecasCustoBruto = Math.Round(faturamentoPecasBruto, 2),
                    FaturamentoPecasComMarkup = Math.Round(faturamentoPecasComMarkup, 2),
                    TotalOrdensServico = quantidadeOs,
                    TicketMedio = Math.Round(ticketMedio, 2)
                },
                DistribuicaoPorStatus = ordensPorStatus
            };
        }

        public async Task<object> ObterComissoesFuncionariosAsync(DateTime dataInicio, DateTime dataFim)
        {
            var ordens = await _relatorioRepository.ObterOrdensServicoCompletasPorPeriodoAsync(dataInicio, dataFim);
            var funcionarios = await _relatorioRepository.ObterFuncionariosAtivosAsync();

            var relatorioComissoes = funcionarios.Select(func =>
            {
                var osDoFuncionario = ordens.Where(os => os.FuncionarioId == func.Id).ToList();
                decimal totalServicosExecutados = 0;

                foreach (var os in osDoFuncionario)
                {
                    foreach (var item in os.Itens.Where(i => i.Tipo.Equals("Servico", StringComparison.OrdinalIgnoreCase)))
                    {
                        totalServicosExecutados += item.Quantidade * item.ValorUnitario;
                    }
                }

                var valorComissao = (totalServicosExecutados * func.PercentualComissaoPadrao) / 100;

                return new
                {
                    FuncionarioId = func.Id,
                    NomeFuncionario = func.Nome,
                    PercentualComissao = func.PercentualComissaoPadrao,
                    TotalOrdensAtendidas = osDoFuncionario.Count,
                    BaseCalculoServicos = Math.Round(totalServicosExecutados, 2),
                    ValorComissaoAReceber = Math.Round(valorComissao, 2)
                };
            }).ToList();

            return new
            {
                Periodo = new { dataInicio, dataFim },
                Comissoes = relatorioComissoes
            };
        }

        public async Task<object> ObterRelatorioEstoqueAsync()
        {
            var produtos = await _relatorioRepository.ObterProdutosEstoqueCompletoAsync();
            // Utiliza 'Quantidade' (ou o nome exato da propriedade de estoque no seu Produto.cs)
            var valorTotalInventario = produtos.Sum(p => p.Quantidade * p.PrecoVenda);

            return new
            {
                TotalItensCadastrados = produtos.Count(),
                ValorEstimadoTotalInventario = Math.Round(valorTotalInventario, 2),
                ItensEstoque = produtos
            };
        }

        public async Task<IEnumerable<object>> ObterOrdensServicoAnaliticoAsync(DateTime dataInicio, DateTime dataFim, string? status)
        {
            var ordens = await _relatorioRepository.ObterOrdensServicoCompletasPorPeriodoAsync(dataInicio, dataFim);

            if (!string.IsNullOrEmpty(status))
            {
                ordens = ordens.Where(os => os.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            }

            return ordens.Select(os => new
            {
                os.Id,
                os.DataAbertura,
                os.DataConclusao,
                os.Status,
                Cliente = os.Cliente?.Nome ?? "Não informado",
                Veiculo = os.Veiculo != null ? $"{os.Veiculo.Marca} {os.Veiculo.Modelo} - {os.Veiculo.Placa}" : "Não informado",
                Responsavel = os.Funcionario?.Nome ?? "Não atribuído",
                TotalPecas = os.Itens.Where(i => i.Tipo.Equals("Produto", StringComparison.OrdinalIgnoreCase)).Sum(i => i.Quantidade * i.ValorUnitario),
                TotalServicos = os.Itens.Where(i => i.Tipo.Equals("Servico", StringComparison.OrdinalIgnoreCase)).Sum(i => i.Quantidade * i.ValorUnitario),
                ValorTotal = os.ValorTotal
            });
        }
    }
}