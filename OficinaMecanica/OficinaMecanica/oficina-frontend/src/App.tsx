import { useState, useEffect } from 'react';
import Login from './features/auth/Login';
import Layout from './components/Layout';
import { Dashboard } from './features/dashboard/Dashboard';
import Clientes from './features/clientes/Clientes';
import { authService } from './features/auth/authService';

export default function App() {
  const [autenticado, setAutenticado] = useState(false);
  const [abaAtiva, setAbaAtiva] = useState('dashboard');

  useEffect(() => {
    const token = authService.obterToken();
    if (token) {
      setAutenticado(true);
    }
  }, []);

  if (!autenticado) {
    return <Login onLoginSucesso={() => setAutenticado(true)} />;
  }

  return (
    <Layout abaAtiva={abaAtiva} setAbaAtiva={setAbaAtiva}>
      {abaAtiva === 'dashboard' && <Dashboard />}
      {abaAtiva === 'clientes' && <Clientes />}
      {/* Outras abas conforme necessário */}
    </Layout>
  );
}