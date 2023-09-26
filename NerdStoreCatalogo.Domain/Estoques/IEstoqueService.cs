using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStoreCatalogo.Domain.Estoques
{
    public interface IEstoqueService : IDisposable
    {
        Task<bool> DebitarEstoque(Guid idProduto, int quantidade);
        Task<bool> ReporEstoque(Guid idProduto, int quantidade);
    }
}
