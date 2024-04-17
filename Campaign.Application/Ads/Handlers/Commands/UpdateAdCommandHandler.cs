using AutoMapper;
using Campaign.Application.Ads.Commands;
using Campaign.Domain.Ads.Repositories;
using MediatR;

namespace Campaign.Application.Ads.Handlers.Commands
{
    public class UpdateAdCommandHandler : IRequestHandler<UpdateAdCommand, bool>
    {
        private readonly IAdsRepository _adsRepository;
        private readonly IMapper _mapper;

        public UpdateAdCommandHandler(IAdsRepository adsRepository, IMapper mapper)
        {
            _adsRepository = adsRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateAdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingAd = await _adsRepository.GetById(request.Id, cancellationToken);

                // Validation

                if (existingAd == null)
                {
                    throw new Exception($"Ad with id {request.Id} not found");
                }

                existingAd.Content = request.Content;
                existingAd.AllocatedBudget = request.AllocatedBudget;
                existingAd.CampaignId = request.CampaignId;
                // Continue updating other properties as needed

                var result = await _adsRepository.UpdateAd(existingAd, cancellationToken);

                // Return the result
                return result;
            }
            catch (Exception ex)
            {
                // Handle any exceptions and rethrow with a custom message
                throw new Exception($"Failed to update ad: {ex.Message}", ex);
            }
        }
    }
}
