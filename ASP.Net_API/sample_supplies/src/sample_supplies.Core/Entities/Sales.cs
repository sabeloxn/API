using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace sample_supplies.Core.Entities
{
    public class sales : BaseEntity
    {
        [BsonIgnoreIfNull]
        public DateTime? saleDate {get; set;}
        [BsonIgnoreIfNull]
        public items[] items {get; set;}
        [BsonIgnoreIfNull]
        public string? storeLocation {get; set;}
        [BsonIgnoreIfNull]
        public customer customer {get; set;}
        [BsonIgnoreIfNull]
        public bool? couponUsed {get; set;}
        [BsonIgnoreIfNull]
        public string? purchaseMethod {get; set;}
    }

    public class items : BaseEntity
    {
        [BsonIgnoreIfNull]
        public string? name {get; set;}
        [BsonIgnoreIfNull]
        public string[] tags {get; set;}
        [BsonIgnoreIfNull]
        public decimal? price {get; set;}
        [BsonIgnoreIfNull]
        public int? quantity {get; set;}
    }

    public class customer : BaseEntity
    {
        [BsonIgnoreIfNull]
        public string? gender {get; set;}
        [BsonIgnoreIfNull]
        public int? age {get; set;}
        [BsonIgnoreIfNull]
        public string? email {get; set;}
        [BsonIgnoreIfNull]
        public int? satisfaction {get; set;}
    }
    
}