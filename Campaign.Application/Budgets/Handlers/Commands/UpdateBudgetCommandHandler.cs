using Campaign.Application.Budgets.Commands;
using Campaign.Domain.Budgets.Repositories;
using MediatR;

namespace Campaign.Application.Budgets.Handlers.Commands
{
    public class UpdateBudgetCommandHandler : IRequestHandler<UpdateBudgetCommand, bool>
    {
        private readonly IBudgetRepository _budgetRepository;

        public UpdateBudgetCommandHandler(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task<bool> Handle(UpdateBudgetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve existing budget from the repository
                var existingBudget = await _budgetRepository.GetById(request.Id, cancellationToken);

                // Validation: Check if the budget exists
                if (existingBudget == null)
                {
                    throw new Exception($"Budget with id {request.Id} not found");
                }

                // Update the budget properties
                existingBudget.TotalBudget = request.TotalBudget;
                existingBudget.DailyBudget = request.DailyBudget;
                existingBudget.Campaigns = request.Campaigns;
                // Continue updating other properties as needed

                // Persist the changes
                var result = await _budgetRepository.UpdateBudget(existingBudget, cancellationToken);

                // Return the result
                return result;
            }
            catch (Exception ex)
            {
                // Handle any exceptions and rethrow with a custom message
                throw new Exception($"Failed to update budget: {ex.Message}", ex);
            }
        }
    }
}
