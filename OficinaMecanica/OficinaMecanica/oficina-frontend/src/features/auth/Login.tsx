import { useState } from 'react';


export default function Login({ onLoginSucesso }: { onLoginSucesso: () => void }) {
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const [erro, setErro] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setErro(null);
    setLoading(true);
    try {
      // Temporariamente para testes locais, aceita qualquer valor e grava um token falso
      localStorage.setItem('token_oficina', 'token_temporario_admin');
      onLoginSucesso(); 
    } catch (err: any) {
      setErro('Erro ao entrar no sistema.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="min-h-screen bg-gray-900 flex items-center justify-center p-4">
      <div className="bg-white rounded-2xl shadow-xl w-full max-w-md p-8">
        <div className="text-center mb-8">
          <h1 className="text-2xl font-extrabold text-gray-900">OficinaPro Gestão</h1>
          <p className="text-sm text-gray-500 mt-1">Entre com as suas credenciais para aceder ao sistema</p>
        </div>

        {erro && (
          <div className="bg-red-50 border-l-4 border-red-400 p-3 text-red-700 text-sm rounded-r-lg mb-4">
            {erro}
          </div>
        )}

        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label className="block text-xs font-medium text-gray-600 mb-1">E-mail de Acesso</label>
            <input 
              type="email" required value={email} onChange={(e) => setEmail(e.target.value)}
              className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:ring-2 focus:ring-blue-500 outline-none"
              placeholder="admin@oficina.com"
            />
          </div>

          <div>
            <label className="block text-xs font-medium text-gray-600 mb-1">Palavra-passe</label>
            <input 
              type="password" required value={senha} onChange={(e) => setSenha(e.target.value)}
              className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm focus:ring-2 focus:ring-blue-500 outline-none"
              placeholder="••••••••"
            />
          </div>

          <button 
            type="submit" disabled={loading}
            className="w-full bg-blue-600 hover:bg-blue-700 text-white font-semibold py-2.5 rounded-lg transition-colors shadow"
          >
            {loading ? 'A autenticar...' : 'Entrar no Sistema'}
          </button>
        </form>
      </div>
    </div>
  );
}