using AutoMapper;
using Campaign.Application.Products.Models;
using Campaign.Application.Products.Queries;
using Campaign.Domain.Products.Repositories;
using MediatR;

namespace Campaign.Application.Products.Handlers.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var resultData = await _productRepository.GetAll(cancellationToken);
            return _mapper.Map<List<Product>>(resultData);
        }
    }
}
