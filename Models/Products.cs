using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
namespace StoreApi.Models;

public class Products
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("ID")]
    public int ProductID { get; set; }
    [BsonElement("CategoryID")]
    public int CategoryID { get; set; }
}