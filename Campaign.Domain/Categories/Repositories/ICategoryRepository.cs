using Campaign.Domain.Category.Entities;

namespace Campaign.Domain.Category.Repositories
{
    public interface ICategoryRepository
    {
        Task<CategoryEntity> CreateCategory(CategoryEntity category, CancellationToken cancellationToken);
        Task<List<CategoryEntity>> GetAll(CancellationToken cancellationToken);
        Task<CategoryEntity> GetById(string id, CancellationToken cancellationToken);
        Task<bool> DeleteCategory(string id, CancellationToken cancellationToken);
        Task<bool> UpdateCategory(CategoryEntity existingCategory, CancellationToken cancellationToken);
    }
}
