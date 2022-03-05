namespace CocoaStore.Vendas.Domain.Descontos;

public class Oferta
{
    public double PorcentagemDesconto { get; }
    public decimal ValorDesconto { get; }

    public Oferta(double porcentagemDesconto)
    {
        PorcentagemDesconto = porcentagemDesconto;
        ValorDesconto = 0;
    }

    public Oferta(decimal valorDesconto)
    {
        ValorDesconto = valorDesconto;
        PorcentagemDesconto = 0;
    }
}