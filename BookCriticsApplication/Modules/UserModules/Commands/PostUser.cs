using BookCriticsApplication.ModelDtos;
using MediatR;

namespace BookCriticsApplication.Modules.UserModules.Commands;

public class PostUser : IRequest<bool>
{
    public UserDto UserToPost { get; set; } = null!;
}
