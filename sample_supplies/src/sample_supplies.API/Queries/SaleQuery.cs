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
        public Task<IEnumerable<sales>> GetSalesAsync([Service] ISaleRepository saleRepository) =>
            saleRepository.GetAllAsync();

        public Task<sales> GetSaleAsync(string id, [Service] ISaleRepository saleRepository) =>
            saleRepository.GetByIdAsync(id);
    }
}
