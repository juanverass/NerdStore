using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStoreCatalogo.Domain.Produtos
{
    public class Categoria : EntityBase
    {
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }
        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }
        public string Nome { get; private set; }
        public int Codigo { get; private set; }
    }
}
