using AutoMapper;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.RatingModules.Commands;
using BookCriticsDomain.Models;
using MediatR;

namespace BookCriticsApplication.Modules.RatingModules.CommandHandlers;

public class PostRatingHandler : IRequestHandler<PostRating, bool>
{
    private readonly IRatingRepository repository;
    private readonly IMapper mapper;

    public PostRatingHandler(IRatingRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(PostRating request, CancellationToken cancellationToken)
    {
        if(request.RatingToPost!.RatingValue < 0 || request.RatingToPost!.RatingValue > 5)
            return false;

        var ratingToPost = mapper.Map<Rating>(request.RatingToPost);
        await repository.CreateRating(ratingToPost);

        return true;
    }
}
