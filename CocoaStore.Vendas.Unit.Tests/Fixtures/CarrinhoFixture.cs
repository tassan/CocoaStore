using System;
using System.Collections.Generic;
using Bogus;
using CocoaStore.Vendas.Domain.CarrinhoDeCompras;

namespace CocoaStore.Vendas.Unit.Tests.Fixtures;

public class CarrinhoFixture
{
    public Carrinho GerarCarrinhoDeCompras()
    {
        return new Carrinho();
    }

    public Item GerarItem(int qtdMinima = 1, int qtdMaxima = 20)
    {
        return new Faker<Item>()
            .RuleFor(i => i.Nome, f => f.Commerce.ProductName())
            .RuleFor(i => i.Quantidade, f => f.Random.Int(qtdMinima, qtdMaxima))
            .RuleFor(i => i.PrecoUnitario, f => decimal.Parse(f.Commerce.Price()))
            .RuleFor(i => i.CodigoProduto, f => f.Commerce.Ean8());
    }

    public List<Item> GerarItems(int quantidadeItems = 5)
    {
        var items = new List<Item>();
        for (int i = 0; i < quantidadeItems; i++) items.Add(GerarItem());

        return items;
    }
}