using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonElement("Category")]
    public string Category { get; set; }

    public string Description { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
    public string Discount { get; set; }
}