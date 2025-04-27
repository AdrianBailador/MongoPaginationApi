using MongoDB.Driver;
using MongoPaginationApi.Models;

namespace MongoPaginationApi.Services;

public class ProductService
{
    private readonly IMongoCollection<Product> _collection;

    public ProductService(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
        _collection = database.GetCollection<Product>(configuration["MongoDB:CollectionName"]);
    }

    public async Task<(List<Product>, int totalItems)> GetProductsAsync(string? category, int page, int pageSize)
    {
        var filter = string.IsNullOrEmpty(category)
            ? Builders<Product>.Filter.Empty
            : Builders<Product>.Filter.Eq(p => p.Category, category);

        var totalItems = (int)await _collection.CountDocumentsAsync(filter);

        var products = await _collection.Find(filter)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        return (products, totalItems);
    }
}
