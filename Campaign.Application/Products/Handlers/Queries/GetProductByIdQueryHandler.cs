using AutoMapper;
using Campaign.Application.Products.Models;
using Campaign.Application.Products.Queries;
using Campaign.Domain.Products.Repositories;
using MediatR;

namespace Campaign.Application.Products.Handlers.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var productEntity = await _productRepository.GetById(request.Id, cancellationToken);
            return _mapper.Map<Product>(productEntity);
        }
    }
}
