using AutoMapper;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.BookModules.Commands;
using BookCriticsDomain.Models;
using MediatR;

namespace BookCriticsApplication.Modules.BookModules.CommandHandlers;

public class PostBookHandler : IRequestHandler<PostBook, bool>
{
    private readonly IMapper mapper;
    private readonly IBookRepository repository;

    public PostBookHandler(IMapper mapper, IBookRepository repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<bool> Handle(PostBook request, CancellationToken cancellationToken)
    {
        var bookToPost = mapper.Map<Book>(request.BookToCreate);

        await repository.CreateBook(bookToPost);

        return true;
    }
}
