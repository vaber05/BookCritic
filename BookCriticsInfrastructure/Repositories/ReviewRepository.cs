using BookCriticsApplication.Abstractions;
using BookCriticsDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCriticsInfrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly BookCriticsDbContext context;

    public ReviewRepository(BookCriticsDbContext context)
    {
        this.context = context;
    }

    public async Task<Review> ChangeReview(Review newReview)
    {
        context.ChangeTracker.Clear();

        context.Reviews.Update(newReview);
        await context.SaveChangesAsync();

        return newReview;
    }

    public async Task<Review> CreateReview(Review newReview)
    {
        newReview.LastUpdated = DateTime.Now;

        context.Reviews.Add(newReview);
        await context.SaveChangesAsync();

        return newReview;
    }

    public async Task DeleteReview(int reviewId)
    {
        var currentReview = context.Reviews.FirstOrDefault(r => r.Id == reviewId);

        if (currentReview is null)
            return;

        context.Reviews.Remove(currentReview);
        await context.SaveChangesAsync();
    }

    public async Task<Review> GetReview(int reviewId)
    {
        return await context.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId) ?? new();
    }

    public async Task<int> GetNumberOfLikes(int reviewId)
    {
        var usersWhoLikedReview = await context.UserLikedReviews.Where(ulr => ulr.ReviewId ==  reviewId).ToListAsync();

        return usersWhoLikedReview.Count;
    }

    public async Task<List<Review>> GetReviewsUnderBook(int bookId)
    {
        return await context.Reviews.Where(r => r.BookId == bookId).ToListAsync();
    }

    public async Task RemoveAllThingsReview(int reviewId)
    {
        await context.UserLikedReviews.Where(ulr => ulr.ReviewId == reviewId).ExecuteDeleteAsync();

        await context.SaveChangesAsync();
    }
}