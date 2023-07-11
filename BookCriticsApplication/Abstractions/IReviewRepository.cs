using BookCriticsDomain.Models;

namespace BookCriticsApplication.Abstractions;

public interface IReviewRepository
{
    Task<Review> CreateReview(Review newReview);

    Task<Review> ChangeReview(Review newReview);

    Task DeleteReview(int reviewId);

    Task<Review> GetReview(int reviewId);

    Task<int> GetNumberOfLikes(int reviewId);

    Task<List<Review>> GetReviewsUnderBook(int bookId);

    Task RemoveAllThingsReview(int reviewId);
}
