using Campaign.Application.Ads.Commands;
using Campaign.Domain.Ads.Repositories;
using MediatR;

namespace Campaign.Application.Ads.Handlers.Commands
{
    public class DeleteAdCommandHandler : IRequestHandler<DeleteAdCommand , bool>
    {
        private readonly IAdsRepository _adsRepository;
        
        public DeleteAdCommandHandler(IAdsRepository adsRepository)
        {
            _adsRepository = adsRepository;
        }

        public async Task<bool> Handle(DeleteAdCommand request, CancellationToken cancellationToken)
        {
            var adToDelete = await _adsRepository.GetById(request.Id, cancellationToken);
            if (adToDelete == null)
            {
                throw new Exception($"Ad with ID {request.Id} not found.");
            }

            return await _adsRepository.DeleteAd(request.Id, cancellationToken);
        }
    }
}
