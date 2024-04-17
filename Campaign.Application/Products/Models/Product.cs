using Campaign.Domain.Promotions.Entities;

namespace Campaign.Application.Products.Models
{
    public class Product
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string? CategoryId { get; set; }
        public List<PromotionEntity>? Promotions { get; set; }

    }
}
