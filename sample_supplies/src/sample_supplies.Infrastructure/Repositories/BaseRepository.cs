namespace sample_supplies.Infrastructure.Repositories
{
    using sample_supplies.Core.Entities;
    using sample_supplies.Core.Repositories;
    using sample_supplies.Infrastructure.Data;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> collection;

        public BaseRepository(Isample_suppliesContext sample_suppliesContext)
        {
            if (sample_suppliesContext == null)
            {
                throw new ArgumentNullException(nameof(sample_suppliesContext));
            }

            this.collection = sample_suppliesContext.GetCollection<T>(typeof(T).Name);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq(_ => _.Id, id);

            return await this.collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> InsertAsync(T entity)
        {
            await this.collection.InsertOneAsync(entity);

            return entity;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var result = await this.collection.DeleteOneAsync(Builders<T>.Filter.Eq(_ => _.Id, id));

            return result.DeletedCount > 0;
        }

    }
}
