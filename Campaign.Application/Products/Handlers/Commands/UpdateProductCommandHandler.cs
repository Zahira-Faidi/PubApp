using Campaign.Application.Products.Commands;
using Campaign.Domain.Products.Repositories;
using MediatR;

namespace Campaign.Application.Products.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand , bool>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingProduct = await _productRepository.GetById(request.Id, cancellationToken);

                if (existingProduct == null)
                {
                    throw new Exception($"Product with id {request.Id} not found");
                }

                // Update existingProduct properties based on request
                existingProduct.Name = request.Name;
                existingProduct.Description = request.Description;
                existingProduct.Image = request.Image;
                existingProduct.Price = request.Price;
                existingProduct.Quantity = request.Quantity;
                existingProduct.CategoryId = request.CategoryId;
                var result = await _productRepository.UpdateProduct(existingProduct, cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update product: {ex.Message}", ex);
            }
        }
    }
    }