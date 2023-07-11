using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.BookModules.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCriticsApplication.Modules.BookModules.CommandHandlers;

public class RemoveBookFromGenreHandler : IRequestHandler<RemoveBookFromGenre, bool>
{
    private readonly IBookRepository repository;

    public RemoveBookFromGenreHandler(IBookRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> Handle(RemoveBookFromGenre request, CancellationToken cancellationToken)
    {
        await repository.RemoveBookFromGenre(request.BookId, request.GenreId);

        return true;
    }
}
