using Campaign.Domain.Campaign.Entities;
using MediatR;

namespace Campaign.Application.Budgets.Commands
{
    public class UpdateBudgetCommand : IRequest<bool>
    {
        public string? Id { get; set; }
        public double TotalBudget { get; set; }
        public double DailyBudget { get; set; }
        public List<CampaignEntity>? Campaigns { get; set; }
    }
}
