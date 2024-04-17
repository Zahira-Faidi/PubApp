using AutoMapper;
using Campaign.Application.Promotions.Commands;
using Campaign.Application.Promotions.Models;
using Campaign.Domain.Promotions.Entities;

namespace Campaign.Application.Profiles
{
    public class PromotionProfile : Profile
    {
        public PromotionProfile()
        {
            CreateMap<PromotionEntity, Promotion>();
            CreateMap<PromotionEntity, CreatePromotionCommand>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ReverseMap();

        }
    }
}
