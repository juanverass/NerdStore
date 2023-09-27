using NerdStore.Core.Mediatr;
using NerdStoreCatalogo.Domain.Events;
using NerdStoreCatalogo.Domain.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStoreCatalogo.Domain.Estoques
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatrHandler _mediatrHandler;

        public EstoqueService(
            IProdutoRepository produtoRepository,
            IMediatrHandler mediatrHandler)
        {
            _produtoRepository = produtoRepository;
            _mediatrHandler = mediatrHandler;
        }

        public async Task<bool> DebitarEstoque(Guid idProduto, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(idProduto);

            if (produto == null) return false;
            if (!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            // TODO: Parametrizar a quantidade de estoque abaixo
            if (produto.QuantidadeEstoque < 10)
            {
                await _mediatrHandler.PublicarEvento(
                    new ProdutoAbaixoEstoqueEvent(
                        produto.Id,
                        produto.QuantidadeEstoque));
            }

            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }


        public async Task<bool> ReporEstoque(Guid idProduto, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(idProduto);

            if (produto == null) return false;
            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
