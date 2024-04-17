using Campaign.Domain.Ads.Entities;
using Campaign.Domain.Campaign.Entities;
using Campaign.Domain.Enums;

namespace Campaign.Application.Campaigns.Models
{
    public class CampaignBase
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Budget { get; set; }
        public Status Status { get; set; }
        public List<AdsEntity>? Ads { get; set; }
        public string? BudgetId { get; set; }

    }
}
