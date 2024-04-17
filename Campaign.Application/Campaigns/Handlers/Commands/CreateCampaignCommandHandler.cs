using AutoMapper;
using Campaign.Application.Campaigns.Commands;
using Campaign.Application.Campaigns.Models;
using Campaign.Domain.Campaign.Entities;
using Campaign.Domain.Campaign.Repositories;
using MediatR;

namespace Campaign.Application.Campaigns.Handlers.Commands
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, CampaignBase>
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;

        public CreateCampaignCommandHandler(ICampaignRepository campaignRepository, IMapper mapper)
        {
            _campaignRepository = campaignRepository;
            _mapper = mapper;
        }

        public async Task<CampaignBase> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaignEntity = _mapper.Map<CampaignEntity>(request);

            var result = await _campaignRepository.CreateCampaign(campaignEntity, cancellationToken);

            var campaignBase = _mapper.Map<CampaignBase>(result);

            return campaignBase;
        }
    }
}
