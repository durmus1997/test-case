using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace StoreApi.Models
{

    public class OrderProducts
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("ID")]
        public int OrderProductsID { get; set; }
        [BsonElement("OrderID")]
        public int OrderID { get; set; }
        [BsonElement("ProductID")]
        public int ProductID { get; set; }
        [BsonElement("Price")]
        public decimal Price { get; set; }
    }
}