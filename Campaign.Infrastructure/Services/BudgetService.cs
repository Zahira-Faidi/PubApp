using Campaign.Domain.Budgets.Entities;
using Campaign.Domain.Budgets.Repositories;
using Campaign.Infrastructure.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Campaign.Infrastructure.Repositories
{
    public class BudgetService : IBudgetRepository
    {
        private readonly IMongoCollection<BudgetEntity> _budgetsCollection;
        private readonly IOptions<DataBaseSettings> _dbSettings;

        public BudgetService(IOptions<DataBaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(_dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_dbSettings.Value.DatabaseName);
            _budgetsCollection = mongoDatabase.GetCollection<BudgetEntity>(_dbSettings.Value.BudgetsCollectionName);
        }

        public async Task<BudgetEntity> CreateBudget(BudgetEntity budget, CancellationToken cancellationToken)
        {
            await _budgetsCollection.InsertOneAsync(budget, cancellationToken: cancellationToken);
            return budget;
        }

        public async Task<bool> DeleteBudget(string id, CancellationToken cancellationToken)
        {
            var result = await _budgetsCollection.DeleteOneAsync(b => b.Id == id, cancellationToken);
            return result.DeletedCount > 0;
        }

        public async Task<List<BudgetEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _budgetsCollection.Find(b => true).ToListAsync(cancellationToken);
        }

        public async Task<BudgetEntity> GetById(string id, CancellationToken cancellationToken)
        {
            return await _budgetsCollection.Find(b => b.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> UpdateBudget(BudgetEntity existingBudget, CancellationToken cancellationToken)
        {
            var result = await _budgetsCollection.ReplaceOneAsync(b => b.Id == existingBudget.Id, existingBudget, cancellationToken: cancellationToken);
            return result.ModifiedCount > 0;
        }
    }
}
