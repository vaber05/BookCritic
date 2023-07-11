using MediatR;

namespace BookCriticsApplication.Modules.ReviewModules.Commands;

public class EditReview : IRequest<bool>
{
    public int ReviewId { get; set; }

    public string? NewContent { get; set;}
}
