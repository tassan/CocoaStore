using Bogus;
using CocoaStore.Vendas.Domain.Estoque;
using CocoaStore.Vendas.Unit.Tests.Config.Fixtures;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CocoaStore.Vendas.Unit.Tests.Estoque;

public class ProdutoUnitTests : IClassFixture<ProdutoFixture>
{
    private readonly ProdutoFixture _fixture;
    private readonly ITestOutputHelper _outputHelper;

    public ProdutoUnitTests(ProdutoFixture fixture, ITestOutputHelper outputHelper)
    {
        _fixture = fixture;
        _outputHelper = outputHelper;
    }

    [Fact]
    public void Deve_Criar_ProdutoValido()
    {
        var produto = new Produto("23242526", "Novo Produto", 10m);

        produto.Descricao = new Faker().Commerce.ProductDescription();
        
        produto.Codigo
            .Should()
            .NotBeEmpty();

        produto.Codigo
            .Should()
            .HaveLength(8);

        produto.Nome
            .Should()
            .NotBeEmpty();

        produto.Descricao
            .Should()
            .NotBeEmpty();

        produto.Preco
            .Should()
            .NotBe(0);
        
        _outputHelper.WriteLine("{0}", produto);
    }
    
    [Fact]
    public void Deve_Criar_ProdutoValido_ComBogus()
    {
        var produto = _fixture.GerarProdutoValido();

        produto.Descricao = new Faker().Commerce.ProductDescription();
        
        produto.Codigo
            .Should()
            .NotBeEmpty();

        produto.Codigo
            .Should()
            .HaveLength(8);

        produto.Nome
            .Should()
            .NotBeEmpty();

        produto.Descricao
            .Should()
            .NotBeEmpty();

        produto.Preco
            .Should()
            .NotBe(0);
        
        _outputHelper.WriteLine("{0}", produto);
    }
    
    [Fact]
    public void Deve_Criar_ProdutoInvalido_ComBogus()
    {
        var produto = _fixture.GerarProdutoInvalido();

        produto.Codigo
            .Should()
            .BeEmpty();

        produto.Codigo
            .Should()
            .HaveLength(0);
        
        produto.Descricao
            .Should()
            .BeEmpty();

        produto.Preco
            .Should()
            .Be(0);
        
        _outputHelper.WriteLine("{0}", produto);
    }
}