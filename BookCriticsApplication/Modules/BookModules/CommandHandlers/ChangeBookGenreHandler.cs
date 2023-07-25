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
        await repository.UpdateBookGenres(request.BookId, request.OldBookGenre, request.NewBookGenre);

        return true;
    }
}
