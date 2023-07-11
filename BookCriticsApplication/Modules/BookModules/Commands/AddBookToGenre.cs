using MediatR;

namespace BookCriticsApplication.Modules.BookModules.Commands;

public class AddBookToGenre : IRequest<bool>
{
    public int GenreId { get; set; }

    public int BookId { get; set; }
}
