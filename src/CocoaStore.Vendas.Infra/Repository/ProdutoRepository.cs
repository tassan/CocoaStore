using CocoaStore.Vendas.Domain.Estoque;
using CocoaStore.Vendas.Domain.Shared.Interfaces.Repositories.Estoque;
using CocoaStore.Vendas.Infra.Interfaces;

namespace CocoaStore.Vendas.Infra.Repository;

public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    public ProdutoRepository(IMongoContext context) : base(context)
    {
    }
}