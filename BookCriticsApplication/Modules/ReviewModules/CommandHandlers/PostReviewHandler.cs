using AutoMapper;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Models.MLModelIO;
using BookCriticsApplication.Modules.ReviewModules.Commands;
using BookCriticsDomain.Models;
using MediatR;

namespace BookCriticsApplication.Modules.ReviewModules.CommandHandlers;

public class PostReviewHandler : IRequestHandler<PostReview, bool>
{
    private readonly IReviewRepository repository;
    private readonly IMapper mapper;
    private readonly IMLModel<ModelInput, ModelOutput> mlModel;

    public PostReviewHandler(IReviewRepository repository, IMapper mapper, IMLModel<ModelInput, ModelOutput> mlModel)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.mlModel = mlModel;
    }

    public async Task<bool> Handle(PostReview request, CancellationToken cancellationToken)
    {
        if(request.ReviewToPost is null)
            return false;

        var modelInput = new ModelInput { Review = request.ReviewToPost.Content };

        var prediction = mlModel.Predict(modelInput);

        request.ReviewToPost.IsPositive = prediction.Sentiment;

        var reviewToPost = mapper.Map<Review>(request.ReviewToPost);

        reviewToPost.LastUpdated = DateTime.Now;
        reviewToPost.Id = 0;
        reviewToPost.NumberOfLikes = 0;

        await repository.CreateReview(reviewToPost);

        return true;
    }
}
