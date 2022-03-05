namespace CocoaStore.Vendas.Infra.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<bool> Commit();
}