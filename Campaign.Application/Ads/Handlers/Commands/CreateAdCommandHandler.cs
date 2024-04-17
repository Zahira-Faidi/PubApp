using AutoMapper;
using Campaign.Application.Ads.Commands;
using Campaign.Application.Ads.Models;
using Campaign.Domain.Ads.Entities;
using Campaign.Domain.Ads.Repositories;
using MediatR;

namespace Campaign.Application.Ads.Handlers.Commands
{
    public class CreateAdCommandHandler : IRequestHandler<CreateAdCommand, Ad>
    {
        private readonly IAdsRepository _adsRepository;
        private readonly IMapper _mapper;

        public CreateAdCommandHandler(IAdsRepository adsRepository, IMapper mapper)
        {
            _adsRepository = adsRepository;
            _mapper = mapper;
        }

        public async Task<Ad> Handle(CreateAdCommand request, CancellationToken cancellationToken)
        {
            var adEntity = _mapper.Map<AdsEntity>(request);
            var result = await _adsRepository.CreateAd(adEntity, cancellationToken);
            return _mapper.Map<Ad>(result);
        }
    }
}
