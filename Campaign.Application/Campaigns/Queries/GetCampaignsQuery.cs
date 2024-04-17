using Campaign.Application.Campaigns.Models;
using MediatR;

namespace Campaign.Application.Campaigns.Queries
{
    public class GetCampaignsQuery : IRequest<List<CampaignBase>>
    {
    }
}
