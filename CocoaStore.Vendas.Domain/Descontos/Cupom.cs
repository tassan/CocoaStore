using CocoaStore.Vendas.Domain.Core.Entidades;

namespace CocoaStore.Vendas.Domain.Descontos;

public class Cupom : Entidade
{
    public string Codigo { get; set; }
    public double Desconto { get; set; }
}