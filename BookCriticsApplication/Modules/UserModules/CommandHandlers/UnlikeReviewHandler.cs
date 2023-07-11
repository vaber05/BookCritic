using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.UserModules.Commands;
using MediatR;

namespace BookCriticsApplication.Modules.UserModules.CommandHandlers;

public class UnlikeReviewHandler : IRequestHandler<UnlikeReview, bool>
{
    private readonly IUserRepository userRepository;

    public UnlikeReviewHandler(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<bool> Handle(UnlikeReview request, CancellationToken cancellationToken)
    {
        await userRepository.UnlikeReview(request.UserId, request.ReviewId);

        return true;
    }
}