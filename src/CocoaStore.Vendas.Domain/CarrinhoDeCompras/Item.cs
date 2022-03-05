using CocoaStore.Vendas.Domain.Estoque;

namespace CocoaStore.Vendas.Domain.CarrinhoDeCompras;

public class Item
{
    public string CodigoProduto { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal PrecoTotal => CalcularTotal();

    public Item()
    {
        
    }
    
    public Item(string codigoProduto, string nome, int quantidade, decimal precoUnitario)
    {
        CodigoProduto = codigoProduto;
        Nome = nome;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
    }

    private decimal CalcularTotal()
    {
        return Quantidade * PrecoUnitario;
    }

    public override string ToString() =>
        $"\n({CodigoProduto}) {Nome} Qtd.: {Quantidade} Preço: {PrecoUnitario:C} Total:  {PrecoTotal:C}";

    public void Adicionar()
    {
        Quantidade++;
    }

    public void Remover()
    {
        if (Quantidade == 1) return;
        Quantidade--;
    }
}