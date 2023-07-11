using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.RatingModules.Commands;
using MediatR;

namespace BookCriticsApplication.Modules.RatingModules.CommandHandlers;

public class DeleteRatingHandler : IRequestHandler<DeleteRating, bool>
{
    private readonly IRatingRepository repository;

    public DeleteRatingHandler(IRatingRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> Handle(DeleteRating request, CancellationToken cancellationToken)
    {
        await repository.DeleteRating(request.UserId, request.BookId);

        return true;
    }
}
