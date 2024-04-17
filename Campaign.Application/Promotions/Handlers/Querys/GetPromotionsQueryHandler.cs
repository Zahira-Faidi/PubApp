using AutoMapper;
using Campaign.Application.Promotions.Models;
using Campaign.Application.Promotions.Queries;
using Campaign.Domain.Promotions.Repositories;
using MediatR;

namespace Campaign.Application.Promotions.Handlers.Queries
{
    public class GetPromotionsQueryHandler : IRequestHandler<GetPromotionsQuery, List<Promotion>>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public GetPromotionsQueryHandler(IPromotionRepository promotionRepository, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<List<Promotion>> Handle(GetPromotionsQuery request, CancellationToken cancellationToken)
        {
            var resultData = await _promotionRepository.GetAll(cancellationToken);

            // Use AutoMapper to map PromotionEntity to Promotion directly
            var promotions = _mapper.Map<List<Promotion>>(resultData);

            return promotions;
        }
    }
}
