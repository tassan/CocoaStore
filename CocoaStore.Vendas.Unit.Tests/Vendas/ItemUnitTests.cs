using CocoaStore.Vendas.Unit.Tests.Config.Fixtures;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CocoaStore.Vendas.Unit.Tests.Vendas;

public class ItemUnitTests : IClassFixture<CarrinhoFixture>
{
    private readonly CarrinhoFixture _carrinhoFixture;
    private readonly ITestOutputHelper _outputHelper;

    public ItemUnitTests(CarrinhoFixture carrinhoFixture, ITestOutputHelper outputHelper)
    {
        _carrinhoFixture = carrinhoFixture;
        _outputHelper = outputHelper;
    }

    [Fact]
    public void Deve_AumentarQuantidade_Do_Item()
    {
        var item = _carrinhoFixture.GerarItem(1, 1);
        _outputHelper.WriteLine("{0}", item);
        
        item.Adicionar();

        item.Quantidade
            .Should()
            .Be(2);

        item.PrecoTotal
            .Should()
            .BeGreaterThan(item.PrecoUnitario);
        
        _outputHelper.WriteLine("{0}", item);
    }
    
    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(2, 2, 1)]
    [InlineData(20, 20, 19)]
    [InlineData(50, 50, 49)]
    public void Deve_DiminuirQuantidade_Do_Item(int qtdMin, int qtdMax, int resultado)
    {
        var item = _carrinhoFixture.GerarItem(qtdMin, qtdMax);
        _outputHelper.WriteLine("{0}", item);
        
        item.Remover();

        item.Quantidade
            .Should()
            .Be(resultado);

        _outputHelper.WriteLine("{0}", item);
    }
}