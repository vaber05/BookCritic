using BookCriticsApplication.Models;
using MediatR;

namespace BookCriticsApplication.Modules.RatingModules.Commands;

public class PatchRating : IRequest<bool>
{
    public RatingDto? RatingToPatch { get; set; }
}
