using Campaign.Domain.Campaign.Entities;
using Campaign.Domain.Campaign.Repositories;
using Campaign.Infrastructure.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Campaign.Infrastructure.Repositories
{
    public class CampaignService : ICampaignRepository
    {
        private readonly IMongoCollection<CampaignEntity> _campaignsCollection;
        private readonly IOptions<DataBaseSettings> _dbSettings;

        public CampaignService(IOptions<DataBaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(_dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_dbSettings.Value.DatabaseName);
            _campaignsCollection = mongoDatabase.GetCollection<CampaignEntity>(_dbSettings.Value.CampaignsCollectionName);

        }
        public async Task<CampaignEntity> CreateCampaign(CampaignEntity campaign, CancellationToken cancellationToken)
        {
            await _campaignsCollection.InsertOneAsync(campaign, cancellationToken: cancellationToken);
            return campaign;
        }

        public async Task<bool> DeleteCampaign(string id, CancellationToken cancellationToken)
        {
            var result = await _campaignsCollection.DeleteOneAsync(c => c.Id == id, cancellationToken);
            return result.DeletedCount > 0;
        }

        public async Task<List<CampaignEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _campaignsCollection.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<CampaignEntity> GetById(string id, CancellationToken cancellationToken)
        {
            var campaign= await _campaignsCollection.Find(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
            return campaign;
        }

        public async Task<bool> UpdateCampaign(CampaignEntity existingCampaign, CancellationToken cancellationToken)
        {
            var result = await _campaignsCollection.ReplaceOneAsync(c => c.Id == existingCampaign.Id, existingCampaign, cancellationToken: cancellationToken);
            return result.ModifiedCount > 0;
        }
    }
    }
