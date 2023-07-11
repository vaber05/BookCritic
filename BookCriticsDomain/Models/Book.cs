namespace BookCriticsDomain.Models;

public class Book
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Author { get; set; }

    public int NumberOfPages { get; set; }

    public int ReleaseYear { get; set; }

    public DateTime? DateAdded { get; set; }

    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public ICollection<UserLikedBook> LikedByUsers { get; set; } = new List<UserLikedBook>();

    public ICollection<BookInGenre> Genres { get; set; } = new List<BookInGenre>();
}
