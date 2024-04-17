using AutoMapper;
using Campaign.Application.Campaigns.Models;
using Campaign.Application.Campaigns.Queries;
using Campaign.Domain.Campaign.Repositories;
using MediatR;

namespace Campaign.Application.Campaigns.Handlers.Queries
{
    public class GetCampaignsQueryHandler : IRequestHandler<GetCampaignsQuery, List<CampaignBase>>
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;

        public GetCampaignsQueryHandler(ICampaignRepository campaignRepository, IMapper mapper)
        {
            _campaignRepository = campaignRepository;
            _mapper = mapper;
        }

        public async Task<List<CampaignBase>> Handle(GetCampaignsQuery request, CancellationToken cancellationToken)
        {
            var resultData = await _campaignRepository.GetAll(cancellationToken);

            // Use AutoMapper to map CampaignEntity to CampaignBase directly
            var campaigns = _mapper.Map<List<CampaignBase>>(resultData);

            return campaigns;
        }
    }
}
