using BookCriticsApplication.ModelDtos;
using MediatR;

namespace BookCriticsApplication.Modules.UserModules.Queries;

public class GetUserById : IRequest<UserDto>
{
    public int userId { get; set; }
}
