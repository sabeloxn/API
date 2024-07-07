namespace sample_supplies.Infrastructure.Repositories
{
    using sample_supplies.Core.Entities;
    using sample_supplies.Core.Repositories;
    using sample_supplies.Infrastructure.Data;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class SaleRepository : BaseRepository<sales>, ISaleRepository
    {
        private readonly IMongoCollection<sales> collection;
        public SaleRepository(Isample_suppliesContext sample_suppliesContext) : base(sample_suppliesContext)
        {
            if (sample_suppliesContext == null)
            {
                throw new ArgumentNullException(nameof(sample_suppliesContext));
            }

            this.collection = sample_suppliesContext.GetCollection<sales>(typeof(sales).Name);
        }
    }
}