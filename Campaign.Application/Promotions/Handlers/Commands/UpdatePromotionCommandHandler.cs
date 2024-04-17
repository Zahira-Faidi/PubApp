using Campaign.Application.Promotions.Commands;
using Campaign.Domain.Promotions.Repositories;
using MediatR;

namespace Campaign.Application.Promotions.Handlers.Commands
{
    public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand, bool>
    {
        private readonly IPromotionRepository _promotionRepository;

        public UpdatePromotionCommandHandler(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<bool> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingPromotion = await _promotionRepository.GetById(request.Id, cancellationToken);

                // Validation
                if (existingPromotion == null)
                {
                    throw new Exception($"Promotion with id {request.Id} not found");
                }

                // Update existingPromotion properties based on request
                existingPromotion.Description = request.Description;
                existingPromotion.Discount = request.Discount;

                var result = await _promotionRepository.UpdatePromotion(existingPromotion, cancellationToken);

                // Result 
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update Promotion: {ex.Message}", ex);
            }
        }
    }
}
