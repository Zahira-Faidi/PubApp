using AutoMapper;
using Campaign.Application.Categories.Commands;
using Campaign.Application.Categories.Models;
using Campaign.Domain.Category.Entities;

namespace Campaign.Application.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryEntity, Category>();
            CreateMap<CategoryEntity, CreateCategoryCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
