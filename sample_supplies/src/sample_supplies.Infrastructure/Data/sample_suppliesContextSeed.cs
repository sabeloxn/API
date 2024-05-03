namespace sample_supplies.Infrastructure.Data
{
    using sample_supplies.Core.Entities;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Data.Common;

    public class sample_suppliesContextSeed

    {
        public static void SeedData(IMongoDatabase database)
        {
            InsertSales(database.GetCollection<sales>(nameof(sales)));
        }

        private static void InsertSales(IMongoCollection<sales> salesCollection)
        {
            //salesCollection.DeleteMany(_ => true);
            salesCollection.InsertMany(
                new List<sales>
                {
                    new sales 
                    { 
                        saleDate = DateTime.Now,
                        items = new  items[]
                        {
                            new items
                            {
                                name = "printer paper",
                            }
                        }
                    }
                });
        }
    }
}
