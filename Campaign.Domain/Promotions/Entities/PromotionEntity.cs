using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Campaign.Domain.Products.Entities;
namespace Campaign.Domain.Promotions.Entities
{
    public class PromotionEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Description { get; set; }
        public double Discount { get; set; }
        //__________________________________________
        // Reference to ProductEntity
        public List<ProductEntity>? Products { get; set; }
    }
}
