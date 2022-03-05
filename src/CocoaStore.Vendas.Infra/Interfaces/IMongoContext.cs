using MongoDB.Driver;

namespace CocoaStore.Vendas.Infra.Interfaces;

public interface IMongoContext : IDisposable
{
    void AddCommand(Func<Task> func);
    Task<int> SaveChanges();
    IMongoCollection<T> GetCollection<T>(string name);
}