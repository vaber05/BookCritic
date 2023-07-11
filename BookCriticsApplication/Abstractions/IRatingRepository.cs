using BookCriticsDomain.Models;

namespace BookCriticsApplication.Abstractions;

public interface IRatingRepository
{
    Task<Rating> UpdateRating(Rating rating);

    Task DeleteRating(int raterId, int bookId);

    Task <Rating> CreateRating(Rating rating);
}
