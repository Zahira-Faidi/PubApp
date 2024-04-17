using Campaign.Application.Products.Models;
using Campaign.Domain.Promotions.Entities;
using MediatR;

namespace Campaign.Application.Products.Commands
{
    public record CreateProductCommand : IRequest<Product>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string? CategoryId {  get; set; }
        public List<PromotionEntity>? Promotions { get; set; }

    }
}
