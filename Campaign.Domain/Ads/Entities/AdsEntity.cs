using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Campaign.Domain.Ads.Entities
{
    public class AdsEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Content { get; set; }
        public double AllocatedBudget { get; set; }
        // Reference to CampaignEntity
        public string? CampaignId { get; set; }
    }
}
