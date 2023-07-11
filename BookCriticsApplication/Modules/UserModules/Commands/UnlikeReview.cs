using MediatR;

namespace BookCriticsApplication.Modules.UserModules.Commands;

public class UnlikeReview : IRequest<bool>
{
    public int UserId { get; set; }

    public int ReviewId { get; set; }
}
