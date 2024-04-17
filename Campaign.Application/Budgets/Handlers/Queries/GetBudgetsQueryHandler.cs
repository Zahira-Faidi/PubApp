using AutoMapper;
using Campaign.Application.Budgets.Models;
using Campaign.Application.Budgets.Queries;
using Campaign.Domain.Budgets.Repositories;
using MediatR;

namespace Campaign.Application.Budgets.Handlers.Queries
{
    public class GetBudgetsQueryHandler : IRequestHandler<GetBudgetsQuery, List<Budget>>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;

        public GetBudgetsQueryHandler(IBudgetRepository budgetRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository ?? throw new ArgumentNullException(nameof(budgetRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<Budget>> Handle(GetBudgetsQuery request, CancellationToken cancellationToken)
        {
            var resultData = await _budgetRepository.GetAll(cancellationToken);
            List<Budget> budgets = _mapper.Map<List<Budget>>(resultData);
            return budgets;
        }
    }
}
