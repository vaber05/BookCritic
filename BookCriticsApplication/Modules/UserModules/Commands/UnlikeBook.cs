using MediatR;

namespace BookCriticsApplication.Modules.UserModules.Commands;

public class UnlikeBook : IRequest<bool>
{
    public int UserId { get; set; }

    public int BookId { get; set; }
}
