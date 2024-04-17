using Campaign.Domain.Campaign.Entities;
namespace Campaign.Domain.Campaign.Repositories
{
    public interface ICampaignRepository
    {
        Task<CampaignEntity> CreateCampaign(CampaignEntity campaign, CancellationToken cancellationToken);
        Task<List<CampaignEntity>> GetAll(CancellationToken cancellationToken);
        Task<CampaignEntity> GetById(string id, CancellationToken cancellationToken);
        Task<bool> DeleteCampaign(string id, CancellationToken cancellationToken);
        Task<bool> UpdateCampaign(CampaignEntity existingCampaign, CancellationToken cancellationToken);
    }
}
