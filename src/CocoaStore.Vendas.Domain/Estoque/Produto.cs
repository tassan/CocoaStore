using CocoaStore.Vendas.Domain.Core.Entidades;
using CocoaStore.Vendas.Domain.Descontos;

namespace CocoaStore.Vendas.Domain.Estoque;

public class Produto : Entidade
{
    public Produto(string codigo, string nome, decimal preco)
    {
        Codigo = codigo;
        Nome = nome;
        Preco = preco;
        Descricao = "";
    }

    public Produto() { }
    
    public string Codigo { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public decimal Preco { get; set; }

    public override string ToString() => $"\n ({Codigo}) {Nome} Preço: {Preco} Desc.: {Descricao}";
}