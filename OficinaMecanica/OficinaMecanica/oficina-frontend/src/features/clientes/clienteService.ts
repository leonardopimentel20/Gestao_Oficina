import { api } from '../../api/api';

export interface Cliente {
  id?: number;
  nome: string;
  documento: string;
  email?: string;
  telefone: string;
  tipoPessoa: string;
  observacoes?: string;
  ativo: boolean;
}

export interface VeiculoDto {
  clienteId?: number;
  marca: string;
  modelo: string;
  placa: string;
  ano: number;
  cor: string;
  kmAtual: number;
}

export const clienteService = {
  // Obter todos os clientes
  listarClientes: async (): Promise<Cliente[]> => {
    const response = await api.get('/clientes');
    return response.data;
  },

  // Obter cliente por ID
  obterClientePorId: async (id: number): Promise<Cliente> => {
    const response = await api.get(`/clientes/${id}`);
    return response.data;
  },

  // Criar cliente e veículo associado numa única transação lógica
  criarClienteComVeiculo: async (clienteData: any, veiculoData: any): Promise<any> => {
    try {
      // 1. Tenta criar o cliente
      const responseCliente = await api.post('/clientes', clienteData);
      const clienteCriado = responseCliente.data;
      const clienteId = clienteCriado.id || clienteCriado.Id;

      // 2. Se houver placa, tenta registar o veículo associado
      if (clienteId && veiculoData.placa) {
        const payloadVeiculo = {
          clienteId: Number(clienteId),
          marca: String(veiculoData.marca || ''),
          modelo: String(veiculoData.modelo || ''),
          placa: String(veiculoData.placa || '').toUpperCase(),
          ano: Number(veiculoData.ano || 0),
          cor: String(veiculoData.cor || ''),
          kmAtual: Number(veiculoData.kmAtual || 0)
        };
        await api.post('/veiculos', payloadVeiculo);
      }

      return clienteCriado;
    } catch (error: any) {
      console.error("Erro detalhado na API:", error.response?.data || error.message);
      throw error;
    }
  },

  // Atualizar cliente existente
  atualizarCliente: async (id: number, cliente: Cliente): Promise<void> => {
    await api.put(`/clientes/${id}`, cliente);
  },

  // Remover / Inativar cliente
  removerCliente: async (id: number): Promise<void> => {
    await api.delete(`/clientes/${id}`);
  }
};