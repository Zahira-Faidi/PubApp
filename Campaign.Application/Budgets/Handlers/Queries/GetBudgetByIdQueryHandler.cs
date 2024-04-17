using AutoMapper;
using Campaign.Application.Budgets.Models;
using Campaign.Application.Budgets.Queries;
using Campaign.Domain.Budgets.Repositories;
using MediatR;

namespace Campaign.Application.Budgets.Handlers.Queries
{
    public class GetBudgetByIdQueryHandler : IRequestHandler<GetBudgetByIdQuery, Budget>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;

        public GetBudgetByIdQueryHandler(IBudgetRepository budgetRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
        }

        public async Task<Budget> Handle(GetBudgetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _budgetRepository.GetById(request.Id, cancellationToken);
            var budget = _mapper.Map<Budget>(result);
            return budget;
        }
    }
}
