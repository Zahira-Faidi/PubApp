using MediatR;

namespace Campaign.Application.Promotions.Commands
{
    public class DeletePromotionCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public DeletePromotionCommand(string id)
        {
            Id = id;
        }
    }
}
