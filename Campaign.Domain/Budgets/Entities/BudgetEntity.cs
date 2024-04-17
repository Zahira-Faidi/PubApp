using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Campaign.Domain.Campaign.Entities;

namespace Campaign.Domain.Budgets.Entities
{
    public class BudgetEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public double TotalBudget { get; set; }
        public double DailyBudget { get; set; }
        // Reference to CampaignEntity
       public List<CampaignEntity>? Campaigns { get; set; }
    }
}
