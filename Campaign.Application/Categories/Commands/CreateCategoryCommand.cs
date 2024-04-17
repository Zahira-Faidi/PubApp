using Campaign.Application.Categories.Models;
using MediatR;

namespace Campaign.Application.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public string? Name { get; set; }
    }
}
