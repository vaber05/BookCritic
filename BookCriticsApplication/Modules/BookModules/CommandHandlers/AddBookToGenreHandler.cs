using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.BookModules.Commands;
using MediatR;

namespace BookCriticsApplication.Modules.BookModules.CommandHandlers;

public class AddBookToGenreHandler : IRequestHandler<AddBookToGenre, bool>
{
    private readonly IBookRepository repository;

    public AddBookToGenreHandler(IBookRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> Handle(AddBookToGenre request, CancellationToken cancellationToken)
    {
        await repository.AddBookToGenre(request.BookId, request.GenreId);

        return true;
    }
}
