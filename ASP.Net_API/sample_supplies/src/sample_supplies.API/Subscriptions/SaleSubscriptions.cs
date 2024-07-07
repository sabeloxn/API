namespace sample_supplies.API.Subscriptions
{
    using sample_supplies.Core.Entities;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Subscription")]
    public class SaleSubscriptions
    {
        [Subscribe]
        [Topic]
        public Task<sales> OnCreateAsync([EventMessage] sales sale) =>
            Task.FromResult(sale);

        [Subscribe]
        [Topic]
        public Task<string> OnRemoveAsync([EventMessage] string saleId) =>
            Task.FromResult(saleId);

        [Subscribe]
        [Topic]
        public Task<string> OnUpdateAsync([EventMessage] string saleId) =>
            Task.FromResult(saleId);
    }
}
