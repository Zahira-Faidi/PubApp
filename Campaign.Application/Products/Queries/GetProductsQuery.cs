using Campaign.Application.Products.Models;
using MediatR;

namespace Campaign.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<List<Product>>
    {
    }
}
