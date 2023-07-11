using System.ComponentModel.DataAnnotations.Schema;

namespace BookCriticsDomain.Models;

public class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Password { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastLoggin { get; set; }

    public ICollection<Review> WrittenReviews { get; set; } = new List<Review>();

    public ICollection<Rating> RatingsMade { get; set; } = new List<Rating>();

    public ICollection<UserLikedBook> LikedBooks { get; set; } = new List<UserLikedBook>();

    public ICollection<UserInRole> Roles { get; set; } = new List<UserInRole>();

    public ICollection<UserLikedReview> LikedReviews { get; set; } = new List<UserLikedReview>();
}
