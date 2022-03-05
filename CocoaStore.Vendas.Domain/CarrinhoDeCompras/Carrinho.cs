using CocoaStore.Vendas.Domain.Core.Entidades;

namespace CocoaStore.Vendas.Domain.CarrinhoDeCompras;

public class Carrinho : Entidade
{
    public List<Item> Items { get; set; }
    public decimal PrecoTotal { get; set; }
}