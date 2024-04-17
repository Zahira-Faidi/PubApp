using MediatR;

namespace Campaign.Application.Budgets.Commands
{
    public class DeleteBudgetCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public DeleteBudgetCommand(string id)
        {
            Id = id;
        }
    }
}
