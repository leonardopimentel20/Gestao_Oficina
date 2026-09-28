import axios from 'axios';

export const api = axios.create({
  baseURL: 'http://localhost:5200/api', // Mantenha a sua porta correta
  headers: {
    'Content-Type': 'application/json',
  },
});

// Interceptor para adicionar o token de autenticação automaticamente em cada pedido
api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token_oficina');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
}, (error) => {
  return Promise.reject(error);
});