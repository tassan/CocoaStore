using CocoaStore.Vendas.Domain.Core.Entidades;

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
    public decimal Preco { get; set; }

}