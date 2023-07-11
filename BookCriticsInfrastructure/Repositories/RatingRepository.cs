using BookCriticsApplication.Abstractions;
using BookCriticsDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCriticsInfrastructure.Repositories;

public class RatingRepository : IRatingRepository
{
    private readonly BookCriticsDbContext context;

    public RatingRepository(BookCriticsDbContext context)
    {
        this.context = context;
    }

    public async Task<Rating> CreateRating(Rating rating)
    {
        await context.Ratings.AddAsync(rating);
        await context.SaveChangesAsync();

        return rating;
    }

    public async Task DeleteRating(int userId, int bookId)
    {
        var ratingToDelete = await context.Ratings.FirstOrDefaultAsync(r => r.UserId == userId && r.BookId == bookId);

        if (ratingToDelete is null)
            return;

        context.Ratings.Remove(ratingToDelete);
        await context.SaveChangesAsync();
    }

    public async Task<Rating> UpdateRating(Rating rating)
    {
        context.Ratings.Update(rating);
        await context.SaveChangesAsync();

        return rating;
    }
}
