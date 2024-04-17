using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Campaign.Domain.Promotions.Entities;

namespace Campaign.Domain.Products.Entities
{
    public class ProductEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        //_____________________________________
        // Reference to CategoryEntity
        public string? CategoryId { get; set; }

        // Reference to PromotionEntity
        public List<PromotionEntity>? Promotions { get; set; }
    }
}
