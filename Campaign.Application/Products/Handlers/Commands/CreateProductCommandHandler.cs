using AutoMapper;
using Campaign.Application.Products.Commands;
using Campaign.Application.Products.Models;
using Campaign.Domain.Products.Entities;
using Campaign.Domain.Products.Repositories;
using MediatR;

namespace Campaign.Application.Products.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductEntity>(request);
            var result = await _productRepository.CreateProduct(product, cancellationToken);
            return _mapper.Map<Product>(result); 
        }
    }
}
