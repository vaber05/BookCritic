using BookCriticsApplication.Models;
using MediatR;

namespace BookCriticsApplication.Modules.RatingModules.Commands;

public class PostRating : IRequest<bool>
{
    public RatingDto? RatingToPost { get; set; }
}
