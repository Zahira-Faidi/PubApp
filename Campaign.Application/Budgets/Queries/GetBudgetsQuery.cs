using Campaign.Application.Budgets.Models;
using MediatR;

namespace Campaign.Application.Budgets.Queries
{
    public class GetBudgetsQuery : IRequest<List<Budget>>
    {
    }
}
