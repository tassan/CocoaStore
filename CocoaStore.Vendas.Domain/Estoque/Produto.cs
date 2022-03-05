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
    }

    public Produto() { }
    
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public Oferta Oferta { get; set; }

    public override string ToString() => $"\n ({Codigo}) {Nome} Preço: {Preco} Desc.: {Descricao}";
}