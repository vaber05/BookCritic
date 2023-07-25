using AutoMapper;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.BookModules.Commands;
using MediatR;

namespace BookCriticsApplication.Modules.BookModules.CommandHandlers;

public class PatchBookHandler : IRequestHandler<PatchBook, bool>
{
    private readonly IMapper mapper;
    private readonly IBookRepository repository;

    public PatchBookHandler(IMapper mapper, IBookRepository repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<bool> Handle(PatchBook request, CancellationToken cancellationToken)
    {
        var currentBook = await repository.GetBookById(request.NewBook!.Id);

        var bookToPatch = mapper.Map(request.NewBook, currentBook);

        await repository.UpdateBook(bookToPatch);

        return true;
    }
}
