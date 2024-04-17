using AutoMapper;
using Campaign.Domain.Campaign.Entities;
using Campaign.Application.Campaigns.Models;
using Campaign.Application.Campaigns.Commands;

namespace Campaign.Application.Profiles
{
    public class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<CampaignEntity , CampaignBase>();
            CreateMap<CampaignEntity, CreateCampaignCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Budget, opt => opt.MapFrom(src => src.Budget))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ReverseMap();

        }
    }
}
