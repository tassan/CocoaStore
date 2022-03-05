using CocoaStore.Vendas.Domain.Estoque;

namespace CocoaStore.Vendas.Domain.CarrinhoDeCompras;

public class Item
{
    public string CodigoProduto { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal PrecoTotal => Quantidade * PrecoUnitario;
    public Produto Produto { get; set; }
}