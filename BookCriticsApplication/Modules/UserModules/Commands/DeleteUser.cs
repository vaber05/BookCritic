using MediatR;

namespace BookCriticsApplication.Modules.UserModules.Commands;

public class DeleteUser : IRequest<bool>
{
    public int UserId { get; set; }
}
