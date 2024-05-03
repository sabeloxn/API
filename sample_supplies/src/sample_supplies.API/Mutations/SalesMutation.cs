namespace sample_supplies.API.Mutations
{
    using sample_supplies.Core.Entities;
    using sample_supplies.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Subscriptions;
    using HotChocolate.Types;
    using MongoDB.Driver;
    using System.Threading.Tasks;
    using System;
    using MongoDB.Bson;

    [ExtendObjectType(Name = "Mutation")]
    public class SaleMutation
    {
    }
}
