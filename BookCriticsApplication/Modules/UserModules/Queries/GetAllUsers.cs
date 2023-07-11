using BookCriticsApplication.ModelDtos;
using MediatR;

namespace BookCriticsApplication.Modules.UserModules.Queries;

public class GetAllUsers : IRequest<List<UserDto>>
{
}
