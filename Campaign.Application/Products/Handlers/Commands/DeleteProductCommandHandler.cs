using Campaign.Application.Products.Commands;
using Campaign.Domain.Products.Repositories;
using MediatR;

namespace Campaign.Application.Products.Handlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _productRepository.GetById(request.ProductId, cancellationToken);
            if (productToDelete == null) 
            {
                throw new Exception($"Product with ID {request.ProductId} not found.");
            }

            return await _productRepository.DeleteProduct(request.ProductId, cancellationToken);
        }
    }
}
