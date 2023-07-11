using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.BookModules.Commands;
using MediatR;

namespace BookCriticsApplication.Modules.BookModules.CommandHandlers;

public class ChangeBookGenreHandler : IRequestHandler<ChangeBookGenre, bool>
{
    private readonly IBookRepository repository;

    public ChangeBookGenreHandler(IBookRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> Handle(ChangeBookGenre request, CancellationToken cancellationToken)
    {
        await repository.RemoveBookFromGenre(request.BookId, request.OldGenreId);

        await repository.AddBookToGenre(request.BookId, request.NewGenreId);

        return true;
    }
}
