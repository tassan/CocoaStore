using CocoaStore.Vendas.Domain.Core.Entidades;

namespace CocoaStore.Vendas.Domain.CarrinhoDeCompras;

public class Carrinho : Entidade
{
    public List<Item> Items { get; set; }
    public decimal PrecoTotal => Items.Sum(i => i.PrecoTotal);

    public Carrinho()
    {
        Items = new List<Item>();
    }

    public bool ItemNoCarrinho(Item item) => Items.Contains(item); 

    public void AdicionarItem(Item item)
    {
        if (ItemNoCarrinho(item))
        {
            var itemExistente = Items.Find(i => i.CodigoProduto == item.CodigoProduto);
            itemExistente?.Adicionar();
            return;
        }
        
        Items.Add(item);
    }

    public override string ToString() => $"Id: {Id} Total: {PrecoTotal:C} Qtd. Items: {Items.Sum(i => i.Quantidade)} Items: \n{string.Join(',', Items)}";

    public void RemoverItem(Item item) => Items.Remove(item);

    public void RemoverItem(string codigoProduto) => Items.RemoveAll(i => i.CodigoProduto == codigoProduto);

    public void AdicionarItem(List<Item> items)
    {
        Items.AddRange(items);
    }
}