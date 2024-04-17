using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Campaign.Domain.Category.Entities
{
    public class CategoryEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
