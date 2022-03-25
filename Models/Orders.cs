using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
namespace StoreApi.Models
{
    public class Orders
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("ID")]
        public int OrderID { get; set; }
        [BsonElement("CustomerID")]
        public int CustomerID { get; set; }
        [BsonElement("Price")]
        public decimal Price { get; set; }
    }
}