using BookCriticsApplication.ModelDtos;
using MediatR;

namespace BookCriticsApplication.Modules.BookModules.Commands;

public class PostBook : IRequest<bool>
{
    public BookDto? BookToCreate { get; set; }
}
