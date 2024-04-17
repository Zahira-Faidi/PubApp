using Campaign.Domain.Products.Entities;
using Campaign.Domain.Products.Repositories;
using Campaign.Infrastructure.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Campaign.Infrastructure.Repositories
{
    public class ProductService : IProductRepository
    {
        private readonly IMongoCollection<ProductEntity> _productsCollection;
        private readonly IOptions<DataBaseSettings> _dbSettings;

        public ProductService(IOptions<DataBaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(_dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_dbSettings.Value.DatabaseName);
            _productsCollection = mongoDatabase.GetCollection<ProductEntity>(_dbSettings.Value.ProductsCollectionName);
        }
        // add new product
        public async Task<ProductEntity> CreateProduct(ProductEntity product, CancellationToken cancellationToken)
        {
            await _productsCollection.InsertOneAsync(product);
            return product;
        }
        // Delete product 
        public async Task<bool> DeleteProduct(string id, CancellationToken cancellationToken)
        {
            var result = await _productsCollection.DeleteOneAsync(p => p.Id == id, cancellationToken);
            return result.DeletedCount > 0;
        }
        // Get All product 
        public async Task<List<ProductEntity>> GetAll(CancellationToken cancellationToken)
        {
            var products = await _productsCollection.Find(_ => true).ToListAsync(cancellationToken);
            return products;
        }
        // Get product By Id
        public async Task<ProductEntity> GetById(string id, CancellationToken cancellationToken)
        {
            var product = await _productsCollection.Find(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
            return product;
        }
        // update product 
        public async Task<bool> UpdateProduct(ProductEntity existingProduct, CancellationToken cancellationToken)
        {
            var result = await _productsCollection.ReplaceOneAsync(p => p.Id == existingProduct.Id, existingProduct, cancellationToken: cancellationToken);
            return result.ModifiedCount > 0;
        }
    }
}
