using System;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Oficina.Application.Interfaces;
using Oficina.Application.Services;
using Oficina.Domain.Entities;

namespace Oficina.Application.Tests
{
    public class VeiculoServiceTests
    {
        private readonly Mock<IVeiculoRepository> _veiculoRepositoryMock;
        private readonly Mock<IClienteRepository> _clienteRepositoryMock;
        private readonly VeiculoService _veiculoService;

        public VeiculoServiceTests()
        {
            _veiculoRepositoryMock = new Mock<IVeiculoRepository>();
            _clienteRepositoryMock = new Mock<IClienteRepository>();
            _veiculoService = new VeiculoService(_veiculoRepositoryMock.Object, _clienteRepositoryMock.Object);
        }

        [Fact]
        public async Task RegistarVeiculoAsync_ClienteNaoPertenceAUnidade_DeveLancarUnauthorizedAccessException()
        {
            // Arrange
            var unidadeSegura = Guid.NewGuid();
            var dto = new CriarVeiculoDto
            {
                ClienteId = Guid.NewGuid(),
                Placa = "ABC1234",
                Marca = "VW",
                Modelo = "Gol"
            };

            // Cliente nulo significa que nao pertence a unidade (repository filtrou)
            _clienteRepositoryMock.Setup(repo => repo.ObterPorIdAsync(dto.ClienteId, unidadeSegura))
                .ReturnsAsync((Cliente?)null);

            // Act & Assert
            await Assert.ThrowsAsync<UnauthorizedAccessException>(() => _veiculoService.RegistarVeiculoAsync(dto, unidadeSegura));
        }
    }
}
