using BookCriticsApplication.ModelDtos;
using MediatR;

namespace BookCriticsApplication.Modules.ReviewModules.Queries;

public class GetReviewsUnderBook : IRequest<List<ReviewDto>>
{
    public int BookId { get; set; }
}
