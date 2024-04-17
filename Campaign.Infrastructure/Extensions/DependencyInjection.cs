using Campaign.Domain.Ads.Repositories;
using Campaign.Domain.Budgets.Repositories;
using Campaign.Domain.Campaign.Repositories;
using Campaign.Domain.Category.Repositories;
using Campaign.Domain.Products.Repositories;
using Campaign.Domain.Promotions.Repositories;
using Campaign.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Campaign.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastractureConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductService>();
            services.AddTransient<IAdsRepository, AdService>();
            services.AddTransient<IBudgetRepository, BudgetService>();
            services.AddTransient<IPromotionRepository, PromotionService>();
            services.AddTransient<ICategoryRepository, CategoryService>();
            services.AddTransient<ICampaignRepository, CampaignService>();
            return services;
        }
    }
}
