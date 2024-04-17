using Campaign.Application.Promotions.Models;
using Campaign.Domain.Products.Entities;
using MediatR;

namespace Campaign.Application.Promotions.Commands
{
    public class CreatePromotionCommand : IRequest<Promotion>
    {
        public string? Id { get; set; }
        //public Type? Type { get; set; }
        public string? Description { get; set; }
        public double Discount { get; set; }
        public List<ProductEntity>? Products { get; set; }

    }
}
