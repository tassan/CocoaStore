using Bogus;
using CocoaStore.Vendas.Domain.Estoque;
using CocoaStore.Vendas.Unit.Tests.Fixtures;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CocoaStore.Vendas.Unit.Tests;

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
}