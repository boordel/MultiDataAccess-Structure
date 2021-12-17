using DataStructure1.Core.Models;
using DataStructure1.Infra.DataAccess;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DataStructure1.Infra.MongoDB.DataAccess;

public class MongoDataAccess: IDataAccess
{
    private readonly IConfiguration _config;

    public MongoDataAccess(IConfiguration config)
    {
        _config = config;
    }

    private IMongoCollection<T> GetCollection<T>(string collectionName,
                                                 string mongoDatabase = "MongoDatabase",
                                                 string connectionId = "MongoUri")
    {
        var client = new MongoClient(_config.GetConnectionString(connectionId));
        var database = client.GetDatabase(_config.GetConnectionString(mongoDatabase));
        return database.GetCollection<T>(collectionName);
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string collectionName,
                                               U filter,
                                               string connectionId = "MongoUri")
    {
        var collection = GetCollection<T>(collectionName);
        var result = filter is FilterDefinition<T> ?
            await collection.FindAsync((filter as FilterDefinition<T>)) :
            await collection.FindAsync(_ => true);
        return result.ToEnumerable();
    }

    public async Task SaveData<T>(string collectionName, 
                                  T data, 
                                  DataChangeType changeType = DataChangeType.Command,
                                  string connectionId = "MongoUri")
    {
        var collection = GetCollection<T>(collectionName);
        switch (changeType)
        {
            case DataChangeType.Insert:
                // Generate new id
                var lastRedord = await collection.Find(_ => true)
                    .SortByDescending(d => (d as BaseModel)!.Id).Limit(1).FirstOrDefaultAsync();
                (data as BaseModel)!.Id = lastRedord != null ? (lastRedord as BaseModel)!.Id + 1 : 1;

                await collection.InsertOneAsync(data);
                break;
            case DataChangeType.Update:
            case DataChangeType.Delete:
                int id = (data as BaseModel)!.Id;
                var filter = Builders<T>.Filter.Eq("Id", id);
                if (changeType == DataChangeType.Update)
                    await collection.ReplaceOneAsync(filter, data, new ReplaceOptions { IsUpsert = true });
                else
                    await collection.DeleteOneAsync(filter);
                break;
        }
    }
}
