using Campaign.Domain.Ads.Entities;

namespace Campaign.Domain.Ads.Repositories
{
    public interface IAdsRepository
    {
        Task<AdsEntity> CreateAd(AdsEntity ad, CancellationToken cancellationToken);
        Task<List<AdsEntity>> GetAll(CancellationToken cancellationToken);
        Task<AdsEntity> GetById(string id, CancellationToken cancellationToken);
        Task<bool> DeleteAd(string id, CancellationToken cancellationToken);
        Task<bool> UpdateAd(AdsEntity existingAd, CancellationToken cancellationToken);
    }
}
