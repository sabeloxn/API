namespace sample_supplies.Infrastructure.Data
{
    using sample_supplies.Infrastructure.Configurations;
    using MongoDB.Driver;

    public class sample_suppliesContext : Isample_suppliesContext
    {
        private readonly IMongoDatabase database;

        public sample_suppliesContext(MongoDbConfiguration mongoDbConfiguration)
        {
            var client = new MongoClient(mongoDbConfiguration.ConnectionString);

            this.database = client.GetDatabase(mongoDbConfiguration.Database);

            sample_suppliesContextSeed.SeedData(this.database);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return this.database.GetCollection<T>(name);
        }
    }
}
