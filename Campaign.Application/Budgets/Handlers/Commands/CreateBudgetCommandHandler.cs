using AutoMapper;
using Campaign.Application.Budgets.Commands;
using Campaign.Application.Budgets.Models;
using Campaign.Domain.Budgets.Entities;
using Campaign.Domain.Budgets.Repositories;
using MediatR;

namespace Campaign.Application.Budgets.Handlers.Commands
{
    public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, Budget>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;

        public CreateBudgetCommandHandler(IBudgetRepository budgetRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
        }

        public async Task<Budget> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
        {
            var budgetEntity = _mapper.Map<BudgetEntity>(request);
            var result = await _budgetRepository.CreateBudget(budgetEntity, cancellationToken);
            var budget = _mapper.Map<Budget>(result);
            return budget;
        }
    }
}
