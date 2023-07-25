using AutoMapper;
using BookCriticsApplication.Abstractions;
using BookCriticsApplication.ModelDtos;
using BookCriticsApplication.Modules.ReviewModules.Queries;
using MediatR;

namespace BookCriticsApplication.Modules.ReviewModules.QueryHandlers;

public class GetReviewUnderBookHandler : IRequestHandler<GetReviewsUnderBook, List<ReviewDto>>
{
    private readonly IReviewRepository repository;
    private readonly IMapper mapper;

    public GetReviewUnderBookHandler(IReviewRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<List<ReviewDto>> Handle(GetReviewsUnderBook request, CancellationToken cancellationToken)
    {
        var reviews = await repository.GetReviewsUnderBook(request.BookId);
        var reviewDtos = new List<ReviewDto>();

        foreach (var review in reviews)
        {
            var reviewDto = mapper.Map<ReviewDto>(review);
            reviewDto.NumberOfLikes = await repository.GetNumberOfLikes(reviewDto.Id);
            reviewDtos.Add(reviewDto);
        }

        return reviewDtos;
    }
}
