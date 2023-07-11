using BookCriticsApplication.ModelDtos;
using MediatR;

namespace BookCriticsApplication.Modules.BookModules.Commands;

public class PatchBook : IRequest<bool>
{
    public BookDto? NewBook { get; set; }
}
