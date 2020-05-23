using AcademiaDemo.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace AcademiaDemo.Infrastructure.Repository.Context
{
    public class AcademiaDemoContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public AcademiaDemoContext(IConfiguration configuration)
        {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            var client = new MongoClient(configuration.GetSection("ConnectionString").Value);
            _mongoDatabase = client.GetDatabase(configuration.GetSection("Database").Value);
        }

        public IMongoCollection<Sale> Sale =>
            _mongoDatabase.GetCollection<Sale>(nameof(Sale));
        public IMongoCollection<Payment> Payment =>
            _mongoDatabase.GetCollection<Payment>(nameof(Payment));
        public IMongoCollection<Stock> Stock =>
            _mongoDatabase.GetCollection<Stock>(nameof(Stock));
        public IMongoCollection<Item> Item =>
            _mongoDatabase.GetCollection<Item>(nameof(Item));
    }
}
