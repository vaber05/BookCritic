using BookCriticsApplication.ModelDtos;
using MediatR;

namespace BookCriticsApplication.Modules.ReviewModules.Commands;

public class PostReview : IRequest<bool>
{
    public ReviewDto? ReviewToPost { get; set; }
}
