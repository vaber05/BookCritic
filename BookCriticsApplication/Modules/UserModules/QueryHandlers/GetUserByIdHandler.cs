using AutoMapper;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.ModelDtos;
using BookCriticsApplication.Modules.UserModules.Queries;
using MediatR;

namespace BookCriticsApplication.Modules.UserModules.QueryHandlers;

public class GetUserByIdHandler : IRequestHandler<GetUserById, UserDto>
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;

    public GetUserByIdHandler(IUserRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        var user = await repository.GetUserById(request.userId);
        return mapper.Map<UserDto>(user);
    }
}
