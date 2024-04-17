using MediatR;

namespace Campaign.Application.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
