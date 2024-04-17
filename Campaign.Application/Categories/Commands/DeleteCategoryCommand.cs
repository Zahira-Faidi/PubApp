using MediatR;

namespace Campaign.Application.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public DeleteCategoryCommand(string id)
        {
            Id = id;
        }
    }
}
