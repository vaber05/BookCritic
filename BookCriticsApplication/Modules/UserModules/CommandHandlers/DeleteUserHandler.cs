using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.UserModules.Commands;
using MediatR;

namespace BookCriticsApplication.Modules.UserModules.CommandHandlers;

public class DeleteUserHandler : IRequestHandler<DeleteUser, bool>
{
    private readonly IUserRepository repository;

    public DeleteUserHandler(IUserRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> Handle(DeleteUser request, CancellationToken cancellationToken)
    {
        await repository.RemoveAllThingsUser(request.UserId);

        await repository.DeleteUser(request.UserId);
        return true;
    }
}
