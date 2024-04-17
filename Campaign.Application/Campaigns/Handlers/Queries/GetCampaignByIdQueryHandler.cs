using AutoMapper;
using Campaign.Application.Campaigns.Models;
using Campaign.Application.Campaigns.Queries;
using Campaign.Domain.Campaign.Repositories;
using MediatR;

namespace Campaign.Application.Campaigns.Handlers.Queries
{
    public class GetCampaignByIdQueryHandler : IRequestHandler<GetCampaignByIdQuery, CampaignBase>
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;

        public GetCampaignByIdQueryHandler(ICampaignRepository campaignRepository, IMapper mapper)
        {
            _campaignRepository = campaignRepository;
            _mapper = mapper;
        }

        public async Task<CampaignBase> Handle(GetCampaignByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _campaignRepository.GetById(request.Id, cancellationToken);

            // Use AutoMapper to map CampaignEntity to CampaignBase directly
            var campaign = _mapper.Map<CampaignBase>(result);

            return campaign;
        }
    }
}
