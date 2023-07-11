using AutoMapper;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.UserModules.Commands;
using BookCriticsDomain.Models;
using MediatR;

namespace BookCriticsApplication.Modules.UserModules.CommandHandlers;

public class CreateUserHandler : IRequestHandler<PostUser, bool>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;

    public CreateUserHandler(IUserRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(PostUser request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request.UserToPost);
        var userExists = await repository.DoesUserExist(user);

        user.Id = 0;
        user.CreatedDate = DateTime.Now;
        user.LastLoggin = DateTime.Now;

        if (userExists)
            return false;

        await repository.CreateUser(user);
        await repository.AddUserToRole(user.Id, 1);

        return true;
    }
}
