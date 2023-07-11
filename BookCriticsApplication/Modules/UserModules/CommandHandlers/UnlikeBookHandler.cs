using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.UserModules.Commands;
using MediatR;

namespace BookCriticsApplication.Modules.UserModules.CommandHandlers;

public class UnlikeBookHandler : IRequestHandler<UnlikeBook, bool>
{
    private readonly IUserRepository userRepository;

    public UnlikeBookHandler(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<bool> Handle(UnlikeBook request, CancellationToken cancellationToken)
    {
        await userRepository.UnlikeBook(request.UserId, request.BookId);

        return true;
    }
}