using Campaign.Domain.Budgets.Entities;
using Campaign.Domain.Campaign.Entities;

namespace Campaign.Application.Budgets.Models
{
    public class Budget
    {
        public string? Id { get; set; }
        public double TotalBudget { get; set; }
        public double DailyBudget { get; set; }
        public List<CampaignEntity>? Campaigns { get; set; }

    }
}
