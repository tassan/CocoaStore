namespace CocoaStore.Vendas.Domain.Core.Entidades;

public class Entidade
{
    public Guid Id { get; set; }
    public DateTime DataCriacao { get; set; }

    public Entidade()
    {
        Id = Guid.NewGuid();
        DataCriacao = DateTime.UtcNow;
    }
}