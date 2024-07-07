namespace sample_supplies.API.Types
{
    using sample_supplies.API.Resolvers;
    using sample_supplies.Core.Entities;
    using HotChocolate.Types;

    public class SaleType : ObjectType<sales>
    {
        protected override void Configure(IObjectTypeDescriptor<sales> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.storeLocation);
            descriptor.Field(_ => _.couponUsed);
            descriptor.Field(_ => _.purchaseMethod);

            //descriptor.Field<ActivityResolver>(_ => _.GetActivityDrillAsync(default, default));
        }
    }
}
