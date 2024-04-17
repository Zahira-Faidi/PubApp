using Campaign.Application.Ads.Models;
using MediatR;

namespace Campaign.Application.Ads.Commands
{
    public class UpdateAdCommand : IRequest<bool>
    {
        public string? Id { get; set; }
        public string? Content { get; set; }
        public double AllocatedBudget { get; set; }
        public string? CampaignId { get; set; }

    }
}
