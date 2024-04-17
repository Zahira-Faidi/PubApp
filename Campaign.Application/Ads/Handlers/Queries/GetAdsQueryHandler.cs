using AutoMapper;
using Campaign.Application.Ads.Models;
using Campaign.Application.Ads.Queries;
using Campaign.Domain.Ads.Repositories;
using MediatR;

namespace Campaign.Application.Ads.Handlers.Queries
{
    public class GetAdsQueryHandler : IRequestHandler<GetAdsQuery, List<Ad>>
    {
        private readonly IAdsRepository _adsRepository;
        private readonly IMapper _mapper;

        public GetAdsQueryHandler(IAdsRepository adsRepository, IMapper mapper)
        {
            _adsRepository = adsRepository;
            _mapper = mapper;
        }

        public async Task<List<Ad>> Handle(GetAdsQuery request, CancellationToken cancellationToken)
        {
            var resultData = await _adsRepository.GetAll(cancellationToken);
            var ads = _mapper.Map<List<Ad>>(resultData);
            return ads;
        }
    }
}
