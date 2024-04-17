using MediatR;

namespace Campaign.Application.Campaigns.Commands
{
    public class DeleteCampaignCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public DeleteCampaignCommand(string id)
        {
            Id = id;
        }
    }
}
