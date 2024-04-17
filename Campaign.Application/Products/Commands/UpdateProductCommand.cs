﻿using Campaign.Domain.Promotions.Entities;
using MediatR;

namespace Campaign.Application.Products.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string? CategoryId { get; set; }

    }
}
