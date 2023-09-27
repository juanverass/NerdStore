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
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Produto, ProdutoDto>()
               .ForMember(d => d.Largura, o => o.MapFrom(s => s.Dimensoes.Largura))
               .ForMember(d => d.Altura, o => o.MapFrom(s => s.Dimensoes.Altura))
               .ForMember(d => d.Profundidade, o => o.MapFrom(s => s.Dimensoes.Profundidade));

            CreateMap<Categoria, CategoriaDto>();
        }
    }
}
