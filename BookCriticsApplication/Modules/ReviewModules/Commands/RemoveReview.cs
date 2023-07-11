using MediatR;

namespace BookCriticsApplication.Modules.ReviewModules.Commands;

public class RemoveReview : IRequest<bool>
{
    public int ReviewId { get; set; }
}
