using CocoaStore.Vendas.Domain.Core.Entidades;
using CocoaStore.Vendas.Domain.Shared.Interfaces.Repositories;
using CocoaStore.Vendas.Infra.Interfaces;
using MongoDB.Driver;
using ServiceStack;

namespace CocoaStore.Vendas.Infra.Repository;

public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entidade
{
    protected readonly IMongoContext Context;
    protected readonly IMongoCollection<TEntity> DbSet;

    protected BaseRepository(IMongoContext context)
    {
        Context = context;
        DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
    }

    public virtual void Add(TEntity entity) => Context.AddCommand(async () => await DbSet.InsertOneAsync(entity));

    public virtual async Task<TEntity> GetById(Guid id)
    {
        var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
        return data.FirstOrDefault();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
        return all.ToList();
    }

    public virtual void Update(TEntity entity)
    {
        Context.AddCommand(async () =>
        {
            await DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.GetId()), entity);
        });
    }

    public virtual void Delete(Guid id)
    {
        Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
    }

    public void Dispose() => Context?.Dispose();
}