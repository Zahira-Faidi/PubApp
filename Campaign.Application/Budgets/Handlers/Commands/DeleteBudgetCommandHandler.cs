using Campaign.Application.Budgets.Commands;
using Campaign.Domain.Budgets.Repositories;
using MediatR;

namespace Campaign.Application.Budgets.Handlers.Commands
{
    public class DeleteBudgetCommandHandler : IRequestHandler<DeleteBudgetCommand, bool>
    {
        private readonly IBudgetRepository _budgetRepository;
        public DeleteBudgetCommandHandler(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }
        public async Task<bool> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
        {
            var budgetToDelete = await _budgetRepository.GetById(request.Id, cancellationToken);
            if (budgetToDelete == null)
            {
                throw new Exception($"Budget with ID {request.Id} not found.");
            }

            return await _budgetRepository.DeleteBudget(request.Id, cancellationToken);
        }
    }
}
