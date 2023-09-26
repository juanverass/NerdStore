using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStoreCatalogo.Domain.Produtos
{
    public class Produto : EntityBase, IAggregateRoot
    {
        public Produto(
            string nome,
            string descricao,
            bool ativo,
            decimal valor,
            Guid idCategoria,
            DateTime dataCadastro,
            string imagem
           )
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            IdCategoria = idCategoria;
            DataDoCadastro = dataCadastro;
            Imagem = imagem;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            IdCategoria = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {

        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataDoCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public virtual Categoria Categoria { get; private set; }
        public Guid IdCategoria { get; private set; }

    }
}
