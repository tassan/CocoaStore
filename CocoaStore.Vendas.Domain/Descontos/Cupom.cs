using CocoaStore.Vendas.Domain.Core.Entidades;
using CocoaStore.Vendas.Domain.Estoque;

namespace CocoaStore.Vendas.Domain.Descontos;

public class Cupom : Entidade
{
    public string Codigo { get; set; }
    public double Desconto { get; set; }
    public List<Produto> ProdutosLiberados { get; set; }
    public List<Produto> ProdutosBloqueados { get; set; }

    public Cupom(string codigo, double desconto)
    {
        Codigo = codigo;
        Desconto = desconto;
        ProdutosLiberados = new List<Produto>();
        ProdutosBloqueados = new List<Produto>();
    }

    public void AdicionarProdutoLiberado(Produto produto) => ProdutosLiberados.Add(produto);
    public void AdicionarProdutoBloqueado(Produto produto) => ProdutosBloqueados.Add(produto);
    public void RemoverProdutoLiberado(Produto produto) => ProdutosLiberados.Remove(produto);
    public void RemoverProdutoBloqueado(Produto produto) => ProdutosBloqueados.Remove(produto);
    public bool EhProdutoLiberado(Produto produto) => ProdutosLiberados.Contains(produto);
    public bool EhProdutoBloqueado(Produto produto) => ProdutosBloqueados.Contains(produto);
}