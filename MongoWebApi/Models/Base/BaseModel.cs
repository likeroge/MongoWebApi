using MongoDB.Bson.Serialization.Attributes;

namespace MongoWebApi.Models.Base;

public abstract class BaseModel
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
    public DateTime CreatedAt { get; set; }
    
    [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
    public DateTime UpdatedAt { get; set; }
    

    
}