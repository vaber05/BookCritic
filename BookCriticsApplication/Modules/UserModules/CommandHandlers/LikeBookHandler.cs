using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.UserModules.Commands;
using MediatR;

namespace BookCriticsApplication.Modules.UserModules.CommandHandlers;

public class LikeBookHandler : IRequestHandler<LikeBook, bool>
{
    private readonly IUserRepository userRepository;

    public LikeBookHandler(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<bool> Handle(LikeBook request, CancellationToken cancellationToken)
    {
        await userRepository.LikeBook(request.UserId, request.BookId);

        return true;
    }
}