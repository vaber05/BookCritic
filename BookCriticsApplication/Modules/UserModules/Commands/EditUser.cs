using BookCriticsApplication.ModelDtos;
using MediatR;

namespace BookCriticsApplication.Modules.UserModules.Commands;

public class EditUser : IRequest<bool>
{
    public UserDto? UserToEdit { get; set; }
}
