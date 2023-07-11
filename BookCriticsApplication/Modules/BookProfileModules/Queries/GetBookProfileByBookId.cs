using BookCriticsApplication.Models;
using MediatR;

namespace BookCriticsApplication.Modules.BookProfileModules.Queries;

public class GetBookProfileByBookId : IRequest<BookProfile>
{
    public int BookId { get; set; }
}
