using MediatR;

namespace BookCriticsApplication.Modules.UserModules.Commands;

public class PromoteUserToAdmin : IRequest<bool>
{
    public int UserId { get; set; }
}
