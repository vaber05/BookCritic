using AutoMapper;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.UserModules.Commands;
using BookCriticsDomain.Models;
using MediatR;

namespace BookCriticsApplication.Modules.UserModules.CommandHandlers;

public class EditUserHandler : IRequestHandler<EditUser, bool>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;

    public EditUserHandler(IUserRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(EditUser request, CancellationToken cancellationToken)
    {
        var currentUser = await repository.GetUserById(request.UserToEdit!.Id);
        var userToUpdate = mapper.Map(request.UserToEdit, currentUser);

        var userExists = await repository.DoesUserExist(userToUpdate);

        if (userExists)
            return false;

        await repository.UpdateUser(userToUpdate);

        return true;
    }
}
