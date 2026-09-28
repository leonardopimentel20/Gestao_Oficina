import React, { useState } from 'react';
import { LayoutDashboard, Wrench, Users, Package, Menu, X } from 'lucide-react';

interface LayoutProps {
  children: React.ReactNode;
  abaAtiva: string;
  setAbaAtiva: (tab: string) => void;
}

export default function Layout({ children, abaAtiva, setAbaAtiva }: LayoutProps) {
  const [mobileMenuOpen, setMobileMenuOpen] = useState(false);

  const menuItems = [
    { id: 'dashboard', label: 'Dashboard', icon: LayoutDashboard },
    { id: 'os', label: 'Ordens de Serviço', icon: Wrench },
    { id: 'clientes', label: 'Clientes & Veículos', icon: Users },
    { id: 'produtos', label: 'Peças & Estoque', icon: Package },
  ];

  return (
    <div className="min-h-screen bg-gray-50 flex flex-col md:flex-row">
      {/* Barra superior mobile */}
      <header className="bg-slate-900 text-white md:hidden flex items-center justify-between p-4 shadow-md">
        <h1 className="font-bold text-lg tracking-wide">Oficina Mecânica</h1>
        <button 
          onClick={() => setMobileMenuOpen(!mobileMenuOpen)}
          className="p-2 rounded-lg bg-slate-800 text-gray-200 focus:outline-none"
        >
          {mobileMenuOpen ? <X size={24} /> : <Menu size={24} />}
        </button>
      </header>

      {/* Menu Lateral (Sidebar) */}
      <aside className={`
        fixed inset-y-0 left-0 z-50 w-64 bg-slate-900 text-slate-300 transform transition-transform duration-300 ease-in-out md:translate-x-0 md:static
        ${mobileMenuOpen ? 'translate-x-0' : '-translate-x-full'}
      `}>
        <div className="p-6 hidden md:block">
          <h1 className="text-xl font-extrabold text-white tracking-tight">OficinaPro</h1>
          <p className="text-xs text-slate-400 mt-1">Gestão Inteligente & OS</p>
        </div>

        <nav className="mt-6 px-4 space-y-1">
          {menuItems.map((item) => {
            const Icon = item.icon;
            const isActive = abaAtiva === item.id;
            return (
              <button
                key={item.id}
                onClick={() => {
                  setAbaAtiva(item.id);
                  setMobileMenuOpen(false);
                }}
                className={`
                  w-full flex items-center gap-3 px-4 py-3 rounded-xl font-medium text-sm transition-all
                  ${isActive 
                    ? 'bg-blue-600 text-white shadow-lg shadow-blue-600/30' 
                    : 'hover:bg-slate-800 hover:text-white text-slate-400'}
                `}
              >
                <Icon size={20} />
                {item.label}
              </button>
            );
          })}
        </nav>
      </aside>

      {/* Conteúdo Principal */}
      <main className="flex-1 p-4 md:p-8 max-w-7xl mx-auto w-full">
        {children}
      </main>
    </div>
  );
}