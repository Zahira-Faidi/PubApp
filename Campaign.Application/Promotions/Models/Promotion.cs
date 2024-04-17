using Campaign.Domain.Products.Entities;
namespace Campaign.Application.Promotions.Models
{
    public class Promotion
    {
        public string? Id { get; set; }
        //public Type Type { get; set; }
        public string? Description { get; set; }
        public double Discount { get; set; }
        public List<ProductEntity>? Products { get; set; }

    }
}
