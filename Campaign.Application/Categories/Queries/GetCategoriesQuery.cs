using Campaign.Application.Categories.Models;
using MediatR;

namespace Campaign.Application.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<List<Category>>
    {
    }
}
