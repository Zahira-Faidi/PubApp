using Campaign.Domain.Products.Entities;
using MediatR;
//using Type = Campaign.Domain.Enums.Type;

namespace Campaign.Application.Promotions.Commands
{
    public class UpdatePromotionCommand : IRequest<bool>
    {
        public string? Id { get; set; }
        //public Type Type { get; set; }
        public string? Description { get; set; }
        public double Discount { get; set; }
        public List<ProductEntity>? Products { get; set; }

    }
}
