using AutoMapper;
using Campaign.Application.Promotions.Commands;
using Campaign.Application.Promotions.Models;
using Campaign.Domain.Promotions.Entities;
using Campaign.Domain.Promotions.Repositories;
using MediatR;

namespace Campaign.Application.Promotions.Handlers.Commands
{
    public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand, Promotion>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public CreatePromotionCommandHandler(IPromotionRepository promotionRepository, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<Promotion> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            // Map CreatePromotionCommand to PromotionEntity
            var promotionEntity = _mapper.Map<PromotionEntity>(request);

            // Create the promotion using the mapped entity
            var result = await _promotionRepository.CreatePromotion(promotionEntity, cancellationToken);

            // Map PromotionEntity to Promotion and return
            var promotionModel = _mapper.Map<Promotion>(result);
            return promotionModel;
        }
    }
}
