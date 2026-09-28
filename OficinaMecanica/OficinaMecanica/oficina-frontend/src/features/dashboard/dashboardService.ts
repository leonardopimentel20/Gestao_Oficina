import { api } from '../../api/api';

export const dashboardService = {
  obterResumo: async () => {
    const response = await api.get('/dashboard/resumo');
    return response.data;
  }
};

export interface DashboardData {
  faturamentoTotal: number;
  faturamentoServicos: number;
  faturamentoPecas: number;
  totalOrdensServico: number;
  ticketMedio: number;
  valorTotalInventario: number;
  totalItensEstoque: number;
}

export async function buscarDadosDashboard(): Promise<DashboardData> {
  try {
    // Definimos o período padrão (ex: mês atual)
    const hoje = new Date();
    const primeiroDiaMes = new Date(hoje.getFullYear(), hoje.getMonth(), 1).toISOString().split('T')[0];
    const ultimoDiaMes = new Date(hoje.getFullYear(), hoje.getMonth() + 1, 0).toISOString().split('T')[0];

    // Chamadas paralelas otimizadas à nossa API .NET
    const [resFaturamento, resEstoque] = await Promise.all([
      api.get(`/relatorios/faturamento-detalhado?dataInicio=${primeiroDiaMes}&dataFim=${ultimoDiaMes}`),
      api.get('/relatorios/estoque')
    ]);

    const resumo = resFaturamento.data.ResumoFinanceiro;
    const estoque = resEstoque.data;

    return {
      faturamentoTotal: resumo?.ValorTotalFaturado || 0,
      faturamentoServicos: resumo?.FaturamentoServicosMaoDeObra || 0,
      faturamentoPecas: resumo?.FaturamentoPecasComMarkup || 0,
      totalOrdensServico: resumo?.TotalOrdensServico || 0,
      ticketMedio: resumo?.TicketMedio || 0,
      valorTotalInventario: estoque?.ValorEstimadoTotalInventario || 0,
      totalItensEstoque: estoque?.TotalItensCadastrados || 0,
    };
  } catch (error) {
    console.error("Erro ao carregar dados do dashboard:", error);
    throw error;
  }
}