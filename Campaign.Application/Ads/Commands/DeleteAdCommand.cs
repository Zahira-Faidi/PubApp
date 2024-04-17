using MediatR;

namespace Campaign.Application.Ads.Commands
{
    public class DeleteAdCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public DeleteAdCommand(string id)
        {
            Id = id;
        }
    }
}
