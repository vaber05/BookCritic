using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.UserModules.Commands;
using MediatR;

namespace BookCriticsApplication.Modules.UserModules.CommandHandlers;

public class LikeReviewHandler : IRequestHandler<LikeReview, bool>
{
    private readonly IUserRepository userRepository;

    public LikeReviewHandler(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<bool> Handle(LikeReview request, CancellationToken cancellationToken)
    {
        await userRepository.LikeReview(request.UserId, request.ReviewId);

        return true;
    }
}