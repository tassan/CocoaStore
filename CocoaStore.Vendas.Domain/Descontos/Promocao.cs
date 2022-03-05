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
}