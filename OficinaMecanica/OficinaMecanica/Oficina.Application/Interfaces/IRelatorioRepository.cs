using Oficina.Domain.Entities;

namespace Oficina.Application.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<IEnumerable<OrdemServico>> ObterOrdensServicoCompletasPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<Produto>> ObterProdutosEstoqueCompletoAsync();
        Task<IEnumerable<Funcionario>> ObterFuncionariosAtivosAsync();
    }
}