using Campaign.Domain.Ads.Entities;

namespace Campaign.Application.Ads.Models
{
    public class Ad
    {
        public string? Id { get; set; }
        public string? Content { get; set; }
        public double AllocatedBudget { get; set; }
        public string? CampaignId { get; set; }

    }
}
