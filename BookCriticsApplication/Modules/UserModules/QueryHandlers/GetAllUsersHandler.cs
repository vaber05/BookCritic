using AutoMapper;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.ModelDtos;
using BookCriticsApplication.Modules.UserModules.Queries;
using MediatR;

namespace BookCriticsApplication.Modules.UserModules.QueryHandlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsers, List<UserDto>>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;

    public GetAllUsersHandler(IUserRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetAllUsers request, CancellationToken cancellationToken)
    {
        var users = await repository.GetAllUSers();
        return mapper.Map<List<UserDto>>(users);
    }
}
