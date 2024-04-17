using Campaign.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Campaign.Domain.Ads.Entities;

namespace Campaign.Domain.Campaign.Entities
{
    public class CampaignEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Budget { get; set; }
        public Status Status { get; set; }
        //_________________________________________
        // Reference to AdsEntity
        public List<AdsEntity>? Ads { get; set; }

        // Reference to BudgetEntity
        public string? BudgetId { get; set; }
    }
}
