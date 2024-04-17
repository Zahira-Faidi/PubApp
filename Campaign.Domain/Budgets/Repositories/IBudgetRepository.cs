using Campaign.Domain.Budgets.Entities;

namespace Campaign.Domain.Budgets.Repositories
{
    public interface IBudgetRepository
    {
        Task<BudgetEntity> CreateBudget(BudgetEntity budget, CancellationToken cancellationToken);
        Task<List<BudgetEntity>> GetAll(CancellationToken cancellationToken);
        Task<BudgetEntity> GetById(string id, CancellationToken cancellationToken);
        Task<bool> DeleteBudget(string id, CancellationToken cancellationToken);
        Task<bool> UpdateBudget(BudgetEntity existingBudget, CancellationToken cancellationToken);
    }
}
