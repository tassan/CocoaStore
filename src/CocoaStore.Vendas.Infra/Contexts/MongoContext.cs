using CocoaStore.Vendas.Infra.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CocoaStore.Vendas.Infra.Contexts;

public class MongoContext : IMongoContext
{
    private IMongoDatabase Database { get; set; }
    public IClientSessionHandle Session { get; set; }
    public MongoClient MongoClient { get; set; }
    private readonly List<Func<Task>> _commands;
    private readonly IConfiguration _configuration;

#pragma warning disable CS8618
    public MongoContext(IConfiguration configuration)
#pragma warning restore CS8618
    {
        _configuration = configuration;
        _commands = new List<Func<Task>>();
    }

    public void AddCommand(Func<Task> func) => _commands.Add(func);

    public async Task<int> SaveChanges()
    {
        ConfigureMongo();

        using (Session = await MongoClient.StartSessionAsync())
        {
            Session.StartTransaction();

            var commandTasks = _commands.Select(c => c());

            await Task.WhenAll(commandTasks);
            await Session.CommitTransactionAsync();
        }

        return _commands.Count;
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        ConfigureMongo();
        return Database.GetCollection<T>(name);
    }

    private void ConfigureMongo()
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        if (MongoClient is not null) return;
        MongoClient = new MongoClient(_configuration["MongoSettings:Connection"]);
        Database = MongoClient.GetDatabase(_configuration["MongoSettings:DatabaseName"]);
    }

    public void Dispose()
    {
        Session?.Dispose();
        GC.SuppressFinalize(this);
    }
}