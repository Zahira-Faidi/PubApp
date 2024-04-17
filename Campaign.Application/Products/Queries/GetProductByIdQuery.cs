using Campaign.Application.Products.Models;
using MediatR;

namespace Campaign.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public string Id { get; }
        public GetProductByIdQuery(string id)
        {
            Id = id;
        }
    }
}
