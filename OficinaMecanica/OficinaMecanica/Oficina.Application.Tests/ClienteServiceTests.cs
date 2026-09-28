using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Oficina.Application.DTOs;
using Oficina.Application.Interfaces;
using Oficina.Application.Services;
using Oficina.Domain.Entities;
using Oficina.Domain.Enums;

namespace Oficina.Application.Tests
{
    public class ClienteServiceTests
    {
        private readonly Mock<IClienteRepository> _clienteRepositoryMock;
        private readonly ClienteService _clienteService;

        public ClienteServiceTests()
        {
            _clienteRepositoryMock = new Mock<IClienteRepository>();
            _clienteService = new ClienteService(_clienteRepositoryMock.Object);
        }

        [Fact]
        public async Task RegistarClienteAsync_DeveAtribuirUnidadeIdSeguraDoToken()
        {
            // Arrange
            var unidadeSegura = Guid.NewGuid();
            var dto = new CriarClienteDto
            {
                UnidadeId = Guid.NewGuid(), // Tentativa de injeção de unidade diferente
                Nome = "Cliente Teste IDOR",
                TipoPessoa = TipoPessoa.Fisica
            };

            Cliente? clienteSalvo = null;
            _clienteRepositoryMock.Setup(repo => repo.AdicionarAsync(It.IsAny<Cliente>()))
                .Callback<Cliente>(c => clienteSalvo = c)
                .Returns(Task.CompletedTask);

            // Act
            await _clienteService.RegistarClienteAsync(dto, unidadeSegura);

            // Assert
            Assert.NotNull(clienteSalvo);
            Assert.Equal(unidadeSegura, clienteSalvo.UnidadeId);
            Assert.NotEqual(dto.UnidadeId, clienteSalvo.UnidadeId);
        }
    }
}
