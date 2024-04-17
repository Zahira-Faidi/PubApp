using Campaign.Application.Budgets.Models;
using MediatR;

namespace Campaign.Application.Budgets.Queries
{
    public class GetBudgetByIdQuery :  IRequest<Budget>
    {
        public string Id { get; set; }
        public GetBudgetByIdQuery(string id)
        {
            Id = id;
        }
    }
}
