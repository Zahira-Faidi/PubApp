using AutoMapper;
using Campaign.Application.Budgets.Commands;
using Campaign.Application.Budgets.Models;
using Campaign.Domain.Budgets.Entities;

namespace Campaign.Application.Profiles
{
    public class BudgetProfile : Profile
    {
        public BudgetProfile()
        {
            CreateMap<BudgetEntity, Budget>().ReverseMap();
            CreateMap<BudgetEntity, CreateBudgetCommand>()
                .ForMember(dest => dest.TotalBudget, opt => opt.MapFrom(src => src.TotalBudget))
                .ForMember(dest => dest.DailyBudget, opt => opt.MapFrom(src => src.DailyBudget))
                .ReverseMap();

        }
    }
}
