import { api } from '../../api/api';

export const authService = {
  login: async (email: string, senha: string) => {
    // Ajuste a rota '/auth/login' ou '/usuarios/login' conforme o seu backend .NET
    const response = await api.post('/auth/login', { email, senha });
    
    // Se o backend retornar o token, guardamos no localStorage
    if (response.data && response.data.token) {
      localStorage.setItem('token_oficina', response.data.token);
    }
    return response.data;
  },

  logout: () => {
    localStorage.removeItem('token_oficina');
  },

  obterToken: () => {
    return localStorage.getItem('token_oficina');
  }
};