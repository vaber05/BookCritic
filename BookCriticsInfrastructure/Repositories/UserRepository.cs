using BookCriticsApplication.Abstractions;
using BookCriticsDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCriticsInfrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BookCriticsDbContext context;

    public UserRepository(BookCriticsDbContext context)
    {
        this.context = context;
    }

    public async Task<User> CreateUser(User newUser)
    {
        await context.Users.AddAsync(newUser);
        await context.SaveChangesAsync();

        return newUser;
    }

    public async Task DeleteUser(int userId)
    {
        var userToDelete = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (userToDelete is null)
            return;

        context.Users.Remove(userToDelete);
        await context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllUSers()
    {
        return await context.Users.Include(u => u.LikedBooks)
                            .Include(u => u.WrittenReviews)
                            .Include(u => u.RatingsMade)
                            .Include(u => u.Roles).ToListAsync();
    }

    public async Task<User> GetUserById(int userId)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Id == userId) ?? new();
    }

    public async Task<User> UpdateUser(User newUser)
    {
        context.ChangeTracker.Clear();

        context.Users.Update(newUser);
        await context.SaveChangesAsync();

        return newUser;
    }

    public async Task AddUserToRole(int userId, int roleId)
    {
        context.UserInRoles.Add(new UserInRole
        {
            UserId = userId,
            RoleId = roleId
        });
        await context.SaveChangesAsync();
    }

    public async Task LikeBook(int userId, int bookId)
    {
        await context.UserLikedBooks.AddAsync(new UserLikedBook
        {
            BookId = bookId,
            UserId = userId
        });
        await context.SaveChangesAsync();
    }

    public async Task UnlikeBook(int userId, int bookId)
    {
        context.UserLikedBooks.Remove(new UserLikedBook
        {
            BookId = bookId,
            UserId = userId
        });
        await context.SaveChangesAsync();
    }

    public async Task LikeReview(int userId, int reviewId)
    {
        await context.UserLikedReviews.AddAsync(new UserLikedReview
        {
            ReviewId = reviewId,
            UserId = userId
        });
        await context.SaveChangesAsync();
    }

    public async Task UnlikeReview(int userId, int reviewId)
    {
        context.UserLikedReviews.Remove(new UserLikedReview
        {
            ReviewId = reviewId,
            UserId = userId
        });
        await context.SaveChangesAsync();
    }

    public async Task<bool> DoesUserExist(User userToCheck)
    {
        var users = await context.Users.ToListAsync();

        return users.Any(u => u.Username == userToCheck.Username);
    }

    public async Task RemoveAllThingsUser(int userId)
    {
        await context.Reviews.Where(r => r.UserId == userId).ExecuteDeleteAsync();
        await context.Ratings.Where(r => r.UserId == userId).ExecuteDeleteAsync();
        await context.UserLikedBooks.Where(ulb => ulb.UserId == userId).ExecuteDeleteAsync();
        await context.UserLikedReviews.Where(ulr => ulr.UserId == userId).ExecuteDeleteAsync();
        await context.Ratings.Where(r => r.UserId == userId).ExecuteDeleteAsync();

        await context.SaveChangesAsync();
    }
}
