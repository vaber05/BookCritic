using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.ReviewModules.Commands;
using MediatR;

namespace BookCriticsApplication.Modules.ReviewModules.CommandHandlers;

public class RemoveReviewHandler : IRequestHandler<RemoveReview, bool>
{
    private readonly IReviewRepository repository;

    public RemoveReviewHandler(IReviewRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> Handle(RemoveReview request, CancellationToken cancellationToken)
    {
        await repository.RemoveAllThingsReview(request.ReviewId);

        await repository.DeleteReview(request.ReviewId);

        return true;
    }
}
