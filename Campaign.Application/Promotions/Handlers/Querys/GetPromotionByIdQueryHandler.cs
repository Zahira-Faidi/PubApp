using AutoMapper;
using Campaign.Application.Promotions.Models;
using Campaign.Application.Promotions.Queries;
using Campaign.Domain.Promotions.Repositories;
using MediatR;

namespace Campaign.Application.Promotions.Handlers.Queries
{
    public class GetPromotionByIdQueryHandler : IRequestHandler<GetPromotionByIdQuery, Promotion>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public GetPromotionByIdQueryHandler(IPromotionRepository promotionRepository, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<Promotion> Handle(GetPromotionByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _promotionRepository.GetById(request.Id, cancellationToken);

            // Use AutoMapper to map PromotionEntity to Promotion directly
            var promotion = _mapper.Map<Promotion>(result);

            return promotion;
        }
    }
}
