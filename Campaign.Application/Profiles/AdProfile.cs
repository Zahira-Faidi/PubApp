using AutoMapper;
using Campaign.Domain.Ads.Entities;
using Campaign.Application.Ads.Models;
using Campaign.Application.Ads.Commands;

namespace Campaign.Application.Profiles
{
    public class AdProfile : Profile
    {
        public AdProfile()
        {
            CreateMap<AdsEntity, Ad>().ReverseMap();
            CreateMap<AdsEntity, CreateAdCommand>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.AllocatedBudget, opt => opt.MapFrom(src => src.AllocatedBudget))
                .ReverseMap();

        }
    }
}
