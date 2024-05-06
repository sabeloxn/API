namespace sample_supplies.API.Queries
{
    using sample_supplies.Core.Entities;
    using sample_supplies.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Query")]
    public class SaleQuery
    {
        public Task<IEnumerable<sales>> GetSalesAsync(int limit,[Service] ISaleRepository saleRepository) =>
            saleRepository.GetAllAsync(limit);

        public Task<sales> GetSaleAsync(string id, [Service] ISaleRepository saleRepository) =>
            saleRepository.GetByIdAsync(id);
    }
}
