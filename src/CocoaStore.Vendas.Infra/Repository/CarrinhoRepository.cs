using CocoaStore.Vendas.Domain.CarrinhoDeCompras;
using CocoaStore.Vendas.Domain.Shared.Interfaces.Repositories.CarrinhoDeCompras;
using CocoaStore.Vendas.Infra.Interfaces;

namespace CocoaStore.Vendas.Infra.Repository;

public class CarrinhoRepository : BaseRepository<Carrinho>, ICarrinhoRepository
{
    public CarrinhoRepository(IMongoContext context) : base(context)
    {
    }
}