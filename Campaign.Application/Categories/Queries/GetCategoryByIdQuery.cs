using Campaign.Application.Categories.Models;
using MediatR;

namespace Campaign.Application.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public string Id { get; set; }
        public GetCategoryByIdQuery(string id) 
        {
            Id = id;
        }
    }
}
