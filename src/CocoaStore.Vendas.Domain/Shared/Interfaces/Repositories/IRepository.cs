namespace CocoaStore.Vendas.Domain.Shared.Interfaces.Repositories;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    void Add(TEntity entity);
    Task<TEntity> GetById(Guid id);
    Task<IEnumerable<TEntity>> GetAll();
    void Update(TEntity entity);
    void Delete(Guid id);
}