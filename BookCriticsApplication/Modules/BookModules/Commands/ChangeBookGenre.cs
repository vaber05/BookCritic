using MediatR;

namespace BookCriticsApplication.Modules.BookModules.Commands;

public class ChangeBookGenre : IRequest<bool>
{
    public int BookId { get; set; }

    public int OldGenreId { get; set; }

    public int NewGenreId { get; set; }
}
