using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.BookModules.Commands;
using MediatR;

namespace BookCriticsApplication.Modules.BookModules.CommandHandlers;

public class RemoveBookHandler : IRequestHandler<RemoveBook, bool>
{
    private readonly IBookRepository repository;

    public RemoveBookHandler(IBookRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> Handle(RemoveBook request, CancellationToken cancellationToken)
    {
        await repository.DeleteBook(request.BookId);

        return true;
    }
}
