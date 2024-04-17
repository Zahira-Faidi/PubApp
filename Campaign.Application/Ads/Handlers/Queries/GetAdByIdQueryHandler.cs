using AutoMapper;
using Campaign.Application.Ads.Models;
using Campaign.Application.Ads.Queries;
using Campaign.Domain.Ads.Repositories;
using MediatR;

namespace Campaign.Application.Ads.Handlers.Queries
{
    public class GetAdByIdQueryHandler : IRequestHandler<GetAdByIdQuery, Ad>
    {
        private readonly IAdsRepository _adsRepository;
        private readonly IMapper _mapper;

        public GetAdByIdQueryHandler(IAdsRepository adsRepository, IMapper mapper)
        {
            _adsRepository = adsRepository;
            _mapper = mapper;
        }

        public async Task<Ad> Handle(GetAdByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _adsRepository.GetById(request.Id, cancellationToken);
            var ad = _mapper.Map<Ad>(result);
            return ad;
        }
    }
}
