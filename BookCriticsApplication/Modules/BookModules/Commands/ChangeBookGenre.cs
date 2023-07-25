using BookCriticsApplication.Models;
using MediatR;

namespace BookCriticsApplication.Modules.BookModules.Commands;

public class ChangeBookGenre : IRequest<bool>
{
    public int BookId { get; set; }

    public int OldBookGenre { get; set; }

    public int NewBookGenre { get; set; }
}
