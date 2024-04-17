using Campaign.Application.Promotions.Models;
using MediatR;

namespace Campaign.Application.Promotions.Queries
{
    public class GetPromotionsQuery:IRequest<List<Promotion>>
    {
    }
}
