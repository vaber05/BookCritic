using AutoMapper;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.Modules.RatingModules.Commands;
using BookCriticsDomain.Models;
using MediatR;

namespace BookCriticsApplication.Modules.RatingModules.CommandHandlers;

public class PatchRatingHandler : IRequestHandler<PatchRating, bool>
{
    private readonly IRatingRepository repository;
    private readonly IMapper mapper;

    public PatchRatingHandler(IMapper mapper, IRatingRepository repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<bool> Handle(PatchRating request, CancellationToken cancellationToken)
    {
        if (request.RatingToPatch!.RatingValue < 0 || request.RatingToPatch!.RatingValue > 5)
            return false;

        var ratingToPatch = mapper.Map<Rating>(request.RatingToPatch);
        await repository.UpdateRating(ratingToPatch);

        return true;
    }
}
