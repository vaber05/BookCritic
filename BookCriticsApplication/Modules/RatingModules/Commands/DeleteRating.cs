using MediatR;

namespace BookCriticsApplication.Modules.RatingModules.Commands;

public class DeleteRating : IRequest<bool>
{
    public int UserId { get; set; }

    public int BookId { get; set;}
}
