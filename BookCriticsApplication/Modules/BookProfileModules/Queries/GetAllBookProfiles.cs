using BookCriticsApplication.Models;
using MediatR;

namespace BookCriticsApplication.Modules.BookProfileModules.Queries;

public class GetAllBookProfiles : IRequest<List<BookProfile>>
{ 
}
