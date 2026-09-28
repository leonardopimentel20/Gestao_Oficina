using System;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Oficina.Application.DTOs;
using Oficina.Application.Interfaces;
using Oficina.Application.Services;
using Oficina.Domain.Entities;

namespace Oficina.Application.Tests
{
    public class UsuarioServiceTests
    {
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly UsuarioService _usuarioService;

        public UsuarioServiceTests()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _tokenServiceMock = new Mock<ITokenService>();
            _usuarioService = new UsuarioService(_usuarioRepositoryMock.Object, _tokenServiceMock.Object);
        }

        [Fact]
        public async Task CriarUsuarioAsync_ComDadosValidos_DeveRetornarGuid()
        {
            // Arrange
            var dto = new CriarUsuarioDto
            {
                UnidadeId = Guid.NewGuid(),
                Nome = "Teste",
                Email = "teste@teste.com",
                Senha = "senha"
            };

            _usuarioRepositoryMock.Setup(repo => repo.ObterPorEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((Usuario?)null);

            _usuarioRepositoryMock.Setup(repo => repo.AdicionarAsync(It.IsAny<Usuario>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _usuarioService.CriarUsuarioAsync(dto);

            // Assert
            Assert.NotEqual(Guid.Empty, result);
            _usuarioRepositoryMock.Verify(repo => repo.AdicionarAsync(It.IsAny<Usuario>()), Times.Once);
        }

        [Fact]
        public async Task CriarUsuarioAsync_ComEmailExistente_DeveLancarExcecao()
        {
            // Arrange
            var dto = new CriarUsuarioDto
            {
                UnidadeId = Guid.NewGuid(),
                Nome = "Teste",
                Email = "teste@teste.com",
                Senha = "senha"
            };

            var usuarioExistente = new Usuario { Email = dto.Email, Nome = "Existente", SenhaHash = "hash" };

            _usuarioRepositoryMock.Setup(repo => repo.ObterPorEmailAsync(dto.Email))
                .ReturnsAsync(usuarioExistente);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _usuarioService.CriarUsuarioAsync(dto));
        }
    }
}
