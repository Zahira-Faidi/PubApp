using AutoMapper;
using Campaign.Application.Campaigns.Commands;
using Campaign.Domain.Campaign.Repositories;
using MediatR;

namespace Campaign.Application.Campaigns.Handlers.Commands
{
    public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, bool>
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;

        public UpdateCampaignCommandHandler(ICampaignRepository campaignRepository, IMapper mapper)
        {
            _campaignRepository = campaignRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingCampaign = await _campaignRepository.GetById(request.Id, cancellationToken);

                // Validation
                if (existingCampaign == null)
                {
                    throw new Exception($"Campaign with id {request.Id} not found");
                }


                // Update the campaign properties
                // You can directly access the newly mapped properties
                existingCampaign.Name = request.Name;
                existingCampaign.Description = request.Description;
                existingCampaign.StartDate = request.StartDate;
                existingCampaign.EndDate = request.EndDate;
                existingCampaign.Budget = request.Budget;
                existingCampaign.Status = request.Status;
                existingCampaign.Ads = request.Ads;
                existingCampaign.BudgetId = request.BudgetId;
                // Update other campaign properties as needed

                var result = await _campaignRepository.UpdateCampaign(existingCampaign, cancellationToken);

                // Return the result
                return result;
            }
            catch (Exception ex)
            {
                // Handle any exceptions and rethrow with a custom message
                throw new Exception($"Failed to update campaign: {ex.Message}", ex);
            }
        }
    }
}
