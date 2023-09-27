using NerdStore.Catalogo.Application.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.AppServices
{
    public interface IProdutoAppService : IDisposable
    {
        Task<IEnumerable<ProdutoDto>> ObterPorCategoria(int codigo);
        Task<ProdutoDto> ObterPorId(Guid id);
        Task<IEnumerable<ProdutoDto>> ObterTodos();
        Task<IEnumerable<CategoriaDto>> ObterCategorias();

        Task AdicionarProduto(ProdutoDto produtoViewModel);
        Task AtualizarProduto(ProdutoDto produtoViewModel);

        Task<ProdutoDto> DebitarEstoque(Guid id, int quantidade);
        Task<ProdutoDto> ReporEstoque(Guid id, int quantidade);
    }
}
