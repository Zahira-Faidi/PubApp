using Campaign.Domain.Category.Entities;
using Campaign.Domain.Category.Repositories;
using Campaign.Infrastructure.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Campaign.Infrastructure.Repositories
{
    public class CategoryService : ICategoryRepository
    {
        private readonly IMongoCollection<CategoryEntity> _categoriesCollection;
        private readonly IOptions<DataBaseSettings> _dbSettings;

        public CategoryService(IOptions<DataBaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(_dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_dbSettings.Value.DatabaseName);
            _categoriesCollection = mongoDatabase.GetCollection<CategoryEntity>(_dbSettings.Value.CategoriesCollectionName);
        }

        public async Task<CategoryEntity> CreateCategory(CategoryEntity category, CancellationToken cancellationToken)
        {
            await _categoriesCollection.InsertOneAsync(category, cancellationToken: cancellationToken);
            return category;
        }

        public async Task<bool> DeleteCategory(string id, CancellationToken cancellationToken)
        {
            var result = await _categoriesCollection.DeleteOneAsync(c => c.Id == id, cancellationToken);
            return result.DeletedCount > 0;
        }

        public async Task<List<CategoryEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _categoriesCollection.Find(c => true).ToListAsync(cancellationToken);
        }

        public async Task<CategoryEntity> GetById(string id, CancellationToken cancellationToken)
        {
            return await _categoriesCollection.Find(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> UpdateCategory(CategoryEntity existingCategory, CancellationToken cancellationToken)
        {
            var result = await _categoriesCollection.ReplaceOneAsync(c => c.Id == existingCategory.Id, existingCategory, cancellationToken: cancellationToken);
            return result.ModifiedCount > 0;
        }
    }
}
