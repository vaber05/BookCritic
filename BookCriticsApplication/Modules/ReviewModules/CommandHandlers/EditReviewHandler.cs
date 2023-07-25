using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Models.MLModelIO;
using BookCriticsApplication.Modules.ReviewModules.Commands;
using BookCriticsDomain.Models;
using MediatR;

namespace BookCriticsApplication.Modules.ReviewModules.CommandHandlers;

public class EditReviewHandler : IRequestHandler<EditReview, bool>
{
    private readonly IReviewRepository repository;
    private readonly IMLModel<ModelInput, ModelOutput> mlModel;

    public EditReviewHandler(IReviewRepository repository, IMLModel<ModelInput, ModelOutput> mlModel)
    {
        this.repository = repository;
        this.mlModel = mlModel;
    }

    public async Task<bool> Handle(EditReview request, CancellationToken cancellationToken)
    {
        var currentreview = await repository.GetReview(request.ReviewId);

        if (currentreview.Id == 0)
            return false;

        await repository.ChangeReview(new Review
        {
            Id = currentreview.Id,
            BookId = currentreview.BookId,
            UserId = currentreview.UserId,
            LastUpdated = DateTime.Now,
            Content = request.NewContent,
            IsPositive = mlModel.Predict(new ModelInput { Review = request.NewContent }).Sentiment
        });

        return true;
    }
}
