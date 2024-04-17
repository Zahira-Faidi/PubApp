using Campaign.Domain.Ads.Entities;
using Campaign.Domain.Ads.Repositories;
using Campaign.Infrastructure.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Campaign.Infrastructure.Repositories
{
    public class AdService : IAdsRepository
    {
        private readonly IMongoCollection<AdsEntity> _adsCollection;
        private readonly IOptions<DataBaseSettings> _dbSettings;

        public AdService(IOptions<DataBaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(_dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_dbSettings.Value.DatabaseName);
            _adsCollection = mongoDatabase.GetCollection<AdsEntity>(_dbSettings.Value.AdsCollectionName);
        }

        public async Task<AdsEntity> CreateAd(AdsEntity ad, CancellationToken cancellationToken)
        {
            await _adsCollection.InsertOneAsync(ad, cancellationToken: cancellationToken);
            return ad;
        }

        public async Task<bool> DeleteAd(string id, CancellationToken cancellationToken)
        {
            var result = await _adsCollection.DeleteOneAsync(a => a.Id == id, cancellationToken);
            return result.DeletedCount > 0;
        }

        public async Task<List<AdsEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _adsCollection.Find(a => true).ToListAsync(cancellationToken);
        }

        public async Task<AdsEntity> GetById(string id, CancellationToken cancellationToken)
        {
            return await _adsCollection.Find(a => a.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> UpdateAd(AdsEntity existingAd, CancellationToken cancellationToken)
        {
            var result = await _adsCollection.ReplaceOneAsync(a => a.Id == existingAd.Id, existingAd, cancellationToken: cancellationToken);
            return result.ModifiedCount > 0;
        }
    }
}
