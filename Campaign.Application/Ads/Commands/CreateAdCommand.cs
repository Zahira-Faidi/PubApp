using Campaign.Application.Ads.Models;
using MediatR;

namespace Campaign.Application.Ads.Commands
{
    public class CreateAdCommand : IRequest<Ad>
    {
        public string? Content { get; set; }
        public double AllocatedBudget { get; set; }
        public string? CampaignId { get; set; }

    }
}
