using Campaign.Application.Promotions.Models;
using MediatR;

namespace Campaign.Application.Promotions.Queries
{
    public class GetPromotionByIdQuery : IRequest<Promotion>
    {
        public GetPromotionByIdQuery(string id)
        {
            Id = id;
        }

        public string? Id { get; set; }
    }
}
