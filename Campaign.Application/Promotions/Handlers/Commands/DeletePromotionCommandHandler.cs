using Campaign.Application.Promotions.Commands;
using Campaign.Domain.Promotions.Repositories;
using MediatR;

namespace Campaign.Application.Promotions.Handlers.Commands
{
    public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand, bool>
    {
        private readonly IPromotionRepository _promotionRepository;
        public DeletePromotionCommandHandler(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }
        public async Task<bool> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotionToDelete = await _promotionRepository.GetById(request.Id, cancellationToken);
            if(promotionToDelete == null)
            {
                throw new Exception($"Promotion with ID {request.Id} not found.");

            }
            return await _promotionRepository.DeletePromotion(request.Id , cancellationToken);
        }
    }
}
