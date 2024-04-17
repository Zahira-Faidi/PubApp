using Campaign.Domain.Promotions.Entities;

namespace Campaign.Domain.Promotions.Repositories
{
    public interface IPromotionRepository
    {
        Task<PromotionEntity> CreatePromotion(PromotionEntity promotion, CancellationToken cancellationToken);
        Task<List<PromotionEntity>> GetAll(CancellationToken cancellationToken);
        Task<PromotionEntity> GetById(string id, CancellationToken cancellationToken);
        Task<bool> DeletePromotion(string id, CancellationToken cancellationToken);
        Task<bool> UpdatePromotion(PromotionEntity existingPromotion, CancellationToken cancellationToken);
    }
}
