using Microsoft.Azure.Cosmos;
using M4_04_CosmosDB_WebApp.Models;

namespace M4_04_CosmosDB_WebApp.Services;

public class CosmosService
{
    private readonly Container _container;

    public CosmosService(IConfiguration config)
    {
        var connectionString = config["CosmosDb:ConnectionString"];
        var databaseName = config["CosmosDb:DatabaseName"];
        var containerName = config["CosmosDb:ContainerName"];
        
        var client = new CosmosClient(connectionString);
        _container = client.GetContainer(databaseName, containerName);
    }
    
    public async Task AddSupportMessageAsync(SupportMessage message)
    {
        await _container.CreateItemAsync(message, new PartitionKey(message.category));
    }

    public async Task<List<SupportMessage>> GetAllSupportMessagesAsync()
    {
        var query = _container.GetItemQueryIterator<SupportMessage>("SELECT * FROM c");
        var results = new List<SupportMessage>();

        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response);
        }
        
        return results;
    }
}