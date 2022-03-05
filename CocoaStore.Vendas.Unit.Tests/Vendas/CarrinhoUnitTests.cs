using CocoaStore.Vendas.Unit.Tests.Config.Fixtures;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CocoaStore.Vendas.Unit.Tests.Vendas;

public class CarrinhoUnitTests : IClassFixture<CarrinhoFixture>
{
    private readonly CarrinhoFixture _carrinhoFixture;
    private readonly ITestOutputHelper _outputHelper;

    public CarrinhoUnitTests(CarrinhoFixture carrinhoFixture, ITestOutputHelper outputHelper)
    {
        _carrinhoFixture = carrinhoFixture;
        _outputHelper = outputHelper;
    }

    [Fact]
    public void Deve_AdicionarItem_Ao_Carrinho()
    {
        var carrinho = _carrinhoFixture.GerarCarrinhoDeCompras();

        carrinho.AdicionarItem(_carrinhoFixture.GerarItem());

        carrinho.Items
            .Should()
            .HaveCount(1);
        
        _outputHelper.WriteLine("{0}", carrinho);
    }
    
    [Fact]
    public void Deve_AumentarQuantidade_De_ItemDuplicado_Ao_Carrinho()
    {
        var carrinho = _carrinhoFixture.GerarCarrinhoDeCompras();
        var item = _carrinhoFixture.GerarItem(1, 1);

        carrinho.AdicionarItem(item);
        carrinho.AdicionarItem(item);

        carrinho.Items
            .Should()
            .HaveCount(1);

        carrinho.Items.Find(i => i.CodigoProduto == item.CodigoProduto)
            ?.Quantidade
            .Should()
            .Be(2);
        
        _outputHelper.WriteLine("{0}", carrinho);
    }
    
    [Theory]
    [InlineData(5)]
    [InlineData(25)]
    [InlineData(50)]
    public void Deve_Adicionar_ListaDeItems_Ao_Carrinho(int quantidade)
    {
        var carrinho = _carrinhoFixture.GerarCarrinhoDeCompras();
        var items = _carrinhoFixture.GerarItems(quantidade);
        carrinho.AdicionarItem(items);

        carrinho.Items
            .Should()
            .HaveCount(quantidade);
        
        _outputHelper.WriteLine("{0}", carrinho);
    }

    [Fact]
    public void Deve_RemoverItem_Do_Carrinho()
    {
        var carrinho = _carrinhoFixture.GerarCarrinhoDeCompras();
        var itemParaRemover = _carrinhoFixture.GerarItem();
        
        carrinho.AdicionarItem(itemParaRemover);
        carrinho.AdicionarItem(_carrinhoFixture.GerarItem());
        carrinho.AdicionarItem(_carrinhoFixture.GerarItem());
        carrinho.AdicionarItem(_carrinhoFixture.GerarItem());
        
        _outputHelper.WriteLine("\n\n{0}", carrinho);
        
        carrinho.RemoverItem(itemParaRemover);
        
        carrinho.Items
            .Should()
            .HaveCount(3);
        
        _outputHelper.WriteLine("{0}", carrinho);
    }
    
    [Fact]
    public void Deve_RemoverItem_Do_Carrinho_Pelo_CodigoProduto()
    {
        var carrinho = _carrinhoFixture.GerarCarrinhoDeCompras();
        var itemParaRemover = _carrinhoFixture.GerarItem();
        
        carrinho.AdicionarItem(itemParaRemover);
        carrinho.AdicionarItem(_carrinhoFixture.GerarItem());
        carrinho.AdicionarItem(_carrinhoFixture.GerarItem());
        carrinho.AdicionarItem(_carrinhoFixture.GerarItem());
        
        _outputHelper.WriteLine("\n\n{0}", carrinho);
        
        carrinho.RemoverItem(itemParaRemover.CodigoProduto);
        
        carrinho.Items
            .Should()
            .HaveCount(3);
        
        _outputHelper.WriteLine("{0}", carrinho);
    }
}