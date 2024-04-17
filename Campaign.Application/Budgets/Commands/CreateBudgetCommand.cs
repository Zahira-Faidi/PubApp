using Campaign.Application.Budgets.Models;
using Campaign.Domain.Campaign.Entities;
using MediatR;

namespace Campaign.Application.Budgets.Commands
{
    public class CreateBudgetCommand : IRequest<Budget>
    {
        public double TotalBudget { get; set; }
        public double DailyBudget { get; set; }
        public List<CampaignEntity>? Campaigns { get; set; }
    }
}
