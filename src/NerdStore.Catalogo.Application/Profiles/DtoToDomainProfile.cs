using AutoMapper;
using NerdStore.Catalogo.Application.DTOS;
using NerdStoreCatalogo.Domain.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.Profiles
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<ProdutoDto, Produto>()
                .ConstructUsing(p =>
                    new Produto(
                        p.Nome, 
                        p.Descricao, 
                        p.Ativo,
                        p.Valor,
                        p.IdCategoria, 
                        p.DataCadastro,
                        p.Imagem, 
                        new Dimensoes(
                            p.Altura, 
                            p.Largura, 
                            p.Profundidade)
                        )
                    );

            CreateMap<CategoriaDto, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
        }
    }
}
