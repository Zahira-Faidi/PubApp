using Campaign.Domain.Products.Entities;
namespace Campaign.Domain.Products.Repositories
{
    public interface IProductRepository
    {
        Task<ProductEntity> CreateProduct(ProductEntity product, CancellationToken cancellationToken);
        Task<List<ProductEntity>> GetAll(CancellationToken cancellationToken);
        Task<ProductEntity> GetById(string id, CancellationToken cancellationToken);
        Task<bool> DeleteProduct(string id, CancellationToken cancellationToken);
        Task<bool> UpdateProduct(ProductEntity existingProduct, CancellationToken cancellationToken);
    }
}
