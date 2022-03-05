using CocoaStore.Vendas.Domain.Shared.Interfaces.Repositories.CarrinhoDeCompras;
using CocoaStore.Vendas.Domain.Shared.Interfaces.Repositories.Estoque;
using CocoaStore.Vendas.Infra.Contexts;
using CocoaStore.Vendas.Infra.Interfaces;
using CocoaStore.Vendas.Infra.Repository;
using CocoaStore.Vendas.Infra.UoW;

namespace CocoaStore.Vendas.Api.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.MongoServices();
        services.RepositoryServices();
    }

    private static void MongoServices(this IServiceCollection services)
    {
        services.AddScoped<IMongoContext, MongoContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void RepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
    }
}