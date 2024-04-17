using Campaign.Application.Campaigns.Models;
using Campaign.Domain.Ads.Entities;
using Campaign.Domain.Enums;
using MediatR;

namespace Campaign.Application.Campaigns.Commands
{
    public class CreateCampaignCommand : IRequest<CampaignBase>
    {
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
