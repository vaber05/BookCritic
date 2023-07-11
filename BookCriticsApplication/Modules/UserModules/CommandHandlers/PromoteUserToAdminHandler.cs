using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.UserModules.Commands;
using MediatR;

namespace BookCriticsApplication.Modules.UserModules.CommandHandlers;

public class PromoteUserToAdminHandler : IRequestHandler<PromoteUserToAdmin, bool>
{
    private readonly IUserRepository repository;

    public PromoteUserToAdminHandler(IUserRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> Handle(PromoteUserToAdmin request, CancellationToken cancellationToken)
    {
        await repository.AddUserToRole(request.UserId, 2);

        return true;
    }
}
