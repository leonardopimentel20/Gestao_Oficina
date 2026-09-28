import { useState, useEffect } from 'react';
import { dashboardService } from './dashboardService';

export function Dashboard() {
  const [metricas, setMetricas] = useState<any>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    carregarDadosDashboard();
  }, []);

  const carregarDadosDashboard = async () => {
    try {
      setLoading(true);
      const dados = await dashboardService.obterResumo();
      setMetricas(dados);
    } catch (err) {
      console.error('Erro ao carregar dashboard:', err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="p-8 max-w-7xl mx-auto space-y-6">
      {/* Cabeçalho */}
      <div className="flex justify-between items-center">
        <div>
          <h1 className="text-2xl font-bold text-gray-900">Painel Operacional da Oficina</h1>
          <p className="text-sm text-gray-500">Acompanhamento em tempo real das atividades, aprovações e pós-venda.</p>
        </div>
        <div className="flex items-center space-x-2 bg-emerald-50 border border-emerald-200 px-3 py-1.5 rounded-full">
          <span className="w-2.5 h-2.5 bg-emerald-500 rounded-full animate-pulse"></span>
          <span className="text-xs font-semibold text-emerald-700">Sistema Sincronizado</span>
        </div>
      </div>

      {/* Cartões de Métricas Rápidas */}
      <div className="grid grid-cols-1 md:grid-cols-4 gap-4">
        <div className="bg-white p-5 rounded-2xl shadow-sm border border-gray-100">
          <p className="text-xs font-semibold text-gray-400 uppercase tracking-wider">Faturamento do Mês</p>
          <h3 className="text-2xl font-extrabold text-gray-900 mt-2">
            {loading ? '...' : `R$ ${metricas?.faturamentoMes?.toFixed(2) || '0,00'}`}
          </h3>
          <span className="text-xs text-gray-500 mt-1 block">Serviços + Peças</span>
        </div>

        <div className="bg-white p-5 rounded-2xl shadow-sm border border-gray-100">
          <p className="text-xs font-semibold text-gray-400 uppercase tracking-wider">Ordens de Serviço</p>
          <h3 className="text-2xl font-extrabold text-gray-900 mt-2">
            {loading ? '...' : metricas?.totalOrdensServico || 0}
          </h3>
          <span className="text-xs text-blue-600 mt-1 block font-medium">Ativas no período</span>
        </div>

        <div className="bg-white p-5 rounded-2xl shadow-sm border border-gray-100">
          <p className="text-xs font-semibold text-gray-400 uppercase tracking-wider">Aguardando Aprovação</p>
          <h3 className="text-2xl font-extrabold text-amber-600 mt-2">
            {loading ? '...' : (metricas?.aguardandoAprovacao || 0)}
          </h3>
          <span className="text-xs text-amber-600 mt-1 block font-medium">Orçamentos pendentes</span>
        </div>

        <div className="bg-white p-5 rounded-2xl shadow-sm border border-gray-100">
          <p className="text-xs font-semibold text-gray-400 uppercase tracking-wider">Veículos na Oficina</p>
          <h3 className="text-2xl font-extrabold text-gray-900 mt-2">
            {loading ? '...' : (metricas?.veiculosNaOficina || 0)}
          </h3>
          <span className="text-xs text-gray-500 mt-1 block">Em atendimento</span>
        </div>
      </div>

      {/* Secções Operacionais (OS Aguardando & Pós-Venda / Aniversários) */}
      <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
        
        {/* Coluna Principal: Ordens de Serviço Aguardando Aprovação */}
        <div className="lg:col-span-2 bg-white rounded-2xl shadow-sm border border-gray-100 p-6">
          <div className="flex justify-between items-center mb-4">
            <h2 className="text-lg font-bold text-gray-800">Ordens de Serviço Aguardando Aprovação</h2>
            <span className="text-xs bg-amber-50 text-amber-700 px-2.5 py-1 rounded-lg font-medium border border-amber-200">
              Atenção Requerida
            </span>
          </div>

          <div className="overflow-x-auto">
            <table className="min-w-full divide-y divide-gray-200">
              <thead>
                <tr>
                  <th className="px-4 py-3 text-left text-xs font-semibold text-gray-500 uppercase">OS #</th>
                  <th className="px-4 py-3 text-left text-xs font-semibold text-gray-500 uppercase">Cliente / Veículo</th>
                  <th className="px-4 py-3 text-left text-xs font-semibold text-gray-500 uppercase">Valor Estimado</th>
                  <th className="px-4 py-3 text-right text-xs font-semibold text-gray-500 uppercase">Ação</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-gray-100 text-sm">
                <tr>
                  <td className="px-4 py-3 font-medium text-gray-900">#1042</td>
                  <td className="px-4 py-3 text-gray-600">Carlos Silva (Chevrolet Corsa)</td>
                  <td className="px-4 py-3 font-semibold text-gray-900">R$ 450,00</td>
                  <td className="px-4 py-3 text-right">
                    <button 
                      onClick={() => alert('Abrir detalhes da OS para aprovação')}
                      className="text-xs bg-blue-50 text-blue-600 font-semibold px-3 py-1.5 rounded-lg hover:bg-blue-100 transition-colors"
                    >
                      Ver Orçamento
                    </button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>

        {/* Coluna Lateral: Pós-Venda Ativo (Aniversariantes e Revisões do Mês) */}
        <div className="bg-white rounded-2xl shadow-sm border border-gray-100 p-6 space-y-6">
          <div>
            <h2 className="text-lg font-bold text-gray-800 mb-3">🎉 Aniversariantes do Mês</h2>
            <div className="space-y-3">
              <div className="flex items-center justify-between p-3 bg-blue-50/50 rounded-xl border border-blue-100">
                <div>
                  <p className="text-sm font-semibold text-gray-800">Mariana Souza</p>
                  <p className="text-xs text-blue-600">Faz anos dia 15/04</p>
                </div>
                <button 
                  onClick={() => alert('Enviar parabéns por WhatsApp')}
                  className="text-xs bg-blue-600 text-white font-medium px-2.5 py-1.5 rounded-lg hover:bg-blue-700 transition-colors"
                >
                  Parabéns
                </button>
              </div>
            </div>
          </div>

          <div>
            <h2 className="text-lg font-bold text-gray-800 mb-3">🔧 Revisões Próximas</h2>
            <div className="p-3 bg-gray-50 rounded-xl border border-gray-100">
              <p className="text-sm font-semibold text-gray-800">Volkswagen Gol (ABC-1234)</p>
              <p className="text-xs text-gray-500 mt-0.5">Última revisão há 6 meses</p>
              <span className="inline-block mt-2 text-xs bg-emerald-50 text-emerald-700 px-2 py-0.5 rounded font-medium">
                Ligar para agendar
              </span>
            </div>
          </div>
        </div>

      </div>
    </div>
  );
}