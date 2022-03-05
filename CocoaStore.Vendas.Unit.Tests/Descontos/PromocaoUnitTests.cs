using CocoaStore.Vendas.Domain.Core.Types;
using CocoaStore.Vendas.Domain.Descontos;
using CocoaStore.Vendas.Unit.Tests.Config.Fixtures;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CocoaStore.Vendas.Unit.Tests.Descontos;

public class PromocaoUnitTests : IClassFixture<ProdutoFixture>
{
    private readonly ProdutoFixture _fixture;
    private readonly ITestOutputHelper _outputHelper;

    public PromocaoUnitTests(ITestOutputHelper outputHelper, ProdutoFixture fixture)
    {
        _outputHelper = outputHelper;
        _fixture = fixture;
    }

    [Fact]
    public void Deve_AdicionarProduto_A_Promocao()
    {
        var promoProgressiva = new Promocao("Promocao Inverno", TipoPromocao.Progressiva, 500m);

        promoProgressiva.AdicionarProduto(_fixture.GerarProdutoValido());

        promoProgressiva.Produtos
            .Should()
            .NotBeNull();

        promoProgressiva.Produtos
            .Should()
            .HaveCount(1);

        _outputHelper.WriteLine("{0}", promoProgressiva);
    }

    [Fact]
    public void Deve_RemoverProduto_A_Promocao()
    {
        var promoProgressiva = new Promocao("Promocao Inverno", TipoPromocao.Progressiva, 500m);
        var produtoParaRemover = _fixture.GerarProdutoValido();

        promoProgressiva.AdicionarProduto(_fixture.GerarProdutoValido());
        promoProgressiva.RemoverProduto(produtoParaRemover);

        promoProgressiva.Produtos
            .Should()
            .NotBeNull();

        promoProgressiva.Produtos
            .Should()
            .NotContain(produtoParaRemover);

        _outputHelper.WriteLine("{0}", promoProgressiva);
    }

    [Fact]
    public void Deve_CriarPromocao()
    {
        var promocao = new Promocao();

        promocao.Produtos
            .Should()
            .NotBeNull();
    }
    
    [Theory]
    [InlineData(5, TipoPromocao.Progressiva, 450)]
    [InlineData(10, TipoPromocao.PagueMenos, 500)]
    [InlineData(15, TipoPromocao.Progressiva, 2000)]
    [InlineData(50, TipoPromocao.PagueMenos, 5000)]
    public void Deve_CriarPromocao_ComProdutos(int quantidadeProdutos, TipoPromocao tipoPromocao, decimal valorMinCarrinho)
    {
        var produtos = _fixture.GerarProdutosValidos(quantidadeProdutos);
        var promocao = new Promocao("Promoção de Verão", tipoPromocao, valorMinCarrinho, produtos);

        promocao.Produtos
            .Should()
            .NotBeNull();

        promocao.Produtos
            .Should()
            .HaveCount(quantidadeProdutos);
    }
}