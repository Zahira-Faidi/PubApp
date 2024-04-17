using AutoMapper;
using Campaign.Application.Products.Commands;
using Campaign.Application.Products.Models;
using Campaign.Domain.Products.Entities;

namespace Campaign.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, Product>().ReverseMap();
            //CreateMap<ProductEntity, CreateProductCommand>().ReverseMap();
            CreateMap<ProductEntity, CreateProductCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.CategoryId , opt=> opt.MapFrom(src => src.CategoryId))
                .ReverseMap();
        }
    }
}
