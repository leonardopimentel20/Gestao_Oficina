import { useEffect, useState } from 'react';
import { clienteService, type Cliente } from './clienteService';
import { Modal } from '../../components/Modal';

// Base de dados inteligente de marcas e modelos para autocomplete na oficina
const MARCAS_E_MODELOS: Record<string, string[]> = {
  "Fiat": ["Palio", "Uno", "Strada", "Toro", "Argo", "Mobi", "Siena", "Pulse", "Fastback"],
  "Volkswagen": ["Gol", "Voyage", "Saveiro", "Polo", "Virtus", "T-Cross", "Nivus", "Fox", "Golf"],
  "Chevrolet": ["Onix", "Prisma", "Tracker", "S10", "Cruze", "Montana", "Spin", "Corsa"],
  "Ford": ["Ka", "EcoSport", "Fiesta", "Ranger", "Focus", "Fusion"],
  "Toyota": ["Corolla", "Hilux", "Etios", "Yaris", "Corolla Cross", "SW4"],
  "Honda": ["Civic", "Fit", "HR-V", "WR-V", "City"],
  "Hyundai": ["HB20", "Creta", "Tucson", "ix35"],
  "Renault": ["Sandero", "Logan", "Duster", "Captur", "Kwid", "Oroch"]
};

export default function Clientes() {
  const [clientes, setClientes] = useState<Cliente[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [erro, setErro] = useState<string | null>(null);
  
  // Estados do Modal e Formulário
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [erroModal, setErroModal] = useState<string | null>(null);

  // Campos do Cliente
  const [nome, setNome] = useState('');
  const [documento, setDocumento] = useState('');
  const [email, setEmail] = useState(''); // Opcional
  const [telefone, setTelefone] = useState('');
  
  // Campos do Veículo
  const [marca, setMarca] = useState('');
  const [modelo, setModelo] = useState('');
  const [placa, setPlaca] = useState('');
  const [ano, setAno] = useState('');
  const [cor, setCor] = useState('');
  const [kmAtual, setKmAtual] = useState('');

  // Modelos dinâmicos baseados na marca selecionada
  const modelosDisponiveis = MARCAS_E_MODELOS[marca] || [];

  useEffect(() => {
    carregarClientes();
  }, []);

  const carregarClientes = async () => {
    try {
      setLoading(true);
      const dados = await clienteService.listarClientes();
      setClientes(dados);
      setErro(null);
    } catch (err) {
      console.error('Erro ao carregar clientes:', err);
      setErro('Não foi possível carregar a lista de clientes. Verifique a ligação com a API.');
    } finally {
      setLoading(false);
    }
  };

  const handleSalvarCliente = async (e: React.FormEvent) => {
    e.preventDefault();
    setErroModal(null);
    try {
      const dadosCliente = {
        nome: nome.trim(),
        documento: documento.trim(),
        email: email ? email.trim() : undefined,
        telefone: telefone.trim(),
        tipoPessoa: 0,
        ativo: true
      };

      const dadosVeiculo = {
        marca: marca.trim(),
        modelo: modelo.trim(),
        placa: placa.trim().toUpperCase(),
        ano: ano ? Number(ano) : 0,
        cor: cor.trim(),
        kmAtual: kmAtual ? Number(kmAtual) : 0
      };

      await clienteService.criarClienteComVeiculo(dadosCliente, dadosVeiculo);
      
      // Fecha o modal e limpa todos os campos
      setIsModalOpen(false);
      setNome(''); setDocumento(''); setEmail(''); setTelefone('');
      setMarca(''); setModelo(''); setPlaca(''); setAno(''); setCor(''); setKmAtual('');

      carregarClientes();
    } catch (err: any) {
      console.error('Erro detalhado ao guardar:', err.response);
      const mensagemErro = err.response?.data?.errors 
        ? Object.values(err.response.data.errors).flat().join(' ') 
        : err.response?.data?.message || 'Erro ao guardar o registo. Verifique os campos preenchidos.';
      setErroModal(mensagemErro);
    }
  };

  return (
    <div className="p-8 max-w-7xl mx-auto">
      <div className="flex justify-between items-center mb-6">
        <div>
          <h1 className="text-2xl font-bold text-gray-900">Gestão de Clientes e Veículos</h1>
          <p className="text-sm text-gray-500">Consulte e gira os clientes e automóveis registados na oficina.</p>
        </div>
        <button 
          onClick={() => { setErroModal(null); setIsModalOpen(true); }}
          className="bg-blue-600 hover:bg-blue-700 text-white px-4 py-2 rounded-lg font-medium shadow transition-colors"
        >
          + Novo Cliente & Veículo
        </button>
      </div>

      {erro && (
        <div className="bg-red-50 border-l-4 border-red-400 p-4 mb-6 text-red-700 text-sm rounded-r-lg">
          {erro}
        </div>
      )}

      <div className="bg-white shadow-md rounded-xl overflow-hidden border border-gray-100">
        {loading ? (
          <div className="p-8 text-center text-gray-500">A carregar clientes...</div>
        ) : clientes.length === 0 ? (
          <div className="p-12 text-center text-gray-400">Nenhum cliente registado no sistema.</div>
        ) : (
          <table className="min-w-full divide-y divide-gray-200">
            <thead className="bg-gray-50">
              <tr>
                <th className="px-6 py-3 text-left text-xs font-semibold text-gray-500 uppercase tracking-wider">Nome</th>
                <th className="px-6 py-3 text-left text-xs font-semibold text-gray-500 uppercase tracking-wider">Documento</th>
                <th className="px-6 py-3 text-left text-xs font-semibold text-gray-500 uppercase tracking-wider">Telemóvel</th>
                <th className="px-6 py-3 text-left text-xs font-semibold text-gray-500 uppercase tracking-wider">Email</th>
                <th className="px-6 py-3 text-right text-xs font-semibold text-gray-500 uppercase tracking-wider">Ações</th>
              </tr>
            </thead>
            <tbody className="bg-white divide-y divide-gray-200">
              {clientes.map((cliente) => (
                <tr key={cliente.id} className="hover:bg-gray-50 transition-colors">
                  <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">{cliente.nome}</td>
                  <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{cliente.documento}</td>
                  <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{cliente.telefone}</td>
                  <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{cliente.email || 'Não informado'}</td>
                  <td className="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
                    <button 
                      onClick={() => alert(`Gerir veículos do cliente ID: ${cliente.id}`)}
                      className="text-blue-600 hover:text-blue-900 mr-3"
                    >
                      Gerir Veículos
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        )}
      </div>

      {/* Modal de Registo Integrado (Cliente + Veículo) */}
      <Modal isOpen={isModalOpen} onClose={() => setIsModalOpen(false)} title="Registar Cliente e Veículo">
        <form onSubmit={handleSalvarCliente} className="space-y-4 max-h-[80vh] overflow-y-auto pr-2">
          {erroModal && (
            <div className="bg-red-50 border-l-4 border-red-400 p-3 text-red-700 text-sm rounded-r-lg">
              {erroModal}
            </div>
          )}

          <div className="border-b pb-2 font-semibold text-gray-700 text-sm">1. Informações do Cliente</div>
          
          <div>
            <label className="block text-xs font-medium text-gray-600 mb-1">Nome Completo</label>
            <input 
              type="text" required value={nome} onChange={(e) => setNome(e.target.value)}
              className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:ring-2 focus:ring-blue-500 outline-none"
              placeholder="Ex: Carlos Silva"
            />
          </div>

          <div className="grid grid-cols-2 gap-4">
            <div>
              <label className="block text-xs font-medium text-gray-600 mb-1">Documento (CPF/CNPJ)</label>
              <input 
                type="text" required value={documento} onChange={(e) => setDocumento(e.target.value)}
                className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:ring-2 focus:ring-blue-500 outline-none"
                placeholder="000.000.000-00"
              />
            </div>
            <div>
              <label className="block text-xs font-medium text-gray-600 mb-1">Telemóvel</label>
              <input 
                type="text" required value={telefone} onChange={(e) => setTelefone(e.target.value)}
                className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:ring-2 focus:ring-blue-500 outline-none"
                placeholder="(00) 00000-0000"
              />
            </div>
          </div>

          <div>
            <label className="block text-xs font-medium text-gray-600 mb-1">E-mail (Opcional)</label>
            <input 
              type="email" value={email} onChange={(e) => setEmail(e.target.value)}
              className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:ring-2 focus:ring-blue-500 outline-none"
              placeholder="exemplo@email.com (opcional)"
            />
          </div>

          <div className="border-b pb-2 pt-2 font-semibold text-gray-700 text-sm">2. Informações do Veículo (Autocomplete)</div>

          <div className="grid grid-cols-2 gap-4">
            <div>
              <label className="block text-xs font-medium text-gray-600 mb-1">Marca</label>
              <input 
                type="text" 
                list="marcas-list"
                value={marca} 
                onChange={(e) => { setMarca(e.target.value); setModelo(''); }}
                className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:ring-2 focus:ring-blue-500 outline-none"
                placeholder="Ex: Fiat, Chevrolet..."
              />
              <datalist id="marcas-list">
                {Object.keys(MARCAS_E_MODELOS).map((m) => (
                  <option key={m} value={m} />
                ))}
              </datalist>
            </div>

            <div>
              <label className="block text-xs font-medium text-gray-600 mb-1">Modelo</label>
              <input 
                type="text" 
                list="modelos-list"
                value={modelo} 
                onChange={(e) => setModelo(e.target.value)}
                className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:ring-2 focus:ring-blue-500 outline-none"
                placeholder={marca ? "Selecione o modelo..." : "Escolha a marca primeiro"}
              />
              <datalist id="modelos-list">
                {modelosDisponiveis.map((mod) => (
                  <option key={mod} value={mod} />
                ))}
              </datalist>
            </div>
          </div>

          <div className="grid grid-cols-3 gap-3">
            <div>
              <label className="block text-xs font-medium text-gray-600 mb-1">Placa</label>
              <input 
                type="text" value={placa} onChange={(e) => setPlaca(e.target.value)}
                className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:ring-2 focus:ring-blue-500 outline-none uppercase"
                placeholder="ABC-1234"
              />
            </div>
            <div>
              <label className="block text-xs font-medium text-gray-600 mb-1">Ano</label>
              <input 
                type="number" value={ano} onChange={(e) => setAno(e.target.value)}
                className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:ring-2 focus:ring-blue-500 outline-none"
                placeholder="2020"
              />
            </div>
            <div>
              <label className="block text-xs font-medium text-gray-600 mb-1">Cor</label>
              <input 
                type="text" value={cor} onChange={(e) => setCor(e.target.value)}
                className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:ring-2 focus:ring-blue-500 outline-none"
                placeholder="Prata"
              />
            </div>
          </div>

          <div>
            <label className="block text-xs font-medium text-gray-600 mb-1">Quilometragem (Km)</label>
            <input 
              type="number" value={kmAtual} onChange={(e) => setKmAtual(e.target.value)}
              className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:ring-2 focus:ring-blue-500 outline-none"
              placeholder="50000"
            />
          </div>

          <div className="flex justify-end space-x-3 pt-4 border-t border-gray-100">
            <button
              type="button"
              onClick={() => setIsModalOpen(false)}
              className="px-4 py-2 border border-gray-300 text-gray-700 rounded-lg text-sm font-medium hover:bg-gray-50 transition-colors"
            >
              Cancelar
            </button>
            <button
              type="submit"
              className="px-4 py-2 bg-blue-600 text-white rounded-lg text-sm font-medium hover:bg-blue-700 transition-colors shadow"
            >
              Guardar Registo
            </button>
          </div>
        </form>
      </Modal>
    </div>
  );
}