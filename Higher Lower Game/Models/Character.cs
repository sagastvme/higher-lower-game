using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Character
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public double Views { get; set; }
}

