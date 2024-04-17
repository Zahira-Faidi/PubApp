using Campaign.Application.Ads.Models;
using MediatR;

namespace Campaign.Application.Ads.Queries
{
    public class GetAdsQuery : IRequest<List<Ad>>
    {

    }
}
