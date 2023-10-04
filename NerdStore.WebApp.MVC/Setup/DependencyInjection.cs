using MediatR;
using NerdStore.Catalogo.Application.AppServices;
using NerdStore.Core.Mediatr;
using NerdStoreCatalogo.Data.Repositorys;
using NerdStoreCatalogo.Data;
using NerdStoreCatalogo.Domain.Estoques;
using NerdStoreCatalogo.Domain.Events;
using NerdStoreCatalogo.Domain.Produtos;

namespace NerdStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();
        }
    }
}
