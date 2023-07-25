using MediatR;

namespace BookCriticsApplication.Modules.BookModules.Commands;

public class RemoveBook : IRequest<bool>
{
    public int BookId { get; set; }
}
