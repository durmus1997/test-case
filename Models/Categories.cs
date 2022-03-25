using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace StoreApi.Models
{
    public class Categories
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("ID")]
        public int CategoryID { get; set; }
        [BsonElement("ParentID")]
        public int ParentID { get; set; }
    }
}
