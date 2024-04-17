using Campaign.Application.Campaigns.Commands;
using Campaign.Domain.Campaign.Repositories;
using MediatR;

namespace Campaign.Application.Campaigns.Handlers.Commands
{
    public class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommand, bool>
    {
        private readonly ICampaignRepository _campaignRepository;

        public DeleteCampaignCommandHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<bool> Handle(DeleteCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaignToDelete = await _campaignRepository.GetById(request.Id, cancellationToken);
            if (campaignToDelete == null)
            {
                throw new Exception($"Campaign with ID {request.Id} not found.");
            }

            return await _campaignRepository.DeleteCampaign(request.Id, cancellationToken);
        }
    }
}
