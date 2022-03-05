using CocoaStore.Vendas.Domain.Descontos;
using CocoaStore.Vendas.Unit.Tests.Config.Fixtures;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CocoaStore.Vendas.Unit.Tests.Descontos;

public class CupomUnitTests : IClassFixture<ProdutoFixture>
{
    private readonly ProdutoFixture _fixture;
    private readonly ITestOutputHelper _outputHelper;

    public CupomUnitTests(ProdutoFixture fixture, ITestOutputHelper outputHelper)
    {
        _fixture = fixture;
        _outputHelper = outputHelper;
    }

    [Fact]
    public void Deve_CriarCupom()
    {
        var cupom = new Cupom("SOHOJE", 150);

        cupom.Codigo
            .Should()
            .NotBeNull();

        cupom.Desconto
            .Should()
            .NotBe(0);

        cupom.ProdutosLiberados
            .Should()
            .NotBeNull();
        
        cupom.ProdutosBloqueados
            .Should()
            .NotBeNull();
    }

    [Fact]
    public void Deve_AdicionarProduto_A_ListaDeLiberados()
    {
        var cupom = new Cupom("100OFF", 100);
        var produto = _fixture.GerarProdutoValido();

        cupom.AdicionarProdutoLiberado(produto);

        cupom.EhProdutoLiberado(produto)
            .Should()
            .BeTrue();
    }

    [Fact]
    public void Deve_AdicionarProduto_A_ListaDeBloqueados()
    {
        var cupom = new Cupom("100OFF", 100);
        var produto = _fixture.GerarProdutoValido();

        cupom.AdicionarProdutoBloqueado(produto);

        cupom.EhProdutoBloqueado(produto)
            .Should()
            .BeTrue();
    }
    
    [Fact]
    public void Deve_RemoverProduto_Da_ListaDeLiberados()
    {
        var cupom = new Cupom("100OFF", 100);
        var produto = _fixture.GerarProdutoValido();

        cupom.RemoverProdutoLiberado(produto);

        cupom.EhProdutoLiberado(produto)
            .Should()
            .BeFalse();
    }

    [Fact]
    public void Deve_RemoverProduto_Da_ListaDeBloqueados()
    {
        var cupom = new Cupom("100OFF", 100);
        var produto = _fixture.GerarProdutoValido();

        cupom.RemoverProdutoBloqueado(produto);

        cupom.EhProdutoBloqueado(produto)
            .Should()
            .BeFalse();
    }
}