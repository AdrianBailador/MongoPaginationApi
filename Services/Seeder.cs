using MongoDB.Driver;
using MongoPaginationApi.Models;

namespace MongoPaginationApi.Services;

public class Seeder
{
    private readonly IMongoCollection<Product> _collection;

    public Seeder(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
        _collection = database.GetCollection<Product>(configuration["MongoDB:CollectionName"]);
    }

    public async Task SeedAsync()
    {
        var count = await _collection.CountDocumentsAsync(FilterDefinition<Product>.Empty);

        if (count == 0)
        {
            var random = new Random();
            var categories = new[] { "Books", "Electronics", "Clothing", "Toys", "Home", "Garden" };
            var products = new List<Product>();

            for (int i = 1; i <= 100; i++)
            {
                products.Add(new Product
                {
                    Name = $"Product {i}",
                    Category = categories[random.Next(categories.Length)],
                    Price = (decimal)(random.NextDouble() * 100.0 + 1.0)
                });
            }

            await _collection.InsertManyAsync(products);
            Console.WriteLine("Seed completed: 100 products inserted!");
        }
        else
        {
            Console.WriteLine("Database already contains products. No seeding needed.");
        }
    }
}
