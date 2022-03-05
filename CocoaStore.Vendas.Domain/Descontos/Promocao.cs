using CocoaStore.Vendas.Domain.Core.Entidades;
using CocoaStore.Vendas.Domain.Core.Types;
using CocoaStore.Vendas.Domain.Estoque;

namespace CocoaStore.Vendas.Domain.Descontos;

public class Promocao : Entidade
{
    public string Nome { get; set; }
    public TipoPromocao TipoPromocao { get; set; }
    public decimal ValorMinimoCarrinho { get; set; }
    public List<Produto> Produtos { get; set; }

    public Promocao()
    {
        Produtos = new List<Produto>();
    }

    public Promocao(string nome, TipoPromocao tipo, decimal valorMinCarrinho, List<Produto> produtos)
    {
        Nome = nome;
        TipoPromocao = tipo;
        ValorMinimoCarrinho = valorMinCarrinho;
        Produtos = produtos;
    }

    public Promocao(string nome, TipoPromocao tipo, decimal valorMinCarrinho)
    {
        Nome = nome;
        TipoPromocao = tipo;
        ValorMinimoCarrinho = valorMinCarrinho;
        Produtos = new List<Produto>();
    }

    public void AdicionarProduto(Produto produto) => Produtos.Add(produto);

    public override string ToString() => $"{Nome} Tipo: {TipoPromocao} Valor Min.: {ValorMinimoCarrinho} Produtos: \n {string.Join(',', Produtos)}";

    public void RemoverProduto(Produto produto) => Produtos.Remove(produto);
}