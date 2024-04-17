using Campaign.Domain.Promotions.Entities;
using Campaign.Domain.Promotions.Repositories;
using Campaign.Infrastructure.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Campaign.Infrastructure.Repositories
{
    public class PromotionService : IPromotionRepository
    {
        private readonly IMongoCollection<PromotionEntity> _promotionsCollection;
        private readonly IOptions<DataBaseSettings> _dbSettings;

        public PromotionService(IOptions<DataBaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(_dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_dbSettings.Value.DatabaseName);
            _promotionsCollection = mongoDatabase.GetCollection<PromotionEntity>(_dbSettings.Value.PromotionsCollectionName);
        }
        // Add new promotions
        public async Task<PromotionEntity> CreatePromotion(PromotionEntity promotion, CancellationToken cancellationToken)
        {
           await _promotionsCollection.InsertOneAsync(promotion, cancellationToken:cancellationToken);
            return promotion;
        }
        // Delete promotion
        public async Task<bool> DeletePromotion(string id, CancellationToken cancellationToken)
        {
            var result = await _promotionsCollection.DeleteOneAsync(c => c.Id == id, cancellationToken);
            return result.DeletedCount > 0;
        }
        // Get All Promotions
        public async Task<List<PromotionEntity>> GetAll(CancellationToken cancellationToken)
        {
            var promotions = await _promotionsCollection.Find(_ => true).ToListAsync(cancellationToken);
            return promotions;
        }

        public async Task<PromotionEntity> GetById(string id, CancellationToken cancellationToken)
        {
            var promotion = await _promotionsCollection.Find(p =>  p.Id == id).FirstOrDefaultAsync(cancellationToken);
            return promotion;
        }

        public async Task<bool> UpdatePromotion(PromotionEntity existingPromotion, CancellationToken cancellationToken)
        {
            var result = await _promotionsCollection.ReplaceOneAsync(c => c.Id == existingPromotion.Id, existingPromotion, cancellationToken: cancellationToken);
            return result.ModifiedCount > 0;
        }
    }
}
