namespace sample_supplies.Infrastructure.Data
{
    using MongoDB.Driver;

    public interface Isample_suppliesContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}