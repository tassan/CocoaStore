using Bogus;
using CocoaStore.Vendas.Domain.Estoque;

namespace CocoaStore.Vendas.Unit.Tests.Fixtures;

public class ProdutoFixture
{
    public Produto GerarProdutoValido()
    {
        return new Faker<Produto>()
            .RuleFor(p => p.Codigo, f => f.Commerce.Ean8())
            .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
            .RuleFor(p => p.Descricao, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Preco, f => decimal.Parse(f.Commerce.Price()));
    }
    
    public Produto GerarProdutoInvalido()
    {
        return new Faker<Produto>()
            .RuleFor(p => p.Codigo, f => string.Empty)
            .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
            .RuleFor(p => p.Descricao, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Preco, f => 0);
    }
}