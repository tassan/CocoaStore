using CocoaStore.Vendas.Domain.Descontos;
using CocoaStore.Vendas.Unit.Tests.Config.Fixtures;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CocoaStore.Vendas.Unit.Tests.Descontos;

public class OfertaUnitTests : IClassFixture<ProdutoFixture>
{
    private readonly ProdutoFixture _fixture;
    private readonly ITestOutputHelper _outputHelper;

    public OfertaUnitTests(ProdutoFixture fixture, ITestOutputHelper outputHelper)
    {
        _fixture = fixture;
        _outputHelper = outputHelper;
    }

    [Fact]
    public void Deve_CriarOferta_De_Porcentagem()
    {
        var oferta = new Oferta(10d);

        oferta.PorcentagemDesconto
            .Should()
            .Be(10d);

        oferta.ValorDesconto
            .Should()
            .Be(0);
    }
    
    [Fact]
    public void Deve_CriarOferta_De_Valor()
    {
        var oferta = new Oferta(10m);

        oferta.ValorDesconto
            .Should()
            .Be(10m);

        oferta.PorcentagemDesconto
            .Should()
            .Be(0);
    }
}