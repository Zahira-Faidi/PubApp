using Campaign.Application.Ads.Models;
using MediatR;

namespace Campaign.Application.Ads.Queries
{
    public class GetAdByIdQuery : IRequest<Ad>
    {
        public string Id { get; set; }
        public GetAdByIdQuery(string id) 
        {
            Id = id;
        }
    }
}
