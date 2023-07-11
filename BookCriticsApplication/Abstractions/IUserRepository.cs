using BookCriticsDomain.Models;

namespace BookCriticsApplication.Abstractions;

public interface IUserRepository
{
    Task<List<User>> GetAllUSers();

    Task<User> GetUserById(int userId);

    Task<User> UpdateUser(User newUser);

    Task DeleteUser(int userId);

    Task<User> CreateUser(User newUser);

    Task AddUserToRole(int userId, int roleId);

    Task LikeBook(int userId, int bookId);

    Task UnlikeBook(int userId, int bookId);

    Task LikeReview(int userId, int reviewId);

    Task UnlikeReview(int userId, int reviewId);

    Task<bool> DoesUserExist(User userToCheck);

    Task RemoveAllThingsUser(int userId);
}
