using Campaign.Application.Campaigns.Models;
using MediatR;

namespace Campaign.Application.Campaigns.Queries
{
    public class GetCampaignByIdQuery :IRequest<CampaignBase>
    {
        public string Id { get; set; }
        public GetCampaignByIdQuery(string id)
        {
            Id = id;
        }   
    }
}
